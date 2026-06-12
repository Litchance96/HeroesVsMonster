using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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

        // Constructeur qui initialise le butin
        public Monstre()
        {
            _ButinPrive = new();
        }

        // Gestion de butin :
        // - (Privé) Dico avec les méthodes de mutations(Add, Remove, ...), c'est celui-ci qu'on va utiliser pour le modifier en interne ! :

        private Dictionary<string, int> _ButinPrive { get; set; }

        // - (Public) Accès aux données du dico en lecture, c'est celui-ci qu'on va utiliser en dehors de la classe ! :
        public ReadOnlyDictionary<string, int> Butin
        {
            get
            { return _ButinPrive.AsReadOnly(); }
           
        }

        // - (Public) Méthode pour supprimer une valeur de butin et elle renvoie la quantité de celui-ci

        public int SupprimerButin(string nomDuButin) //Methode public donc les héros peuvent l'utiliser
        {

            //On cherche à voir il y a combien de tel ou tel butin par ex : Voir combien d'or le loup a, donc nomDuButin (or) et va renvoyer "out" la quantité de l'or. 
            //int quantite;
            //bool possedeButin = _ButinPrive.TryGetValue(nomDuButin, out quantite); *

            if (_ButinPrive.ContainsKey(nomDuButin)) // *
            {
                // On récupère la valeur du butin pour cette clef *TryGetValue
                int quantite = _ButinPrive[nomDuButin];

                // Suppression de la ligne du butin 
                _ButinPrive.Remove(nomDuButin);

                // Renvoi la quantité de butin * out int quantite
                return quantite;
            }
            return 0;

        }

        protected void AjouterButin(string nomDuButin, int quantite) //Si le monstre tape sur un caillou qui lui permet d'acquerir de l'or par ex.
        {

            // Test de garde pour eviter d'avoir 0 d'un butin
            if (quantite <= 0) return;
            if (_ButinPrive.ContainsKey(nomDuButin))
            {
                // Modifier la valeur si la clé est présente
                _ButinPrive[nomDuButin] += quantite;
            }
            else
            {
                //Ajouter une nouvelle clé avec la valeur
                _ButinPrive.Add(nomDuButin, quantite);
            }
        }


        public void AttackHero()
        {

        }

        public virtual void Potion()
        {

        }
    }
}
