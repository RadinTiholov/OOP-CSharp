using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList:List<string>
    {
        public string RandomString() 
        {
            Random rnd = new Random();
            int number = rnd.Next(0, Count);
            string text = this[number];
            RemoveAt(number);
            return text;
        }
    }
}
