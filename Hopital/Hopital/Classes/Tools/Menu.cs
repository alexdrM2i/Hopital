using System;
using System.Threading;

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
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"      {Messages.TitreProjet}         ");
            Console.WriteLine("----------------------------------------------------");
            Console.ResetColor();
        }
        /// <summary>
        /// Génération du corps du Menu
        /// </summary>
        /// 
        private static void MenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine(Messages.MenuPrincipal);
            Console.WriteLine(" ");

            do
            {
                Console.WriteLine($"1 - {Messages.TitrePatients}");
                Console.WriteLine($"2 - {Messages.TitreMedecin}");
                Console.WriteLine($"9 - {Messages.ClearConsole}");
                Console.WriteLine("0 - Quitter");
                Console.WriteLine(" ");
                Console.Write(Messages.Choix);
                try
                {
                    choix = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Messages.AfficherMessageErreur(Messages.NotANumber);
                }

                switch (choix)
                {
                    case 1:
                        MenuPatientPrincipal();
                        break;
                    case 2:
                        MenuMedecinPrincipal();
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
                    case 9:
                        Console.Clear();
                        Accueil();
                        break;

                    default:
                        Messages.AfficherMessageErreur(Messages.NoFunction);

                        break;
                }
            }
            while (choix != 0);
        }

        private static void MenuMedecinPrincipal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Titre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine(Messages.TitreMedecin);
            Console.WriteLine(" ");
            Console.WriteLine($"1 - {Messages.TitreAjouterMedecin}");
            Console.WriteLine($"2 - {Messages.TitreModifierMedecin}");
            Console.WriteLine($"3 - {Messages.TitreAjouterSpecialiteMedecin}");
            Console.WriteLine($"0 - {Messages.RetourMenuPrincipal}");

            do
            {
                try
                {
                    Console.WriteLine(Messages.Choix);
                    choix = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Messages.AfficherMessageErreur(Messages.NotANumber);
                }
                switch (choix)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.White;
                        DataBase.Instance.AddMedecin();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.White;
                        DataBase.Instance.UpdateMedecin();
                        break;
                    case 3:
                        Console.Clear();
                        MenuMedecinSpecialite();
                        Console.Write("Tapez 1 pour menu Medecin - Tapez 2 pour menu spécialité");
                        int choixM = Convert.ToInt32(Console.ReadLine());
                        switch (choixM)
                        {
                            case 1:
                                MenuMedecinPrincipal();
                                break;
                            case 2:
                                MenuMedecinSpecialite();
                                break;
                        }
                        break;

                    case 0:
                        Accueil();
                        break;
                    default:
                        Console.WriteLine("aucune fonction");
                        break;
                }
            }
            while (choix != 3);
        }

        private static void MenuPatientPrincipal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Titre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine($"{Messages.TitrePatients}");
            Console.WriteLine(" ");

            Console.WriteLine($"1 - {Messages.TitreAjouterPatient}");
            Console.WriteLine($"2 - {Messages.TitreModifierPatient}");
            Console.WriteLine($"3 - {Messages.TitreAjouterRDVPatient}");
            Console.WriteLine($"4 - {Messages.TitreModifierRDVPatient}");
            Console.WriteLine($"0- {Messages.RetourMenuPrincipal}");

            choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 0:
                    Console.Clear();
                    Accueil();
                    break;
                case 1:
                    Console.Clear();
                    Titre();
                    DataBase.Instance.AddPatient();
                    Thread.Sleep(3000);
                    Console.Clear();
                    Titre();
                    break;
                case 2:
                    Console.Clear();
                    Titre();
                    // DataBase.Instance.AddPatient();
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Titre();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"{Messages.TitreAjouterRDVPatient}");
                    DataBase.Instance.AddRDV();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Titre();
                    Console.Clear();
                    break;

            }

        }

        private static void MenuMedecinSpecialite()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Titre();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine($"{Messages.TitreSpecialiteMedecin}");
            Console.WriteLine($"1 - {Messages.TitreListerSpecialiteMedecin}");
            Console.WriteLine($"2 - {Messages.TitreAjouterSpecialiteMedecin}");

            Console.WriteLine($"0 - {Messages.RetourMenuPrincipalMedecin}");

            try
            {
                choix = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {

                Messages.AfficherMessageErreur(Messages.NotANumber);
            }

            switch (choix)

            {
                case 1:
                    DataBase.Instance.ListAllSpec();
                    break;
                case 2:
                    DataBase.Instance.AddSpecialite();

                    break;
                case 0:
                    MenuMedecinPrincipal();
                    break;

            }
        }
    }
}
