using System;
using System.Collections.Generic;


namespace AI_ProblemSolving
{
    using System.Security.Cryptography;
    using System.Linq;
    class PuzzleState : ABoardState
    {
        public PuzzleState(uint size, bool initRandomly = false)
        {
            this.size = size;
            this.board = new int[size, size];

            if (initRandomly)
                this.RandomBoard();
        }

        public PuzzleState(uint size, ref int[,] board)
        {
            this.board = new int[size, size];
            this.size = size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.board[i, j] = board[i, j];
                }
            }
        }

        public PuzzleState(ABoardState state)
        {
            this.size = state.size;
            this.board = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = state.board[i, j];
                }
            }
        }

        public void swap(ref Position tileToSwapA, ref Position tileToSwapB)
        {

            int tmp = board[tileToSwapA.first, tileToSwapA.second];
            board[tileToSwapA.first, tileToSwapA.second] = board[tileToSwapB.first, tileToSwapB.second];
            board[tileToSwapB.first, tileToSwapB.second] = tmp;
        }

        private int GetNextInt32(RNGCryptoServiceProvider random)
        {
            byte[] randomInt = new byte[4];
            random.GetBytes(randomInt);
            return System.Convert.ToInt32(randomInt[0]);
        }

        public override void RandomBoard()
        {
            RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
            int[] content = new int[size * size];

            for (int i = 0; i < size * size; i++)
            {
                content[i] = i;
            }
            content = content.OrderBy(x => GetNextInt32(random)).ToArray();


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    this.board[i, j] = content[i + j * size];
                }
            }
        }

        public new int heuristic(ABoardState goalState)
        {
            List<Tuple<int, Position>> cache = new List<Tuple<int, Position>>();
            for (uint i2 = 0; i2 < size; i2++)
            {
                for (uint j2 = 0; j2 < size; j2++)
                {
                    Tuple<int, Position> result = new Tuple<int, Position>(goalState.board[i2, j2], new Position(i2, j2));
                    cache.Add(result);
                }
            }

            int score = 0;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    for (var k = 0; k < cache.Count; k++)
                    {
                        if (cache[k].Item1 == this.board[i, j])
                        {
                            score += (int)Math.Abs(i - (int)cache[k].Item2.first) + (int)Math.Abs(j - (int)cache[k].Item2.second);
                            cache.RemoveAt(k);
                        }
                    }
                }
            }
            // Console.WriteLine("new calc diff: {0}", score);
            return score;
        }

        public override bool checkBoard(string _board)
        {
            int tmp;
            int max = (int)(size * size) - 1;
            int[] occ = new int[size * size];
            string[] split = _board.Split(' ');

            if (split.Length != size * size)
            {
                return false;
            }
            for (int i = 0; i < split.Length; i++)
            {
                tmp = int.Parse(split[i]);
                if (tmp > max)
                {
                    return false;
                }
                occ[tmp] += 1;
                if (occ[tmp] > 1)
                {
                    return false;
                }
            }
            return true;
        }
        ~PuzzleState() { }
    }
}