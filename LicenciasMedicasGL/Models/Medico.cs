using System;
using System.Collections.Generic;

namespace LicenciasMedicasGL.Models
{
    public class Medico : Persona
    {
        public string Matricula { get; set; }
               
        public Prestadora Prestadora { get; set; }

       
    }

}
