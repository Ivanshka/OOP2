using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Memento
    {
        public ObjectState State { get; private set; }
        public Memento(ObjectState state)
        {
            Console.WriteLine("Memento created");
            State = state;
        }
    }
}
