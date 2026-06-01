
using Models.Outils; 

using Models.Unites;

namespace HeroesvsMonster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Création d'un personnage (2 facons de faire)
            Personnage lori = new Personnage();
            Personnage bobi = new();

            // Points de vies
            // lori.PV = 20;
            // bobi.PV = 20;
            // On a gerer les points de vie dans le personnage (private set) pour eviter que les points de vie soient modifiés n'importe comment dans le code, on a donc creer une methode Frappe qui va gerer les points de vie.
            // Valeur par défaut dans le personnage + Encapsulation (private set) + Methode Frappe pour gerer les points de vie

            // Frappe
            lori.Frappe(bobi);

            Console.WriteLine("Lori a frappé Bobi, Bobi a maintenant " + bobi.PV + " points de vie tandis que Lori à toujours " + lori.PV + " points de vie.");
            
            Console.WriteLine("Un arbre tombe sur Bobi !");
            //bobi.PV -= 4; //problème car on a dit qu'on peut modfier les points de vie n'importe comment, on va donc creer une methode Frappe qui va gerer les points de vie.

            bobi.SubitDegats(4);
            bobi.SubitDegats(-4);

            if (!bobi.EstEnVie) 
            {
                Console.WriteLine("Bobi est mort !");
            }
        }
    }
}