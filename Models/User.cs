using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TodoNetExample.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public List<TodoList> TodoLists { get; set; }
    }
}