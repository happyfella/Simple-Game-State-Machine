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
            var game = new Game();
            game.Run();
        }
    }
}
