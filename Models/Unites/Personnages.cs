using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Models.Unites
{
    public class Personnage
    {
        public string Nom;
        public int Force;
        public int Endurance;
        public int PV;

        public void Frappe(Personnage_cible, int PV)
        {
            Random lancerDe = new Random();
            int result = lancerDe.Next(1, 5);
            PV -= result;
            
        }

    }

}
