using System.Runtime.Serialization;

namespace Life.LivingProperty
{
    [DataContract]
    public class Herbivorous1Property
    {
        [DataMember(Name = "EnergyBaseBegin")]
        public int EnergyBaseBegin { get; set; }
        [DataMember(Name = "EnergyBase")]
        public int EnergyBase { get; set; }
        [DataMember(Name = "EnergyConsumption")]
        public int EnergyConsumption { get; set; }
        [DataMember(Name = "StartRot")]
        public int StartRot { get; set; }
        [DataMember(Name = "TimeRot")]
        public int TimeRot { get; set; }
        [DataMember(Name = "Grass2Radius")]
        public int Grass2Radius { get; set; }
        [DataMember(Name = "EnergyGrass")]
        public int EnergyGrass { get; set; }
        [DataMember(Name = "Speed")]
        public int Speed { get; set; }

        public Herbivorous1Property(Herbivorous1Property other)
        {
            EnergyBaseBegin = other.EnergyBaseBegin;
            EnergyBase = other.EnergyBase;
            EnergyConsumption = other.EnergyConsumption;
            StartRot = other.StartRot;
            TimeRot = other.TimeRot;
            Grass2Radius = other.Grass2Radius;
            EnergyGrass = other.EnergyGrass;
            Speed = other.Speed;
        }
        public Herbivorous1Property(int energyBaseBegin, int energyBase, int energyConsumption, int startRot, int timeRot, int grass2Radius, int energyGrass, int speed)
        {
            EnergyBaseBegin = energyBaseBegin;
            EnergyBase = energyBase;
            EnergyConsumption = energyConsumption;
            StartRot = startRot;
            TimeRot = timeRot;
            Grass2Radius = grass2Radius;
            EnergyGrass = energyGrass;
            Speed = speed;
        }
    }
}
