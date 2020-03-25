using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6
{
    abstract class Component
    {
        public abstract void Operation();
    }
    class UnusualEngineComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Дополнительный необычный движок запущен!");
        }
    }
    class PowerfullUnusualEngineComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("МОЩНЫЙ дополнительный необычный движок запущен!");
        }
    }

    abstract class RocketDecorator : Component
    {
        protected Component component;

        public void SetComponent(Component component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            Console.WriteLine("Запускаю основные двигатели...");
            if (component != null)
                component.Operation();
        }
    }
    class RocketWithPrint : RocketDecorator
    {
        public RocketWithPrint() { }
        public RocketWithPrint(string s) => Color = s;
        public override void Operation()
        {
            Console.Write($"Цвет ракеты: {Color}. ");
            base.Operation();
        }
        public string Color { get; set; } = "красный";
    }
    class RocketWithAdditionalEngine : RocketDecorator
    {
        public string Engine { get; set; }
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Дополнительный движок запущен!"); // Дополнительная операция ракеты с дополнительным движком.
        }
    }
}
