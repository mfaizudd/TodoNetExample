using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoNetExample.Data;
using TodoNetExample.Models;

namespace TodoNetExample.Controllers
{

    [Authorize]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
        private readonly UserManager<User> _userManager;

        public TodoController(TodoContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Todo
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(await _context.TodoLists.Where(x => x.User == user).ToListAsync());
        }

        // GET: Todo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(m => m.Id == id);

            // Check ownership
            var user = await _userManager.GetUserAsync(User);
            if (user.Id != todoList.UserId)
                return Unauthorized();

            if (todoList == null)
            {
                return NotFound();
            }

            var vm = new TodoDetailsViewModel
            {
                List = todoList
            };

            return View(vm);
        }

        // GET: Todo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CreateTodoListViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var todoList = new TodoList
                {
                    Name = model.Name,
                    User = user
                };
                _context.Add(todoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Todo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }
            return View(todoList);
        }

        // POST: Todo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UserId")] TodoList todoList)
        {
            if (id != todoList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoListExists(todoList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todoList);
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoList = await _context.TodoLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoList == null)
            {
                return NotFound();
            }

            return View(todoList);
        }

        // POST: Todo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            _context.TodoLists.Remove(todoList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("[controller]/{id}/[action]/{itemId}")]
        public async Task<IActionResult> DeleteItem(int id, int itemId)
        {
            var todoList = await _context.TodoLists.FindAsync(id);
            var item = todoList.TodoItems.Find(x => x.Id == itemId);

            // Check ownership
            var user = await _userManager.GetUserAsync(User);
            if (user.Id != todoList.UserId)
                return Unauthorized();
            
            todoList.TodoItems.Remove(item);
            _context.TodoLists.Update(todoList);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = id });
        }

        private bool TodoListExists(int id)
        {
            return _context.TodoLists.Any(e => e.Id == id);
        }
    }
}
