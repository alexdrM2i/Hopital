using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{

    public class Specialite
    {
        private int id;  
        private string specialiteM;
        private int codeSpec;
         
        public int Id { get => id; set => id = value; }
        public string SpecialiteM { get => specialiteM; set => specialiteM = value; }
        public int CodeSpec { get => codeSpec; set => codeSpec = value; }

        public Specialite()
        {
        }

    }

}
