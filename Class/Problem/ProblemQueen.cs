using System;
using System.Collections.Generic;


namespace AI_ProblemSolving
{
    class Queen : AProblem<ABoardState>
    {
        protected override bool updateCache(ABoardState newState)
        {
            return true;
        }

        public Queen(uint size)
        {
            this.name = "Queen";
            this.initialState = new QueenState(size);
            this.goalState = new QueenState(size);
            this.cache = new List<ABoardState>();
        }

        public override List<ABoardState> expand(ABoardState state)
        {
            //Console.WriteLine("Queen: extand method !");
            List<ABoardState> result = new List<ABoardState>();
            List<Position> emptyPositionNotEatable = state.getNotEatableTile();
            uint queenNumber = new QueenState(state).queenNumber;
            //Console.WriteLine("queenNumber", queenNumber);

            foreach (Position elem in emptyPositionNotEatable)
            {
                if (elem.first == queenNumber) 
                {
                    QueenState newState = new QueenState(state);
                    Position newPosition = new Position(elem.first, elem.second);
                    newState.putQueen(ref newPosition);
                    if (updateCache(newState))
                        result.Add(newState);
                }
            }
            return result;
        }

        public override int getHeuristicValue(Node<ABoardState> node)
        {
            return 0;
        }

        public override bool isResolved(ABoardState state)
        {
            QueenState qCurrentState = (QueenState)state;
            return goalState.size == qCurrentState.queenNumber;
        }
    }
}