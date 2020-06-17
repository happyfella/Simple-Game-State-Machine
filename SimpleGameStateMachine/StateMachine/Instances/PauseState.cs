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
        private readonly States pausedStateIdentifier;

        public PauseState(Machine context) : base(context)
        {
            StateIdentifier = States.PAUSE;
        }

        public PauseState(Machine context, States pausedStateIdentifier) : base(context)
        {
            StateIdentifier = States.PAUSE;
            this.pausedStateIdentifier = pausedStateIdentifier;
        }

        public override void Init()
        {
            base.Init();
        }

        public override void Process()
        {
            base.Process();
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
