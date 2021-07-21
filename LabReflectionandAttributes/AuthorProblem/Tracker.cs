using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor() 
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.Static|BindingFlags.NonPublic);
            foreach (var item in methods)
            {
                if (item.CustomAttributes.Any(x => x.AttributeType == (typeof(AuthorAttribute))))
                {
                    var attributes = item.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{item.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
