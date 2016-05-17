namespace Life.LivingProperty
{
    public class GameProperty
    {
        public string NamePlayer { get; set; }
        public string NamePlay { get; set; }
        public int SizeX { get; set; }
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
