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
    public class LicenciasController : Controller
    {
        private readonly LicenciasMedicasContext _context;

        public LicenciasController(LicenciasMedicasContext context)
        {
            _context = context;
        }

        // GET: Licencia
        public async Task<IActionResult> Index()
        {
            var licenciasMedicasContext = _context.Licencias.Include(l => l.Empleado).Include(l => l.Medico);
            return View(await licenciasMedicasContext.ToListAsync());
        }

        // GET: Licencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencia = await _context.Licencias
                .Include(l => l.Empleado)
                .Include(l => l.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licencia == null)
            {
                return NotFound();
            }

            return View(licencia);
        }


        // GET: Licencia/Create
        
        public IActionResult Create(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            ViewData["EmpleadoId"] = id;
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido");
            return View();
        }

        // POST: Licencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MedicoId,FechaSolicitud,Descripcion,EmpleadoId,VisitaId,FechaInicioSolicitada,FechaFinSolicitada,FechaInicio,FechaFin,Activa")] Licencia licencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           // ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", licencia.EmpleadoId);
           // ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido", licencia.MedicoId);
            return View(licencia);
        }

        // GET: Licencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencia = await _context.Licencias.FindAsync(id);
            if (licencia == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", licencia.EmpleadoId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido", licencia.MedicoId);
            return View(licencia);
        }

        // POST: Licencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MedicoId,FechaSolicitud,Descripcion,EmpleadoId,VisitaId,FechaInicioSolicitada,FechaFinSolicitada,FechaInicio,FechaFin,Activa")] Licencia licencia)
        {
            if (id != licencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenciaExists(licencia.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellido", licencia.EmpleadoId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido", licencia.MedicoId);
            return View(licencia);
        }

        // GET: Licencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licencia = await _context.Licencias
                .Include(l => l.Empleado)
                .Include(l => l.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (licencia == null)
            {
                return NotFound();
            }

            return View(licencia);
        }

        // POST: Licencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licencia = await _context.Licencias.FindAsync(id);
            _context.Licencias.Remove(licencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenciaExists(int id)
        {
            return _context.Licencias.Any(e => e.Id == id);
        }
    }
}
