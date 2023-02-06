using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LicenciasMedicasGL.ViewModels
{
    public class RegistroUsuario
    {

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [EmailAddress(ErrorMessage = ErrorMsg.MsgEmail)]
        [Display(Name = "Correo Electronico")]
        public string Email{ get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }   
        

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmacion Contraseña")]
        [Compare("Password", ErrorMessage = ErrorMsg.PassIncorrecta)]
        public string ConfirmacionPassword { get; set; }
            
    }
}
