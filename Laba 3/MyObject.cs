using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    enum Input { _DOWN, _UP}
    interface ObjectState
    {
        void HandleInput(MyObject hero, Input input);
        void Update(MyObject hero);
    };


    class MyObject
    {
        public void HandleInput(Input input)
        {
            _state.HandleInput(this, input);
        }
        void Update()
        {
            _state.Update(this);
        }
        public void ChangeState(ObjectState state) { _state = state; }
        // Другие методы...
        private ObjectState _state;

        public Memento CreateMemento()
        {
            Console.WriteLine("Memento trying to create");
            return new Memento(_state);
        }

    };

    class Restorer
    {
        MyObject myObject;
        Memento memento;
        public Restorer(MyObject myobj, Memento memento)
        {
            Console.WriteLine("Memento and object pointer's setted");
            myObject = myobj;
            this.memento = memento;
        }
        public void SetMemento()
        {
            Console.WriteLine("State setted by memento");
            myObject.ChangeState(memento.State);
        }
    }

    class DuckingState : ObjectState
    {
        public DuckingState() { }
        public void HandleInput(MyObject hero, Input input)
        {
            if (input == Input._UP)
            {
                Console.WriteLine("I'm flying");
                // Переход в другое состояние
                hero.ChangeState(new JumpingState());
            }
            //...
        }
        public void Update(MyObject hero)
        {
            //...
        }
    }

    class JumpingState : ObjectState
    {
        public JumpingState() { }
        public void HandleInput(MyObject hero, Input input)
        {
            if (input == Input._DOWN)
            {
                Console.WriteLine("I'm ducking");
                // Переход в другое состояние
                hero.ChangeState(new DuckingState());
            }
            //...
        }
        public void Update(MyObject hero)
        {
            //...
        }
    }
}
