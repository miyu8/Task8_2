using Life.Living;
using Life.LivingProperty;
using Life.Models;

namespace Life.Gaming
{
    class Game2 : GameBase
    {
        Grass1Property grass1Property;
        public Game2(GameProperty gameproperty, Grass1Property grass1property)
        {
            gameProperty = gameproperty;
            grass1Property = grass1property;
        }
        public override void InitRnd()
        {
            gameField = new Cell[gameProperty.SizeX, gameProperty.SizeY];
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    switch (generaterandom.RandomString(4))
                    {
                        case 0 - 2:
                            break;
                        case 3:
                            gameField[i, j] = new Cell(new Grass1(i, j, gameProperty.SizeX, gameProperty.SizeY, grass1Property), Cell.LivingName.Grass1, i, j);
                            ValueCells[(int)gameField[i, j].livingName]++;
                            break;
                    }
                }
            }
            ValueCells[0] = 2;
            ListgameField.Add(gameField);
        }
    }
}
