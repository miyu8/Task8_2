using Life.Models;
using Life.Interface;
using Life.LivingProperty;

namespace Life.Living
{
    public class Grass2 : ILiving
    {
        public int CoordX { get; private set; }
        public int CoordY { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public struct Point
        {
            public int X;
            public int Y;
        }
        public Grass2Property grass2Property;
        GenerateRandom generaterandom = new GenerateRandom();
        public Grass2(int coordX, int coordY, int sizeX, int sizeY, Grass2Property grass2property)
        {
            CoordX = coordX;
            CoordY = coordY;
            SizeX = sizeX;
            SizeY = sizeY;
            grass2Property = grass2property;
        }
        public Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            Grass2Property grass2Property2 = new Grass2Property(((Grass2)gameField[CoordX, CoordY].Living).grass2Property.Course, ((Grass2)gameField[CoordX, CoordY].Living).grass2Property.Frequency);
            grass2Property2.Course++;
            gameFieldNext[CoordX, CoordY] = new Cell(new Grass2(CoordX, CoordY, SizeX, SizeY, grass2Property2), Cell.LivingName.Grass2, CoordX, CoordY);
            if (grass2Property2.Course % grass2Property2.Frequency + 1 == grass2Property2.Frequency)
                gameFieldNext = ElementAdd(gameField, gameFieldNext);
            return gameFieldNext;
        }

        public Cell[,] ElementAdd(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            Grass2Property grass2Property2 = new Grass2Property(0, ((Grass2)gameField[CoordX, CoordY].Living).grass2Property.Frequency);
            Point[] point = new Point[9];
            int p = 0;
            for (int x = CoordX - 1; x <= CoordX + 1; x++)
                for (int y = CoordY - 1; y <= CoordY + 1; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY
                       || (x == CoordX && y == CoordY))
                        continue;

                    if (gameField[x, y] == null)
                    {
                        point[p].X = x;
                        point[p].Y = y;
                        p++;
                    }
                }
            if (p != 0)
            {
                if (p != 1)
                    p = generaterandom.RandomString(p);
                else
                    p = 0;
                gameFieldNext[point[p].X, point[p].Y] = new Cell(new Grass2(point[p].X, point[p].Y, SizeX, SizeY, grass2Property2), Cell.LivingName.Grass2, point[p].X, point[p].Y);
            }
            return gameFieldNext;
        }
    }
}