using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LicenciasMedicasGL.Data;
using LicenciasMedicasGL.Models;

namespace LicenciasMedicasGL.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly LicenciasMedicasContext _context;

        public EmpleadosController(LicenciasMedicasContext context)
        {
            _context = context;
        }

        // GET: Empleado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empleados.ToListAsync());
        }

        // GET: Empleado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Legajo,LicenciaId,estaActivo,Id,DNI,Nombre,Apellido,Email,FechaAlta,Direccion,ObraSocial,TelefonoId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Legajo,LicenciaId,estaActivo,Id,DNI,Nombre,Apellido,Email,FechaAlta,Direccion,ObraSocial,TelefonoId")] Empleado empleadoDelFormulario)
        {
            if (id != empleadoDelFormulario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Empleado empleadoEnDb = _context.Empleados.Find(empleadoDelFormulario.Id);
                    if (empleadoEnDb == null)
                    {
                        return NotFound();
                    }

                    empleadoEnDb.DNI = empleadoDelFormulario.DNI;
                    empleadoEnDb.Legajo = empleadoDelFormulario.Legajo;
                    empleadoEnDb.LicenciaId = empleadoDelFormulario.LicenciaId;
                    empleadoEnDb.estaActivo = empleadoDelFormulario.estaActivo;
                    empleadoEnDb.Nombre = empleadoDelFormulario.Nombre;
                    empleadoEnDb.Apellido = empleadoDelFormulario.Apellido;
                    empleadoEnDb.FechaAlta = empleadoDelFormulario.FechaAlta;
                    empleadoEnDb.Direccion = empleadoDelFormulario.Direccion;
                    empleadoEnDb.ObraSocial = empleadoDelFormulario.ObraSocial;
                    empleadoEnDb.TelefonoId = empleadoDelFormulario.TelefonoId;

                    if (!ActualizarEmail(empleadoDelFormulario, empleadoEnDb))
                    {
                        ModelState.AddModelError("Email", "El mail esta actualizado.");
                        return View(empleadoDelFormulario);

                    }

                    //_context.Update(empleadoDelFormulario);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleadoDelFormulario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(empleadoDelFormulario);
        }

        private bool ActualizarEmail(Empleado empleadoForm, Empleado empleadoDb)
        {
            bool resultado = true;
            try
            {
                if (!empleadoDb.NormalizedEmail.Equals(empleadoForm.Email.ToUpper()))
                {
                    //si son iguales - tengo que procesar 
                    //verifico si ya existe el mail
                    if (ExisteEmail(empleadoForm.Email))
                    {
                        //si existe no puede ser actualizado 
                        resultado = false;
                    }
                    else
                    {
                        //como existe puedo actualizar
                        empleadoDb.Email = empleadoForm.Email;
                        empleadoDb.NormalizedEmail = empleadoForm.Email.ToUpper();
                        empleadoDb.UserName = empleadoForm.Email;
                        empleadoDb.NormalizedUserName = empleadoForm.NormalizedEmail;
                    }
                }
                else
                {
                    //son iguales, no se actualiza. Ya lo está
                }
            }
            catch 
            {

                resultado = false; 
            }
            return resultado;
        }

        private bool ExisteEmail(string email)
        {
            return _context.Personas.Any(p=>p.NormalizedEmail == email.ToUpper());
        }

        // GET: Empleado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}
