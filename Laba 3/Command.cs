using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    enum State
    {
        STAING,
        FIRE,
        JUMPING
    };

    interface ICommand
    {
        void Execute();
    }

    class JumpCommand : ICommand
    {
        Receiver receiver;
        public JumpCommand(Receiver r)
        {
            receiver = r;
        }
        public void Execute()
        {
            receiver.state = State.JUMPING;
            Console.WriteLine("JumpCommand called");
            receiver.Operation();
        }
    }

    class FireCommand : ICommand
    {
        Receiver receiver;
        public FireCommand(Receiver r)
        {
            receiver = r;
        }
        public void Execute()
        {
            receiver.state = State.FIRE;
            Console.WriteLine("FireCommand called");
            receiver.Operation();
        }
    }

    // получатель команды
    class Receiver
    {
        public State state = State.STAING;
        public void Operation()
        {
            Console.WriteLine("Operation called");
        }

        public void WriteState()
        {
            Console.WriteLine(state.ToString());
        }
    }
    // инициатор команды
    class Invoker
    {
        ICommand command;
        public void SetCommand(ICommand c)
        {
            Console.WriteLine("I'm invoker and i set the command");
            command = c;
        }
        public void Operation()
        {
            Console.WriteLine("I'm invoker and i call the operation");
            command.Execute();
        }
    }
}

