using System;

namespace Life
{
    public class GenerateRandom
    {
        private Random random = new Random((int)DateTime.Now.Ticks);

        public int RandomString(int quantity)
        {
            return Convert.ToInt32(Math.Floor(quantity * random.NextDouble()));
        }

        public bool Mutation()
        {
            switch (RandomString(20))
            {
                case 0:
                case 1:
                case 2:
                    return true;
            }
            return false;
        }
        public bool Coin()
        {
            if (RandomString(2) == 1)
                return true;
            return false;
        }
    }
}
