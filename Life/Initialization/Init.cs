using System;
using Life.Models;
using System.Threading;
using Life.BaseData;
using Life.Gaming;
using Life.GameConsole;

namespace Life.Initialization
{
    public class Move
    {
        public Cell[,] gameField { get; set; }
        public Cell[,] gameFieldNext;
        public GameBase igame;
        public GameBaseConsole gameBaseConsole;
        public Options options;
        public int[] ValueCells = new int[6];
        public RecordBase recordBase = new RecordBase();
        public int Id { get; private set; }
        public Move(int type, Options newOptions)
        {
            Console.Clear();

            options = newOptions;
            switch (type)
            {
                case 1:
                    igame = new Game1(options.gameProperty);
                    gameBaseConsole = new Game1Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
                    break;
                case 2:
                    igame = new Game2(options.gameProperty, options.grass1Property);
                    gameBaseConsole = new Game2Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
                    break;
                case 3:
                    igame = new Game3(options.gameProperty, options.grass1Property);
                    gameBaseConsole = new Game3Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
                    break;
                case 4:
                    igame = new Game4(options.gameProperty, options.grass2Property, options.herbivorous1Property);
                    gameBaseConsole = new Game4Console(options.gameProperty.SizeX, options.gameProperty.SizeY, igame.GetType().Name);
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
            gameBaseConsole.DrawConsole(igame.gameField, igame.iteration, igame.ValueCells);
            Thread.Sleep(500);
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                End();
                return;
            }
            while (igame.Step())
            {
                gameBaseConsole.ClearNumbers();
                gameBaseConsole.DrawConsole(igame.gameField, igame.iteration, igame.ValueCells);
                Thread.Sleep(500);
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    End();
                    return;
                }
            }
            recordBase.RemoveList(Id);
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
