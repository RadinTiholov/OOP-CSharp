﻿using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Classes
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
