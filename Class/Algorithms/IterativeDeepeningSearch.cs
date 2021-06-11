using System.Collections.Generic;
using System;


namespace AI_ProblemSolving
{
    class IterativeDeepeningSearch : AUninformedSearchAlgorithm<ABoardState>
    {
        private uint limit; 
        public IterativeDeepeningSearch(uint limit)
        {
            this.name = "IterativeDeepeningSearch";
            this.limit = limit;
        }

        public override List<Node<ABoardState>> resolveOneStep(ref List<Node<ABoardState>> currentNodes, ref AProblem<ABoardState> problem)
        {
            Node<ABoardState> currentNode = currentNodes[0];
            currentNodes.RemoveAt(0);

            if (problem.isResolved(currentNode.getState()))
            {
                currentNode.isTheSolution = true;
                this.isFinished = true;
                this.isSolved = true;
                return new List<Node<ABoardState>> { currentNode };
            }

            if (currentNode.depth < limit)
            {
                List<ABoardState> childrenStates = problem.expand(currentNode.getState());
                foreach (ABoardState childState in childrenStates)
                {
                    Node<ABoardState> childNode = createAndConnectChildNode(childState, ref currentNode);
                    this.isSolved = true;
                    currentNodes.Insert(0, childNode);
                }
            }

            if (currentNodes.Count <= 0)
            {
                this.isFinished = true;
                this.isSolved = false;
                return new List<Node<ABoardState>> { currentNode };
            }

            return currentNodes;
        }
    }
}