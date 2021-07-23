using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        private int minValue;
        private int maxValue;
        public override bool IsValid(object obj)
        {
            if (obj is int)
            {
                int value = (int)obj;
                if (value >= minValue && value <= maxValue)
                {
                    return true;
                }
                return false;
            }
            else
            {
                throw new ArgumentException("Invalid type");
            }
        }
    }
}
