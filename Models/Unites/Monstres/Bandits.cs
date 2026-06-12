using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Models.Outils;

namespace Models.Unites.Monstres
{
    public class Bandits : Monstre
    {

        //public Bandits()
        //{
        //    //Or, Repas, tout le butin des autres monstres.

        //    this.AjouterButin("Repas", De3.Lancer());

        //    this.AjouterButin("Or", De100.Lancer());

        //    this.AjouterButin("Peau", De3.Lancer());

        //    this.AjouterButin("Griffes", De4.Lancer() + 1);

        //    this.AjouterButin("Crocs", De3.Lancer() - 1);

        //    this.AjouterButin("Viande", De6.Lancer());

        //    if (De100.Lancer() <= 5)
        //    {

        //        this.AjouterButin("Ailes", 2);

        //    }

        //}

        // Dans cette version de constructeur on va créer un bandit un peu plus réaliste (ex : qui a tuer qqun en chemin ou trouver des ailes ect) :

        public Bandits()
        {
            this.AjouterButin("Or", De100.Lancer());
            this.AjouterButin("Repas", De3.Lancer());
            this.AjouterButin("Viande", De6.Lancer());

            if (De100.Lancer() <= 50)
            {
                // Le bandit a loot un loup
                this.AjouterButin("Peau", De3.Lancer());
                this.AjouterButin("Crocs", De3.Lancer() - 1);
            }

            if (De100.Lancer() <= 25)
            {
                // Le bandit a loot un ours
                this.AjouterButin("Peau", De3.Lancer());
                this.AjouterButin("Griffes", De4.Lancer() + 1);
            }

            if (De100.Lancer() <= 5)
            {
                // Le bandit a loot un dragonnet
                this.AjouterButin("Ailes", 2);
            }
        }

        

        public override int Force => base.Force + 3;


        public override int Endurance
        {
            get
            {
                int tempsEndurance = base.Endurance - 2;
                return (tempsEndurance <1) ?  tempsEndurance :  1 ;

                //Autre facon
                //if (base.Endurance - 2 >= 1)
                //{
                //    return base.Endurance - 2;
                //}
                //else if (base.Endurance - 1 <= 1)
                //{
                //    return base.Endurance - 1;
                //}
                //else
                //{
                //    return base.Endurance;
                //}
            }
        }


        public override void SubitDegats(int degats)
        {
            base.SubitDegats(degats); //on déclanche la methode parent pour que les dégats s'appliquent

            if (PV < 5)
            {
                Console.WriteLine("Le bandit tente de prendre une potion");
                De De100 = new(100);
                
                if (De100.Lancer() == 11)
                {
                    Console.WriteLine("... et récupère 5 PV");
                    PV += 5;
                }
                else
                {
                    Console.WriteLine("... et la fait tomber au sol.");
                }

            }

        }
    }
}
