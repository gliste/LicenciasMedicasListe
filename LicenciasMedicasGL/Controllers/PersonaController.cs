using LicenciasMedicasGL.Data;
using LicenciasMedicasGL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LicenciasMedicasGL.Controllers
{
    public class PersonaController : Controller
    {
        private readonly LicenciasMedicasContext _contexto;
        public PersonaController(LicenciasMedicasContext contexto)
        {
           this._contexto = contexto;
        }
        public IActionResult Index()
        {

            var personas = _contexto.Personas.ToList();   
            

            return View(personas);
        }
    }
}
