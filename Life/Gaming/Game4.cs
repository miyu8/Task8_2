using Life.LivingProperty;
using Life.Living;
using Life.Models;
using Life.Living.Grass;

namespace Life.Gaming
{
    public class Game4 : GameBase
    {
        Grass2Property grass2Property;
        Herbivorous1Property herbivorous1Property;
        public Game4(GameProperty gameproperty, Grass2Property grass2property, Herbivorous1Property herbivorous1property)
        {
            Type = 4;
            gameProperty = gameproperty;
            grass2Property = grass2property;
            herbivorous1Property = herbivorous1property;
        }
        public override void InitRnd()
        {
            gameField = new Cell[gameProperty.SizeX, gameProperty.SizeY];
            for (int i = 0; i < gameProperty.SizeX; i++)
            {
                for (int j = 0; j < gameProperty.SizeY; j++)
                {
                    switch (generaterandom.RandomString(4))//3
                    {
                        case 0 - 2:
                            break;
                        case 3:
                            gameField[i, j] = new Cell(new Grass2(i, j, gameProperty.SizeX, gameProperty.SizeY, grass2Property), LivingName.Grass2, i, j);
                            ValueCells[(int)gameField[i, j].livingName]++;
                            break;
                    }
                }
            }

            for (int rndX, rndY, rnd = generaterandom.RandomString(3), i = 0; i <= rnd; i++)
            {
                rndX = generaterandom.RandomString(gameProperty.SizeX);
                rndY = generaterandom.RandomString(gameProperty.SizeY);
                gameField[rndX, rndY] = new Cell(new Herbivorous1(rndX, rndY, gameProperty.SizeX, gameProperty.SizeY,
                    herbivorous1Property, grass2Property), LivingName.Herbivorous1, rndX, rndY);
                ValueCells[(int)gameField[rndX, rndY].livingName]++;
            }
            ValueCells[0] = 4;
            ListgameField.Add(gameField);
        }
    }
}
