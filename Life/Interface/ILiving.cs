using Life.Models;

namespace Life.Interface
{
    public interface ILiving
    {
        int CoordX { get; set; }
        int CoordY { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }

        Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext);
    }
}
