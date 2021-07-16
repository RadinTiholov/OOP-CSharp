using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadNumbersFromConsole();
        }
        public static int ReadNumbers(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                throw new IndexOutOfRangeException();
            }
            return number;
        }
        public static void ReadNumbersFromConsole() 
        {
            int[] buffer = new int[10];
            buffer[0] = int.MinValue;
            for (int i = 1; i <= 11; i++)
            {
                try
                {
                    int n = ReadNumbers(1, 100);
                    if (n < buffer[i-1])
                    {
                        throw new ArgumentException();
                    }
                    buffer[i] = n;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Enter all of them again.");
                    ReadNumbersFromConsole();
                    break;
                }
            }
        }
    }
}
