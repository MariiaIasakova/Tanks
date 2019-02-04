using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items
{
    public class Empty : Item
    {
        public Empty(int x,int y) : this(new Point(x, y))
        {
        }

        public Empty(Point position) : base(position)
        {
            Picture = Properties.Resources.empty;
            Type = ItemType.Empty;
        }
    }
}
