using MyToDoList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoList.Commands
{
    internal class CompletedCommand : ICommand
    {
        private readonly IToDoList _toDoList;

        public string Description => "Завершить задачу";

        public CompletedCommand(IToDoList toDoList)
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
                    _toDoList.MarkAsCompleted(id);
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
