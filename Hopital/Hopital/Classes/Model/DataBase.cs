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
            SqlCommand command = new SqlCommand("SELECT m.Id, m.Nom, m.Prenom FROM Medecin as m where m.idservice= @id", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@id", id));
            Connection.Instance.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Medecin m = new Medecin()
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),

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
            foreach (Specialite s in GetSpecialite())
            {
                Console.Write(s.CodeSpec.ToString() + " " + s.SpecialiteM + " / ");
            }
            m.CodeSpecialite = Convert.ToInt32(Console.ReadLine());
            //string c = GetSpecialite().Find((x) => x.CodeSpec == m.CodeSpecialite).SpecialiteM;
            if (m.CodeSpecialite == 1) m.IdService = 2;
            else if (m.CodeSpecialite == 2) m.IdService = 1;
            else if (m.CodeSpecialite == 3) m.IdService = 2;
            else if (m.CodeSpecialite == 4) m.IdService = 7;
            else if (m.CodeSpecialite == 5) m.IdService = 4;
            else if (m.CodeSpecialite == 6) m.IdService = 6;
            else if (m.CodeSpecialite == 7) m.IdService = 3;
            SqlCommand command = new SqlCommand("INSERT INTO Medecin (Nom, Prenom, Tel, CodeSpecialite, IdService) OUTPUT INSERTED.ID VALUES(@n,@p,@t,@cs)", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@n", m.Nom));
            command.Parameters.Add(new SqlParameter("@p", m.Prenom));
            command.Parameters.Add(new SqlParameter("@t", m.Tel));
            command.Parameters.Add(new SqlParameter("@cs", m.CodeSpecialite));
            command.Parameters.Add(new SqlParameter("@cs", m.IdService));
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
            Console.WriteLine("--- Enregistrement patient ---");
            Patient p = new Patient();
            Console.Write("Nom: ");
            p.Nom = Console.ReadLine();
            Console.Write("Prénom: ");
            p.Prenom = Console.ReadLine();
            Console.Write("Date de naissance: ");
            p.DateNaissance = Console.ReadLine();
            Console.Write("Sexe ? F/H :");
            p.Sexe = Console.ReadLine();
            Console.Write("Adresse: ");
            p.Adresse = Console.ReadLine();
            Console.Write("Numéro de téléphone: ");
            p.Tel = Console.ReadLine();
            Console.Write("Numéro de Sécurité Sociale : ");
            p.Assurance = Console.ReadLine();
            Console.Write("Nom de la personne à prevenir en cas d'urgence : ");
            p.NomPersPrevenir = Console.ReadLine();
            Console.WriteLine("Numéro de téléphone de la personne à prevenir : ");
            p.TelPersPrevenir = Console.ReadLine();

            SqlCommand command = new SqlCommand("INSERT INTO Patient (Nom, Prenom, DateNaissance, Sexe, Adresse, Tel, Assurance, NomPersPrevenir, TelPersPrevenir, Situation, NomPere, NomMere) OUTPUT INSERTED.ID VALUES(@n,@p,@d,@s,@ad,@t,@ass,@nps,@tps,@si,@np,@nm)", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@n", p.Nom));
            command.Parameters.Add(new SqlParameter("@p", p.Prenom));
            command.Parameters.Add(new SqlParameter("@d", p.DateNaissance));
            command.Parameters.Add(new SqlParameter("@s", p.Sexe));
            command.Parameters.Add(new SqlParameter("@ad", p.Adresse));
            command.Parameters.Add(new SqlParameter("@t", p.Tel));
            command.Parameters.Add(new SqlParameter("@ass", p.Assurance));
            command.Parameters.Add(new SqlParameter("@nps", p.NomPersPrevenir));
            command.Parameters.Add(new SqlParameter("@tps", p.TelPersPrevenir));

            Console.WriteLine("Voulez-vous renseigner votre situation ainsi que les noms de vos parents ? O/N : ");
            string input = Console.ReadLine().ToLower();
            if (input == "o")
            {
                Console.WriteLine("Situation familiale : ");
                p.Situation = Console.ReadLine();
                Console.WriteLine("Nom de votre mère : ");
                p.NomMere = Console.ReadLine();
                Console.WriteLine("Nom de votre père : ");
                p.NomPere = Console.ReadLine();

                command.Parameters.Add(new SqlParameter("@si", p.Situation));
                command.Parameters.Add(new SqlParameter("@np", p.NomPere));
                command.Parameters.Add(new SqlParameter("@nm", p.NomMere));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("@si", "non renseigné"));
                command.Parameters.Add(new SqlParameter("@np", "non renseigné"));
                command.Parameters.Add(new SqlParameter("@nm", "non renseigné"));
            }
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
            Console.WriteLine($"Patient n° {p.Id} : {p.Nom} {p.Prenom} - Né(e) le: {p.DateNaissance}\nCoordonnées: {p.Adresse}, {p.Tel}");
            Console.WriteLine("");
            return p;
        }

        public void AddRDV()
        {
            Console.WriteLine("--- Prise de rendez-vous ---");
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Patient p = GetPatient(nom);
            if (p.Nom == nom)
            {
                Console.WriteLine("Listes des services : ");
                Console.WriteLine("--------------------");
                foreach (Service s in GetService())
                {
                    Console.WriteLine(s.Id + " - " + s.Nom);
                }
                Console.Write("Dans quel service souhaitez-vous un rendez-vous ? : ");
                int choixService = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Listes des medecins de ce service : ");
                Console.WriteLine("--------------------");
                string nomService = null;
                listeServices.ForEach(x =>
                {
                    if (x.Id == choixService)
                    nomService = x.Nom;
                });
                foreach (Medecin m in GetMedecinById(choixService))
                {
                    Console.WriteLine($"Identifiant: {m.Id} - {m.Nom} {m.Prenom}, {m.Tel}");
                }
                Console.Write("Saisissez l' identifiant du medecin : ");
                int choixMedecin = Convert.ToInt32(Console.ReadLine());
                string nomMedecin = null;
                listeMedecins.ForEach(x =>
                {
                    if (x.Id == choixMedecin) { nomMedecin = $" {x.Nom} {x.Prenom}"; }
                });
                Console.WriteLine("Date de RDV souhaitée : (JJ/MM/AAAA HH:MM)");
                DateTime dateRDV = Convert.ToDateTime(Console.ReadLine());
                string CodeRDV = Guid.NewGuid().ToString();
                SqlCommand command = new SqlCommand("INSERT INTO RDV (CodeRDV, Medecin, DateRDV, Service, IdPatient) VALUES(@c,@m,@d,@s,@i)", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@c", CodeRDV));
                command.Parameters.Add(new SqlParameter("@m", nomMedecin));
                command.Parameters.Add(new SqlParameter("@d", dateRDV));
                command.Parameters.Add(new SqlParameter("@s", nomService));
                command.Parameters.Add(new SqlParameter("@i", p.Id));
                Connection.Instance.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                Connection.Instance.Close();
                Console.WriteLine(Messages.RdvAjoute);
                Console.WriteLine($"Code du rendez-vous: {CodeRDV},\nService: {nomService}, Nom du medecin: {nomMedecin}, Date : {dateRDV}");
            }
            else { AddPatient(); AddRDV(); }
        }

        List<RDV> listeRDV = new List<RDV>();
        public List<RDV> GetRdvByIdPatient()
        {
            {
                Console.Write("Entrer le numéro du patient pour voir ses rendez-vous: ");
                int id = Convert.ToInt32(Console.ReadLine());
                SqlCommand command = new SqlCommand("SELECT Id, Medecin, DateRDV, Service FROM RDV where IdPatient = @id", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@id", id));
                Connection.Instance.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RDV r = new RDV()
                    {
                        Id = reader.GetInt32(0),
                        Medecin = reader.GetString(1),
                        DateRDV = reader.GetDateTime(2),
                        Service = reader.GetString(3)
                    };
                    listeRDV.Add(r);
                }
                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                Console.WriteLine("--- Liste des rendez-vous ---");
                foreach (RDV r in listeRDV)
                {
                    Console.WriteLine($"RDV n°: {r.Id} - Date: {r.DateRDV} avec Dr {r.Medecin} en {r.Service}");
                }
                return listeRDV;
            }
            #endregion
        }
    }
}
