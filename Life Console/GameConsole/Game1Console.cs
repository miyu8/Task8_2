using Life.Models;

namespace Life.GameConsole
{
    public class Game1Console : GameBaseConsole
    {
        public Game1Console(int x, int y, string game) : base(x, y, game)
        {
            WriteAt("Grass cells: ", 1, 1, 1, j);
        }

        public override void DrawConsole(Cell[,] gameField, int iteration, int[] ValueCells)
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    if (gameField[i, j] != null)
                        WriteAt("X", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);

            WriteAt(iteration.ToString(), 1, 16, 0, j);
            WriteAt(ValueCells[1].ToString(), 1, 18, 1, j);
        }

        public override void ClearNumbers()
        {
            ClearTable();
            WriteAt("          ", 1, 16, 0, j);
            WriteAt("          ", 1, 18, 1, j);
        }
    }
}
