using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Classes
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitted = args.Split();
            string command = splitted[0];
            string[] commandArgs = splitted[1..];

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name.StartsWith(command));
            ICommand instance = (ICommand)Activator.CreateInstance(type);
            string result = instance.Execute(commandArgs);
            return result;
        }
    }
}
