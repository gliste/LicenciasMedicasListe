using LicenciasMedicasGL.Models;
using LicenciasMedicasGL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LicenciasMedicasGL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Persona> _usermanager;
        private readonly SignInManager<Persona> _signinmanager;
        public AccountController(UserManager<Persona> usermanager, SignInManager<Persona> signInManager)
        {
            this._usermanager = usermanager;
            this._signinmanager = signInManager;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult>  Registrar([Bind("Email, Password, ConfirmacionPassword")] RegistroUsuario registroUsuarioVM)
        {
            if (ModelState.IsValid)
            {
               
                Empleado empleadoACrear = new Empleado()
                {
                    Email = registroUsuarioVM.Email,
                    UserName = registroUsuarioVM.Email
                };

                var resultadoCreate = await _usermanager.CreateAsync(empleadoACrear, registroUsuarioVM.Password);
                if (resultadoCreate.Succeeded)
                {
                    await _signinmanager.SignInAsync(empleadoACrear, isPersistent: false);
                    return RedirectToAction("Edit", "Empleados", new {id = empleadoACrear.Id});
                }

                foreach(var error in resultadoCreate.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            
            return View(registroUsuarioVM);
        }


    }
}
