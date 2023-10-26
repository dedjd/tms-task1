namespace MyToDoList.Data;

public class ToDoList : IToDoList
{
    private readonly List<Task> _todoTasks = new List<Task>();
    private readonly List<Task> _doneTasks = new List<Task>();

    public void Add(string taskDescription)
    {
        _todoTasks.Add(new Task(taskDescription));
    }

    public void Delete(int id)
    {
        _todoTasks.RemoveAt(id);
    }

    public void MarkAsCompleted(int id)
    {
        var task = _todoTasks[id];
        task.CompletedTime = DateTime.Now;
        _todoTasks.RemoveAt(id);
        _doneTasks.Add(task);
    }

    public string[] ToDoItems()
    {
        return _todoTasks.Select(task => $"{task.Description} (время создания: {task.CreatedTime})").ToArray();
    }

    public string[] DoneItems()
    {
        return _doneTasks.Select(task => $"{task.Description} (время создания: {task.CreatedTime}, время завершения: " +
        $"{task.CompletedTime})").ToArray();
    }

    public void Save(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var task in _todoTasks)
            {
                writer.WriteLine($"Задача: {task.Description},{task.CreatedTime}");
            }
            foreach (var task in _doneTasks)
            {
                writer.WriteLine($"Выполненная задача: {task.Description},{task.CreatedTime},{task.CompletedTime}");
            }
        }
    }
}
