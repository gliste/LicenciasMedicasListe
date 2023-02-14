using System.ComponentModel.DataAnnotations;
using LicenciasMedicasGL.Helpers;


namespace LicenciasMedicasGL.ViewModels
{
    public class EmpleadoConTelefono
    {
        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [Range(1000000, 99999999, ErrorMessage = ErrorMsg.MsgRango)]
        public int DNI { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [MaxLength(50, ErrorMessage = ErrorMsg.MsgMax)]
        [MinLength(3, ErrorMessage = ErrorMsg.MsgMin)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = ErrorMsg.MsgRango)]
        public string Apellido { get; set; }

        [Display(Name = "Telefono")]
        public int TelefonoId { get; set; }


    }
}
