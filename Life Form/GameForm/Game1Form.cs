using System.Text;
using Life.Models;

namespace Life_Form.GameForm
{
    class Game1Form : GameBaseForm
    {
        public Game1Form(int x, int y, string game, Form1 form) : base(x, y, game, form)
        {
            inform.Add(new StringBuilder("Grass cells: "));
        }

        public override void DrawForm(Cell[,] gameField, int iteration, int[] ValueCells)
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    if (gameField[i, j] != null)
                        form.dataGridView1[i, j].Value = "X";
            inform[0].Append(iteration.ToString());
            inform[1].Append(ValueCells[1].ToString());
            UpdateScreen(inform);
        }

        public override void ClearNumbers()
        {
            ClearTable();
            inform[0].Remove(11, inform[0].Length - 11);
            inform[1].Remove(13, inform[1].Length - 13);
        }
    }
}
