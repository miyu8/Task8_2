using Life.LivingProperty;

namespace Life.Initialization
{
    public class Options
    {
        public GameProperty gameProperty = new GameProperty("User", "Life", 5, 5);
        public Grass1Property grass1Property = new Grass1Property(3, 2);
        public Grass2Property grass2Property = new Grass2Property(0, 2);
        public Herbivorous1Property herbivorous1Property = new Herbivorous1Property(10, 10, 1, 0, 1, 1, 3, 1);
        public GameProperty ChangeGameProperty(string nameplayer, string nameplay, int sizeX, int sizeY)
        {
            gameProperty.NamePlayer = nameplayer;
            gameProperty.NamePlay = nameplay;
            gameProperty.SizeX = sizeX;
            gameProperty.SizeY = sizeY;
            return gameProperty;
        }

        public Grass1Property ChangeGrass1Property(int death, int reproduction)
        {
            grass1Property.Death = death;
            grass1Property.Reproduction = reproduction;
            return grass1Property;
        }

        public Grass2Property ChangeGrass2Property(int course, int frequency)
        {
            grass2Property.Course = course;
            grass2Property.Frequency = frequency;
            return grass2Property;
        }

        public Herbivorous1Property ChangeHerbivorous1Property(int energyBase, int energyConsumption, int timeRot, int grass2Radius, int energyGrass, int speed)
        {
            herbivorous1Property.EnergyBase = energyBase;
            herbivorous1Property.EnergyConsumption = energyConsumption;
            herbivorous1Property.TimeRot = timeRot;
            herbivorous1Property.Grass2Radius = grass2Radius;
            herbivorous1Property.EnergyGrass = energyGrass;
            herbivorous1Property.Speed = speed;
            return herbivorous1Property;
        }
    }
}
