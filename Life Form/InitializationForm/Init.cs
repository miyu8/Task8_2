using System;
using Life.Models;
using System.Threading;
using Life.BaseData;
using Life.Gaming;
using Life.Initialization;
using Life;
using Life_Form.GameForm;
using System.Windows.Forms;

namespace Life_Form.InitializationForm
{
    public class Move
    {
        public Cell[,] gameField { get; set; }
        public Cell[,] gameFieldNext;
        public GameBase igame;
        public GameBaseForm gameBaseForm;
        public Options options;
        public int[] ValueCells = new int[6];
        public RecordBase recordBase = new RecordBase();
        public int Id { get; private set; }
        public Form1 form;
        public Move(int type, Form1 form, Options newOptions)
        {
            this.form = form;

            options = newOptions;
            switch (type)
            {
                case 1:
                    igame = new Game1(form.options.gameProperty);
                    gameBaseForm = new Game1Form(form.options.gameProperty.SizeX, form.options.gameProperty.SizeY, igame.GetType().Name, this.form);
                    break;
                case 2:
                    igame = new Game2(form.options.gameProperty, form.options.grass1Property);
                    gameBaseForm = new Game2Form(form.options.gameProperty.SizeX, form.options.gameProperty.SizeY, igame.GetType().Name, this.form);
                    break;
                case 3:
                    igame = new Game3(form.options.gameProperty, form.options.grass1Property);
                    gameBaseForm = new Game3Form(form.options.gameProperty.SizeX, form.options.gameProperty.SizeY, igame.GetType().Name, this.form);
                    break;
                case 4:
                    igame = new Game4(form.options.gameProperty, form.options.grass2Property, form.options.herbivorous1Property);
                    gameBaseForm = new Game4Form(form.options.gameProperty.SizeX, form.options.gameProperty.SizeY, igame.GetType().Name, this.form);
                    break;
            }
        }

        public void RunSave(int id, int iteration)
        {
            Id = id;
            igame.gameField = recordBase.TakeList(id, igame.ValueCells, options);
            igame.iteration = iteration;
        }

        public void RunNew()
        {
            igame.InitRnd();
            igame.iteration = 1;
        }

        public void Begin()
        {

            gameBaseForm.DrawForm(igame.gameField, igame.iteration, igame.ValueCells);
            Thread.Sleep(500);
            if (form.exit)
            {
                End();
                return;
            }
            while (igame.Step())
            {
                gameBaseForm.ClearNumbers();
                gameBaseForm.DrawForm(igame.gameField, igame.iteration, igame.ValueCells);
                Thread.Sleep(500);
                if (form.exit)
                {
                    End();
                    gameBaseForm.ClearTable();
                    MessageBox.Show("Игра остановлена и сохранена");
                    return;
                }
            }
            gameBaseForm.ClearTable();
            MessageBox.Show("Игра окончена");
        }

        public void End()
        {
            try
            {
                using (var db = new DataModelContainer())
                {
                    recordBase.AddList(igame.gameField, igame.Type, igame.iteration);
                }
            }
            catch (Exception ex)
            {
                recordBase.ErrorBase(ex);
            }
        }
    }
}
