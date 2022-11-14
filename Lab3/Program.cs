using static Lab3.ColorEnum;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] numbers = new int[2];

            while (true)
            {
                Console.Write("Please enter N and M (two integers in the range [2, 255]): ");

                var inputString = Console.ReadLine().Trim().Split();

                for (int i = 0; i < numbers.Length; i++)
                {
                    try
                    {
                        numbers[i] = Convert.ToInt32(inputString[i]);

                        if (!(numbers[i] > 1 && numbers[i] < 256))
                        {
                            Console.WriteLine($"Invalid input! {numbers[i]} is not in the range [2, 255]");
                            Console.WriteLine();

                            numbers[i] = 0;

                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid input!");
                        Console.WriteLine();

                        break;
                    }
                }

                if (numbers[0] > 0 && numbers[1] > 0) break;
            }

            int[] keyArray = new int[numbers[0]];
            int[] keyArray2 = new int[numbers[1]];


            Console.WriteLine();
            Console.WriteLine($"Please enter {keyArray.Length} values to be added into the Red-Black Tree: ");

            for (int i = 0; i < keyArray.Length; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}/{keyArray.Length}: ");

                    var inputString = Console.ReadLine().Trim().Split();
                    try
                    {
                        keyArray[i] = Convert.ToInt32(inputString[0]);
                        
                        break;
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid input!");
                        Console.WriteLine();
                    }
                }
                
            }

            Console.WriteLine();
            Console.WriteLine($"Please enter {keyArray2.Length} values to be found in the Red-Black Tree: ");

            for (int i = 0; i < keyArray2.Length; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}/{keyArray2.Length}: ");

                    var inputString = Console.ReadLine().Trim().Split();
                    try
                    {
                        keyArray2[i] = Convert.ToInt32(inputString[0]);

                        break;
                    }
                    catch
                    {
                        Console.WriteLine($"Invalid input! {inputString[0]} is not interger");
                        Console.WriteLine();
                    }
                }

            }

            RedBlackTree tree = new RedBlackTree();

            Console.WriteLine();
            for (int i = 0; i < keyArray.Length; i++)
            {
                Console.Write($"Add {keyArray[i]} to the tree. ");
                tree.Insert(keyArray[i]);

                if (tree.MinValue.color == Color.Black)
                {
                    Console.Write($"Min value: {tree.MinValue.value}, Color: {tree.MinValue.color}. ");
                }
                else
                {
                    Console.Write($"Min value: {tree.MinValue.value}, Color: {tree.MinValue.color}.   ");
                }

                tree.DisplayTree();
                Console.WriteLine();
            }

            Console.WriteLine();
            for (int i = 0; i < keyArray2.Length; i++)
            {
                Console.Write($"Find {keyArray2[i]} in the tree. ");
                var key = tree.Find(keyArray2[i]);

                if (key == null)
                {
                    Console.Write($"{keyArray2[i]} not found");
                }
                else
                {
                    Console.Write($"{keyArray2[i]} found. ");
                    Console.Write($"Color: {key.color}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Remove 1 from the tree. ");
            tree.Remove(1);
            tree.DisplayTree();
            Console.WriteLine();

            Console.Write("Remove 3 from the tree. ");
            tree.Remove(3);
            tree.DisplayTree();
            Console.WriteLine();

            Console.Write("Remove 9 from the tree. ");
            tree.Remove(9);
            Console.WriteLine();

            Console.Write("Final tree: ");
            tree.DisplayTree();

            Console.WriteLine();
        }
    }
}