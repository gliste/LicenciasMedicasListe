using LicenciasMedicasGL.Helpers;
using LicenciasMedicasGL.Models;
using LicenciasMedicasGL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LicenciasMedicasGL.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<Persona> _usermanager;
        private readonly SignInManager<Persona> _signinmanager;
        private readonly RoleManager<Rol> _rolmanager;
        public AccountController(UserManager<Persona> usermanager, SignInManager<Persona> signInManager, RoleManager<Rol> roleManager)
        {
            this._usermanager = usermanager;
            this._signinmanager = signInManager;
            this._rolmanager = roleManager;
        }
        [AllowAnonymous]
        public IActionResult Registrar()
        {
            return View();
        }
        [AllowAnonymous]
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
                    var resultadoAddRole = await _usermanager.AddToRoleAsync(empleadoACrear,Configs.EmpleadoRolName);

                    if (resultadoAddRole.Succeeded)
                    {
                        await _signinmanager.SignInAsync(empleadoACrear, isPersistent: false);
                        return RedirectToAction("Edit", "Empleados", new { id = empleadoACrear.Id });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"No se puedo agregar el rol de {Configs.EmpleadoRolName}");
                    }

                    
                }

                foreach(var error in resultadoCreate.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            
            return View(registroUsuarioVM);
        }

        [AllowAnonymous]
        public IActionResult IniciarSesion(string returnUrl)
        {
            ViewBag.Url1 = returnUrl;
            ViewData["Url2"] = returnUrl;
            TempData["Url3"] = returnUrl;

            return View(); 
        }

        [AllowAnonymous]
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

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListarRoles()
        {
            var roles = _rolmanager.Roles.ToList();

            return View(roles);
        }


    }
}
