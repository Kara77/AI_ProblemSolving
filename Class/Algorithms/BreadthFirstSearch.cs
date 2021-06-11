using System.Collections.Generic;
using System;


namespace AI_ProblemSolving
{
    class BreadthFirstSearch : AUninformedSearchAlgorithm<ABoardState>
    {
        public BreadthFirstSearch()
        {
            this.name = "BreadthFirstSearch";
        }

        public override List<Node<ABoardState>> resolveOneStep(ref List<Node<ABoardState>> currentNodes, ref AProblem<ABoardState> problem)
        {
            if (currentNodes.Count == 0)
            {
                Console.WriteLine("fail");
                this.isFinished = true;
                this.isSolved = false;
                return currentNodes;
            }
            Node<ABoardState> currentNode = currentNodes[0];
            currentNodes.RemoveAt(0);

            //currentNode.getState().consoleDisplay();
            //Console.WriteLine("_____");

            if (problem.isResolved(currentNode.getState()))
            {
                currentNode.isTheSolution = true;
                this.isFinished = true;
                this.isSolved = true;
                return new List<Node<ABoardState>> { currentNode };
            }

            List<ABoardState> childrenStates = problem.expand(currentNode.getState());
            foreach (ABoardState childState in childrenStates)
            {
                Node<ABoardState> childNode = createAndConnectChildNode(childState, ref currentNode);
                currentNodes.Add(childNode);
            }
            return currentNodes;
        }
    }
}