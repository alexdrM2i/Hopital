using System;


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
            Console.WriteLine(" ");
            Console.WriteLine(Messages.MenuPrincipal);
            Console.WriteLine(" ");

            do
            {
                Console.WriteLine("1 - Gestion du patient");
                Console.WriteLine("2 - Gestion du médecin");
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
                        MenuPatientPrincipal();
                       
                        break;
                    case 2:
                        MenuMedecinPrincipal();

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

        private static void MenuMedecinPrincipal()
        {
            Console.Clear();
            Titre();
            Console.WriteLine(" ");
            Console.WriteLine(Messages.TitreMedecin);
            Console.WriteLine(" ");
            Console.WriteLine($"1 - {Messages.TitreAjouterMedecin}");
            Console.WriteLine($"2 - {Messages.TitreModifierMedecin}");
        }

        private static void MenuPatientPrincipal()
        {
            Console.Clear();
            Titre();
            Console.WriteLine(" ");
            Console.WriteLine($"{Messages.TitrePatients}");
            Console.WriteLine(" ");
            Console.WriteLine($"1 - {Messages.TitreAjouterPatient}");
            Console.WriteLine($"2 - {Messages.TitreModifierPatient}");
        }
        private static void MenuMedecinSpecialite()
        {
            Console.Clear();
            Titre();
            Console.WriteLine(" ");
            Console.WriteLine($"{Messages.TitreSpecialiteMedecin}");
            Console.WriteLine($"1 -{Messages.TitreAjouterSpecialiteMedecin}");
            Console.WriteLine($"2 - {Messages.TitreModifierSpecialiteMedecin}");

            switch (choix)

            {
                case 1:
                    DataBase.Instance.AddMedecin();
                    break;
            }


           
        }
    }
}
