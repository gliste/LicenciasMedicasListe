using System;
using System.Collections.Generic;
using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LicenciasMedicasGL.Models
{
    public class Medico : Persona
    {
        [Required (ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(12, MinimumLength = 1, ErrorMessage = ErrorMsg.MsgRango)]
        public string Matricula { get; set; }

       // public int PestadoraId { get; set; } ¿está demás? ¿alcanca con la propiedad relacional MedicoId en Prestadora?
                       
        public Prestadora Prestadora { get; set; }

        public int LicenciaId { get; set; }

       
    }

}
