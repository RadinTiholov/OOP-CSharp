using System;
using System.Linq;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> list = new List<string>();
            while (input != "End")
            {
                var splitted = input.Split();
                string type = splitted[0];
                if (type == "Citizen")
                {
                    list.Add(splitted[4]);
                }
                else if (type == "Pet")
                {
                    list.Add(splitted[2]);
                }
                
                input = Console.ReadLine();
            }
            int number = int.Parse(Console.ReadLine());
            if (list.Any(x => x.EndsWith(number.ToString())))
            {
                Console.WriteLine(string.Join("\n", list.Where(x => x.EndsWith(number.ToString()))));
            }
            else
            {
                Console.WriteLine("<empty output>");
            }
        }
    }
}
