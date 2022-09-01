namespace LicenciasMedicasGL.Models
{
    public class Prestadora
    {
        public string Nombre { get; set; }
        public Direccion Direccion { get; set; }

        public Telefono TelefonoContacto { get; set; }

        public string EmailContacto { get; set; }

        List<Medico> Medicos { get; set; }
    }

    /*

- TelefonoContacto

- Medicos*/
}



