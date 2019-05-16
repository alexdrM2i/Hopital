using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class Prescription
    {
        private int idPatien;
        private DateTime datePrescription;
        private string nomPatien;
        private string prenomPatien;
        private string note;

        public int IdPatien { get => idPatien; set => idPatien = value; }
        public DateTime DatePrescription { get => datePrescription; set => datePrescription = value; }
        public string NomPatien { get => nomPatien; set => nomPatien = value; }
        public string PrenomPatien { get => prenomPatien; set => prenomPatien = value; }
        public string Note { get => note; set => note = value; }

        public Prescription()
        {
            
        }
    }
}
