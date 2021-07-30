using System;

namespace LabDesignPatterns
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var container1 = SingletonDataContainer.Instance;
            Console.WriteLine(container1.GetPopulation("Sofia"));
            var container2 = SingletonDataContainer.Instance;
            Console.WriteLine(container1.GetPopulation("Athens"));
        }
    }
}
