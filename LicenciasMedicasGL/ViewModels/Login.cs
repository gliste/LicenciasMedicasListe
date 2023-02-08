using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LicenciasMedicasGL.ViewModels
{
    public class Login
    {


        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [EmailAddress(ErrorMessage = ErrorMsg.MsgEmail)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public bool Recordarme { get; set; }

    }
}
