using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Models.Unites
{
    public class Heros : Personnage
    {

        public string? Nom;

        public Dictionary<string, int> Butin { get; set; } = new()
        {
            {"Or", 0}, 

            {"Repas", 0},

            {"Viande", 0 }
        };

        public void AttackMonstres() 
        { 

        }

        public void Repos()
        {
            //TODO : peut etre envisager des pv max au dessus desquels on ne peut pas remonter, on va mettre 20 ici por etre sure : 
            Console.WriteLine("Votre héro se repose...");
            // Si en récuperent 10, je passe au dessus de 20, on ajoute plutot les pv manquants

            if(PV + 10 > 20)
            {
                PV += (20 - PV);
            }
            //Sinon, on peut rajouter 10
            else
            { PV += 10; }

        }

        public void Cuisiner()
        {
            // Vérifier s'il possède des viandes à cuisiner

            if(Butin["Viande"] > 0)
            {
                Console.WriteLine("[Inserer musique de Monster Hunter] Vous avez fabriqué 1 x repas !");

                Butin["Viande"]--; //On retire une viande
                Butin["Repas"]++; //On rajoute un repas
            }
            else
            {
                Console.WriteLine("NOPE, Vous n'avez pas de viande dans votre inventaire...");
            }
        }

        public void Manger()
        {
            //On va vérifier si le héro possède des repas
            if(Butin["Repas"] > 0)
            {
                Console.WriteLine("Votre héro se délecte d'un délicieux repas");
                Butin["Repas"]--;
                if (PV + 5 > 20)
                {  PV += (20 - PV); }
                else 
                { PV += 5; }
            }
            else
            {
                Console.WriteLine("Votre héro ne possède pas de repas, il va devoir manger de la viande crue... Beurk.");

                Butin["Viande"]--; //on enleve la viande de l'inventaire
                int recuperation = Random.Shared.Next(-3, 4);
                if (recuperation < 0)
                {
                    Console.WriteLine("Votre héros s'est intoxiqué, vous avez perdu des PV..");
                    PV += recuperation;
                }
                else
                {
                    // On regagne le max qu'on peut ou la récup
                    if (PV + recuperation > 20) 
                    {
                        PV += 20 - PV;
                    }
                    else
                    {
                        PV += recuperation;
                    }
                }
            }
        }

        public void Loot(Monstre cible)
        {
            // Test de garde
            if(cible.EstEnVie)
            {
                // TODO : Erreur, la créature doit être mouru
                return;
            }
        
        
            // Rappel : Dans un foreach c'est interdit de modifier la structure (ici supprimer éléments), il faut tout mettre à zero à la place

            // foreach(KeyValuePair<string, int> element in cible.Butin) --> une facon de le faire :

            while(cible.Hasloot) //On a creer une methode chez les monstres!!
            {
                // Le butin qu'on réucpere :
                KeyValuePair<string, int> butin = cible.Butin.First(); 
                // --->  KeyValuePair<> = var ; First() --> tant que le 1er élément existe on prend, et ca va s'arreter quand il n'y en aura plus. Car c'est un dictionnaire, on n'a pas d'index. 

                string typeButin = butin.Key;
                int valeurButin = butin.Value;

                if(this.Butin.ContainsKey(typeButin))
                {
                    // Si on possède déjà le type de butin, on augmente sa valeur
                    this.Butin[typeButin] += valeurButin;
                }else
                {
                    // Si on ne l'a pas, on l'ajoute
                    this.Butin.Add(typeButin, valeurButin);
                }

                // Suppression du butin sur la cible
                cible.Butin.Remove(typeButin);
            }
        }
    }
}
