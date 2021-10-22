namespace TodoNet.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}