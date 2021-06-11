using System;
using System.Collections.Generic;

namespace AI_ProblemSolving
{
    abstract class ASearchingAlgorithm<TState>
    {
        public string name
        {
            get; set;
        }

        public bool isFinished
        {
            get; set;
        }

        public bool isSolved
        {
            get; set;
        }

        public ASearchingAlgorithm() {
            this.isFinished = false;
            this.isSolved = false;
        }

        protected Node<TState> createAndConnectChildNode(TState childState, ref Node<TState> parentNode)
        {
            Node<TState> childNode = new Node<TState>(childState);
            childNode.setParentNode(ref parentNode);
            parentNode.addChildNode(ref childNode);
            return childNode;
        }

        public abstract (Node<TState>, Node<TState>) resolve(AProblem<TState> problem);

        public abstract List<Node<TState>> resolveOneStep(ref List<Node<TState>> firstNodes, ref AProblem<TState> problem);
    }
}