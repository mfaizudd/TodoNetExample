using System.Collections.Generic;

namespace TodoNetExample.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual List<TodoItem> TodoItems { get; set; }
    }
}