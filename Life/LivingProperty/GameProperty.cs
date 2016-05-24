using System.Runtime.Serialization;

namespace Life.LivingProperty
{
    [DataContract]
    public class GameProperty
    {
        [DataMember(Name = "NamePlayer")]
        public string NamePlayer { get; set; }
        [DataMember(Name = "NamePlay")]
        public string NamePlay { get; set; }
        [DataMember(Name = "SizeX")]
        public int SizeX { get; set; }
        [DataMember(Name = "SizeY")]
        public int SizeY { get; set; }
        public GameProperty(string namePlayer, string namePlay, int sizeX, int sizeY)
        {
            NamePlayer = namePlayer;
            NamePlay = namePlay;
            SizeX = sizeX;
            SizeY = sizeY;
        }
    }
}
