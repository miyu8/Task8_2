using Life.Interface;

namespace Life.LivingProperty
{
    public class Grass1Property
    {
        public int Death { get; set; }
        public int Reproduction { get; set; }
        public Grass1Property(int death, int reproduction)
        {
            Death = death;
            Reproduction = reproduction;
        }
    }

}
