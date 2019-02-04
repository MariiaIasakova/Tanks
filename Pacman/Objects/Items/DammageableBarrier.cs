using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items
{
    public class DammageableBarrier : Item
    {
        public bool Dammaged { get; set; }
        public override Bitmap Picture
        {
            get => Dammaged ? Properties.Resources.empty : Properties.Resources.wall_dammaged;
            set => base.Picture = value;
        }

        public DammageableBarrier(int x, int y) : base(x, y)
        {
            Picture = Properties.Resources.wall_dammaged;
            Type = ItemType.DammageableWall;
        }
    }
}
