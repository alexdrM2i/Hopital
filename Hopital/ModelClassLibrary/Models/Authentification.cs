using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModelClassLibrary.Models
{
    public class Authentification
    {
        public string Identifiant { get; set; }
        public string Password { get; set; }

        //public static List<Authentification> listAuthentification ;

        public Authentification()
        {
        }

        public Authentification(string i, string p)
        {
            Identifiant = i;
            Password = p;
        }
        public static ObservableCollection<Authentification> ListIdentifiant()
        {
            ObservableCollection<Authentification> listAuthentification = new ObservableCollection<Authentification>
            {
                new Authentification( "abdel",  "abdel1"),
                new Authentification(  "fabien", "fabien1"),
                new Authentification( "alex",   "alex1"),
                new Authentification( "olivier",  "olivier1"),
                new Authentification("ihab", "ihab1") 
            };
            return listAuthentification;
        }

    }
}
