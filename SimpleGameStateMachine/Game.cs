using SimpleGameStateMachine.StateMachine;
using SimpleGameStateMachine.StateMachine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine
{
    public class Game
    {
        public Game()
        {

        }

        public void Run()
        {
            var stateMachine = new Machine(States.SPLASH);
            var running = true;

            // Main Loop
            while (running)
            {
                stateMachine.Process();
            }
        }
    }
}
