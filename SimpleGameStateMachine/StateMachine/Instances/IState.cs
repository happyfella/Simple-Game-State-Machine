using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameStateMachine.StateMachine.Instances
{
    public interface IState
    {
        void Init();

        void Process();

        void Update();

        void Close();
    }
}
