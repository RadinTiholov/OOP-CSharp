namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Knight a = new Knight("asdas", 12);
            System.Console.WriteLine(a.Level + " " + a.Username);
        }
    }
}