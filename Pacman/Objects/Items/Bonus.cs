using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items
{
    public class Bonus : Item
    {
        public override bool IsDirty
        {
            get => base.IsDirty;
            set => base.IsDirty = true;
        }
        public Bonus(int x, int y) : base(x,y)
        {
            Picture = Properties.Resources.bonus_live;
            Type = ItemType.Bonus;
        }
    }
}
