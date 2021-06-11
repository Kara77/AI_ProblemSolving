using System.Collections.Generic;
using System;


namespace AI_ProblemSolving
{
    class HillClimbing : ALocalSearchAlgorithm<ABoardState>
    {
        public HillClimbing()
        {
            this.name = "HillClimbing";
        }

        protected int getDifference(Node<ABoardState> currentNode, ref AProblem<ABoardState> problem)
        {
            uint size = currentNode.getState().size;

            List<Tuple<int, Position>> cache = new List<Tuple<int, Position>>();
            for (uint i2 = 0; i2 < size; i2++)
            {
                for (uint j2 = 0; j2 < size; j2++)
                {
                    Tuple<int, Position> result = new Tuple<int, Position>(problem.goalState.board[i2, j2], new Position(i2, j2));
                    cache.Add(result);
                }
            }

            int dif = 0;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    for (var k = 0; k < cache.Count; k++)
                    {
                        if (cache[k].Item1 == currentNode.getState().board[i, j])
                        {
                            dif += (int)Math.Abs(i - (int)cache[k].Item2.first) + (int)Math.Abs(j - (int)cache[k].Item2.second);
                            cache.RemoveAt(k);
                        }
                    }    
                }
            }
            Console.WriteLine("new calc diff: {0}", dif);
            return dif;
        }

        public override List<Node<ABoardState>> resolveOneStep(ref List<Node<ABoardState>> currentNodes, ref AProblem<ABoardState> problem)
        {
            Node<ABoardState> currentNode = currentNodes[0];
            currentNode.getState().consoleDisplay();

            int currentNodeDifference = this.getDifference(currentNode, ref problem);

            if (currentNodeDifference == 0)
            {
                Console.WriteLine("solved: current diff = 0");
                this.isFinished = true;
                this.isSolved = true;
                return new List<Node<ABoardState>> { currentNode };
            }

            List<ABoardState> childrenStates = problem.expand(currentNodes[0].getState());
            Console.WriteLine("children count {0}", childrenStates.Count);
            Node<ABoardState> minChildNode = createAndConnectChildNode(childrenStates[0], ref currentNode);
            int minNodeDifference = this.getDifference(minChildNode, ref problem);
            childrenStates.RemoveAt(0);

            foreach (ABoardState childState in childrenStates)
            {
                Node<ABoardState> childNode = createAndConnectChildNode(childState, ref currentNode);
                int currentDifference = getDifference(childNode, ref problem);
                if (minNodeDifference > currentDifference)
                {
                    Console.WriteLine("new min");
                    minChildNode = childNode;
                    minNodeDifference = currentDifference;
                }
            }

            Console.WriteLine("min dif and currentNode dif {0} and {1}", minNodeDifference, currentNodeDifference);
            if (minNodeDifference > currentNodeDifference)
            {
                Console.WriteLine("algo bloqué");
                this.isFinished = true;
                this.isSolved = false;
                return new List<Node<ABoardState>> { currentNode };
            }

            currentNodes[0] = minChildNode;
            return currentNodes;
        }
    }
}