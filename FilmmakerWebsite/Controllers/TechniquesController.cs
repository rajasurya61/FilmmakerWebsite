using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmmakerWebsite;
using FilmmakerWebsite.Models;

namespace FilmmakerWebsite.Controllers
{
    public class TechniquesController : Controller
    {
        private readonly FilmmakingDbContext _context;

        public TechniquesController(FilmmakingDbContext context)
        {
            _context = context;
        }

        // GET: Techniques
        public async Task<IActionResult> Index()
        {
              return _context.Techniques != null ? 
                          View(await _context.Techniques.ToListAsync()) :
                          Problem("Entity set 'FilmmakingDbContext.Techniques'  is null.");
        }

        // GET: Techniques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Techniques == null)
            {
                return NotFound();
            }

            var technique = await _context.Techniques
                .FirstOrDefaultAsync(m => m.TechniqueID == id);
            if (technique == null)
            {
                return NotFound();
            }

            return View(technique);
        }

        // GET: Techniques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Techniques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechniqueID,Title,Description,Example,UploadDate")] Technique technique)
        {
            if (ModelState.IsValid)
            {
                // Set the UploadDate to Utc DateTime
                technique.UploadDate = DateTime.UtcNow;

                _context.Add(technique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(technique);
        }

        // GET: Techniques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Techniques == null)
            {
                return NotFound();
            }

            var technique = await _context.Techniques.FindAsync(id);
            if (technique == null)
            {
                return NotFound();
            }
            return View(technique);
        }

        // POST: Techniques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechniqueID,Title,Description,Example,UploadDate")] Technique technique)
        {
            if (id != technique.TechniqueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Set the UploadDate to Utc DateTime
                    technique.UploadDate = DateTime.UtcNow;

                    _context.Update(technique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechniqueExists(technique.TechniqueID))
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
            return View(technique);
        }

        // GET: Techniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Techniques == null)
            {
                return NotFound();
            }

            var technique = await _context.Techniques
                .FirstOrDefaultAsync(m => m.TechniqueID == id);
            if (technique == null)
            {
                return NotFound();
            }

            return View(technique);
        }

        // POST: Techniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Techniques == null)
            {
                return Problem("Entity set 'FilmmakingDbContext.Techniques'  is null.");
            }
            var technique = await _context.Techniques.FindAsync(id);
            if (technique != null)
            {
                _context.Techniques.Remove(technique);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechniqueExists(int id)
        {
          return (_context.Techniques?.Any(e => e.TechniqueID == id)).GetValueOrDefault();
        }
    }
}
