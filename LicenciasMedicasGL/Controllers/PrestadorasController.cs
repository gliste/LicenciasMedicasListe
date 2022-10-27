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
    public class PrestadorasController : Controller
    {
        private readonly LicenciasMedicasContext _context;

        public PrestadorasController(LicenciasMedicasContext context)
        {
            _context = context;
        }

        public IActionResult Index1()
        {
            var prestadoras = _context.Prestadoras.ToList();

            return View(prestadoras);
        }


        // GET: Prestadora
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prestadoras.ToListAsync());
        }

        // GET: Prestadora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestadora = await _context.Prestadoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestadora == null)
            {
                return NotFound();
            }

            return View(prestadora);
        }

        // GET: Prestadora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prestadora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Direccion,EmailContacto")] Prestadora prestadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prestadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prestadora);
        }

        // GET: Prestadora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestadora = await _context.Prestadoras.FindAsync(id);
            if (prestadora == null)
            {
                return NotFound();
            }
            return View(prestadora);
        }

        // POST: Prestadora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,EmailContacto")] Prestadora prestadora)
        {
            if (id != prestadora.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestadoraExists(prestadora.Id))
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
            return View(prestadora);
        }

        // GET: Prestadora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prestadora = await _context.Prestadoras
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prestadora == null)
            {
                return NotFound();
            }

            return View(prestadora);
        }

        // POST: Prestadora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestadora = await _context.Prestadoras.FindAsync(id);
            _context.Prestadoras.Remove(prestadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrestadoraExists(int id)
        {
            return _context.Prestadoras.Any(e => e.Id == id);
        }
    }
}
