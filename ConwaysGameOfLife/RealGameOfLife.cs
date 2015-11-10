using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    public class RealGameOfLife : Board
    {
        private bool[,] CurrentBoard;
        private bool[,] NewBoard;
        int BoardSize;
        public RealGameOfLife(int size)
        {
            BoardSize = size;
            CurrentBoard = new bool[size, size];
            NewBoard = new bool[size, size];
        }

        public bool cellStatus(int x, int y)
        {
            return CurrentBoard[x, y];
        }

        public void Flipper(int x, int y)
        {
            CurrentBoard[x, y] = (!CurrentBoard[x, y]);
        }

        public void ModFlipper(int x, int y)
        {
            NewBoard[x, y] = (!NewBoard[x, y]);
        }

        public int CheckNeighbors(int x, int y)
        {
            int NeighborCount = 0;
            if (CheckIndex(x + 1, y + 1) && CurrentBoard[x + 1, y + 1]) NeighborCount++;
            if (CheckIndex(x + 1, y)     && CurrentBoard[x + 1, y])     NeighborCount++;
            if (CheckIndex(x + 1, y - 1) && CurrentBoard[x + 1, y - 1]) NeighborCount++;
            if (CheckIndex(x, y + 1)     && CurrentBoard[x, y + 1])     NeighborCount++;
            if (CheckIndex(x, y - 1)     && CurrentBoard[x, y - 1])     NeighborCount++;
            if (CheckIndex(x - 1, y + 1) && CurrentBoard[x - 1, y + 1]) NeighborCount++;
            if (CheckIndex(x - 1, y)     && CurrentBoard[x - 1, y])     NeighborCount++;
            if (CheckIndex(x - 1, y - 1) && CurrentBoard[x - 1, y - 1]) NeighborCount++;
            return NeighborCount;
        }

        public bool CheckIndex(int x, int y)
        {
            if (x < 0 || y < 0 || x > CurrentBoard.GetLength(0) - 1 || y > CurrentBoard.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }

        public void Tick()
        {
            NewBoard = (bool[,])CurrentBoard.Clone();
            for (int x = 0; x < CurrentBoard.GetLength(0); x++)
            {
                for (int y = 0; y < CurrentBoard.GetLength(1); y++)
                {
                    //live cell with fewer than two live neighbours dies
                    if (CheckNeighbors(x, y) < 2 && CurrentBoard[x,y]) { NewBoard[x, y] = false; }
                    //live cell with two or three live neighbours lives
                    if ((CheckNeighbors(x, y) == 2 || CheckNeighbors(x, y)==3) && CurrentBoard[x, y]) { NewBoard[x, y] = true; }
                    // live cell with more than three live neighbours dies
                    if (CheckNeighbors(x, y) > 3 && CurrentBoard[x, y]) { NewBoard[x, y] = false; }
                    //dead cell with exactly three live neighbours becomes a live
                    if (CheckNeighbors(x, y) == 3 && !CurrentBoard[x, y]) { NewBoard[x, y] = true; }
                }
            }
            CurrentBoard = (bool[,])NewBoard.Clone();
        }

        public List<List<bool>> ToList()
        {
            List<List<bool>> BoardList = new List<List<bool>>();
            for (int i = 0; i < CurrentBoard.GetLength(0); i++)
            {
                List <bool> row = new List<bool>();
                for (int j = 0; j <= CurrentBoard.GetLength(1); j++)
                {
                    if (j < CurrentBoard.GetLength(1))
                    {
                        row.Add(CurrentBoard[i, j]);
                    }
                    else
                    {
                        //throw new ArgumentException("this happens");
                        BoardList.Add(row);
                    }
                }
            }
            return BoardList;
        }

        public bool[,] GetBoard()
        {
            return CurrentBoard;
        }

        public void Pattern_Selector (string input)
        {
            if (input.ToLower() == "blinker" )
            {
                BoardSize = 5;
                CurrentBoard = new bool[5, 5];
                NewBoard = new bool[5, 5];
                Flipper(1, 2);
                Flipper(2, 2);
                Flipper(3, 2);
            }
            else if (input.ToLower() == "toad")
            {
                BoardSize = 6;
                CurrentBoard = new bool[6, 6];
                NewBoard = new bool[6, 6];
                Flipper(2, 3);
                Flipper(2, 4);
                Flipper(2, 5);
                Flipper(3, 2);
                Flipper(3, 3);
                Flipper(3, 4);
            }
            else if (input.ToLower() == "beacon")
            {
                BoardSize = 6;
                CurrentBoard = new bool[6, 6];
                NewBoard = new bool[6, 6];
                Flipper(1, 1);
                Flipper(1, 2);
                Flipper(2, 1);
                Flipper(3, 4);
                Flipper(4, 3);
                Flipper(4, 4);
            }
            else
            {
                throw new ArgumentException("We haven't implemented that pattern yet");
            }
        }
    }
}