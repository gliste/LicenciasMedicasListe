using System;
using System.Collections.Generic;

namespace LicenciasMedicasGL.Models
{
    public class Licencia

    {
        public DateTime FechaSolicitud { get; set; }
        public string Descripcion { get; set; }

        public Empleado Empleado { get; set; }

        public List<Visita> Visitas { get; set; }

        public DateTime FechaInicioSolicitada { get; set; }

        public DateTime FechaFinSolicitada { get; set; }

        public DateTimeOffset FechaInicio { get; set; }
        
        public DateTimeOffset FechaFin { get; set; }
        public bool Activa { get; set; }


    }


}
