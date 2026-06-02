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
        private int _ForceBase = 10;
        public string? Nom; //{ get(recuperation); set(écriture dedans); } // Propriété auto-implémentée pour le nom du personnage
        public virtual int Force 
        { 
            get 
            { 
                return _ForceBase; //return base.Force + 2; quand on voudra modifier a nos monstres et héros
            } 
            private set; 
        } 
        public virtual int Endurance { get; private set; } = 10;
        public int PV { get; private set; } = 20;

        public virtual int Bonus { get; set;  }

        public virtual int Malus { get; set; }
        public bool EstEnVie
        {
            get
            {
                return PV > 0; // Le personnage est en vie tant que ses points de vie sont supérieurs à zéro
            }
        }

        public virtual void Frappe(Personnage cible)
        {
            //Lancer un dé (à quatre faces)pour déterminer les dégâts infligés (retirer des PV) à la cible

            De de = new De(); // Création d'un dé à 4 faces
            de.Max = 4;      // Définition du nombre de faces du dé

            int degats = de.Lancer(); // Lancer le dé pour obtenir les dégâts
            cible.PV -= degats;      // Retirer les dégâts des PV de la cible

        }

        public virtual void SubitDegats(int degats)
        {
            //PV -= degats; // Retirer les dégâts des PV du personnage MAIS en infligeant on additionne donc ca fera - - = + (si on arrive à des dégats négatifs) donc on doit additionner au lieu de soustraire
            if (degats >= 0)
            {
                PV -= degats; // Retirer les dégâts des PV du personnage
            }

            //TODO error a gérer (ce qu'on verra plus tard)
        }



    }

}


