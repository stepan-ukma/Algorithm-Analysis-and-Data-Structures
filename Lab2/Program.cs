using System.ComponentModel.Design;

namespace Lab2
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
                            Console.WriteLine($"{numbers[i]} is not in the range [2, 255]");
                            Console.WriteLine();

                            numbers[i] = 0;

                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input!");
                        Console.WriteLine();

                        break;
                    }
                }

                if (numbers[0] > 0 && numbers[1] > 0) break;
            }

            string[] keyValueArray = new string[numbers[0]];

            for (int i = 0; i < keyValueArray.Length; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}/{keyValueArray.Length}. Please enter key (int) and value (string) pair: ");

                    var keyValue = Console.ReadLine().Trim();
                    var keyValueParts = keyValue.Split();

                    try
                    {
                        int key = Convert.ToInt32(keyValueParts[0]);
                        string value = keyValueParts[1];

                        keyValueArray[i] = keyValue;

                        break;
                    }
                    catch
                    { 
                        Console.WriteLine($"Invalid input!");
                        Console.WriteLine();
                    }
                }
            }

            int[] keyArray = new int[numbers[1]];
            
            for (int i = 0; i < keyArray.Length; i++)
            {
                while (true)
                {
                    Console.Write($"{i + 1}/{keyArray.Length}. Please enter key (int): ");

                    int key;

                    if (int.TryParse(Console.ReadLine().Trim(), out key))
                    {
                        keyArray[i] = key;

                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                        Console.WriteLine();
                    }
                }
            }

            // Fill dictionary
            MyDictionary dict = new MyDictionary();

            for (int i = 0; i < keyValueArray.Length; i++)
            {
                int key = Convert.ToInt32(keyValueArray[i].Split()[0]);
                string value = keyValueArray[i].Split()[1];

                dict.Add(key, value);
            }

            Console.WriteLine();
            Console.WriteLine("Result: ");

            for (int i = 0; i < keyArray.Length; i++)
            {
                Console.WriteLine(dict.GetValue(keyArray[i]));
            }

            Console.WriteLine();
            Console.WriteLine($"Count: {dict.Count}");
            Console.WriteLine($"IsEmpty: {dict.IsEmpty}");
            Console.WriteLine($"Capacity: {dict.Capacity}");
            Console.WriteLine($"ContainsKey 10: {dict.ContainsKey(10)}");
            Console.WriteLine($"ContainsValue 'Kyiv': {dict.ContainsValue("Kyiv")}");

            Console.WriteLine("Add 10 'Kyiv'");
            dict.Add(10, "Kyiv");
            Console.WriteLine($"10: {dict.GetValue(10)}");

            Console.WriteLine("Remove 10");
            dict.Remove(10);
            Console.WriteLine($"10: {dict.GetValue(10)}");


            Console.WriteLine("Clear");
            dict.Clear();
            Console.WriteLine($"1: {dict.GetValue(10)}");

            Console.WriteLine();
        }
    }
}