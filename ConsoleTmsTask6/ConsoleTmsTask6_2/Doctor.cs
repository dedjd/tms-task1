using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTmsTask6_2
{
    public abstract class Doctor
    {
        public string Type { get; }

        public Doctor(string type)
        {
            Type = type;
        }

        public abstract void Treat(Patient patient);
    }
}
