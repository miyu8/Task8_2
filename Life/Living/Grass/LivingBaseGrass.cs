using Life.Models;
using Life.Interface;

namespace Life.Living.Grass
{
    public abstract class LivingBaseGrass : LivingBase
    {
        public int p;
        public Point[] point;

        public abstract override Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext);

        public LivingBaseGrass(int coordX, int coordY, int sizeX, int sizeY) : base(coordX, coordY, sizeX, sizeY) { }

        public Cell[,] ElementAdd(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            point = new Point[9];
            p = 0;
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
                gameFieldNext[point[p].X, point[p].Y] = new Cell((ILiving)MemberwiseClone(), livingName, point[p].X, point[p].Y);
                gameFieldNext[point[p].X, point[p].Y].Living.CoordX = point[p].X;
                gameFieldNext[point[p].X, point[p].Y].Living.CoordY = point[p].Y;
            }
            return gameFieldNext;
        }
    }
}
