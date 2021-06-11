using System;

namespace AI_ProblemSolving
{
    using System.Collections.Generic;
    abstract class AUninformedSearchAlgorithm<TState>: ASearchingAlgorithm<TState>
    {
        public override (Node<TState>, Node<TState>) resolve(AProblem<TState> problem)
        {
            Node<TState> firstNode = new Node<TState>(problem.initialState);
            List<Node<TState>> currentNodes = new List<Node<TState>> { firstNode };

            while (!this.isFinished)
            {
                currentNodes = this.resolveOneStep(ref currentNodes, ref problem);
            }

            if (currentNodes.Count <= 0)
            {
                throw new Exception("even if it's unsolved, resolveOneStep can't return an empty List.");
            }

            return (firstNode, currentNodes[0]);
        }
    }
}