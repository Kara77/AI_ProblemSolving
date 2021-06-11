using System;
using System.Collections.Generic;


namespace AI_ProblemSolving
{
    class Puzzle : AProblem<ABoardState>
    {


        private void initGoalState(uint size)
        {
            int[,] solution = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    solution[i, j] = i * (int)size + j + 1;
                }
            }
            solution[size - 1, size - 1] = 0;
            goalState = new PuzzleState(size, ref solution);
        }

        protected override bool updateCache(ABoardState newState)
        {
            foreach (ABoardState state in cache)
            {
                if (state.isEqual(newState))
                {
                    return false;
                }
            }
            this.cache.Add(newState);
            return true;
        }

        public Puzzle(uint size)
        {
            this.initGoalState(size);
            initialState = new PuzzleState(size, true);
            name = (size * size - 1).ToString() + "-puzzle";
            this.cache = new List<ABoardState>();
        }

        public Puzzle(uint size, ref int[,] initialBoard)
        {
            this.initGoalState(size);
            initialState = new PuzzleState(size, ref initialBoard);
            name = (size * size - 1).ToString() + "-puzzle";
            this.cache = new List<ABoardState>();
        }

        public override List<ABoardState> expand(ABoardState state)
        {
            List<ABoardState> result = new List<ABoardState>();
            Position emptyPosition = state.getEmptyTile();

            if (emptyPosition.first != 0)
            {
                PuzzleState newState = new PuzzleState(state);

                Position newPosition = new Position(emptyPosition.first - 1, emptyPosition.second);
                newState.swap(ref emptyPosition, ref newPosition);
                if (updateCache(newState))
                    result.Add(newState);
            }
            if (emptyPosition.first + 1 < state.size)
            {
                PuzzleState newState = new PuzzleState(state);
                Position newPosition = new Position(emptyPosition.first + 1, emptyPosition.second);
                newState.swap(ref emptyPosition, ref newPosition);
                if (updateCache(newState))
                    result.Add(newState);
            }
            if (emptyPosition.second != 0)
            {
                PuzzleState newState = new PuzzleState(state);
                Position newPosition = new Position(emptyPosition.first, emptyPosition.second - 1);
                newState.swap(ref emptyPosition, ref newPosition);
                if (updateCache(newState))
                    result.Add(newState);
            }
            if (emptyPosition.second + 1 < state.size)
            {
                PuzzleState newState = new PuzzleState(state);
                Position newPosition = new Position(emptyPosition.first, emptyPosition.second + 1);
                newState.swap(ref emptyPosition, ref newPosition);
                if (updateCache(newState))
                    result.Add(newState);
            }
            return result;
        }

        public override int getHeuristicValue(Node<ABoardState> node)
        {
            return ((PuzzleState)(node.getState())).heuristic(this.goalState);
        }

        public override bool isResolved(ABoardState state)
        {
            return state.isEqual(this.goalState);
        }
    }
}