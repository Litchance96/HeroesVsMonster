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
        public int _ForceBase = 10;
        private int _EnduranceBase = 10;
         //{ get(recuperation); set(écriture dedans); } // Propriété auto-implémentée pour le nom du personnage
        public virtual int Force 
        {
            get
            {
                return _ForceBase; //return base.Force + 2; quand on voudra modifier a nos monstres et héros
            }
            private set; 
        } 
        public virtual int Endurance 
        { get
            {
                return _EnduranceBase;
            } 
        private set; 
        }
        public int PV { get; protected set; } = 20;


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

            De de = new De(4); // Création d'un dé à 4 faces.
                // Définition du nombre de faces du dé.

            // Lancer le dé pour obtenir les dégâts -----> "this" pour preciser que cest la force de celui qui va frapper.
            int degats = de.Lancer() + CalculBonus(this.Force);

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


