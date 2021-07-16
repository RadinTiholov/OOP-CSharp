using System;

namespace FixingVol2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            int result;
            num1 = 30;
            num2 = 60;
            result = Convert.ToInt32(num1 * num2);
            Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
        }
    }
}
