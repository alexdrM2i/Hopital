using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class Chirurgie
    {
        private int id;
        private string chirurgien;
        private string anesthesiste;

        public int Id { get => id; set => id = value; }
        public string Chirurgien { get => chirurgien; set => chirurgien = value; }
        public string Anesthesiste { get => anesthesiste; set => anesthesiste = value; }

        public Chirurgie()
        {
            
        }
    }
}
