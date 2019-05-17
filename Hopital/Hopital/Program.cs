using Hopital.Classes;
using System;

namespace Hopital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quel est votre nom ? : ");
            string nom = Console.ReadLine();
            DataBase.Instance.GetPatient(nom);
            DataBase.Instance.GetRdvByIdPatient();
            //Menu.Accueil();

            Console.ReadLine();
        }
    }
}
