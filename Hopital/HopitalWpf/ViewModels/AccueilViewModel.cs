using GalaSoft.MvvmLight.Command;
using HopitalWpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HopitalWpf.ViewModel
{
    public class AccueilViewModel
    {
        public ICommand ajoutPatient { get; set; }

        public AccueilViewModel()
        {
            ajoutPatient = new RelayCommand(add);
        }

        public void add()
        {
            AjoutPatient fenetreAjoutPatient = new AjoutPatient();
            fenetreAjoutPatient.Show();
        }
    }
}
