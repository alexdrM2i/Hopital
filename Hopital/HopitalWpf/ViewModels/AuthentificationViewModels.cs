using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ModelClassLibrary.Models;

namespace HopitalWpf.ViewModels
{
    public class AuthentificationViewModels : ViewModelBase, INotifyPropertyChanged
    {
        public Authentification _a { get; set; }
        public Authentification _au { get; set; }

        private string identifiant;
        private string password;
        private string message;

        public string Identifiant
        {
            get => _a.Identifiant;
            set
            {
                _a.Identifiant = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            private get => _a.Password;
            set
            {
                _a.Password = value;
                RaisePropertyChanged();
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                StartNotify("Message");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void StartNotify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand ValiderCommand { get; set; }

        public AuthentificationViewModels()
        {
            _a = new Authentification();
            ValiderCommand = new RelayCommand(CheckLog);
        }

        private void CheckLog()
        {
            ObservableCollection<Authentification> logPasswordList = Authentification.ListIdentifiant();

            Message = string.Empty;
            foreach (var au in logPasswordList)
            {
                if (string.Equals(au.Identifiant, _a.Identifiant) && string.Equals(au.Password, _a.Password))
                {
                    Message = string.Empty;
                    Message = "Good authentification";
                    return;
                }
                else
                {
                    Message = string.Empty;
                    Message = "Erreur authentification";
                }
            }
        }
    }
}
