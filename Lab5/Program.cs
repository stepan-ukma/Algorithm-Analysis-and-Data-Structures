using System;

namespace Lab5
{
    class Program
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
                    Graph g = new Graph(verticesCount);

                    Console.WriteLine();
                    Console.WriteLine($"Please enter the pairs of adjacency vertices (enter 'stop' to finish creating the graph): ");

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

                                if (u >= verticesCount || v >= verticesCount)
                                {
                                    Console.WriteLine($"Invalid input! Vertix should less than the number of vertices in the graph! ");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    g.AddEdge(u, v);
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
                    Console.WriteLine("Topological sort of the created graph: ");
                    g.TopologicalSort();

                    break;    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input! " + ex.Message);
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}