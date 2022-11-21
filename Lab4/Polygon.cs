using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    class PolygonException : Exception
    {
        public PolygonException(string message) : base(message) { }

    }

    class Polygon
    {
        private List<Point> points;

        public Polygon()
        {
            points = new List<Point>();
        }

        public void AddPoint(Point p)
        {

            foreach (Point p2 in points)
            {

                if (p2.Equals(p))
                {
                    PolygonException dp = new PolygonException("Duplicate point. \n");
                    throw dp;
                }
            }

            points.Add(p);
        }

        public List<Point> Points
        {
            get => points;
            set => points = new List<Point>(points);
        }

        public int FindLowest()
        {
            Point point = points[0];
            int minIndex = 0;

            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Y < point.Y)
                {
                    point = points[i];
                    minIndex = i;
                }
                else if (points[i].Y == point.Y)
                {
                    if (points[i].X < point.X)
                    {
                        point = points[i];
                        minIndex = i;
                    }
                }
            }

            return minIndex;
        }

        public List<Point> GetConvexHull()
        {
            if (points.Count < 3)
            {
                PolygonException pe = new PolygonException("A polygon must have at least 3 points to calculate its convex hull. \n");
                throw pe;
            }
            else if (points.Count == 3)
            {
                return points;
            }

            int i0 = FindLowest();
            int i = i0;
            int k = 0; // Index of the point with the smallest angle
            double angle;
            double angleMin = 0.0;
            List<Point> convexHull = new List<Point>();
            Point aux = new Point(points[i0].X + 1, points[i0].Y); // This auxiliary point is used to create the first axis of the algorithm
            Vector previousEdge = new Vector(points[i], aux);      // Create the first axis of the algorithm
            Vector newEdge;

            convexHull.Add(points[i0]);

            do
            {
                angleMin = 360; // Initialize the angle

                for (int j = 0; j < points.Count(); j++)
                {
                    if (j != i)
                    {
                        newEdge = new Vector(points[i], points[j]); // Create the new vector
                        angle = previousEdge.AngleTo(newEdge);      //  Calculate the angle of the previous vector with the new one

                        if ((angle <= angleMin))
                        {
                            angleMin = angle;
                            k = j;
                        }
                    }
                }

                convexHull.Add(points[k]);
                previousEdge = new Vector(points[i], points[k]); // Update the previous axis
                i = k;                                           // Update the index of the previous point
            }
            while (i != i0);

            return convexHull;
        }

        public override string ToString()
        {
            string str = "";

            foreach (Point pointPolygon in points)
            {
                str += pointPolygon.ToString() + "\n";
            }

            return str;
        }
    }
}
