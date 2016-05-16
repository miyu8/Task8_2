﻿using Life.Living;
using Life.LivingProperty;
using Life.Models;

namespace Life.Gaming
{
    public class Game1 : GameBase
    {
        public Game1(GameProperty gameproperty)
        {
            gameProperty = gameproperty;
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
                            gameField[i, j] = new Cell(new Grass(i, j, gameProperty.SizeX, gameProperty.SizeY), Cell.LivingName.Grass, i, j);
                            ValueCells[(int)gameField[i, j].livingName]++;
                            break;
                    }
                }
            }
            ValueCells[0] = 1;
            ListgameField.Add(gameField);
        }
    }
}
