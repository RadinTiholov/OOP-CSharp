using System;
using System.Collections.Generic;
using System.Text;
using ValidPerson.Interfaces;
using ValidPerson.Modules;

namespace ValidPerson.Engines
{
    public class BasicEngine : IEngine
    {
        public void Run()
        {
            try
            {
                Person stoqn = new Person("Stoqn", "Kolev", -12);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Person gosho = new Person("gosho", "Stolev", 1240);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
