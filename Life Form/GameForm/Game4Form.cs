using System.Text;
using Life.Models;

namespace Life_Form.GameForm
{
    class Game4Form : GameBaseForm
    {
        public Game4Form(int x, int y, string game, Form1 form) : base(x, y, game, form)
        {
            inform.Add(new StringBuilder("Grass2 cells: "));
            inform.Add(new StringBuilder("Herbivorous1 cells: "));
            inform.Add(new StringBuilder("Corpse cells: "));
        }

        public override void DrawForm(Cell[,] gameField, int iteration, int[] ValueCells)
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    if (gameField[i, j] != null)
                        switch (gameField[i, j].livingName)
                        {
                            case LivingName.Grass2:
                                form.dataGridView1[i, j].Value = "Z";
                                break;
                            case LivingName.Herbivorous1:
                                form.dataGridView1[i, j].Value = "O";
                                break;
                            case LivingName.Corpse:
                                form.dataGridView1[i, j].Value = "V";
                                break;
                        }
            inform[0].Append(iteration.ToString());
            inform[1].Append(ValueCells[3].ToString());
            inform[2].Append(ValueCells[4].ToString());
            inform[3].Append(ValueCells[5].ToString());
            UpdateScreen(inform);
        }

        public override void ClearNumbers()
        {
            ClearTable();
            inform[0].Remove(11, inform[0].Length - 11);
            inform[1].Remove(14, inform[1].Length - 14);
            inform[2].Remove(20, inform[2].Length - 20);
            inform[3].Remove(14, inform[3].Length - 14);
        }
    }
}
