using System;
using System.Collections.Generic;
using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LicenciasMedicasGL.Models
{
    public class Licencia

    {
        public int Id { get; set; }

        
        public int MedicoId { get; set; }
       
        [Display(Name = "Numero de Medico")]
        public Medico Medico { get; set; }

        [Display(Name = "Fecha Solicitud")]
        public DateTime FechaSolicitud { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(500, ErrorMessage = ErrorMsg.MsgMax)]
        public string Descripcion { get; set; }

       
        public int EmpleadoId { get; set; }
        [Display(Name = "Numero de Empleado")]
        public Empleado Empleado { get; set; }

        [Display(Name = "Numero de Visita")]
        public int VisitaId { get; set; }
        public List<Visita> Visitas { get; set; }
        [Display(Name = "Fecha Inicio Solicitada")]
        public DateTime FechaInicioSolicitada { get; set; }

        [Display(Name = "Fecha Fin Solicitada")]
        public DateTime FechaFinSolicitada { get; set; }

        [Display(Name ="Fecha Inicio")]
        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }
        public bool Activa { get; set; }


    }


}
