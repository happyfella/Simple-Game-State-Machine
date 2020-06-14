using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine.Instances
{
    public class State : IState
    {
        public bool IsInitialized { get; set; }

        public State()
        {
            
        }

        public virtual void Init()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Init");
            IsInitialized = true;
        }

        public virtual void Process()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Process");
        }

        public virtual void Update()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Update");
        }

        public virtual void Close()
        {
            Console.WriteLine($"{this.GetType().ToString()} : Close");
        }
    }
}
