using System.Windows;
using HopitalWpf.ViewModels;
using ModelClassLibrary;

namespace HopitalWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour AjoutPatient.xaml
    /// </summary>
    public partial class AjoutPatient : Window
    {
        public AjoutPatient()
        {
            InitializeComponent();

            DataContext = new PatientViewModels();

        }
    }
}
