using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Hopital.Classes
{
    public class DataBase
    {
        private static DataBase _instance = null;
        private static object _lock = new object();

        public static DataBase Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DataBase();
                    }
                    return _instance;
                }
            }
        }
        private DataBase()
        {

        }

        public static void AddMedecin()
        {
            Medecin m = new Medecin();
            Console.Write("Entrer votre nom: ");
            m.Nom = Console.ReadLine();
            Console.Write("Entrer votre prénom: ");
            m.Prenom = Console.ReadLine();
            Console.Write("Entrer votre numéro de téléphone: ");
            m.Tel = Console.ReadLine();
            SqlCommand command = new SqlCommand("INSERT INTO Medecin (Nom, Prenom, Tel) OUTPUT INSERTED.ID VALUES(@n,@p,@t)", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@n", m.Nom));
            command.Parameters.Add(new SqlParameter("@p", m.Prenom));
            command.Parameters.Add(new SqlParameter("@t", m.Tel));
            Connection.Instance.Open();
            m.Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
        }

        public static void AddPatient()
        { 
            Patient p = new Patient();
            Console.Write("Nom: ");
            p.Nom = Console.ReadLine();
            Console.Write("Prénom: ");
            p.Prenom = Console.ReadLine();
            Console.Write("Date de naissance: ");
            p.DateNaissance = Console.ReadLine();
            Console.Write("Sexe: F/M ");
            p.Sexe = Console.ReadLine();
            Console.Write("Adresse: ");
            p.Adresse = Console.ReadLine();
            Console.Write("Numéro de téléphone: ");
            p.Tel = Console.ReadLine();
            SqlCommand command = new SqlCommand("INSERT INTO Patient (Nom, Prenom, DateNaissance, Sexe, Adresse, Tel) OUTPUT INSERTED.ID VALUES(@n,@p,@d,@s,@a,@t)", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@n", p.Nom));
            command.Parameters.Add(new SqlParameter("@p", p.Prenom));
            command.Parameters.Add(new SqlParameter("@d", p.DateNaissance));
            command.Parameters.Add(new SqlParameter("@s", p.Sexe));
            command.Parameters.Add(new SqlParameter("@a", p.Adresse));
            command.Parameters.Add(new SqlParameter("@t", p.Tel));
            Connection.Instance.Open();
            p.Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();

        }
    }
}
