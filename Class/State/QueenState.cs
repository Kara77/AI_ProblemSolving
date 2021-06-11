using System;

namespace AI_ProblemSolving
{
    class QueenState : ABoardState
    {
        public enum TileStatus
        {
            EMPTY,
            EATABLE,
            QUEEN
        }

        public uint queenNumber { get; set;}

        public QueenState(uint size)
        {
            this.board = new int[size, size];
            this.size = size;
            this.queenNumber = 0;
        }

        public QueenState(ABoardState state)
        {
            size = state.size;
            board = new int[size, size];
            this.queenNumber = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = state.board[i, j];
                    if (state.board[i, j] == (int)TileStatus.QUEEN)
                    {
                        this.queenNumber += 1;
                    }
                }
            }
        }

        public void putQueen(ref Position tileToSpawn)
        {
            board[tileToSpawn.first, tileToSpawn.second] = (int)TileStatus.QUEEN;
            this.queenNumber += 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] != (int)TileStatus.QUEEN)
                    {
                        if (i == tileToSpawn.first) { board[i, j] = (int)TileStatus.EATABLE; }
                        else if (j == tileToSpawn.second) { board[i, j] = (int)TileStatus.EATABLE; }
                        else if (Math.Abs(i - (int)tileToSpawn.first) == Math.Abs(j - (int)tileToSpawn.second)) { board[i, j] = (int)TileStatus.EATABLE; }
                    }
                }
            }
        }

        public override void RandomBoard()
        {
            board = new int[size, size];
            this.queenNumber = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = board[i, j];
                    if (board[i, j] == (int)TileStatus.QUEEN)
                    {
                        this.queenNumber += 1;
                    }
                }
            }
        }

        public override bool checkBoard(string _board)
        {
            int tmp;
            int max = (int)(size * size) - 1;
            string[] split = _board.Split(' ');

            if (split.Length != size * size)
            {
                return false;
            }
            for (int i = 0; i < split.Length; i++)
            {
                tmp = int.Parse(split[i]);
                if (tmp != 0 && tmp != 1 && tmp != 2)
                {
                    return false;
                }
            }
            return true;
        }

        ~QueenState() { }
    }
}