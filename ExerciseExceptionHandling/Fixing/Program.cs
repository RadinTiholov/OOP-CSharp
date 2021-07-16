using System;

namespace Fixing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weekdays = new string[5];
            weekdays[0] = "smt0";
            weekdays[1] = "smt1";
            weekdays[2] = "smt2";
            weekdays[3] = "sm3";
            weekdays[4] = "smt4";
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Console.WriteLine(weekdays[i].ToString());
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
