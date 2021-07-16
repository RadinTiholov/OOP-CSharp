using System;
using ValidPerson.Engines;
using ValidPerson.Interfaces;

namespace ValidPerson
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new BasicEngine();
            //IEngine engine = new StudentProblemEngine();
            engine.Run();
        }

        
    }
}
