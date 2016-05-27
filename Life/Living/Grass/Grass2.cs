using Life.Models;
using Life.LivingProperty;

namespace Life.Living.Grass
{
    public class Grass2 : LivingBaseGrass
    {
        public Grass2Property grass2Property;

        public Grass2(int coordX, int coordY, int sizeX, int sizeY, Grass2Property grass2property) : base(coordX, coordY, sizeX, sizeY)
        {
            livingName = LivingName.Grass2;
            grass2Property = grass2property;
        }

        public override Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            Grass2Property grass2Property2 = new Grass2Property(((Grass2)gameField[CoordX, CoordY].Living).grass2Property.Course, ((Grass2)gameField[CoordX, CoordY].Living).grass2Property.Frequency);
            grass2Property2.Course++;
            gameFieldNext[CoordX, CoordY] = new Cell(new Grass2(CoordX, CoordY, SizeX, SizeY, grass2Property2), livingName, CoordX, CoordY);
            if (grass2Property2.Course % grass2Property2.Frequency + 1 == grass2Property2.Frequency)
            {
                Grass2Property grass2Property3 = new Grass2Property(0, ((Grass2)gameField[CoordX, CoordY].Living).grass2Property.Frequency);
                gameFieldNext = ElementAdd(gameField, gameFieldNext);
            }
            return gameFieldNext;
        }
    }
}