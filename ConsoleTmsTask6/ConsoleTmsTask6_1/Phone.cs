using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTmsTask6
{
    public class Phone
    {
        public long Number { get; }
        public string Model { get; }
        public double Weight { get; }

        public Phone(long number, string model, double weight) : this(number, model)
        {
            Weight = weight;
        }

        public Phone(long number, string model)
        {
            Number = number;
            Model = model;
        }

        public Phone() 
        {
            Number = 80000000000;
            Model = "Unknown";
            Weight = 0.0;
        }

        public void ReceiveCall(string name)
        {
            Console.WriteLine($"Звонит: {name}");
        }

        public void ReceiveCall(string name, long number)
        {
            Console.WriteLine($"Звонит: {name}; Номер: {number}");
        }

        public void GetNumber()
        {
            Console.WriteLine(Number);
        }

        public void SenMessage(params long[] numbers)
        {
            Console.WriteLine("Номера телефонов, которым будет отправлено сообщение:");
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
