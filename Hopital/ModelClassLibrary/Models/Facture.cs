using System;
using System.Data.SqlClient;

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
       private static SqlCommand command;

       public Facture()
       {
           
       }

       public bool Enregistrer()
       {
           bool res = false;
           command = new SqlCommand("INSERT INTO Facture(patient, datetime, total) OUTPUT INSERTED.ID values(@f, @d, @t)", Connection.Instance);
           command.Parameters.Add(new SqlParameter("@c", id));
           command.Parameters.Add(new SqlParameter("@p", date));
           command.Parameters.Add(new SqlParameter("@s", total));
        
           Connection.Instance.Open();
           Id = (int)command.ExecuteScalar();
           command.Dispose();
           Connection.Instance.Close();
           res = (Id > 0);
           return res;
        }
       
    }
}
