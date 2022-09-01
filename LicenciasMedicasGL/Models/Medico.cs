namespace LicenciasMedicasGL.Models
{
    public class Medico : Persona
    {
        public string Matricula { get; set; }

        public Prestadora Prestadora { get; set; }

        List<Licencia> Licencias { get; set; }

    }

    /*
- FechaAlta

-Prestadora una sola 
- Licencias*/
}
