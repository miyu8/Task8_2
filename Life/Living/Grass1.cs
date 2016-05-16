using Life.Models;
using Life.Interface;
using Life.LivingProperty;

namespace Life.Living
{
    public class Grass1 : ILiving
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
        public Grass1Property grass1Property;
        GenerateRandom generaterandom = new GenerateRandom();
        public Grass1(int coordX, int coordY, int sizeX, int sizeY, Grass1Property grass1property)
        {
            CoordX = coordX;
            CoordY = coordY;
            SizeX = sizeX;
            SizeY = sizeY;
            grass1Property = grass1property;
        }
        public Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            int p = NumberNeighbors(gameField);

            if (p >= grass1Property.Reproduction && p <= grass1Property.Death)
            {
                gameFieldNext[CoordX, CoordY] = new Cell(new Grass1(CoordX, CoordY, SizeX, SizeY, grass1Property), Cell.LivingName.Grass1, CoordX, CoordY);
                gameFieldNext = ElementAdd(gameField, gameFieldNext);
                return gameFieldNext;
            }
            if (p < grass1Property.Reproduction)
            {
                gameFieldNext[CoordX, CoordY] = new Cell(new Grass1(CoordX, CoordY, SizeX, SizeY, grass1Property), Cell.LivingName.Grass1, CoordX, CoordY);
                return gameFieldNext;
            }
            return gameFieldNext;
        }

        public int NumberNeighbors(Cell[,] gameField)
        {
            int p = 0;
            for (int x = CoordX - 1; x <= CoordX + 1; x++)
                for (int y = CoordY - 1; y <= CoordY + 1; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY
                       || (x == CoordX && y == CoordY) || gameField[x, y] == null)
                        continue;

                    if ((int)gameField[x, y].livingName == 1 || (int)gameField[x, y].livingName == 2 || (int)gameField[x, y].livingName == 3) p++;

                }
            return p;
        }

        public Cell[,] ElementAdd(Cell[,] gameField, Cell[,] gameFieldNext)
        {
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
                p = generaterandom.RandomString(p);
                gameFieldNext[point[p].X, point[p].Y] = new Cell(new Grass1(point[p].X, point[p].Y, SizeX, SizeY, grass1Property), Cell.LivingName.Grass1, point[p].X, point[p].Y);
            }
            return gameFieldNext;
        }
    }
}
