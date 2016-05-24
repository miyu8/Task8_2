using System.Collections.Generic;
using Life.Interface;

namespace Life.Models
{
    public enum LivingName
    {
        Empty,
        Grass,
        Grass1,
        Grass2,
        Herbivorous1,
        Corpse
    }

    public class Cell
    {
        public ILiving Living { get; private set; }
        public LivingName livingName { get; private set; }
        public List<Cell> cellsNeighbors = new List<Cell>();
        public int CoordX { get; set; }
        public int CoordY { get; set; }

        public Cell(ILiving living, LivingName livingname, int coordX, int coordY)
        {
            Living = living;
            livingName = livingname;
            CoordX = coordX;
            CoordY = coordY;
        }
    }
}
