using System;
using System.Collections.Generic;

namespace AI_ProblemSolving
{
    class Position
    {
        public uint first;
        public uint second;

        public Position(uint first, uint second)
        {
            this.first = first;
            this.second = second;
        }

        public void consoleDisplay()
        {
            Console.WriteLine("first: {0}, second: {1}", this.first, this.second);
        }
    }
    abstract class ABoardState : AState
    {
        public int[,] board { get; set; }
        public uint size { get; set; }

        public Position getEmptyTile()
        {
            for (uint i = 0; i < size; i++)
            {
                for (uint j = 0; j < size; j++)
                {
                    Position position = new Position(i, j);
                    if (this.getValue(position) == 0)
                    {
                        return position;
                    }
                }
            }
            throw new Exception("A state should have an empty tile.");
        }

        public abstract void RandomBoard();
        public void OwnBoard(string _board)
        {
            if (checkBoard(_board) != true)
            {
                Console.WriteLine("Baddd");
                return;
            }

            int n = 0;
            int i = 0;
            int j = 0;
            string[] split = _board.Split(' ');

            for (i = 0; i < split.Length; i++)
            {
                if (n == size)
                {
                    n = 0;
                    j += 1;
                }
                if (j == size)
                    return;
                board[j, n] = int.Parse(split[i]);
                n += 1;
            }
        }
        public abstract bool checkBoard(string _board);

        public List<Position> getNotEatableTile()
        {
            List<Position> res = new List<Position>();

            for (uint i = 0; i < size; i++)
            {
                for (uint j = 0; j < size; j++)
                {
                    Position position = new Position(i, j);
                    if (this.getValue(position) == 0)
                    {
                        res.Add(position);
                    }
                }
            }
            return (res);
        }

        public bool isEqual(ABoardState otherState)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] != otherState.board[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int getValue(Position position)
        {
            return this.board[position.first, position.second];
        }

        public void consoleDisplay()
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    Console.Write(this.board[i, j] != 0 ? this.board[i, j].ToString() : " ");
                    Console.Write(j < this.size - 1 ? " " : "\n");
                }
            }
        }

        public string toGraphicalString()
        {
            string result = "";
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    result += this.board[i, j].ToString();
                    result += j == this.size - 1 ? "\r\n" : " ";
                }
            }
            return result;
        }

        public int heuristic(ABoardState goalState)
        {
            return 0;
        }

        // abstract public void swap(ref Position tileToSwapA, ref Position tileToSwapB);
    }
}
