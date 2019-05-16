using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class RDV
    {
        private int id;
        private string codeRDV;
        private string medecin;
        private DateTime dateRDV;
        private string service;

        public int Id { get => id; set => id = value; }
        public string CodeRDV { get => codeRDV; set => codeRDV = value; }
        public string Medecin { get => medecin; set => medecin = value; }
        public DateTime DateRDV { get => dateRDV; set => dateRDV = value; }
        public string Service { get => service; set => service = value; }
    }
}
