using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoNetExample.Models
{
    public class TodoDetailsViewModel
    {
        public TodoList List { get; set; }
        public TodoItem AddItem { get; set; }
    }
}