using SimpleGameStateMachine.StateMachine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine.Instances
{
    public class PauseState : State
    {
        public PauseState(Machine context) : base(context)
        {
            StateIdentifier = States.PAUSE;
        }

        public override void Init()
        {
            base.Init();
        }

        public int Counter { get; set; }

        public override void Process()
        {
            base.Process();


            Counter++;
            if (Counter == 2)
            {
                Console.ReadKey();
                this.Context.RequestStateChange(States.GAME);
                Counter = 0;
            }
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Render()
        {
            base.Render();
        }

        public override void Close()
        {
            base.Close();
        }
    }
}
