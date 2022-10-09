using System;
using System.Collections.Generic;
using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;



namespace LicenciasMedicasGL.Models
{
    public class Empleado : Persona
    {
        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = ErrorMsg.MsgRango)]
        public string Legajo  { get; set; }
             
       public int LicenciaId { get; set; }
       
       public bool estaActivo { get; set; }
        
    }

    

}
