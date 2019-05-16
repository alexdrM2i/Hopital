using Hopital.Classes;
using System;

namespace Hopital
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase.Instance.AddRDV();
            //Menu.Accueil();

            Console.ReadLine();
        }
    }
}
