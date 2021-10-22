using System.Collections.Generic;

namespace TodoNet.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<TodoItem> TodoItems { get; set; }
    }
}