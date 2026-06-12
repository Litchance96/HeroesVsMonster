using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Models.Unites.Jouables
{
    public class Elf : Heros
    {
        
    
        
        public Elf(string nom) : base(nom) { }
       

        public override int Endurance => base.Endurance + 3;

        public override int Force
        {
            get
            {

                int tempForce = base.Force -2;

                return (tempForce < 1) ? tempForce : 1;

                //Ecriture alternative :

                //if (tempForce <1 )
                //{
                //    return tempForce;
                //}else
                //{
                //    return 1;
                //};
                // ----------------------- version Maude ----------------------------
                //if (base.Force - 2 >= 1)
                //{
                //    return base.Force - 2;
                //}

                //else if (base.Force - 1 >= 1)
                //{
                //    return base.Force - 1;
                //}

                //else
                //{
                //    return base.Force;
                //}
            }
        }

    }
}
