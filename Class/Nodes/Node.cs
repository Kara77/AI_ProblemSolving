using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_ProblemSolving
{
    class Node<TState>
    {
        private Node<TState> parentNode;
        private List<Node<TState>> childrenNodes;
        protected TState state;

        public uint depth;
        public uint g;
        public bool isTheSolution;

        public ref TState getState()
        {
            return ref state;
        }

        public TState getParentNode()
        {
            try
            {
                if (parentNode == null)
                {
                    return state;
                }
                return parentNode.getState();

            }
            catch (NullReferenceException)
            {
                return state;
            }
        }

        public uint getDepth()
        {
            return depth;
        }

        public void setParentNode(ref Node<TState> parentNode)
        {
            if (this.parentNode != null)
            {
                throw new Exception("You can't assign a parent to a Node that already have one.");
            }

            this.parentNode = parentNode;
            this.depth = parentNode.depth + 1;
            this.g = parentNode.g;
        }

        public void addChildNode(ref Node<TState> childNode)
        {
            childrenNodes.Add(childNode);
        }

        public Node(TState state)
        {
            this.parentNode = null;
            this.childrenNodes = new List<Node<TState>>();
            this.state = state;
            this.depth = 0;
            this.isTheSolution = false;
        }

        public void reset() { }
    }
}