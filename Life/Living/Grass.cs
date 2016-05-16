using Life.Models;
using Life.Interface;

namespace Life.Living
{
    public class Grass : ILiving
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
        GenerateRandom generaterandom = new GenerateRandom();
        public Grass(int coordX, int coordY, int sizeX, int sizeY)
        {
            CoordX = coordX;
            CoordY = coordY;
            SizeX = sizeX;
            SizeY = sizeY;
        }

        public Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            int p = NumberNeighbors(gameField);

            if (p == 3)
            {
                gameFieldNext[CoordX, CoordY] = new Cell(new Grass(CoordX, CoordY, SizeX, SizeY), Cell.LivingName.Grass, CoordX, CoordY);
                gameFieldNext = ElementAdd(gameField, gameFieldNext);
                return gameFieldNext;
            }
            if (p == 2)
            {
                gameFieldNext[CoordX, CoordY] = new Cell(new Grass(CoordX, CoordY, SizeX, SizeY), Cell.LivingName.Grass, CoordX, CoordY);
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
                gameFieldNext[point[p].X, point[p].Y] = new Cell(new Grass(point[p].X, point[p].Y, SizeX, SizeY), Cell.LivingName.Grass, point[p].X, point[p].Y);
            }
            return gameFieldNext;
        }
    }
}
