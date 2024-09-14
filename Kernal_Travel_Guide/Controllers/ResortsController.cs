using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Kernal_Travel_Guide.Data;
using Kernal_Travel_Guide.Models;

namespace Kernal_Travel_Guide.Controllers
{
    public class ResortsController : Controller
    {
        private readonly KernalTravelGuideContext _context;

        public ResortsController(KernalTravelGuideContext context)
        {
            _context = context;
        }

        // GET: Resorts
        public async Task<IActionResult> Index()
        {
              return _context.Resorts != null ? 
                          View(await _context.Resorts.ToListAsync()) :
                          Problem("Entity set 'Kernal_Travel_GuideContext.Resort'  is null.");
        }

        // GET: Resorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Resorts == null)
            {
                return NotFound();
            }

            var resort = await _context.Resorts
                .FirstOrDefaultAsync(m => m.ResortId == id);
            if (resort == null)
            {
                return NotFound();
            }

            return View(resort);
        }

        // GET: Resorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResortId,Name,Location,Description,PriceRange,Rating,ImageUrl")] Resort resort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resort);
        }

        // GET: Resorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Resorts == null)
            {
                return NotFound();
            }

            var resort = await _context.Resorts.FindAsync(id);
            if (resort == null)
            {
                return NotFound();
            }
            return View(resort);
        }

        // POST: Resorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResortId,Name,Location,Description,PriceRange,Rating,ImageUrl")] Resort resort)
        {
            if (id != resort.ResortId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResortExists(resort.ResortId))
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
            return View(resort);
        }

        // GET: Resorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Resorts == null)
            {
                return NotFound();
            }

            var resort = await _context.Resorts
                .FirstOrDefaultAsync(m => m.ResortId == id);
            if (resort == null)
            {
                return NotFound();
            }

            return View(resort);
        }

        // POST: Resorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Resorts == null)
            {
                return Problem("Entity set 'Kernal_Travel_GuideContext.Resort'  is null.");
            }
            var resort = await _context.Resorts.FindAsync(id);
            if (resort != null)
            {
                _context.Resorts.Remove(resort);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResortExists(int id)
        {
          return (_context.Resorts?.Any(e => e.ResortId == id)).GetValueOrDefault();
        }
    }
}
