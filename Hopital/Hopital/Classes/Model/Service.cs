using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes.Model
{
    public class Service
    {
        private int id;
        private string nom;
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
    }
}
