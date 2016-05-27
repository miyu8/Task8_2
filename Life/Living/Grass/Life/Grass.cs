using Life.Models;

namespace Life.Living.Grass.Life
{
    public class Grass : LivingBaseGrassLife

    {
        public Grass(int coordX, int coordY, int sizeX, int sizeY) : base(coordX, coordY, sizeX, sizeY)
        {
            livingName = LivingName.Grass;
        }

        public override Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext)
        {
            p = NumberNeighbors(gameField);
            return NextGenerationBase(gameField, gameFieldNext, p == 3, p == 2);
        }
    }
}
