using Life.Models;
using Life.LivingProperty;

namespace Life.Living.Grass.Life
{
    public class Grass1 : LivingBaseGrassLife
    {
        public Grass1Property grass1Property;

        public Grass1(int coordX, int coordY, int sizeX, int sizeY, Grass1Property grass1property) : base(coordX, coordY, sizeX, sizeY)
        {
            livingName = LivingName.Grass1;
            grass1Property = grass1property;
        }

        public override Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            p = NumberNeighbors(gameField);
            return NextGenerationBase(gameField, gameFieldNext, p >= grass1Property.Reproduction && p <= grass1Property.Death, p < grass1Property.Reproduction);
        }
    }
}
