using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items.MoveItems
{
    public class Player : MovingItem
    {
        private Game game;

        public Player(int x, int y, Game game) : base (x, y, (int)game.Configuration.Speed)
        {
            Picture = Properties.Resources.tank_hero;
            Type = ItemType.Player;
            this.game = game;
        }

        public int Score { get; set; }
        
        public void Attack()
        {
            game.CreateBullet(Position, CurrentDirection , this.Type);
        }
    }
}
