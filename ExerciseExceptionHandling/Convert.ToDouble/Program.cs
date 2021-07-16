using System;
using System.Numerics;

namespace Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string smth = "ASDASDDDSS";
            Cat someCat = new Cat("Gosho");
            try
            {
                double number = System.Convert.ToDouble(smth);
                //double number = System.Convert.ToDouble(someCat);
                //double number = System.Convert.ToDouble(long.Parse("9999999999999999999999999999999999999999"));
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                Console.WriteLine("------------------------");
                throw;
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
                Console.WriteLine("------------------------");
                throw;
            }
            catch (OverflowException ofe) 
            {
                Console.WriteLine(ofe.Message);
                Console.WriteLine("------------------------");
                throw;
            }
        }
    }
}
