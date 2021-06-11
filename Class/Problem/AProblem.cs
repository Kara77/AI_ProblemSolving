using System;
using System.Collections.Generic;	


namespace AI_ProblemSolving
{
	abstract class AProblem<TState>
	{
		public string name
		{
			get; set;
		}
		public TState initialState
		{
			get; set;
		}
		public TState goalState
		{
			get; set;
		}
		protected List<TState> cache
		{
			get; set;
		}

		public void resetCache()
        {
			cache = new List<TState>();
        }

		public abstract int getHeuristicValue(Node<TState> node);
		public abstract bool isResolved(TState state);
		public abstract List<TState> expand(TState state);
		abstract protected bool updateCache(TState newState);
	}
}