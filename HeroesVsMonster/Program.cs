
using Models.Outils;
using Models.Commun;
using Models.Unites;
using System.Security.Cryptography.X509Certificates;
using Models.Unites.Jouables;
using Models.Unites.Monstres;

namespace HeroesvsMonster
{
    internal class Program
    {
        static void Main(string[] args)


        {



            
            #region Creation personnages
            //Création d'un personnage (2 facons de faire)
            Personnage lori = new Personnage();
            Personnage bobi = new();

            //Points de vies
            //lori.PV = 20;
            //bobi.PV = 20;
            // On a gerer les points de vie dans le personnage (private set) pour eviter que les points de vie soient modifiés n'importe comment dans le code, on a donc creer une methode Frappe qui va gerer les points de vie.
            // Valeur par défaut dans le personnage + Encapsulation (private set) + Methode Frappe pour gerer les points de vie

            // Frappe
            //lori.Frappe(bobi);

            //Console.WriteLine("Lori a frappé Bobi, Bobi a maintenant " + bobi.PV + " points de vie tandis que Lori à toujours " + lori.PV + " points de vie.");

            //Console.WriteLine("Un arbre tombe sur Bobi !");
            ////bobi.PV -= 4; // Problème car on a dit qu'on peut modfier les points de vie n'importe comment, on va donc creer une methode Frappe qui va gerer les points de vie.

            //bobi.SubitDegats(4);
            //bobi.SubitDegats(-4);

            //if (!bobi.EstEnVie) 
            //{
            //    Console.WriteLine("Bobi est mort !");
            //}

            //Console.WriteLine("Bobibi a maintenant " + bobi.PV + " points de vie.");

            //Console.WriteLine("Appuyez sur n'importe qu'elle touche pour passer à l'exo suivant");
            //Console.ReadKey();
            //Console.Clear();
            #endregion


            #region Creéation Tableau
            //Création de monde

            Plateau monde = new Plateau();
            monde[5, 5] = "|d|";
            monde[6, Plateau.TAILLE - 1] = "|s|"; //--> si on veut aller à la derniere case de la ligne, on peut faire TAILLE - 1 car les indices commencent à 0
            monde[5, 3] = "|f|";
            monde[1,8] = "|c|";


        
            //Affichage du monde

            for (int y = 0; y < Plateau.TAILLE; y++)
            {
                
                for (int x = 0; x < Plateau.TAILLE; x++)
                    {
                        Console.Write((monde[x, y] ?? "|_|") + '\t');
                        
                    }
                    Console.WriteLine('\n');
            }
            

        
        Console.WriteLine("Appuyez sur n'importe qu'elle touche pour passer à l'exo suivant");
        Console.ReadKey();
        Console.Clear();

            #endregion

            #region HERITAGE EXO


            //Test butin hero : 

            Console.WriteLine("TEST : Création des héros et des monstres :");

            Console.WriteLine("Creation 3 héros : ");

            Humain humain = new("Jean Mi");
            //name = "JeanMi";

            Elf elf = new("Lego Legolas");
            //elf.Nom = "Lego Legolas";

            Nain nain = new("Stoemp");
            //nain.Nom = "Stoemp";

            Console.WriteLine("1er héro");
            Console.WriteLine($"{humain.Nom} l'humain.");
            Console.WriteLine($"Endurance : {humain.Endurance}");
            Console.WriteLine($"Force : {humain.Force}");
            Console.WriteLine($"PV : {humain.PV}");

            Console.WriteLine();

            Console.WriteLine("2e Héro : ");
            Console.WriteLine($"{elf.Nom} l'elf.");
            Console.WriteLine($"Endurance : {elf.Endurance}");
            Console.WriteLine($"Force : {elf.Force}");
            Console.WriteLine($"PV : {elf.PV}");

            Console.WriteLine();

            Console.WriteLine("3e héro");
            Console.WriteLine($"{nain.Nom} le nain.");
            Console.WriteLine($"Endurance : {nain.Endurance}");
            Console.WriteLine($"Force : {nain.Force}");
            Console.WriteLine($"PV : {nain.PV}");

            Console.WriteLine();
            Console.WriteLine("Création de 4 monstres :");


            Loup loup = new();
            Ours ours = new();
            Dragonnet dragonnet = new();
            Bandits bandit = new();

            Console.WriteLine();
            AfficherDetailMonstre(loup);
            Console.WriteLine();
            AfficherDetailMonstre(dragonnet);
            Console.WriteLine();
            AfficherDetailMonstre(bandit);
            Console.WriteLine();
            AfficherDetailMonstre(ours);
            Console.WriteLine();





            //Console.WriteLine("1e Monstre -> Le loup : ");

            //Console.WriteLine($"Endurance : {loup.Endurance}");
            //Console.WriteLine($"Force : {loup.Force}");
            //Console.WriteLine($"PV : {loup.PV}");
            //Console.WriteLine("Son Butin :");
            //foreach(KeyValuePair<string, int> elem in loup.Butin)
            //{
            //    Console.WriteLine($" - {elem.Key} : {elem.Value}");
            //}

            //Console.WriteLine();
            //Console.WriteLine("2e Monstre -> L'ours :");

            //Console.WriteLine($"Endurance : {ours.Endurance}");
            //Console.WriteLine($"Force : {ours.Force}");
            //Console.WriteLine($"PV : {ours.PV}");
            //Console.WriteLine();
            //Console.WriteLine("3e Monstre -> Le dragonnet :");

            //Console.WriteLine($"Endurance : {dragonnet.Endurance}");
            //Console.WriteLine($"Force : {dragonnet.Force}");
            //Console.WriteLine($"PV : {dragonnet.PV}");
            //Console.WriteLine();
            //Console.WriteLine("4e Monstre -> Le Bandit : ");

            //Console.WriteLine($"Endurance : {bandit.Endurance}");
            //Console.WriteLine($"Force : {bandit.Force}");
            //Console.WriteLine($"PV : {bandit.PV}");


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Appuyez sur n'importe qu'elle touche pour passer à l'exo suivant");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\n > TEST BAGARRE");

            Console.WriteLine("Le loup :");
            Console.WriteLine($"Endurance : {loup.Endurance}");
            Console.WriteLine($"Force : {loup.Force}");
            Console.WriteLine($"PV : {loup.PV}");

            humain.Frappe(loup);

            Console.WriteLine("Humain frappe loup : ");
            Console.WriteLine();

            Console.WriteLine("Le loup :");
            Console.WriteLine($"Endurance : {loup.Endurance}");
            Console.WriteLine($"Force : {loup.Force}");
            Console.WriteLine($"PV : {loup.PV}");

            Console.WriteLine();

            Console.WriteLine($"{humain.Nom} l'humain.");
            Console.WriteLine($"PV : {humain.PV}");
            Console.WriteLine($"Endurance : {humain.Endurance}");
            ours.Frappe(humain);
            Console.WriteLine("Ours frappe l'humain :");
            Console.WriteLine("Apres la frappe : ");
            Console.WriteLine();
            Console.WriteLine($"{humain.Nom} l'humain");
            Console.WriteLine($"PV : {humain.PV}");
            Console.WriteLine($"Endurance : {humain.Endurance}");

            humain.Repos();
            Console.WriteLine("humain : ");
            Console.WriteLine($" PV : {humain.PV}");

            Console.WriteLine("Appuyez sur n'importe qu'elle touche pour passer à l'exo suivant");
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region CUISINER + MANGER

            Console.WriteLine("TEST CUISINE");
            Console.WriteLine("L'humain va cuisiner :");
            humain.Cuisiner();
            nain.Butin["Viande"] = 2;
            Console.WriteLine("Le nain va cuisiner");
            nain.Cuisiner();
            Console.WriteLine();
            Console.WriteLine("TEST MANGER");
            humain.SubitDegats(10);
            Console.WriteLine($" l'humain vient de prendre des coups --> PV : {humain.PV}");
            humain.Manger();
            Console.WriteLine("l'humain mange");
            Console.WriteLine($" PV : {humain.PV}");

            Console.WriteLine($" PV du nain avant de graille : {nain.PV}");

            nain.SubitDegats(10);

            Console.WriteLine($" PV apres avoir recu des coups : {nain.PV}");
            Console.WriteLine("Le nain se delecte d'un délicieux repas"); 
            nain.Manger();
            Console.WriteLine($" PV : {nain.PV}");
            Console.WriteLine("Appuyez sur n'importe qu'elle touche pour passer à l'exo suivant");
            Console.ReadKey();
            Console.Clear();

            #endregion
            #region POTION
            Console.WriteLine("TEST POTION");

            Console.WriteLine($"PV Bandit : {bandit.PV}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PV}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PV}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PV}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PV}");
            nain.Frappe(bandit);
            Console.WriteLine($"PV Bandit : {bandit.PV}");
            nain.Frappe(bandit);

            Console.WriteLine("Appuyez sur n'importe qu'elle touche pour passer à l'exo suivant");
            Console.ReadKey();
            Console.Clear();

            #endregion


        }

        static void AfficherDetailMonstre(Monstre monstre)
        {
                    
        //Le loup, l'ours, le dragonnet et le bandit sont tous des Monstres
        // -> Polymorphisme : Une variable "Monstre" peut contenir un des éléments

        // Affichage du nom via le type de la classe
            Console.WriteLine($"1e Monstre -> {monstre.GetType().Name} : ");

            Console.WriteLine($"Endurance : {monstre.Endurance}");
            Console.WriteLine($"Force : {monstre.Force}");
            Console.WriteLine($"PV : {monstre.PV}");
            Console.WriteLine("Son Butin :");
            foreach (KeyValuePair<string, int> elem in monstre.Butin)
            {
                Console.WriteLine($" - {elem.Key} : {elem.Value}");
            }
        }

    }
}