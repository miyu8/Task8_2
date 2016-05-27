using System.Collections.Generic;
using Life.LivingProperty;
using Life.Models;
namespace Life.Gaming
{
    public abstract class GameBase
    {
        public int iteration;
        public int[] ValueCells = new int[6];
        public int Type { get; protected set; }
        public Cell[,] gameField { get; set; }
        public Cell[,] gameFieldNext;
        public List<Cell[,]> ListgameField = new List<Cell[,]>();
        public GameProperty gameProperty { get; set; }
        public GenerateRandom generaterandom = new GenerateRandom();

        public abstract void InitRnd();

        public bool Step()
        {
            gameFieldNext = new Cell[gameProperty.SizeX, gameProperty.SizeY];
            for (int i = 0; i < gameProperty.SizeX; i++)
                for (int j = 0; j < gameProperty.SizeY; j++)
                    if (gameField[i, j] != null)
                        gameFieldNext = gameField[i, j].Living.NextGeneration(gameField, gameFieldNext);

            if (!(TestOnZero() && TestOnRepetition()))
                return false;
            iteration++;
            int typeGame = ValueCells[0];
            ValueCells = new int[6];
            ValueCells[0] = typeGame;
            for (int i = 0; i < gameProperty.SizeX; i++)
                for (int j = 0; j < gameProperty.SizeY; j++)
                    if (gameFieldNext[i, j] != null)
                        ValueCells[(int)gameFieldNext[i, j].livingName]++;

            gameField = gameFieldNext;
            gameFieldNext = null;
            ListgameField.Add(gameField);
            return true;
        }
        public bool TestOnZero()
        {
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    if (gameFieldNext[i, j] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Comparison(Cell[,] item)
        {
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    if (gameFieldNext[i, j] == null && item[i, j] != null || gameFieldNext[i, j] != null && item[i, j] == null ||
                        item[i, j] != null && gameFieldNext[i, j] != null && gameFieldNext[i, j].livingName != item[i, j].livingName)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool TestOnRepetition()
        {
            foreach (var item in ListgameField)
                if (Comparison(item))
                    return false;
            return true;
        }
    }
}

