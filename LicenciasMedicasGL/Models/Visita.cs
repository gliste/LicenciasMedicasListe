using System;
using System.ComponentModel.DataAnnotations;
using LicenciasMedicasGL.Helpers;

namespace LicenciasMedicasGL.Models
{
    public class Visita
    {
        public int Id { get; set; }

        public int LicenciaId { get; set; }
        public Licencia Licencia { get; set; }

        public int MedicoId { get; set; }
        public Medico Medico { get; set; }

        public DateTimeOffset FechaYHoraVisita { get; set; }

        public DateTimeOffset FechaInicio { get; set; }

        public DateTimeOffset FechaFin { get; set; }

        [StringLength(200, ErrorMessage = ErrorMsg.MsgMax)]
        public string Descripcion { get; set; }

        public bool Justificada { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [Range(1, 365, ErrorMessage = ErrorMsg.MsgRango)]
        public int CantidadDias { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(200, ErrorMessage = ErrorMsg.MsgMax)]
        public string Nota { get; set; }
        
        
        public bool Cargada { get; set; }



    }

  
}
