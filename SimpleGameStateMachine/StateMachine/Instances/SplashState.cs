using SimpleGameStateMachine.StateMachine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine.Instances
{
    public class SplashState : State
    {        
        public SplashState(Machine context) : base(context) { }

        public override void Init()
        {
            base.Init();
        }

        public override void Process()
        {
            base.Process();

            Counter++;
            if (Counter == 2)
            {
                Console.ReadKey();
                this.Context.RequestStateChange(States.GAME);
                //Machine.Instance.RequestStateChange(States.GAME);
                //Machine.CurrentStateIdentifier = States.GAME;
                Counter = 0;
            }
        }

        public int Counter { get; set; }

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
