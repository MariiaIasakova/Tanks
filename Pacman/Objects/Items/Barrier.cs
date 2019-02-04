using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items
{
    public class Barrier : Item
    {

        public Barrier(int x, int y) : base(x, y)
        {
            Picture = Properties.Resources.wall;
            Type = ItemType.Wall;
        }
    }
}
