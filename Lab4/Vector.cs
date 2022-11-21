using System;

namespace Lab4
{
    class Vector
    {
        private int _x;
        private int _y;
        private double _module;

        public Vector(Point a, Point b)
        {
            _x = b.X - a.X;
            _y = b.Y - a.Y;

            _module = Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
        }

        public int X
        {
            get => _x;
            set
            {
                _x = value;
                _module = Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
            }

        }

        public int Y
        {
            get => _y;
            set
            {
                _y = value;
                _module = Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
            }
        }

        public double Module
        {
            get => _module;
        }

        public int DotProduct(Vector v)
        {
            return (_x * v._x) + (_y * v._y);
        }

        public double AngleTo(Vector v)
        {
            double cosine = DotProduct(v) / (_module * v.Module);

            return Math.Acos(cosine) * (180 / Math.PI); // Convert radians to degrees
        }
    }
}
