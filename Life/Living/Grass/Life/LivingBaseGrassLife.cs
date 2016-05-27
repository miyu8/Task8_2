using Life.Models;

namespace Life.Living.Grass.Life
{
    public abstract class LivingBaseGrassLife : LivingBaseGrass
    {
        public abstract override Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext);

        public LivingBaseGrassLife(int coordX, int coordY, int sizeX, int sizeY) : base(coordX, coordY, sizeX, sizeY) { }

        public int NumberNeighbors(Cell[,] gameField)
        {
            int p = 0;
            for (int x = CoordX - 1; x <= CoordX + 1; x++)
                for (int y = CoordY - 1; y <= CoordY + 1; y++)
                {
                    if (x < 0 || y < 0 || x >= SizeX || y >= SizeY
                       || (x == CoordX && y == CoordY) || gameField[x, y] == null)
                        continue;

                    if ((int)gameField[x, y].livingName == 1 || (int)gameField[x, y].livingName == 2) p++;

                }
            return p;
        }

        public Cell[,] NextGenerationBase(Cell[,] gameField, Cell[,] gameFieldNext, bool boolDivide, bool boolIt)
        {
            if (boolDivide)
            {
                gameFieldNext[CoordX, CoordY] = gameField[CoordX, CoordY];
                return ElementAdd(gameField, gameFieldNext);
            }
            if (boolIt)
            {
                gameFieldNext[CoordX, CoordY] = gameField[CoordX, CoordY];
                return gameFieldNext;
            }
            return gameFieldNext;
        }
    }
}
