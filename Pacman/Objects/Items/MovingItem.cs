using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Objects.Items.MoveItems
{
    public abstract class MovingItem : Item
    {

        public MovingItem(int x, int y, int speed) : base(x,y)
        {
            Speed = speed;
        }

        public int Speed { get; set; }
        public Direction NextDirection { get; set; }
        public Direction CurrentDirection { get; set; }

        public void Move()
        {
            OldPosition = new Point(Position);
            switch (CurrentDirection)
            {
                case Direction.Up:
                    Position.AbsY -= Speed;
                    break;
                case Direction.Down:
                    Position.AbsY += Speed;
                    break;
                case Direction.Left:
                    Position.AbsX -= Speed;
                    break;
                case Direction.Right:
                    Position.AbsX += Speed;
                    break;
            }
            IsDirty = true;
        }
    }
}
