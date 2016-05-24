using Life.LivingProperty;
using System.Runtime.Serialization;

namespace Life.Initialization
{
    [DataContract]
    public class Options
    {
        [DataMember(Name = "gameProperty")]
        public GameProperty gameProperty;
        [DataMember(Name = "grass1Property")]
        public Grass1Property grass1Property;
        [DataMember(Name = "grass2Property")]
        public Grass2Property grass2Property;
        [DataMember(Name = "herbivorous1Property")]
        public Herbivorous1Property herbivorous1Property;
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
