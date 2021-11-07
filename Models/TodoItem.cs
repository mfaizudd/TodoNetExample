namespace TodoNetExample.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }

        public int TodoListId { get; set; }
        public virtual TodoList TodoList { get; set; }
    }
}