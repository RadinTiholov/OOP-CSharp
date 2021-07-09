using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy:ISoldier
    {
        public Spy(int id, string firstName, string lastName, int code)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Code = code;
        }
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public int Code { get; private set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id}\nCode Number: {Code}";
        }
    }
}
