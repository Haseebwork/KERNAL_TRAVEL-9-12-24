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
    public class TravelInfoesController : Controller
    {
        private readonly KernalTravelGuideContext _context;

        public TravelInfoesController(KernalTravelGuideContext context)
        {
            _context = context;
        }

        // GET: TravelInfoes
        public async Task<IActionResult> Index()
        {
              return _context.TravelInfos != null ? 
                          View(await _context.TravelInfos.ToListAsync()) :
                          Problem("Entity set 'Kernal_Travel_GuideContext.TravelInfo'  is null.");
        }

        // GET: TravelInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TravelInfos == null)
            {
                return NotFound();
            }

            var travelInfo = await _context.TravelInfos
                .FirstOrDefaultAsync(m => m.TravelInfoId == id);
            if (travelInfo == null)
            {
                return NotFound();
            }

            return View(travelInfo);
        }

        // GET: TravelInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelInfoId,ModeOfTransport,Description,Availability,PriceRange")] TravelInfo travelInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelInfo);
        }

        // GET: TravelInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TravelInfos == null)
            {
                return NotFound();
            }

            var travelInfo = await _context.TravelInfos.FindAsync(id);
            if (travelInfo == null)
            {
                return NotFound();
            }
            return View(travelInfo);
        }

        // POST: TravelInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelInfoId,ModeOfTransport,Description,Availability,PriceRange")] TravelInfo travelInfo)
        {
            if (id != travelInfo.TravelInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelInfoExists(travelInfo.TravelInfoId))
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
            return View(travelInfo);
        }

        // GET: TravelInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TravelInfos == null)
            {
                return NotFound();
            }

            var travelInfo = await _context.TravelInfos
                .FirstOrDefaultAsync(m => m.TravelInfoId == id);
            if (travelInfo == null)
            {
                return NotFound();
            }

            return View(travelInfo);
        }

        // POST: TravelInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TravelInfos == null)
            {
                return Problem("Entity set 'Kernal_Travel_GuideContext.TravelInfo'  is null.");
            }
            var travelInfo = await _context.TravelInfos.FindAsync(id);
            if (travelInfo != null)
            {
                _context.TravelInfos.Remove(travelInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelInfoExists(int id)
        {
          return (_context.TravelInfos?.Any(e => e.TravelInfoId == id)).GetValueOrDefault();
        }
    }
}
