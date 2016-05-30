using Life.Models;

namespace Life.GameConsole
{
    public class Game2Console : GameBaseConsole
    {
        public Game2Console(int x, int y, string game) : base(x, y, game)
        {
            WriteAt("Grass1 cells: ", 1, 1, 1, j);
        }

        public override void DrawConsole(Cell[,] gameField, int iteration, int[] ValueCells)
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    if (gameField[i, j] != null)
                        WriteAt("Y", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);

            WriteAt(iteration.ToString(), 1, 16, 0, j);
            WriteAt(ValueCells[2].ToString(), 1, 19, 1, j);
        }

        public override void ClearNumbers()
        {
            ClearTable();
            WriteAt("          ", 1, 16, 0, j);
            WriteAt("          ", 1, 19, 1, j);
        }
    }
}
