using Microsoft.AspNetCore.Mvc;
using LicenciasMedicasGL.Models;
using LicenciasMedicasGL.ViewModels;
using LicenciasMedicasGL.Data;

namespace LicenciasMedicasGL.Controllers
{
    public class EmpleadosConTelefonos : Controller
    {
        private readonly LicenciasMedicasContext _contexto;
        public EmpleadosConTelefonos(LicenciasMedicasContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult CrearEmpleado(EmpleadoConTelefono empleadoConTEvm)
        {
            Empleado empleadoNuevo = new Empleado();
            empleadoNuevo.DNI = empleadoConTEvm.DNI;
            empleadoNuevo.Nombre = empleadoConTEvm.Nombre;
            empleadoNuevo.Apellido = empleadoConTEvm.Apellido;
            _contexto.Add(empleadoNuevo);

            Telefono telefonoNuevo = new Telefono();
            telefonoNuevo.Numero = empleadoConTEvm.TelefonoId;
            _contexto.Add(telefonoNuevo);

            _contexto.SaveChanges();

            return View();
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
