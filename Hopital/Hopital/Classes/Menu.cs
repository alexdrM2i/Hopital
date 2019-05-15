using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public static class Menu
    {
        private static int choix = 999;

        public static void Accueil()
        {
            Titre();
            MenuPrincipal();
        }
        /// <summary>
        /// Génération du titre du projet
        /// </summary>
        private static void Titre()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Bienvenue dans la gestion HOPITAL M2I");
            Console.WriteLine("----------------------------------------------------");
        }
        /// <summary>
        /// Génération du corps du Menu
        /// </summary>
        private static void MenuPrincipal()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Menu principal");
            Console.WriteLine(" ");

            do
            {
                Console.WriteLine("1 - Gestion du patient");
                Console.WriteLine("2 - Gestion du médecin");
                Console.WriteLine("2 - Gestion du médecin");
                Console.WriteLine("0 - Quitter");
                Console.WriteLine(" ");
                Console.Write(" Veuillez indiquer votre choix : ");
                try
                {
                    choix = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(MessageErreur.NotANumber);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (choix != 0);

        }
    }
}
