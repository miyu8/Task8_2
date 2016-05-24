using System.Runtime.Serialization;

namespace Life.LivingProperty
{
    [DataContract]
    public class Grass1Property
    {
        [DataMember(Name = "Death")]
        public int Death { get; set; }
        [DataMember(Name = "Reproduction")]
        public int Reproduction { get; set; }
        public Grass1Property(int death, int reproduction)
        {
            Death = death;
            Reproduction = reproduction;
        }
    }

}
