using SimpleGameStateMachine.StateMachine.Enums;
using SimpleGameStateMachine.StateMachine.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine
{
    public class Machine
    {
        public static Machine Instance { get; set; }

        private State CurrentState { get; set; }

        private States State { get; set; }

        private readonly States initialState;

        public Machine()
        {
            Instance = this;
            initialState = States.SPLASH;

        }

        public void RequestStateChange(States requestedState)
        {
            ProcessStateEvent(requestedState);
        }

        public void Process()  
        {
            // Initial State Configuration
            if(State == States.UNDEFINED)
            {
                State = initialState;
            }
            ProcessStateEvent(State);
        }

        private bool ProcessStateEvent(States requestedState)
        {
            // TODO:
            // What happens when paused?
            // What happens when resumed?
                // If current state is paused and next state isn't paused, call close then resume.
            // Think of a better solution instead of these groups of if statements. Are these steps
                // able to be pre-defined?
            
            // Initial call when CurrentState object is null.
            if(CurrentState == null)
            {
                CurrentState = GetState(requestedState);
                return true;
            }

            // Incoming state doesn't equal the current state.
            if(requestedState != State)
            {
                Close();
                State = requestedState;
                CurrentState = GetState(requestedState);
                return true;
            }

            // If the CurrentState hasn't executed Init yet.
            if(!CurrentState.IsInitialized)
            {
                Open();
                State = requestedState;
                return true;
            }
            else
            {
                Run();
                return true;
            }
        }

        private void Open()
        {
            Console.WriteLine($"In State Machine Class : Open");
            CurrentState.Init();
        }

        private void Run()
        {
            Console.WriteLine($"In State Machine Class : Run");
            CurrentState.Process();
            CurrentState.Update();
        }

        private void Pause()
        {
            Console.WriteLine($"In State Machine Class : Pause");
            // TODO: Process the pause event
        }

        private void Resume()
        {
            Console.WriteLine($"In State Machine Class : Resume");
            // TODO: Process the resume event
        }

        private void Close()
        {
            Console.WriteLine($"In State Machine Class : Close");
            CurrentState.Close();
        }

        private State GetState(States state)
        {
            State result;
            switch(state)
            {
                case States.SPLASH:
                    result = new SplashState();
                    break;
                case States.GAME:
                    result = new GameState();
                    break;
                case States.PAUSE:
                    result = new PauseState();
                    break;
                case States.MAINMENU:
                    result = new MainMenuState();
                    break;
                case States.CREDIT:
                    result = new CreditState();
                    break;
                default:
                    result = new FailState();
                    break;
            }
            return result;
        }
    }
}
