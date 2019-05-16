using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
   public class Facture
   {
       private int id;
       private DateTime date;
       private int total;

       public int Id { get => id; set => id = value; }
       public DateTime Date { get => date; set => date = value; }
       public int Total { get => total; set => total = value; }

       public Facture()
       {
           
       }

       
    }
}
