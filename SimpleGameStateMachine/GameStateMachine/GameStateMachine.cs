using SimpleGameStateMachine.StateMachine.Enums;
using SimpleGameStateMachine.StateMachine.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine
{
    public class GameStateMachine
    {
        private readonly States initialState;

        private State CurrentState { get; set; }

        private State PausedState { get; set; }

        private States StagedStateIdentifier { get; set; }

        public GameStateMachine(States initialState)
        {
            this.initialState = initialState;
        }

        public void Process()  
        {
            // Initial State Configuration
            if(CurrentState == null)
            {
                CurrentState = GetState(initialState);
            }

            ProcessStateEvent(CurrentState.StateIdentifier);
        }

        public void RequestStateChange(States requestedState)
        {
            StagedStateIdentifier = requestedState;
        }

        private void ProcessStateChange(States requestedState)
        {
            ProcessStateEvent(requestedState);
        }

        private void ProcessStateEvent(States requestedState)
        {   
            // Initial call when CurrentState object is null.
            if(CurrentState == null)
            {
                CurrentState = GetState(requestedState);   
            }

            // Handle Pause
            if(requestedState == States.PAUSE && CurrentState.StateIdentifier != States.PAUSE)
            {
                PausedState = CurrentState;
                CurrentState = GetState(requestedState);
            }

            // Handle Unpause
            if(requestedState != CurrentState.StateIdentifier && CurrentState.StateIdentifier == States.PAUSE)
            {
                Close();
                CurrentState = PausedState;
            }

            // Incoming state doesn't equal the current state.
            if(requestedState != CurrentState.StateIdentifier && requestedState != States.PAUSE)
            {
                Close();
                CurrentState = GetState(requestedState);
            }

            // If the CurrentState hasn't executed Init yet.
            if(!CurrentState.IsInitialized)
            {
                Open();
            }
            else
            {
                Run();
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
            CurrentState.Render();

            // Ensure all Run execution is processed before state change
            if(StagedStateIdentifier != States.UNDEFINED)
            {
                var nextState = StagedStateIdentifier;
                StagedStateIdentifier = States.UNDEFINED;
                ProcessStateChange(nextState);
            }
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
                    result = new SplashState(this);
                    break;
                case States.GAME:
                    result = new GameState(this);
                    break;
                case States.PAUSE:
                    result = new PauseState(this, CurrentState.StateIdentifier);
                    break;
                case States.MAINMENU:
                    result = new MainMenuState(this);
                    break;
                case States.CREDIT:
                    result = new CreditState(this);
                    break;
                default:
                    result = new FailState(this);
                    break;
            }
            return result;
        }
    }
}
