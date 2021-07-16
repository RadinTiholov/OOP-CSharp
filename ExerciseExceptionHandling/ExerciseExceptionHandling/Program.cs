using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new ArithmeticException();
                }
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
            //catch (Exception) 
            //{
            //}
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
