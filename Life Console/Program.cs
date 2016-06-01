using System;

namespace Life_Console
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Настройка игры может занять некоторое время, пожалуйста, подождите");
            Menu menu = new Menu();
            menu.Run();
        }
    }
}
