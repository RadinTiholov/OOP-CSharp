using SolidExercise.Engine;
using System;

namespace SolidExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var commandInterpreter = new CommandInterpreter();
            commandInterpreter.Run();
        }
    }
}
