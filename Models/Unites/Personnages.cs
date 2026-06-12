using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Models.Outils;

namespace Models.Unites
{
    /*
     * La classe Personnage représente un personnage dans le jeu, avec des attributs tels que le nom, la force, l'endurance et les points de vie (PV).
     * public --> tout le monde peut y accéder
     * internal -->accessible uniquement au sein de l'assembly
     * protected --> accessible dans la classe ET les classes dérivées
     * private --> accessible uniquement dans la classe
     */
    public class Personnage
    {

        //Random random = new Random();
        //public int _ForceBase = 10;
        //public int _EnduranceBase = 10;
        //{ get(recuperation); set(écriture dedans); } // Propriété auto-implémentée pour le nom du personnage

        public virtual int Force { get; private set; }

        public virtual int Endurance { get; private set; }

        public int PV { get; protected set; } = 20;

        // Set de dé du personnage : 
        // - Le private protected permet d'utiliser la classe "De" qui internal dans l'heritage
        private protected De De3 { get; init; }

        private protected De De4 { get; init; }

        private protected De De6 { get; init; }

        private protected De De100 { get; init; }


        // Point de vie maximum calculé et dynamiquement (Minimum 6)
        public int PVMax => Math.Max((Endurance * 2) - 5, 6);
    


        // Constructeur qui initialise les stats
        public Personnage()
        {

            // Comme il n'y a pas de conflit de nom de variable possible, le mot clef "this."avant Force/Endurance/PV n'est pas obligatoire

            Force = Random.Shared.Next(5, 10);

            Endurance = Random.Shared.Next(5, 10);

            // Comme "PVMax" utilise endurance, celui-ci doit être intialiser après "Endurance"

            PV = PVMax;

            // Initialisation des dés
            De3 = new De(3);
            De4 = new De(4);
            De6 = new De(6);
            De100 = new De(100);
        }





        public bool EstEnVie
        {
            get
            {
                return PV > 0; // Le personnage est en vie tant que ses points de vie sont supérieurs à zéro
            }
        }

        public virtual void Frappe(Personnage cible)
        {
            //Lancer un dé (à quatre faces)pour déterminer les dégâts infligés (retirer des PV) à la cible.

     
            //On a appeler les dés au dessus.

            // Lancer le dé pour obtenir les dégâts -----> "this" pour preciser que cest la force de celui qui va frapper.
            int degats = De4.Lancer() + CalculBonus(this.Force);

            // Retirer les dégâts des PV de la cible.
            cible.SubitDegats(degats);      
        }

        public virtual void SubitDegats(int degats)
        {
            //PV -= degats; // Retirer les dégâts des PV du personnage MAIS en infligeant on additionne donc ca fera - - = + (si on arrive à des dégats négatifs) donc on doit additionner au lieu de soustraire.
         
            //On verifie si les dégats sont positifs et si les dégats - le bonus sont positifs aussi pour ne pas rajouter des PV à notre personnage.

            int bonus = CalculBonus(Endurance);
            if (degats >= 0 && degats - bonus >=0)
            {

                // Retirer les dégâts des PV du personnage - Endurance, il subira moins s'il est plus endurant.
                PV -= degats - CalculBonus(Endurance); 
            }

            //TODO error a gérer (ce qu'on verra plus tard)
        }

        protected  int CalculBonus(int stat)
        {
            if (stat < 10)
            { return -1; }
            else if (stat == 10)
            { return 0; }
            else if (stat > 10 && stat < 13)
            { return 1; }
            else
            { return 2; }
        }




    }

}


