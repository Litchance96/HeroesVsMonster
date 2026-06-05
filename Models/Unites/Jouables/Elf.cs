using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Jouables
{
    public class Elf : Heros
    {
        public override int Endurance => base.Endurance + 3;


        public override int Force
        {
            get
            {
                if (base.Force - 2 >= 1)
                {
                    return base.Force - 2;
                }

                else if (base.Force - 1 >= 1)
                {
                    return base.Force - 1;
                }

                else
                {
                    return base.Force;
                }
            }
        }

    }
}
