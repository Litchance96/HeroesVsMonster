using System;
using System.Collections.Generic;
using System.Text;
using Models.Outils;

namespace Models.Unites.Monstres
{
    public class Dragonnet : Monstre
    {


        public override int Force => base.Force + 1;

        public override int Endurance => base.Endurance + 5;

        public Dragonnet()
        {
            this.AjouterButin("Peau", De3.Lancer());
            
            this.AjouterButin("Or", De100.Lancer());

            if(De6.Lancer() >= 5) //On lance un de6 et si on fait moins de 5 on a deux ailes. 
            {
                
                this.AjouterButin("Ailes", 2);
                
            }
        }


    }
}
