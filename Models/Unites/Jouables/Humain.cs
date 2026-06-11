using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Jouables
{
    public class Humain : Heros
    {
        public override int Force
        {
            get
            {
             
                return base.Force +1; 
            }
            
        }
        public override int Endurance => base.Endurance +1; //Autre option d'écriture !! 
    
    }
}
