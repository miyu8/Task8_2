using System;

namespace Life.Models
{
    class MyConsole
    {
        protected int shiftx;
        protected int shifty;

        public MyConsole(int i, int j)
        {
            shiftx = i;
            shifty = j;
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
        public void DrawConsole(Cell[,] gameField, int iteration, int[] ValueCells)
        {
            Console.Clear();
            for (int i = 0; i < shiftx; i++)
                for (int j = 0; j < shifty; j++)
                    Square(i, j);

            int gameFieldX = gameField.Length / gameField.GetLength(0);
            int gameFieldY = gameField.GetLength(0);

            for (int i = 0; i < gameFieldX; i++)
                for (int j = 0; j < gameFieldY; j++)
                    if (gameField[i, j] != null)
                        switch (gameField[i, j].livingName)
                        {
                            case Cell.LivingName.Grass:
                                WriteAt("X", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                            case Cell.LivingName.Grass1:
                                WriteAt("Y", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                            case Cell.LivingName.Grass2:
                                WriteAt("Z", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                            case Cell.LivingName.Herbivorous1:
                                WriteAt("O", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                            case Cell.LivingName.Corpse:
                                WriteAt("V", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                        }

            gameFieldY += 2;
            WriteAt("Iteration: " + iteration, 1, 1, 0, gameFieldY);
            switch (ValueCells[0])
            {
                case 1:
                    WriteAt("Grass cells: " + ValueCells[1], 1, 1, 1, gameFieldY);
                    break;
                case 2:
                    WriteAt("Grass1 cells: " + ValueCells[2], 1, 1, 1, gameFieldY);
                    break;
                case 3:
                    WriteAt("Grass cells: " + ValueCells[1], 1, 1, 1, gameFieldY);
                    WriteAt("Grass1 cells: " + ValueCells[2], 1, 1, 2, gameFieldY);
                    break;
                case 4:
                    WriteAt("Grass2 cells: " + ValueCells[3], 1, 1, 1, gameFieldY);
                    WriteAt("Herbivorous1 cells: " + ValueCells[4], 1, 1, 2, gameFieldY);
                    WriteAt("Corpse cells: " + ValueCells[5], 1, 1, 3, gameFieldY);
                    break;
            }
        }
    }
}
