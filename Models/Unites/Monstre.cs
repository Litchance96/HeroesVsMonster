using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites
{
    public class Monstre : Personnage
    {

        public Dictionary<string, int> Butin { get; set; } = new();
        public void AttackHero()
        {

        }

        public virtual void Potion()
        {

        }
    }
}
