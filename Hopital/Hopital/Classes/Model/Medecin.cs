using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class Medecin
    {
        private int id; 
        private string nom;
        private string prenom;
        private string tel;
        private int codeSpecialite;
        private int idService;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Tel { get => tel; set => tel = value; }
        public int CodeSpecialite { get => codeSpecialite; set => codeSpecialite = value; }
        public int IdService { get => idService; set => idService = value; }

        public Medecin()
        {
            
        }


    }
    
}
