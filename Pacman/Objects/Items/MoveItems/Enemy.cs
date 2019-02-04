using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items.MoveItems
{
    public class Enemy : MovingItem
    {
        public Enemy(int x, int y, int speed) : base(x, y, speed)
        {
            Picture = Properties.Resources.tank_enemy;
            Type = ItemType.Enemy;
        }
    }
}
