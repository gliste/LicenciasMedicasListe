using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LicenciasMedicasGL.Helpers;

namespace LicenciasMedicasGL.Models
{
    public class Persona
    {

        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [Range(1000000, 99999999, ErrorMessage = ErrorMsg.MsgRango)]
        public int DNI { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [MaxLength(50, ErrorMessage = ErrorMsg.MsgMax)]
        [MinLength(3, ErrorMessage = ErrorMsg.MsgMin)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(100, MinimumLength =1, ErrorMessage = ErrorMsg.MsgRango)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [EmailAddress(ErrorMessage = ErrorMsg.MsgEmail)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Display(Name = "Fecha Alta")]
        public DateTime FechaAlta { get; set; } 

        public string  Direccion { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [Display(Name = "Obra Social")]
        public ObraSocial ObraSocial { get; set; }

        
        public List<Licencia> Licencias { get; set; }

        [Display(Name = "Id Telefono")]
        public int TelefonoId { get; set; }
        public List<Telefono> Telefonos { get; set; }
        
        //password

    }
}



