using Life.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life_Form.GameForm
{
    public abstract class GameBaseForm
    {
        protected int shiftx;
        protected int shifty;
        protected string typeGame;
        protected int j;
        protected List<StringBuilder> inform = new List<StringBuilder>();
        public Form1 form;
        public GameBaseForm(int x, int y, string game, Form1 form)
        {
            string s = game;
            shiftx = x;
            shifty = y;
            typeGame = game;
            this.form = form;
            ClearTable();
            inform.Add(new StringBuilder("Iteration: "));
        }

        public void ClearTable()
        {
            for (int i = 0; i < shiftx; i++)
                for (j = 0; j < shifty; j++)
                    form.dataGridView1[i, j].Value = "";
            form.TextBox1Change += form.WriteTextBox;
            form.TextBoxChanged("");
        }

        public void UpdateScreen(List<StringBuilder> inform)
        {
            form.TextBox1Change += form.WriteTextBox;
            form.TextBoxChanged((inform.Aggregate(new StringBuilder(), (s, i) => s.Append(i).AppendLine()).ToString()).TrimEnd());
            form.DataGridView1Change += form.WriteDataGridView;
            form.dataGridViewChanged();

        }

        public abstract void ClearNumbers();
        public abstract void DrawForm(Cell[,] gameField, int iteration, int[] ValueCells);
    }
}
