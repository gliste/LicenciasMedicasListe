using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LicenciasMedicasGL.Data;
using LicenciasMedicasGL.Models;
using Microsoft.AspNetCore.Authorization;

namespace LicenciasMedicasGL.Controllers
{
   
    public class VisitasController : Controller
    {
        private readonly LicenciasMedicasContext _context;

        public VisitasController(LicenciasMedicasContext context)
        {
            _context = context;
        }

        // GET: Visita
        public async Task<IActionResult> Index()
        {
            var licenciasMedicasContext = _context.Visitas.Include(v => v.Licencia).Include(v => v.Medico);
            return View(await licenciasMedicasContext.ToListAsync());
        }

        // GET: Visita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas
                .Include(v => v.Licencia)
                .Include(v => v.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visita/Create
        public IActionResult Create(int? id)
        {
            if (id==null)
            {
                return Content("No pase id Correcto");
            }
            ViewData["LicenciaId"] = id;
            ViewBag.MedicoId = new SelectList(_context.Medicos, "Id", "Apellido");
            return View();
        }

        // POST: Visita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LicenciaId,MedicoId,FechaYHoraVisita,FechaInicio,FechaFin,Descripcion,Justificada,CantidadDias,Nota,Cargada")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LicenciaId"] = new SelectList(_context.Licencias, "Id", "Descripcion", visita.LicenciaId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido", visita.MedicoId);
            return View(visita);
        }

        // GET: Visita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["LicenciaId"] = new SelectList(_context.Licencias, "Id", "Descripcion", visita.LicenciaId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido", visita.MedicoId);
            return View(visita);
        }

        // POST: Visita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LicenciaId,MedicoId,FechaYHoraVisita,FechaInicio,FechaFin,Descripcion,Justificada,CantidadDias,Nota,Cargada")] Visita visita)
        {
            if (id != visita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.Id))
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
            ViewData["LicenciaId"] = new SelectList(_context.Licencias, "Id", "Descripcion", visita.LicenciaId);
            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido", visita.MedicoId);
            return View(visita);
        }

        // GET: Visita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visitas
                .Include(v => v.Licencia)
                .Include(v => v.Medico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visitas.FindAsync(id);
            _context.Visitas.Remove(visita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visitas.Any(e => e.Id == id);
        }
    }
}
