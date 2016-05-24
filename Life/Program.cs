using Life;
using System;
namespace User
{
    public class Program
    {
        public static void Main()

        {
            Console.WriteLine("Настройка игры может занять некоторое время, пожалуйста, подождите");
            Menu menu = new Menu();
            menu.Run();
        }
    }
}