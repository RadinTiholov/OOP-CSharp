using System;
using System.Collections.Generic;
using System.Text;

namespace LabDesignPatterns
{
    public class SingletonDataContainer : ISingletonContainer
    {
        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing object");
            var elements = new string[] {"Sofia", "1231231231", "Tokyo", "12312322", "Athens", "1268678" };
            for (int i = 0; i < elements.Length; i+=2)
            {
                capitals.Add(elements[i], int.Parse(elements[i+1]));
            }
        }

        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        private static SingletonDataContainer instance = new SingletonDataContainer();
        public static SingletonDataContainer Instance => instance;
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
