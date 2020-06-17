using SimpleGameStateMachine.StateMachine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine.Instances
{
    public class GameState : State
    {
        public GameState(Machine context) : base(context)
        {
            StateIdentifier = States.GAME;
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
