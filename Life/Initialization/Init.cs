using System;
using Life.Models;
using System.Threading;
using Life.BaseData;
using User;
using System.Linq;
using Life.Gaming;

namespace Life.Initialization
{
    public class Move
    {
        public Cell[,] gameField { get; set; }
        public Cell[,] gameFieldNext;
        public Thread[] threads = new Thread[2];
        public EventWaitHandle ew;
        GameBase igame;
        Options options;
        public StartConsole console;
        public int[] ValueCells = new int[6];
        public Move()
        {
            console = new StartConsole();
            console.Run();
            Console.Clear();
            options = new Options();
            switch (console.Type)
            {
                case 1:
                    igame = new Game1(options.gameProperty);
                    break;
                case 2:
                    igame = new Game2(options.gameProperty, options.grass1Property);
                    break;
                case 3:
                    igame = new Game3(options.gameProperty, options.grass1Property);
                    break;
                case 4:
                    igame = new Game4(options.gameProperty, options.grass2Property, options.herbivorous1Property);
                    break;
            }
            End(console.Type, igame);
            threads[1].Start();
            Begin(console.Id, igame);
            threads[0].Start();
            ew = new EventWaitHandle(false, EventResetMode.AutoReset);
            ew.WaitOne();
            if (threads[1] != null)
                threads[1].Abort();
            Console.Clear();
        }

        void Begin(int id, GameBase igame)
        {
            threads[0] = new Thread(() =>
            {
                RecordBase recordBase = new RecordBase();
                MyConsole myConsole;
                try
                {
                    using (var db = new DataModelContainer())
                    {
                        Game game;
                        game = db.GameSet.Where(x => x.Id == id).FirstOrDefault();

                        if (game != null)
                        {
                            igame.gameField = recordBase.TakeList(id, ValueCells);
                            igame.gameProperty = options.gameProperty;
                            igame.ValueCells = ValueCells;

                            igame.iteration = game.Iteration;
                        }
                        else
                        {
                            igame.InitRnd();
                            igame.iteration = 1;
                        }
                        myConsole = new MyConsole(options.gameProperty.SizeX, options.gameProperty.SizeY);
                        myConsole.DrawConsole(igame.gameField, igame.iteration, igame.ValueCells);
                        while (igame.Step())
                        {
                            myConsole.DrawConsole(igame.gameField, igame.iteration, igame.ValueCells);
                            Thread.Sleep(500);
                        }

                        recordBase.RemoveList(id);
                        Program.thread.Abort();
                        if (threads[1] != null)
                            threads[1].Abort();
                        Program.thread = new Thread(() =>
                        {
                            Move move = new Move();
                        });
                        Program.thread.Start();
                    }
                }
                catch (Exception ex)
                {
                    recordBase.ErrorBase(ex, console);
                }

            });
        }

        void End(int typeGame, GameBase igame)
        {
            threads[1] = new Thread(() =>
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    Thread.Sleep(500);
                }
                RecordBase recordBase = new RecordBase();
                try
                {
                    using (var db = new DataModelContainer())
                    {
                        recordBase.AddList(igame.gameField, typeGame, igame.iteration);
                    }
                }
                catch (Exception ex)
                {
                    recordBase.ErrorBase(ex, console);
                }
                if (threads[0] != null)
                    threads[0].Abort();
                Program.thread.Abort();
                Program.thread = new Thread(() =>
                 {
                     Move move = new Move();
                 });
                Program.thread.Start();
            });
        }
    }
}
