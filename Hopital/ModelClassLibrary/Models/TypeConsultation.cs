﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hopital.Classes
{
    public class TypeConsultation
    {
        private int id;
        private decimal prix;
        private string type;
         
        public int Id { get => id; set => id = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public string Type { get => type; set => type = value; }
        public TypeConsultation()
        {
            
        }
    }
}
