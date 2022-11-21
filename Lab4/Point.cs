namespace Lab4
{
    public class Point
    {
        private int _x;
        private int _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get => _y;
            set => _y = value;
        }

        public override string ToString()
        {
            return "(" + _x + ", " + _y + ")\n";
        }

        public override bool Equals(Object obj)
        {
            Point p = (Point)obj;

            if (_x == p.X && _y == p.Y)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}