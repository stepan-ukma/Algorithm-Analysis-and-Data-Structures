using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int pointNumber;

            while (true)
            {
                Console.Write("Please enter N (integer in the range [3, 255]) - number of points to generate: ");

                var inputString = Console.ReadLine().Trim();

                try
                {
                    pointNumber = Convert.ToInt32(inputString);

                    if (!(pointNumber > 2 && pointNumber < 256))
                    {
                        Console.WriteLine($"Invalid input! {pointNumber} is not in the range [3, 255]");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine($"Invalid input!");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Generate polygon point coordinates randomly? (Yes/No)");
            var isRandomCoordinates = Console.ReadLine().Trim().ToLower() == "yes" ? true : false;


            List<Point> convexHull;
            Polygon pol = new Polygon();

            if (isRandomCoordinates)
            {
                Random rnd = new Random();

                // Generate N random points and insert them into the polygon
                for (int i = 0; i < pointNumber; i++)
                {
                    int x = rnd.Next(0, 10);
                    int y = rnd.Next(0, 10);
                    Point point = new Point(x, y);

                    try
                    {
                        pol.AddPoint(point);
                    }
                    catch
                    {
                        i--;
                    }
                }
            }
            else
            {
                int[] coordinates = new int[2];

                Console.WriteLine();
                Console.WriteLine($"Please enter {pointNumber} polygon point coordinates (x, y): ");

                for (int i = 1; i <= pointNumber; i++)
                {
                    while (true)
                    {
                        Console.Write($"{i}/{pointNumber}: ");

                        var inputString = Console.ReadLine().Trim().Split();

                        try
                        {
                            var x = Convert.ToInt32(inputString[0]);
                            var y = Convert.ToInt32(inputString[1]);

                            Point point = new Point(x, y);

                            pol.AddPoint(point);

                            break;
                        }
                        catch (PolygonException pe)
                        {
                            Console.WriteLine(pe.ToString());
                        }
                        catch
                        {
                            Console.WriteLine($"Invalid input!");
                            Console.WriteLine();
                        }
                    }
                }
            }

            Console.WriteLine("\nGenerated points of the polygon: ");
            Console.WriteLine(pol);

            try
            {
                convexHull = pol.GetConvexHull();

                Console.WriteLine("Result (Jarvis March algorithm): ");
                foreach (Point p1 in convexHull)
                {
                    Console.WriteLine(p1);
                }
            }
            catch (PolygonException pe)
            {
                Console.WriteLine(pe.ToString());
            }

            Console.ReadLine();
        }
    }
}
