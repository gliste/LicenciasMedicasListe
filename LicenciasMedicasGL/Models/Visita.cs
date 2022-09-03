﻿using System;

namespace LicenciasMedicasGL.Models
{
    public class Visita
    {
        public Licencia Licencia { get; set; }

        public Medico Medico { get; set; }

        public DateTimeOffset FechaYHoraVisita { get; set; }

        public DateTimeOffset FechaInicio { get; set; }

        public DateTimeOffset FechaFin { get; set; }

        public string Descripcion { get; set; }

        public bool Justificada { get; set; }

        public int CantidadDias { get; set; }

        public string Nota { get; set; }

        public bool Cargada { get; set; }



    }

  
}
