using System;

namespace Decorator.Military_laptop
{
    public abstract class Component
    {
        public abstract string Operation();
    }

    class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }

        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class MilitaryDecoratorA : Decorator
    {
        public MilitaryDecoratorA(Component component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"{base.Operation()}, Increased Shock Resistance";
        }
    }
    class MilitaryDecoratorB : Decorator
    {
        public MilitaryDecoratorB(Component component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"{base.Operation()}, Instant russia disappearence";
        }
    }

    public class Client
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(simple);
            Console.WriteLine();

            MilitaryDecoratorA militaryLaptop = new MilitaryDecoratorA(simple);
            MilitaryDecoratorB AdvancedMilitaryLaptop = new MilitaryDecoratorB(militaryLaptop);
            Console.WriteLine("Client: Now I've got a military-grade laptop:");
            client.ClientCode(AdvancedMilitaryLaptop);
        }
    }
}
