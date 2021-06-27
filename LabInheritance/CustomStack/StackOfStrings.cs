namespace CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty() 
        {
            if (Count == 0)
            {
                return true;
            }
            return false;
        }
        public void AddRange(params string[] collection) 
        {
            foreach (var item in collection)
            {
                this.Push(item);
            }
        }
    }
}
