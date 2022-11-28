using System;
using System.Drawing;
using System.Text;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int verticesCount = 0;

                try
                {
                    Console.Write("Please enter the number of vertices in the graph: ");
                    verticesCount = int.Parse(Console.ReadLine());

                    // Create a graph
                    MyGraph g = new MyGraph();

                    for (int i = 0; i < verticesCount; i++)
                    {
                        g.AddVertix(i);
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Please enter the pairs of adjacency vertices and weights (enter 'stop' to finish creating the graph): ");

                    int count = 1;

                    while (true)
                    {
                        string[] inputString;

                        while (true)
                        {
                            Console.Write($"{count}: ");

                            inputString = Console.ReadLine().Trim().Split();

                            try
                            {
                                var u = Convert.ToInt32(inputString[0]);
                                var v = Convert.ToInt32(inputString[1]);
                                var w = Convert.ToInt32(inputString[2]);

                                if (u >= verticesCount || v >= verticesCount)
                                {
                                    Console.WriteLine($"Invalid input! Vertix should less than the number of vertices in the graph! ");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    g.AddEdge(u, v, w);
                                    count++;
                                }

                            }
                            catch (Exception ex)
                            {
                                if (inputString[0] == "stop") break;
                                else
                                {
                                    Console.WriteLine($"Invalid input! " + ex.Message);
                                    Console.WriteLine();
                                }
                            }
                        }

                        break;
                    }

                    Console.WriteLine();
                    Console.WriteLine("The shortest path of the created graph: ");

                    var dijkstra = new Dijkstra(g);
                    var path = dijkstra.FindShortestPath(0, verticesCount-1);

                    Console.WriteLine(path);
                    Console.ReadLine();

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input! " + ex.Message);
                    Console.WriteLine();
                }
            }

        }
    }
}
