using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Command
            Console.WriteLine("Command");
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            JumpCommand command = new JumpCommand(receiver);
            invoker.SetCommand(command);
            receiver.WriteState();
            invoker.Operation();
            receiver.WriteState();

            Console.WriteLine();

            //State
            Console.WriteLine("State");
            MyObject myObject = new MyObject();
            myObject.ChangeState(new DuckingState());
            myObject.HandleInput(Input._UP);
            myObject.HandleInput(Input._DOWN);

            Console.WriteLine();

            //Memento
            Console.WriteLine("Memento");
            Memento memento = myObject.CreateMemento();
            Restorer restorer = new Restorer(myObject, memento);
            myObject.HandleInput(Input._UP);
            restorer.SetMemento();
            myObject.HandleInput(Input._UP);

            Console.WriteLine();

            //Strategy
            Console.WriteLine("Strategy");
            ConcreteStrategy1 concreteStrategy1 = new ConcreteStrategy1();
            ConcreteStrategy2 concreteStrategy2 = new ConcreteStrategy2();
            Context context = new Context(concreteStrategy1);
            context.ExecuteAlgorithm();
            Console.WriteLine("Next algorithm");
            context.ContextStrategy = concreteStrategy2;
            context.ExecuteAlgorithm();

            Console.WriteLine();

            //Observer
            Console.WriteLine("Observer");
            ConcreteObservable concreteObservable = new ConcreteObservable();
            ConcreteObserver concreteObserver = new ConcreteObserver();
            concreteObservable.AddObserver(concreteObserver);
            concreteObservable.NotifyObservers();


            Console.ReadLine();

        }
    }
}
