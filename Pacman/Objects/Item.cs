using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects
{
    public abstract class Item
    {
        public Item(int x, int y)
            :this(new Point(x, y))
        {
        }

        public Item(Point position)
        {
            Position = position;
            IsDirty = true;
            OldPosition = new Point(Position);
        }
        public ItemType Type { get; set; }
        public virtual Bitmap Picture { get; set; }
        public Point Position { get; set; }
        public Point OldPosition { get; set; }
        public virtual bool IsDirty { get; set; }
    }
}
