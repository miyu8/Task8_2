using Life.Models;
using Life.Interface;

namespace Life.Living
{
    public abstract class LivingBase : ILiving
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public LivingName livingName { get; set; }

        public struct Point
        {
            public int X;
            public int Y;
        }
        public GenerateRandom generaterandom = new GenerateRandom();

        public abstract Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext);

        public LivingBase(int coordX, int coordY, int sizeX, int sizeY)
        {
            CoordX = coordX;
            CoordY = coordY;
            SizeX = sizeX;
            SizeY = sizeY;
        }
    }
}
