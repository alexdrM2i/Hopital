using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class ExamensBiologiques
    {
        private int id;
        private string designation;
        private int resultat;

        public int Id { get => id; set => id = value; }
        public string Designation { get => designation; set => designation = value; }
        public int Resultat { get => resultat; set => resultat = value; }
    }
}
