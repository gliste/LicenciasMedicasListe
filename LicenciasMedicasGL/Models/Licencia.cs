namespace LicenciasMedicasGL.Models
{
    public class Licencia
    {
        public string Descripcion { get; set; }

        public Empleado Empleado { get; set; }

        List<Visita> Visitas { }

        public bool Activa { get; set; }


    }

    /*FechaSolicitud


- FechaInicioSolicitada
- FechaFinSolicitada
- FechaInicio
- FechaFin*/
}
