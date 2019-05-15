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
            Console.WriteLine(Messages.TitreProjet);
            Console.WriteLine("----------------------------------------------------");
        }
        /// <summary>
        /// Génération du corps du Menu
        /// </summary>
        private static void MenuPrincipal()
        {
            Console.WriteLine(" ");
            Console.WriteLine(Messages.MenuPrincipal);
            Console.WriteLine(" ");

            do
            {
                Console.WriteLine("1 - Gestion du patient");
                Console.WriteLine("2 - Gestion du médecin");
                Console.WriteLine("3 - Gestion du médecin");
                Console.WriteLine("0 - Quitter");
                Console.WriteLine(" ");
                Console.Write(Messages.Choix);
                try 
                {
                    choix = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(Messages.NotANumber);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.White;
                }

                switch (choix)
                {
                    case 1:
                        MenuPatient();
                        break;
                    case 2:
                        MenuMedecin();
                        break;
                    case 3:
                        break;
                    case 0:
                        Console.Write(Messages.Sortie);
                        string choixSortie = Console.ReadLine();
                        //
                        if (choixSortie.ToUpper() == "O")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            Accueil();
                        }


                        break;
                }
            }
            while (choix != 0);

        
        }

        private static void MenuMedecin()
        {
            Console.Clear();
            Titre();
            Console.WriteLine(Messages.TitreMedecin);
            Console.WriteLine($"1 - {Messages.TitreAjouterMedecin}");
            Console.WriteLine($"2 - {Messages.TitreModifierMedecin}");
        }

        private static void MenuPatient()
        {
            
        }
    }
}
