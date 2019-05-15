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

        static List<Specialite> listeSpecialites = new List<Specialite>();

        public static List<Specialite> GetSpecialite()
        {
            
            SqlCommand command = new SqlCommand("SELECT * FROM Spec", Connection.Instance);
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Specialite s = new Specialite()
                {
                    Id = reader.GetInt32(0),
                    SpecialiteM = reader.GetString(1),
                    CodeSpec = reader.GetInt32(2)
                };
                listeSpecialites.Add(s);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return listeSpecialites;

        }

        public static void AddMedecin()
        {
            Medecin m = new Medecin();
            Console.Write("Nom du medecin: ");
            m.Nom = Console.ReadLine();
            Console.Write("Prénom du medecin: ");
            m.Prenom = Console.ReadLine();
            Console.Write("Téléphone du medecin: ");
            m.Tel = Console.ReadLine();
            Console.Write("Quelle spécialité ? : ");
            foreach(Specialite s in GetSpecialite())
            {
                Console.Write(s.CodeSpec.ToString()+" "+ s.SpecialiteM+" / ");
            }
            m.CodeSpecialite = Convert.ToInt32(Console.ReadLine());
            // listeSpecialites.ForEach(x => Console.WriteLine(x.CodeSpec.ToString(), x.SpecialiteM));
            
            SqlCommand command = new SqlCommand("INSERT INTO Medecin (Nom, Prenom, Tel, CodeSpecialite) OUTPUT INSERTED.ID VALUES(@n,@p,@t,@cs)", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@n", m.Nom));
            command.Parameters.Add(new SqlParameter("@p", m.Prenom));
            command.Parameters.Add(new SqlParameter("@t", m.Tel));
            command.Parameters.Add(new SqlParameter("@cs", m.CodeSpecialite));

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
