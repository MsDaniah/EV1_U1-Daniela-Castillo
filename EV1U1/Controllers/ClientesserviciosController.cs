using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EV1U1.Models;

namespace EV1U1.Controllers
{
    public class ClientesserviciosController : Controller
    {
        private readonly MercyDevelopersContext _context;

        public ClientesserviciosController(MercyDevelopersContext context)
        {
            _context = context;
        }

        // GET: Clientesservicios
        public async Task<IActionResult> Index()
        {
            var mercyDevelopersContext = _context.Clientesservicios.Include(c => c.IdclientesNavigation).Include(c => c.IdserviciosNavigation);
            return View(await mercyDevelopersContext.ToListAsync());
        }

        // GET: Clientesservicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesservicio = await _context.Clientesservicios
                .Include(c => c.IdclientesNavigation)
                .Include(c => c.IdserviciosNavigation)
                .FirstOrDefaultAsync(m => m.Idclientesservicios == id);
            if (clientesservicio == null)
            {
                return NotFound();
            }

            return View(clientesservicio);
        }

        // GET: Clientesservicios/Create
        public IActionResult Create()
        {
            ViewData["Idclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes");
            ViewData["Idservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios");
            return View();
        }

        // POST: Clientesservicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idclientesservicios,Idclientes,Idservicios,FechaInicio,FechaTermino,Estado")] Clientesservicio clientesservicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientesservicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clientesservicio.Idclientes);
            ViewData["Idservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios", clientesservicio.Idservicios);
            return View(clientesservicio);
        }

        // GET: Clientesservicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesservicio = await _context.Clientesservicios.FindAsync(id);
            if (clientesservicio == null)
            {
                return NotFound();
            }
            ViewData["Idclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clientesservicio.Idclientes);
            ViewData["Idservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios", clientesservicio.Idservicios);
            return View(clientesservicio);
        }

        // POST: Clientesservicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idclientesservicios,Idclientes,Idservicios,FechaInicio,FechaTermino,Estado")] Clientesservicio clientesservicio)
        {
            if (id != clientesservicio.Idclientesservicios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientesservicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesservicioExists(clientesservicio.Idclientesservicios))
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
            ViewData["Idclientes"] = new SelectList(_context.Clientes, "Idclientes", "Idclientes", clientesservicio.Idclientes);
            ViewData["Idservicios"] = new SelectList(_context.Servicios, "Idservicios", "Idservicios", clientesservicio.Idservicios);
            return View(clientesservicio);
        }

        // GET: Clientesservicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientesservicio = await _context.Clientesservicios
                .Include(c => c.IdclientesNavigation)
                .Include(c => c.IdserviciosNavigation)
                .FirstOrDefaultAsync(m => m.Idclientesservicios == id);
            if (clientesservicio == null)
            {
                return NotFound();
            }

            return View(clientesservicio);
        }

        // POST: Clientesservicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientesservicio = await _context.Clientesservicios.FindAsync(id);
            if (clientesservicio != null)
            {
                _context.Clientesservicios.Remove(clientesservicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesservicioExists(int id)
        {
            return _context.Clientesservicios.Any(e => e.Idclientesservicios == id);
        }
    }
}
