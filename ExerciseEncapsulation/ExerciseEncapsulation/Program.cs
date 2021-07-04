using System;

namespace ExerciseEncapsulation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //double length = double.Parse(Console.ReadLine());
            //double width = double.Parse(Console.ReadLine());
            //double height = double.Parse(Console.ReadLine());
            //Box box = new Box(length, width, height);
            //Console.WriteLine(box.ToString());

            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            Box box = null;

            try
            {
                box = new Box(length, width, height);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LiteralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
        }
    }
}
