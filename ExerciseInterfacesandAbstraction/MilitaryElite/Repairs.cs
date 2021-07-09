using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repairs
    {
        public Repairs(string name, int hours)
        {
            Name = name;
            Hours = hours;
        }
        public string Name { get; private set; }
        public int Hours { get; private set; }
        public override string ToString()
        {
            return $"Part Name: {Name} Hours Worked: {Hours}";
        }
    }
}
