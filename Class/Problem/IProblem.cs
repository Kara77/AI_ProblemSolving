using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_ProblemSolving.Class.Problem
{
    class IProblem : AProblem
    {
        IState.IState InitialState;
        IState.IState GoalState;

        public IProblem()
        {
            //InitialState = setInitialState(); //function that random and get a state
            //GoalState = setGoalState(); //The goal state who want to get (random or not idk)
        }

        ~IProblem() {}

        public override IState.IState getGoalState()
        {
            throw new NotImplementedException();
        }

        public override IState.IState getInitialState()
        {
            throw new NotImplementedException();
        }

        public override void setGoalState(IState.IState state)
        {
            throw new NotImplementedException();
        }

        public override void setInitialState(IState.IState state)
        {
            throw new NotImplementedException();
        }
    }
}
