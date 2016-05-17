using Life.Initialization;
using System.Threading;

namespace User
{
    public class Program
    {
        public static Thread thread;
        public static void Main()
        {
            thread = Thread.CurrentThread;
            Move move = new Move();
        }
    }
}
