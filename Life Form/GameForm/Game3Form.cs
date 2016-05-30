using System.Text;
using Life.Models;

namespace Life_Form.GameForm
{
    class Game3Form : GameBaseForm
    {
        public Game3Form(int x, int y, string game, Form1 form) : base(x, y, game, form)
        {
            inform.Add(new StringBuilder("Grass cells: "));
            inform.Add(new StringBuilder("Grass1 cells: "));
        }

        public override void DrawForm(Cell[,] gameField, int iteration, int[] ValueCells)
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    if (gameField[i, j] != null)
                        switch (gameField[i, j].livingName)
                        {
                            case LivingName.Grass:
                                form.dataGridView1[i, j].Value = "X";
                                break;
                            case LivingName.Grass1:
                                form.dataGridView1[i, j].Value = "Y";
                                break;
                        }
            inform[0].Append(iteration.ToString());
            inform[1].Append(ValueCells[1].ToString());
            inform[2].Append(ValueCells[2].ToString());
            UpdateScreen(inform);
        }

        public override void ClearNumbers()
        {
            ClearTable();
            inform[0].Remove(11, inform[0].Length - 11);
            inform[1].Remove(13, inform[1].Length - 13);
            inform[2].Remove(14, inform[2].Length - 14);
        }
    }
}
