using Hopital.Classes.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace Hopital.Classes
{
    public class DataBase
    {
        private static DataBase _instance = null;
        private static object _lock = new object();
        private static List<Specialite> _getSpec = null;

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

        /// <summary>
        /// Liste la totalité des spécificités
        /// </summary>
        /// <returns></returns>
        public List<Specialite> ListAllSpec()
        {
            _getSpec = new List<Specialite>();
            _getSpec = GetSpecialite();

            Console.WriteLine(" ");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("                  AFFICHAGE DE LA LISTE DES SPECIALITES                     ");
            Console.WriteLine(" --------------------------------------------------------------------------------------");

            _getSpec.ForEach(x =>
             Console.WriteLine($"Id : {x.Id}     Code spécialité : {x.CodeSpec}   Spécialité : {x.SpecialiteM}")
             );

            return _getSpec;
        }
        /// <summary>
        /// Ajoute une spécificité en base
        /// </summary>
        public void AddSpecialite()
        {
            Specialite spec = new Specialite();

            bool res = false;
            _getSpec = new List<Specialite>();
            _getSpec = ListAllSpec();

            Console.WriteLine($"{Messages.TitreAjouterSpecialiteMedecin}");
            Console.Write($"{ Messages.TitreNouvelleSpecialiteMedecin}");
            spec.SpecialiteM = Console.ReadLine();

            do
            {
                res = _getSpec.Exists(x => x.SpecialiteM.ToLower().Contains(spec.SpecialiteM.ToLower()));
                if (res)
                {
                    Messages.AfficherMessageErreur("Cette spécialité existe déjà");
                    Console.WriteLine(" ");
                    Console.Write($"{ Messages.TitreNouvelleSpecialiteMedecin} :");
                    spec.SpecialiteM = Console.ReadLine();
                }
            }
            while (res);

            int max = _getSpec[0].CodeSpec;

            for (int i = 1; i < _getSpec.Count; i++)
            {
                if (max <= _getSpec[i].CodeSpec)
                {
                    max = _getSpec[i].CodeSpec;
                }
            }
            max = max + 1;

            SqlCommand command = new SqlCommand("INSERT INTO Spec (Specialite, CodeSpec) OUTPUT INSERTED.Id VALUES (@s, @c)", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@s", spec.SpecialiteM[0].ToString().ToUpper() + spec.SpecialiteM.Substring(1).ToLower()));
            command.Parameters.Add(new SqlParameter("@c", max));
            Connection.Instance.Open();
            spec.Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();

            Messages.AfficherMessageInsertOk(Messages.InsertOk);
        }

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

        public List<Medecin> GetMedecinByName(string name)
        {
            SqlCommand command = new SqlCommand("SELECT m.Id, m.Nom, m.Prenom FROM Medecin as m where m.Nom= @name", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@name", name));
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

        public void UpdateMedecin()
        {
            string SpecM = string.Empty;
            string nomM = string.Empty;
            int idSpec = 0;
            int idM = 0;

            do
            {
                Console.Write("Veuillez saisir la spécialité du médecin : ");
                SpecM = Console.ReadLine();

                listeSpecialites = new List<Specialite>();

                listeSpecialites = GetSpecialite();
               
                listeSpecialites.ForEach(x =>
                {
                    if (x.SpecialiteM.ToLower() == SpecM.ToLower())
                    {
                        idSpec = x.Id;
                    }
                });
                if(listeSpecialites.Count == 0)
                {
                    Console.WriteLine("La specialité n'existe pas");
                }
            }
            while (listeSpecialites.Count == 0);

            do
            {
                Console.Write("Veuillez saisir le nom du médecin : ");
                nomM = Console.ReadLine();
                listeMedecins = new List<Medecin>();
                listeMedecins = GetMedecinByName(nomM);
                listeMedecins.ForEach(x =>
                {
                    if (x.Nom.ToLower() == nomM.ToLower())
                    {
                        idM = x.Id;
                    }
                });
                if (listeMedecins.Count == 0)
                {
                    Console.WriteLine("Aucun médecin sous ce nom");
                }
            }
            while (listeMedecins.Count == 0);

            listeMedecins = GetMedecinById(idM);

            listeMedecins.ForEach(x => Console.WriteLine(x.ToString()));
           
              

          
        
        }

        public void AddMedecin()
        {
            Medecin m = new Medecin();
            Console.Write($"{Messages.MedecinNom}");
            m.Nom = Console.ReadLine();
            Console.Write($"{Messages.MedecinPrenom}");
            m.Prenom = Console.ReadLine();
            Console.Write($"{Messages.MedecinTelephone}");
            m.Tel = Console.ReadLine();
            Console.Write($"{Messages.MedecinSpecialite}");
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
            SqlCommand command = new SqlCommand("INSERT INTO Medecin (Nom, Prenom, Tel, CodeSpecialite, IdService) OUTPUT INSERTED.ID VALUES(@n,@p,@t,@cs,@i)", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@n", m.Nom));
            command.Parameters.Add(new SqlParameter("@p", m.Prenom));
            command.Parameters.Add(new SqlParameter("@t", m.Tel));
            command.Parameters.Add(new SqlParameter("@cs", m.CodeSpecialite));
            command.Parameters.Add(new SqlParameter("@i", m.IdService));
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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Messages.TitreAjouterPatient);
            Patient p = new Patient();
            Console.Write($"{Messages.PatientNom}");
            p.Nom = Console.ReadLine();
            Console.Write($"{Messages.PatientPrenom}");
            p.Prenom = Console.ReadLine();
            Console.Write($"{Messages.PatientDateNaissance}");
            p.DateNaissance = Console.ReadLine();
            Console.Write($"{Messages.PatientSexe} ");
            p.Sexe = Console.ReadLine();
            Console.Write($"{Messages.PatientAdresse}");
            p.Adresse = Console.ReadLine();
            Console.Write($"{Messages.PatientTel} ");
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
                command.Parameters.Add(new SqlParameter("@si", ""));
                command.Parameters.Add(new SqlParameter("@np", ""));
                command.Parameters.Add(new SqlParameter("@nm", ""));
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
                    Console.WriteLine($"{m.Id} - {m.Nom}, {m.Prenom}, {m.Tel}");
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
                Console.WriteLine($"Code du rendez-vous: {CodeRDV},\n Service: {nomService}, Nom du medecin: {nomMedecin}, Date : {dateRDV}");
            }
            else { AddPatient(); AddRDV(); }
        }

        List<RDV> listeRDV = new List<RDV>();
        public List<RDV> GetRdvByIdPatient(int id)
        {
            {
                SqlCommand command = new SqlCommand("SELECT Medecin, DateRDV, Service FROM RDV where IdPatient = @id", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@id", id));
                Connection.Instance.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    RDV r = new RDV()
                    {
                        Medecin = reader.GetString(0),
                        DateRDV = reader.GetDateTime(1),
                        Service = reader.GetString(2)
                    };
                    listeRDV.Add(r);
                }
                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                return listeRDV;
            }
            #endregion
        }
    }
}
