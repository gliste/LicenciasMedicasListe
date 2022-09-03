using System;
using System.Collections.Generic;

namespace LicenciasMedicasGL.Models
{
    public class Persona
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public DateTime FechaAlta { get; set; } 

        public Direccion Direccion { get; set; }

        public ObraSocial ObraSocial { get; set; }

        public bool estaActivo { get; set; }

        public List<Licencia> Licencias { get; set; }

        public List<Telefono> Telefonos { get; set; }
         

    }
}



