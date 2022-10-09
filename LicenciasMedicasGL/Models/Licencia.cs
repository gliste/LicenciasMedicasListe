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
        public DateTime FechaSolicitud { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(500, ErrorMessage = ErrorMsg.MsgMax)]
        public string Descripcion { get; set; }

        //public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        public int VisitaId { get; set; }
        public List<Visita> Visitas { get; set; }

        public DateTime FechaInicioSolicitada { get; set; }

        public DateTime FechaFinSolicitada { get; set; }

        public DateTime FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public bool Activa { get; set; }


    }


}
