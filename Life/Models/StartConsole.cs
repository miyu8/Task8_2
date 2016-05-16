using System;
using User;
using System.Linq;
using Life.BaseData;

namespace Life.Models
{
    public class StartConsole
    {
        public int Id { get; private set; }
        public int Type { get; private set; }
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Список команд:");
            Console.WriteLine("---");

            Console.WriteLine("b : запускает новую игру");
            Console.WriteLine("s : запускает сохранённую игру");
            Console.WriteLine("escape : приостанавливает с сохранением");
            Console.WriteLine("e : закрывает программу");

            Console.WriteLine("---");
            Console.WriteLine("---");

            bool outbool = true;
            bool outbool2 = true;
            int outvar;

            while (outbool)
            {
                switch (Console.ReadLine())
                {
                    case "e":
                        Program.thread.Abort();
                        outbool = false;
                        break;
                    case "b":
                        Console.WriteLine("Введите тип игры:");                        
                        while (true)
                        {
                            while (!int.TryParse(Console.ReadLine(), out outvar))
                            {
                                Console.WriteLine("Тип равен 1,2,3 или 4");
                            }
                            if ((outvar == 1 || outvar == 2 || outvar == 3 || outvar == 4)) break;
                            Console.WriteLine("Тип равен 1,2,3 или 4");
                        }

                        Type = outvar;
                        outbool2 = false;
                        outbool = false;
                        break;
                    case "s":                        
                        RecordBase recordBase = new RecordBase();
                        try
                        {
                            using (var db = new DataModelContainer())
                            {
                                int i = db.GameSet.Count();
                                if (i == 0)
                                {
                                    Console.WriteLine("База пуста. Введите на английском e, b или клавишу Esc");
                                    outbool2 = false;
                                }
                                else if (i == 1)
                                {
                                    Id = db.GameSet.First().Id;
                                    Type = db.GameSet.First().Type;
                                    outbool2 = false;
                                    outbool = false;
                                }
                                else
                                {
                                    Console.WriteLine(string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", "Идентификатор", "Тип игры", "Итерация", "Количество строк", "Количество столбцов"));
                                    foreach (var item in db.GameSet)
                                    {
                                        Console.WriteLine(string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", item.Id, item.Type, item.Iteration, item.SizeX, item.SizeY));
                                    }
                                    Console.WriteLine("Введите Id:");
                                    while (true)
                                    {
                                        while (!int.TryParse(Console.ReadLine(), out outvar))
                                        {
                                            Console.WriteLine("Введите число");
                                        }

                                        Game game = db.GameSet.Where(x => x.Id == outvar).FirstOrDefault();
                                        if (game == null)
                                            Console.WriteLine("Введите правильный Id");
                                        else
                                        {
                                            Id = outvar;
                                            Type = game.Type;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            recordBase.ErrorBase(ex, this);
                        }
                        outbool2 = false;
                        outbool = false;
                        break;
                }
                if(outbool2)
                Console.WriteLine("Введите на английском e,b,s или клавишу Esc");
                outbool2 = true;
            }
        }
    }
}
