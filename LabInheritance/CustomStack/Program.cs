﻿namespace CustomStack
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var stringStack = new StackOfStrings();

            Console.WriteLine(stringStack.IsEmpty()); // true

            stringStack.AddRange("1", "2", "3");

            Console.WriteLine(stringStack.IsEmpty()); // false
        }
    }
}
