using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        public Dye(int power)
        {
            this.Power = power;
        }
        private int power;
        public int Power
        {
            get { return power; }
            private set
            {
                if (value < 0)
                {
                    power = 0;
                }
                else
                {
                    power = value;
                }
            }
        }

        public bool IsFinished()
        {
            if (Power == 0)
            {
                return true;
            }
            return false;
        }

        public void Use()
        {
            this.Power -= 10;
            if (Power < 0)
            {
                Power = 0;
            }
        }
    }
}
