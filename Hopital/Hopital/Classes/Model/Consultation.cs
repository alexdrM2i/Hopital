using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class Consultation
    {
        private int id;
        private DateTime date;
        private string synthese;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Synthese { get => synthese; set => synthese = value; }

        public Consultation()
        {
            
        }
    }
}
