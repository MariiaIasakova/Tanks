using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items.MoveItems
{
    public class Bullet : MovingItem
    {
        public Bullet(int x, int y, int speed) : base(x, y, speed)
        {
            Picture = Properties.Resources.bullet;
            Type = ItemType.Bullet;
        }
    }
}
