using SimpleGameStateMachine.StateMachine;
using SimpleGameStateMachine.StateMachine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var stateMachine = new Machine(States.SPLASH);
            var quit = false;

            // Main Loop
            while(!quit)
            {
                stateMachine.Process();
            }

            Console.ReadLine();
        }
    }
}
