using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using ModelClassLibrary;

namespace HopitalWpf.ViewModels
{
    public class PatientViewModels : ViewModelBase
    {
        public ICommand AddPatientCommand { get; set; }
        public Patient _p { get; set; }
        public HopitalDBDataContext Data;

        public string Nom
        {
            get => _p.Nom;
            set
            {
                _p.Nom = value;
                RaisePropertyChanged();
            }
        }
     
        public string Prenom { get => _p.Prenom; set => _p.Prenom = value; }

        public bool TypeSexeM
        {
            get { return (_p.Sexe == "Homme"); }
            set { Sexe = (value) ? "Homme" : "Femme"; }
        }

        public bool TypeSexeF
        {
            get { return (_p.Sexe == "Femme"); }
            set { Sexe = (value) ? "Femme" : "Homme"; }
        }

        public string DateNaissance { get => _p.DateNaissance; set => _p.DateNaissance = value; }
       private string _Sexe;

        public string Sexe
        {
            get { return _p.Sexe; }
            set
            {
                _p.Sexe = value;
            }
        }

       // public string Sexe { get => _p.Sexe; set => _p.Sexe = value; }
        public string Adresse { get => _p.Adresse; set => _p.Adresse = value; }
        public string Situation { get => _p.Situation; set => _p.Situation = value; }
        public string Assurance { get => _p.Assurance; set => _p.Assurance = value; }
        public string CodeAssurance { get => _p.CodeAssurance; set => _p.CodeAssurance = value; }
        public string Tel { get => _p.Tel; set => _p.Tel = value; }
        public string NomPere { get => _p.NomPere; set => _p.NomMere = value; }
        public string NomMere { get => _p.NomMere; set => _p.NomMere = value; }
        public string NomPersPrevenir { get => _p.NomPersPrevenir; set => _p.NomPersPrevenir = value; }
        public string TelPersPrevenir { get => _p.TelPersPrevenir; set => _p.TelPersPrevenir = value; }
    
        public PatientViewModels()
        {
            _p = new Patient();
            AddPatientCommand = new RelayCommand(AddPatient);
        }

        private void AddPatient()
        {
            Data = new HopitalDBDataContext();


            //insertion en local dans le dataset
           Data.Patient.InsertOnSubmit(_p);
            //insertion en base
            Data.SubmitChanges();

        }
    }
   
}
