using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleTmsTask6_2
{
    public class Patient
    {
        public string Name { get; }
        public TherapyPlan Plan { get; }

        public Patient(string name, TherapyPlan plan)
        {
            Name = name;
            Plan = plan;
        }

        public void AssignAndTreat()
        {
            Doctor doctor;

            switch (Plan.Code)
            {
                case 1:
                    doctor = new Surgeon("Хирург");
                    break;
                case 2:
                    doctor = new Dentist("Дантист");
                    break;
                default:
                    doctor = new Therapist("Терапевт");
                    break;
            }

            Console.WriteLine($"Пациент {Name} пришел в клинику с планом лечения {Plan.Code}.");
            doctor.Treat(this);
        }
    }
}
