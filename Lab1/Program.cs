namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers;

            while (true)
            {
                Console.WriteLine("Please enter N integers (1<N<256), none of which should be duplicated:");
                
                string input = Console.ReadLine();

                try
                {
                    numbers = input?.Trim().Split(' ')?.Select(int.Parse)?.ToList();

                    if (numbers.Count != numbers.Distinct().Count())
                    {
                        List<int> duplicates = numbers.GroupBy(x => x)
                                                      .Where(g => g.Count() > 1)
                                                      .Select(x => x.Key)
                                                      .ToList();

                        Console.WriteLine("Input contains duplicates: " + String.Join(", ", duplicates));
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine();
                }
            }

            MyQueue<int> myQueue = new MyQueue<int>();

            foreach(var number in numbers)
            {
                myQueue.Enqueue(number);
            }

            myQueue.PrintMiddleElement();

            Console.ReadKey();
        }
    }
}