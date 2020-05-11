using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Delivery.Web.Data;
using Delivery.Web.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Delivery.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class RepartidoresController : Controller
    {
        private readonly DataContext _context;

        public RepartidoresController(DataContext context)
        {
            _context = context;
        }

        // GET: Repartidores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Repartidores.ToListAsync());
        }

        // GET: Repartidores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repartidorEntity = await _context.Repartidores
                .FirstOrDefaultAsync(m => m.IdRepartidor == id);
            if (repartidorEntity == null)
            {
                return NotFound();
            }

            return View(repartidorEntity);
        }

        // GET: Repartidores/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Repartidores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepartidorEntity repartidorEntity)
        {
            if (ModelState.IsValid)
            {
                repartidorEntity.Placa = repartidorEntity.Placa.ToUpper();
                _context.Add(repartidorEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Esta placa ya se encuetra registrada.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(repartidorEntity);
        }

        // GET: Repartidores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repartidorEntity = await _context.Repartidores.FindAsync(id);
            if (repartidorEntity == null)
            {
                return NotFound();
            }
            return View(repartidorEntity);
        }

        // POST: Repartidores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RepartidorEntity repartidorEntity)
        {
            if (id != repartidorEntity.IdRepartidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                repartidorEntity.Placa = repartidorEntity.Placa.ToUpper();
                _context.Update(repartidorEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Esta placa ya se encuentra  registrada.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }

                //try
                //{
                //    repartidorEntity.Placa = repartidorEntity.Placa.ToUpper();
                //    _context.Update(repartidorEntity);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!RepartidorEntityExists(repartidorEntity.IdRepartidor))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //return RedirectToAction(nameof(Index));
            }
            return View(repartidorEntity);
        }

        // GET: Repartidores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repartidorEntity = await _context.Repartidores
                .FirstOrDefaultAsync(m => m.IdRepartidor == id);
            if (repartidorEntity == null)
            {
                return NotFound();
            }

            _context.Repartidores.Remove(repartidorEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //// POST: Repartidores/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{

        //    var repartidorEntity = await _context.Repartidores.FindAsync(id);
        //    _context.Repartidores.Remove(repartidorEntity);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool RepartidorEntityExists(int id)
        {
            return _context.Repartidores.Any(e => e.IdRepartidor == id);
        }
    }
}
