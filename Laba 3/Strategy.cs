using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("1");
            Console.WriteLine("2");
            Console.WriteLine("3");
            Console.WriteLine("4");
            Console.WriteLine("5");
        }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("5");
            Console.WriteLine("4");
            Console.WriteLine("3");
            Console.WriteLine("2");
            Console.WriteLine("1");
        }
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm();
        }
    }
}
