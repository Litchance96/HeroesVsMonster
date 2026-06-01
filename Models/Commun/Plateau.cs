using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Models.Commun
{
    public class Plateau
    {
        public const int TAILLE = 10; // Constante pour la taille de la grille du plateau de jeu    
        public string[,] _Grille = new string[TAILLE, TAILLE]; // Grille du plateau de jeu, représentée par un tableau à deux dimensions de chaînes de caractères - Console.Write ne peut pas afficher un tableau à deux dimensions, on va donc utiliser DEUX boucles pour afficher la grille, une pour les y et une pour les x

        public string this[int y, int x]
        {
            get
            {
                if (x < 0 || x >= TAILLE || x < 0 || y >= TAILLE)
                { // Vérification des limites de la grille
                  //throw new ArgumentOutOfRangeException("Coordonnées hors limites du plateau.");
                }
                return _Grille[y, x];
            }
            set
            {
                if (x < 0 || x >= TAILLE || x < 0 || y >= TAILLE)
                { // Vérification des limites de la grille
                  //throw new ArgumentOutOfRangeException("Coordonnées hors limites du plateau.");
                }
                _Grille[y, x] = value;
            }
        }
    }
}


 
