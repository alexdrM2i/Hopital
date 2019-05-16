using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public  class ExamensRadiologiques
    {
        private int id;
        private int resultat;
        private string designation;

        public int Id { get => id; set => id = value; }
        public int Resultat { get => resultat; set => resultat = value; }
        public string Designation { get => designation; set => designation = value; }

        public ExamensRadiologiques()
        {
            
        }
    }
}
