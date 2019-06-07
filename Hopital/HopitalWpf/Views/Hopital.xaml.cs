using System.Windows;
using HopitalWpf.ViewModels;

namespace HopitalWpf.Views
{
    /// <summary>
    /// Logique d'interaction pour Hopital.xaml
    /// </summary>
    public partial class Hopital : Window
    {
        public Hopital()
        {
            InitializeComponent();
            DataContext = new AuthentificationViewModels();
        }
    }
}
