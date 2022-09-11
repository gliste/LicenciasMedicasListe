using System.Collections.Generic;
using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LicenciasMedicasGL.Models
{
    public class Prestadora
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [MaxLength(50, ErrorMessage = ErrorMsg.MsgMax)]
        [MinLength(3, ErrorMessage = ErrorMsg.MsgMin)]
        public string Nombre { get; set; }
        public Direccion Direccion { get; set; }

        public Telefono TelefonoContacto { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [EmailAddress(ErrorMessage = ErrorMsg.MsgEmail)]
        [Display(Name = "Correo Electronico")]
        public string EmailContacto { get; set; }
        public int MedicoId { get; set; }

        public List<Medico> Medicos { get; set; }
    }

 
}



