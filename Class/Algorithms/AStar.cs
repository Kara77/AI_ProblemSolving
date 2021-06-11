using System.Collections.Generic;
using System;
using System.Linq;


namespace AI_ProblemSolving
{
    class AStar : AInformedSearchAlgorithm<ABoardState>
    {
        public AStar()
        {
            this.name = "AStar";
        }

        public override List<Node<ABoardState>> resolveOneStep(ref List<Node<ABoardState>> currentNodes, ref AProblem<ABoardState> problem)
        {
            Node<ABoardState> currentNode = currentNodes[0];
            currentNodes.RemoveAt(0);
            // Console.WriteLine(currentNode.getState().heuristic(problem.goalState));

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
            
            ABoardState goalState = problem.goalState;
            Func<Node<ABoardState>, int> getHeuristicValue = problem.getHeuristicValue;
            currentNodes = currentNodes.OrderBy(a => getHeuristicValue(a) + a.getDepth()).ToList();
            return currentNodes;
        }
    }
}