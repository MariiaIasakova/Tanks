using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items
{
    class EnemySpawn : Item
    {
        public EnemySpawn(int x, int y) : base(x, y)
        {
            Picture = Properties.Resources.empty;
            Type = ItemType.EnemySpawn;
        }
    }
}
