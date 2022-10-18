using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;
namespace LicenciasMedicasGL.Models
{
    public class Telefono
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ErrorMsg.MsgRequerido)]
        [Range(1000000, 9999999, ErrorMessage = ErrorMsg.MsgRango)]
        public int Numero { get; set; }

        public TipoTelefono TipoTelefono { get; set; }

        //public int PersonaId { get; set; }

        //public Persona Persona { get; set; }
    }
}
