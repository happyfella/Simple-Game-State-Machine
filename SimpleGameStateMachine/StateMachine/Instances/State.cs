using SimpleGameStateMachine.StateMachine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine.Instances
{
    public class State : IState
    {
        protected Machine Context { get; set; }

        public States StateIdentifier { get; set; }

        public bool IsInitialized { get; set; }

        public bool CanClose { get; set; }

        public bool HasClosed { get; set; }

        public State(Machine context)
        {
            Context = context;
            StateIdentifier = States.UNDEFINED;
        }

        public virtual void Init()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Init");

            IsInitialized = true;
            HasClosed = false;
            CanClose = true;
        }

        public virtual void Process()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Process");

            CanClose = false;
        }

        public virtual void Update()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Update");
        }

        public virtual void Render()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Render");

            CanClose = true;
        }

        public virtual void Close()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Close");

            IsInitialized = false;
            HasClosed = true;
        }
    }
}
