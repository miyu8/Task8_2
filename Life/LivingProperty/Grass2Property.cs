using System.Runtime.Serialization;

namespace Life.LivingProperty
{
    [DataContract]
    public class Grass2Property
    {
        [DataMember(Name = "Course")]
        public int Course { get; set; }
        [DataMember(Name = "Frequency")]
        public int Frequency { get; set; }
        public Grass2Property(int course, int frequency)
        {
            Course = course;
            Frequency = frequency;
        }
    }
}
