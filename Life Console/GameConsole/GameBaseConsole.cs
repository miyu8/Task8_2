using System;
using Life.Models;

namespace Life.GameConsole
{
    public abstract class GameBaseConsole
    {
        protected int shiftx;
        protected int shifty;
        protected string typeGame;
        protected int j;
        public GameBaseConsole(int x, int y, string game)
        {
            string s = game;
            shiftx = x;
            shifty = y;
            typeGame = game;
            Console.Clear();
            for (int i = 0; i < x; i++)
                for (j = 0; j < y; j++)
                    Square(i, j);
            j += 2;
            WriteAt("Iteration: ", 1, 1, 0, j);
            WriteAt("Нажмите Esc для остановки и сохранения в базу ", 1, 1, x + 1, 0);
        }
        protected void WriteAt(string s, int x, int y, int ix, int iy)
        {
            try
            {
                Console.SetCursorPosition(y + 2 * iy, x + 2 * ix);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        protected void Square(int ix, int iy)
        {
            WriteAt("+", 0, 0, ix, iy);
            WriteAt("|", 1, 0, ix, iy);
            WriteAt("+", 2, 0, ix, iy);

            WriteAt("-", 2, 1, ix, iy);
            WriteAt("+", 2, 2, ix, iy);

            WriteAt("|", 1, 2, ix, iy);
            WriteAt("+", 0, 2, ix, iy);

            WriteAt("-", 0, 1, ix, iy);
        }

        protected void ClearTable()
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    WriteAt(" ", 1, 1, i, j);
        }

        public abstract void ClearNumbers();
        public abstract void DrawConsole(Cell[,] gameField, int iteration, int[] ValueCells);
    }
}
