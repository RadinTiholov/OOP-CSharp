using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission
    {
        public Mission(string name, string state)
        {
            Name = name;
            State = state;
        }
        private string state;

        public string State
        {
            get { return state; }
            private set 
            {
                if (value == "inProgress" || value == "Finished")
                {
                    state = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

       
        public string Name { get; private set; }

        public override string ToString()
        {
            return $"Code Name: {Name} State: {State}";
        }
    }
}
