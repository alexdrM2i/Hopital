using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public static class Messages
    {
        #region MessagesGenerals
        public static string TitreProjet = "Bienvenue dans la gestion HOPITAL M2I";
        public static string MenuPrincipal = "Menu principal";
        public static string NotANumber = "Veuillez saisir un chiffre";
        public static string Choix = "Veuillez indiquer votre choix : ";
        public static string NotAString = "Veuillez indiquer une chaine de caractère valide ";
        public static string Sortie = "Voulez-vous vraiment quitter le programme O / N ?";
        public static string RdvAjoute = "Votre rendez-vous à bien été ajouté";
        public static string RetourMenuPrincipal = "Retour au menu principal";
        public static string RetourMenuPrincipalMedecin = "Retour au menu principal du médecin";
        public static string NoFunction = "La fonction demandée n'existe pas.";
        public static string ClearConsole = "Nettoyage de la console";
        public static string GestionHospitalisation = "Gestion de l'hospitalisation";
        public static string InsertOk = "Votre enregistrement a bien été pris en compte.";
        #endregion 

        #region MessagesPartiesMedecin
        public static string TitreMedecin = "Gestion du médecin";
        public static string TitreAjouterMedecin = "Ajouter médecin";
        public static string TitreModifierMedecin = "Modifier médecin";
        public static string TitreSpecialiteMedecin = "Spécialité du médecin";
        public static string TitreAjouterSpecialiteMedecin = "Ajouter spécialité pour un médecin";
        public static string TitreModifierSpecialiteMedecin = "Modifier une spécialité pour le médecin";
        public static string MedecinNom = "Nom du medecin :";
        public static string MedecinPrenom = "Prénom du médecin :";
        public static string MedecinTelephone = "Téléphone du medecin: ";
        public static string MedecinSpecialite = "Quelle spécialité ? : ";


        #endregion

        #region MessagesPartiesPatients
        public static string TitrePatients = "Gestion du patient";
        public static string TitreAjouterPatient = "Ajouter patient";
        public static string TitreModifierPatient = "Modifier patient";
        public static string TitreAjouterRDVPatient = "Planifier un rendez-vous";
        public static string TitreModifierRDVPatient = "Modifier un rendez-vous";
        public static string PatientNom = "Nom du patient :";
        public static string PatientPrenom = "Prénom du patient :";
        public static string PatientDateNaissance = "Date de naissance :";
        public static string PatientSexe = "Sexe: F/H :";
        public static string PatientAdresse = "Adresse complète :";
        public static string PatientSituation = "Situation :";
        public static string PatientAssurance = "Assurance :";
        public static string PatientCodeAssurance = "Code assurance :";
        public static string PatientTel = "Numéro de téléphone :";
        public static string PatientNomPere = "Nom du père :";
        public static string PatientNomMere = "Nom de la mère :";
        public static string PatientNomPersPrevenir = "Nom de la personne à contacter";
        public static string PatientTelPersPrevenir = "Téléphone de la personne à contacter :";
        public static string TitreAutre = "Autre :";
       
        #endregion

        public static void AfficherMessageErreur(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void AfficherMessageInsertOk(string message)
        {
            Console.WriteLine(" ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
