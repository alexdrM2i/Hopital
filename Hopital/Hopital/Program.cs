using Hopital.Classes;
using System;

namespace Hopital
{
    class Program
    {
        static void Main(string[] args)
        {
            Medecin m = new Medecin();
            m.Add();
            Menu.Accueil();
            Console.ReadLine();
        }
    }
}
