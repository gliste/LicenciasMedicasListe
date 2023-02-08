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
        public async Task<IActionResult> Registrar([Bind("Email, Password, ConfirmacionPassword")] RegistroUsuario registroUsuarioVM)
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

        public IActionResult IniciarSesion()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login loginVM)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signinmanager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.Recordarme, false);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }

                ModelState.AddModelError(string.Empty, "Inicio de Sesion inválido.");

                
            }
            return View(loginVM);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


      
    }
}
