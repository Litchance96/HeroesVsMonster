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


        //public void ToutLeButinDesAutres(int LoupPeau, int DragonnetOr, int OursPeau, int LoupViande, int OursViande, int DragonnetAiles, int DragonnetPeau, int LoupCrocs, int OursGriffes)
        //{
        //    public int ButinBandit = LoupPeau +  DragonnetOr + ;
        //}

        //public void ToutLeButinDesAutres2(int Peau, int Or, int Viande, int Ailes, int Crocs, int Griffes)
        //{
        //    public int ButinBandit = ;
        //}
        public override int Force => base.Force + 3;


        public override int Endurance
        {
            get
            {
                int tempsEndurance = base.Endurance - 2;
                return (tempsEndurance <1) ?  tempsEndurance :  1 ;

                //Autre facon
                if (base.Endurance - 2 >= 1)
                {
                    return base.Endurance - 2;
                }
                else if (base.Endurance - 1 <= 1)
                {
                    return base.Endurance - 1;
                }
                else
                {
                    return base.Endurance;
                }
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
