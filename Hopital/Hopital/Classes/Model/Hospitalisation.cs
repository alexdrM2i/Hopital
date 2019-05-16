using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
   public class Hospitalisation
    {
        private int idAdmission;
        private DateTime dateAdmission;
        private string typeAdmission;
        private string medecinTraitant;
        private string nomAccompagnant;
        private string prenomAccompagnant;
        private string lienAccompagnant;
        private DateTime dateSortieAcc;
        private DateTime dateEntreeAcc;
        private DateTime motifSortie;
        private string resultatSortie;
        private DateTime dateDeces;
        private DateTime motifDeces;

        public int IdAdmission { get => idAdmission; set => idAdmission = value; }
        public DateTime DateAdmission { get => dateAdmission; set => dateAdmission = value; }
        public string MedecinTraitant { get => medecinTraitant; set => medecinTraitant = value; }
        public string NomAccompagnant { get => nomAccompagnant; set => nomAccompagnant = value; }
        public string PrenomAccompagnant { get => prenomAccompagnant; set => prenomAccompagnant = value; }
        public string LienAccompagnant { get => lienAccompagnant; set => lienAccompagnant = value; }
        public DateTime DateEntreeAcc { get => dateEntreeAcc; set => dateEntreeAcc = value; }
        public DateTime DateSortieAcc { get => dateSortieAcc; set => dateSortieAcc = value; }
        public DateTime MotifSortie { get => motifSortie; set => motifSortie = value; }
        public string ResultatSortie { get => resultatSortie; set => resultatSortie = value; }
        public DateTime DateDeces { get => dateDeces; set => dateDeces = value; }
        public DateTime MotifDeces { get => motifDeces; set => motifDeces = value; }
        public string TypeAdmission { get => typeAdmission; set => typeAdmission = value; }

        public Hospitalisation()
        {
            
        }
    }
}
