using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTmsTask6_2
{
    public class Dentist : Doctor
    {
        public Dentist(string type) : base(type) { }

        public override void Treat(Patient patient)
        {
            Console.WriteLine($"{Type} лечит пациента {patient.Name}.");
        }
    }
}
