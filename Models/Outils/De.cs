using System.Runtime.CompilerServices;

namespace Models.Outils
{
    public class De   // On l'utilise que dans ce projet, pas besoin de le rendre public
    {
        // Ici on peut garder en public, car on peut vouloir changer la valeur du Max depuis l'extérieur de la classe
        public int Max { get; private set; }

        public int Lancer()
        {
            // Random random = new Random();
            // int result = Random.Shared.Next(Max) + 1;
            // return result; --> une ligne plus courte pour faire la même chose : 

            return Random.Shared.Next(this.Max) + 1;

            // this = self.Max, pour différencier la variable de classe Max de la variable locale Max (si jamais on en avait une)
            // Le mot clé "this" représente l'instance actuelle de la classe, et permet d'accéder à ses membres (variables, méthodes, etc.)
            // Il n'est pas nécessaire d'utiliser "this" dans ce cas, car il n'y a pas de conflit de noms entre la variable locale et la variable de classe. Cependant, l'utilisation de "this" peut améliorer la lisibilité du code en indiquant clairement que nous faisons référence à un membre de la classe.
        }

        public De (int max) 
        {
        this.Max = max;
        }
    }
}
