namespace Life.LivingProperty
{
    public class Herbivorous1Property
    {
        public int EnergyBaseBegin { get; set; }
        public int EnergyBase { get; set; }
        public int EnergyConsumption { get; set; }
        public int StartRot { get; set; }
        public int TimeRot { get; set; }
        public int Grass2Radius { get; set; }
        public int EnergyGrass { get; set; }
        public int Speed { get; set; }

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
