namespace MyToDoList.Data
{
    internal class Task
    {
        public string Description { get; set; }
        public DateTime CreatedTime { get; }
        public DateTime? CompletedTime { get; set; }

        public Task(string description)
        {
            Description = description;
            CreatedTime = DateTime.Now;
        }
    }
}
