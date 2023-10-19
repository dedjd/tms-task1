using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTmsTask6_2
{
    public class Therapist : Doctor
    {
        public Therapist(string type) : base(type) { }

        public override void Treat(Patient patient)
        {
            Console.WriteLine($"{Type} лечит пациента {patient.Name}.");
        }
    }
}
