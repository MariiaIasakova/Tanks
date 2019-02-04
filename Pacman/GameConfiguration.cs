
namespace Pacman
{
    public class GameConfiguration
    {
        public GameConfiguration(int ghosts, int apples, Speed speed)
        {
            Ghosts = ghosts;
            Apples = apples;
            Speed = speed;
        }

        public int Ghosts { get; set; }
        public int Apples { get; set; }
        public Speed Speed { get; set; }
        public int Width { get; set; }
        public int Height{ get; set; }

    }
}
