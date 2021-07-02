namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Snake snake = new Snake("Rambo");
            System.Console.WriteLine(snake.Name);

        }
    }
}