using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
   public class Traitement
   {
       private int id;
       private DateTime date;
       private int prix;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Prix { get => prix; set => prix = value; }

        public Traitement()
        {
            
        }
    }
}
