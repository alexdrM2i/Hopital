using Hopital.Classes.Model;
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

        #region GESTTION DES CONSULTATIONS
        #endregion

        #region GESTION PARTIE MEDECIN
        List<Specialite> listeSpecialites = new List<Specialite>();
        public List<Specialite> GetSpecialite()
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

        List<Medecin> listeMedecins = new List<Medecin>();
        public List<Medecin> GetMedecinById(int id)
        {
            SqlCommand command = new SqlCommand("SELECT m.Nom, m.Prenom FROM Medecin as m where m.idservice= @id", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@id", id));
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Medecin m = new Medecin()
                {
                    Nom = reader.GetString(0),
                    Prenom = reader.GetString(1),

                };
                listeMedecins.Add(m);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return listeMedecins;
        }

        public void AddMedecin()
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

        List<Service> listeServices = new List<Service>();
        public List<Service> GetService()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Service", Connection.Instance);
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Service s = new Service()
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                };
                listeServices.Add(s);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return listeServices;
        }
        #endregion

        #region GESTION PARTIE PATIENT
        public void AddPatient()
        {
            Console.WriteLine(Messages.TitreAjouterPatient);
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
       
        public Patient GetPatient(string nom)
        {
            SqlCommand command = new SqlCommand("SELECT Id, Nom, Prenom, DateNaissance, Sexe, Adresse, Tel FROM Patient WHERE Nom = @n", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@n", nom));
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            Patient p = new Patient();
            if (reader.Read())
            {      
                {
                    p.Id = reader.GetInt32(0);
                    p.Nom = reader.GetString(1);
                    p.Prenom = reader.GetString(2);
                    p.DateNaissance = reader.GetString(3);
                    p.Sexe = reader.GetString(4);
                    p.Adresse = reader.GetString(5);
                    p.Tel = reader.GetString(6);
                };
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return p;
        }

        public void AddRDV()
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Patient p = GetPatient(nom);
            if (p.Nom == nom)
            {
                Console.WriteLine("Listes des services : ");
                Console.WriteLine("--------------------");
                foreach (Service s in GetService())
                {
                    Console.WriteLine(s.Id + " - "+s.Nom);
                }
                Console.Write("Dans quel service souhaitez-vous un rendez-vous ? : ");
                int choixService = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Listes des medecins de ce service : ");
                Console.WriteLine("--------------------");
                foreach (Medecin m in GetMedecinById(choixService))
                {
                    Console.WriteLine($"{m.Nom}, {m.Prenom}, {m.Tel}");
                }
                Console.Write("Saisissez le nom ET le prénom de votre medecin : ");
                string choixMedecin = Console.ReadLine();
                Console.WriteLine("Date de RDV souhaitée : (JJ/MM/AAAA HH:MM)");
                DateTime dateRDV = Convert.ToDateTime(Console.ReadLine());             
                string CodeRDV = Guid.NewGuid().ToString();

                SqlCommand command = new SqlCommand("INSERT INTO RDV (CodeRDV, Medecin, DateRDV, Service, IdPatient) VALUES(@c,@m,@d,@s,@i)", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@c", CodeRDV));
                command.Parameters.Add(new SqlParameter("@m", choixMedecin));
                command.Parameters.Add(new SqlParameter("@d", dateRDV));
                command.Parameters.Add(new SqlParameter("@s", choixService));
                command.Parameters.Add(new SqlParameter("@i", p.Id));
                Connection.Instance.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                Connection.Instance.Close();
            }
            else { AddPatient(); AddRDV(); }
            
        }
        #endregion
    }
}
