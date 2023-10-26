using MyToDoList.Data;
using System.Xml.Linq;

namespace MyToDoList.Commands
{
    internal class SaveCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public string Description => "Сохранить задачи в файл";

        public SaveCommand(IToDoList toDoList)
        {
            _toDoList = toDoList;
        }

        public void Execute()
        {
            Console.WriteLine("Введите имя файла для сохранения задач: ");
            string fileName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                _toDoList.Save(fileName);
                Console.WriteLine("Задачи сохранены в файле.");
            }
            else
            {
                Console.WriteLine("Вы ввели пустую строку!");
            }
        }
    }
}
