using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites
{
    public class Monstre : Personnage
    {

        
        public bool Hasloot 
        { 
        get { return Butin.Any(); } //Any ==> tant que count > 0
        }

        //Autre version
        //public bool Hasloot => Butin.Any();


        public Dictionary<string, int> Butin { get; set; } = new();
        public void AttackHero()
        {

        }

        public virtual void Potion()
        {

        }
    }
}
