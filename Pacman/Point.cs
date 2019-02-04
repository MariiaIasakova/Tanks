using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    public class Point : IEquatable<Point>
    {
        public const int CellSize = 19;
        private int x;
        private int y;
        private int absX;
        private int absY;

        public int X
        {
            get => x;
            set
            {
                x = value;
                absX = value * CellSize;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y = value;
                absY = value * CellSize;
            }
        }
        public int AbsX
        {
            get => absX;
            set
            {
                absX = value;
                x = value / CellSize;
            }
        }

        public int AbsY
        {
            get => absY;
            set
            {
                absY = value;
                y = value / CellSize;
            }
        }
        public Point()
        {

        }
        public Point(Point clone)
        {
            this.AbsX = clone.AbsX;
            this.AbsY = clone.AbsY;
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            absX = x * CellSize;
            absY = y * CellSize;
        }

        public Point(int x, int y, int absX, int absY) : this(x, y)
        {
            AbsX = absX;
            AbsY = absY;
        }

        public static Point FromAbsolute(int absX, int absY)
        {
            var p = new Point();
            p.AbsX = absX;
            p.AbsY = absY;
            return p;
        }

        public static Point FromRelative(int x, int y)
        {
            return new Point(x, y);
        }

        public bool Equals(Point other)
        {
            bool result = AbsX + CellSize <= other.AbsX
                          || AbsX > other.AbsX + CellSize
                          || AbsY + CellSize <= other.AbsY
                          || AbsY > other.AbsY + CellSize;
            return !result;
        }

        public override bool Equals(object other)
        {
            if (other != null && other is Point)
            {
                return Equals((Point)other);
            }
            return false;
        }
#warning TODO переделать GetHashCode опираясь на Equals
        public override int GetHashCode() => 0;

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !point1.Equals(point2);
        }
    }
}
