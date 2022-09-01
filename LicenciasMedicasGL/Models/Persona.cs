using System.Collections.Generic;

namespace LicenciasMedicasGL.Models
{
    public class Persona
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public Direccion Direccion { get; set; }

        List<Licencia> Licencias { get; set; }

        List<Telefono> Telefonos { get; set; }
         

    }
}



