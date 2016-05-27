using System;
using System.Linq;
using Life.Initialization;
using Life.BaseData;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Life
{
    class Menu
    {
        bool exit;
        int choise = 0;
        int choise2 = 0;
        int choise3 = 0;
        public bool[] boolMenu = new bool[2];
        public string[] menu = new string[2];
        public string[] menu2 = new string[4];
        public string[] menu3;
        ConsoleKeyInfo answer;
        public Move move;
        DataModelContainer db;
        string join;
        RecordBase recordBase = new RecordBase();
        Options options;
        public void Run()
        {
            Console.CursorVisible = false;
            menu[0] = "Новая игра";
            menu[1] = "Загрузить существующую игру";
            menu2[0] = "Стандартная";
            menu2[1] = "Альтернативная";
            menu2[2] = "Смешанная";
            menu2[3] = "С травоядными животными";
            boolMenu[0] = true;
            MainMenu();
        }

        private void IsData()
        {
            try
            {
                using (db = new DataModelContainer())
                {
                    if (db.GameSet.Count() != 0)
                        boolMenu[1] = true;
                    else
                        boolMenu[1] = false;
                }
            }
            catch (Exception ex)
            {
                recordBase.ErrorBase(ex);
            }
        }

        private void ColorMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Главное меню\nИспользуйте стрелки для выбора опции. Esc для возврата и выхода");
            Console.ForegroundColor = ConsoleColor.White;
            if (choise == 0)
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(menu[0]);
            Console.ResetColor();
            if (boolMenu[1])
                Console.ForegroundColor = ConsoleColor.White;
            else
                Console.ForegroundColor = ConsoleColor.DarkGray;
            if (choise == 1)
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(menu[1]);
            Console.ResetColor();
        }

        private void NewGame()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите тип игры");
                for (int i = 0; i < menu2.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (i == choise2)
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(menu2[i]);
                    Console.ResetColor();
                }
                answer = Console.ReadKey(true);
                if (answer.Key == ConsoleKey.Escape)
                {
                    exit = true;
                    break;
                }
                else if (answer.Key == ConsoleKey.Enter)
                {
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Options));
                    string json = File.ReadAllText(@"..\..\Settings.json");
                    MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json));
                    options = (Options)js.ReadObject(stream);
                    move = new Move(choise2 + 1, options);
                    move.RunNew();
                    move.Begin();
                }
                else if (answer.Key == ConsoleKey.UpArrow)
                    choise2--;
                else if (answer.Key == ConsoleKey.DownArrow)
                    choise2++;
                if (choise2 < 0)
                    choise2 = menu2.Length - 1;
                else if (choise2 == menu2.Length)
                    choise2 = 0;
            }
        }

        private void OldGame()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите сохранённую игру. Для удаления игры нажмите Delete");
                Console.WriteLine(string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", "Идентификатор", "Тип игры", "Итерация", "Количество строк", "Количество столбцов"));
                int i = 0;
                try
                {
                    using (db = new DataModelContainer())
                    {
                        menu3 = new string[db.GameSet.Count()];
                        foreach (var item in db.GameSet)
                        {
                            menu3[i] = string.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20}", item.Id, item.Type, item.Iteration, item.SizeX, item.SizeY);
                            i++;
                        }
                        join = string.Join("\n", menu3);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(join);
                        Console.SetCursorPosition(0, choise3 + 2);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(menu3[choise3]);
                        Console.ResetColor();
                        answer = Console.ReadKey(true);
                        if (answer.Key == ConsoleKey.Escape)
                        {
                            exit = true;
                            break;
                        }
                        else if (answer.Key == ConsoleKey.Enter)
                        {
                            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Options));
                            string json = File.ReadAllText(@"..\..\Settings.json");
                            MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json));
                            options = (Options)js.ReadObject(stream);
                            options.gameProperty.SizeX = db.GameSet.ToList().ElementAt(choise3).SizeX;
                            options.gameProperty.SizeY = db.GameSet.ToList().ElementAt(choise3).SizeY;
                            move = new Move(db.GameSet.ToList().ElementAt(choise3).Type, options);
                            move.RunSave(db.GameSet.ToList().ElementAt(choise3).Id, db.GameSet.ToList().ElementAt(choise3).Iteration);
                            move.Begin();
                        }
                        else if (answer.Key == ConsoleKey.Delete)
                        {
                            recordBase.RemoveList(db.GameSet.ToList().ElementAt(choise3).Id);
                        }
                        else if (answer.Key == ConsoleKey.UpArrow)
                        {
                            choise3--;
                        }
                        else if (answer.Key == ConsoleKey.DownArrow)
                        {
                            choise3++;
                        }
                        if (choise3 < 0)
                            choise3 = menu3.Length - 1;
                        else if (choise3 == menu3.Length)
                            choise3 = 0;
                    }
                }
                catch (Exception ex)
                {
                    recordBase.ErrorBase(ex);
                }
            }
        }

        private void MainMenu()
        {
            while (true)
            {
                IsData();
                ColorMenu();
                answer = Console.ReadKey(true);
                if (answer.Key == ConsoleKey.Escape)
                    break;
                else if (answer.Key == ConsoleKey.Enter)
                {
                    switch (choise)
                    {
                        case 0:
                            NewGame();
                            break;
                        case 1:
                            OldGame();
                            break;
                    }
                    if (exit)
                    {
                        continue;
                    }
                    exit = false;
                }
                else if (answer.Key == ConsoleKey.UpArrow)
                    choise--;
                else if (answer.Key == ConsoleKey.DownArrow)
                    choise++;
                if (choise < 0)
                    choise = menu.Length - 1;
                else if (choise == menu.Length)
                    choise = 0;
            }
        }
    }
}
