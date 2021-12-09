using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public int Power
        {
            get
            {
                return power;
            }

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

        public Dye(int power)
        {
            this.Power = power;
        }

        public void Use() => this.Power -= 10;

        public bool IsFinished() => this.Power == 0;
    }
}
