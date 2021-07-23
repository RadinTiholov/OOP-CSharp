using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Classes
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            string input = Console.ReadLine();
            while (input != "Exit")
            {
                string result = commandInterpreter.Read(input);
                if (result == null)
                {
                    break;
                }
                Console.WriteLine(result);
                input = Console.ReadLine();
            }
        }
    }
}
