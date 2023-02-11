using LicenciasMedicasGL.Data;
using LicenciasMedicasGL.Helpers;
using LicenciasMedicasGL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LicenciasMedicasGL.Controllers
{
    public class PreCarga : Controller
    {
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<Rol> _roleManager;
        private readonly LicenciasMedicasContext _context;

        private List<string> roles = new List<string>() { Configs.AdminRolName, Configs.EmpleadoRolName, Configs.MedicoRolName, Configs.RRHHRolName};
        public PreCarga(UserManager<Persona> userManager, RoleManager<Rol> roleManager,LicenciasMedicasContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
           _context = context;
        }
        public IActionResult Seed()
        {
            //Crear roles 
            CrearRoles().Wait();
            CrearAdmin().Wait();
            CrearEmpleados().Wait();
            CrearMedicos().Wait();
            CrearTelefonos().Wait();
            CrearLicencias().Wait();


            return RedirectToAction("Index", "Home", new {mensaje = "Proceso seed finalizado"});
        }

        private async Task CrearLicencias()
        {
            
        }

        private async Task CrearTelefonos()
        {
            
        }

        private async Task CrearMedicos()
        {
            
        }

        private async Task CrearAdmin()
        {
           
        }

        private async Task CrearEmpleados()
        {
           
        }

        private async Task CrearRoles()
        {
            foreach (var rolName in roles)
            {
                if(!await _roleManager.RoleExistsAsync(rolName))
                {
                    await _roleManager.CreateAsync(new Rol(rolName));
                }
            }
        }
    }
}
