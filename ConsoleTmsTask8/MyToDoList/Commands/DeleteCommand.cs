using MyToDoList.Data;

namespace MyToDoList.Commands
{
    internal class DeleteCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public string Description => "Удалить задачу";

        public DeleteCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            do
            {
                Console.WriteLine("Введи номер задачи");

                if (int.TryParse(Console.ReadLine(), out int id) && id >= 0 && id < _toDoList.ToDoItems().Length)
                {
                    _toDoList.Delete(id);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный номер задачи");
                }
            } while (true);
        }
    }
}
