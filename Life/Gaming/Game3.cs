using Life.LivingProperty;
using Life.Models;
using Life.Living.Grass.Life;

namespace Life.Gaming
{
    public class Game3 : GameBase
    {
        Grass1Property grass1Property;

        public Game3(GameProperty gameproperty, Grass1Property grass1property)
        {
            Type = 3;
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
                    switch (generaterandom.RandomString(3))
                    {
                        case 0 - 1:
                            break;
                        case 2:
                            if (generaterandom.Coin())
                            {
                                gameField[i, j] = new Cell(new Grass(i, j, gameProperty.SizeX, gameProperty.SizeY), LivingName.Grass, i, j);
                                ValueCells[(int)gameField[i, j].livingName]++;
                            }
                            else if (generaterandom.Coin())
                            {
                                gameField[i, j] = new Cell(new Grass1(i, j, gameProperty.SizeX, gameProperty.SizeY, grass1Property), LivingName.Grass1, i, j);
                                ValueCells[(int)gameField[i, j].livingName]++;
                            }
                            break;
                    }
                }
            }
            ValueCells[0] = 3;
            ListgameField.Add(gameField);
        }
    }
}
