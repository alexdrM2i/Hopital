using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class Patient
    {
        private int id;
        private string nom;
        private string prenom;
        private string dateNaissance;
        private string sexe;
        private string adresse;
        private string situation;
        private string assurance;
        private string codeAssurance;
        private string tel;
        private string nomPere;
        private string nomMere;
        private string nomPersPrevenir;
        private string telPersPrevenir;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Sexe { get => sexe; set => sexe = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Situation { get => situation; set => situation = value; }
        public string Assurance { get => assurance; set => assurance = value; }
        public string CodeAssurance { get => codeAssurance; set => codeAssurance = value; }
        public string Tel { get => tel; set => tel = value; }
        public string NomPere { get => nomPere; set => nomPere = value; }
        public string NomMere { get => nomMere; set => nomMere = value; }
        public string NomPersPrevenir { get => nomPersPrevenir; set => nomPersPrevenir = value; }
        public string TelPersPrevenir { get => telPersPrevenir; set => telPersPrevenir = value; }
    }
}
