using Life.Models;

namespace Life.Interface
{
    public interface ILiving
    {
        Cell[,] NextGeneration(Cell[,] gameField, Cell[,] gameFieldNext);
    }
}
