using Life.Models;

namespace Life.GameConsole
{
    public class Game4Console : GameBaseConsole
    {
        public Game4Console(int x, int y, string game) : base(x, y, game)
        {
            WriteAt("Grass2 cells: ", 1, 1, 1, j);
            WriteAt("Herbivorous1 cells: ", 1, 1, 2, j);
            WriteAt("Corpse cells: ", 1, 1, 3, j);
        }

        public override void DrawConsole(Cell[,] gameField, int iteration, int[] ValueCells)
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    if (gameField[i, j] != null)
                        switch (gameField[i, j].livingName)
                        {
                            case LivingName.Grass2:
                                WriteAt("Z", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                            case LivingName.Herbivorous1:
                                WriteAt("O", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                            case LivingName.Corpse:
                                WriteAt("V", 1, 1, gameField[i, j].CoordX, gameField[i, j].CoordY);
                                break;
                        }

            WriteAt(iteration.ToString(), 1, 16, 0, j);
            WriteAt(ValueCells[3].ToString(), 1, 19, 1, j);
            WriteAt(ValueCells[4].ToString(), 1, 25, 2, j);
            WriteAt(ValueCells[5].ToString(), 1, 19, 3, j);
        }

        public override void ClearNumbers()
        {
            ClearTable();
            WriteAt("          ", 1, 16, 0, j);
            WriteAt("          ", 1, 19, 1, j);
            WriteAt("          ", 1, 25, 2, j);
            WriteAt("          ", 1, 19, 3, j);
        }
    }
}
