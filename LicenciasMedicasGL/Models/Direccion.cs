using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace LicenciasMedicasGL.Models
   
{
    public class Direccion
    {
        public int Id { get; set; }

        public int PersonaId { get; set; }

        public List<Persona> Personas;

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(30, MinimumLength = 1, ErrorMessage = ErrorMsg.MsgRango)]
        public string Calle { get; set; }
        
        [Required (ErrorMessage = ErrorMsg.MsgRequerido)]
        [Range(1,4, ErrorMessage = ErrorMsg.MsgRango)]
        public int Numero { get; set; }

        
    }
}
