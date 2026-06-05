using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Unites.Monstres
{
    public class Ours : Monstre
    {
        public override int Force => base.Force + 2;
  


        public int Peau { get; set; }

        public int Viande { get; set; }

        public int Griffes { get; set; }

    }

}
