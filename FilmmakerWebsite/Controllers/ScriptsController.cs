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
    public class ScriptsController : Controller
    {
        private readonly FilmmakingDbContext _context;

        public ScriptsController(FilmmakingDbContext context)
        {
            _context = context;
        }

        // GET: Scripts
        public async Task<IActionResult> Index()
        {
              return _context.Scripts != null ? 
                          View(await _context.Scripts.ToListAsync()) :
                          Problem("Entity set 'FilmmakingDbContext.Scripts'  is null.");
        }

        // GET: Scripts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Scripts == null)
            {
                return NotFound();
            }

            var script = await _context.Scripts
                .FirstOrDefaultAsync(m => m.ScriptID == id);
            if (script == null)
            {
                return NotFound();
            }

            return View(script);
        }

        // GET: Scripts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scripts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScriptID,Title,Content,UploadDate,Author")] Script script)
        {
            if (ModelState.IsValid)
            {
                // Set the UploadDate to Utc DateTime
                script.UploadDate = DateTime.UtcNow;

                _context.Add(script);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(script);
        }

        // GET: Scripts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Scripts == null)
            {
                return NotFound();
            }

            var script = await _context.Scripts.FindAsync(id);
            if (script == null)
            {
                return NotFound();
            }
            return View(script);
        }

        // POST: Scripts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScriptID,Title,Content,UploadDate,Author")] Script script)
        {
            if (id != script.ScriptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Set the UploadDate to Utc DateTime
                    script.UploadDate = DateTime.UtcNow;

                    _context.Update(script);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScriptExists(script.ScriptID))
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
            return View(script);
        }


        // GET: Scripts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Scripts == null)
            {
                return NotFound();
            }

            var script = await _context.Scripts
                .FirstOrDefaultAsync(m => m.ScriptID == id);
            if (script == null)
            {
                return NotFound();
            }

            return View(script);
        }

        // POST: Scripts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Scripts == null)
            {
                return Problem("Entity set 'FilmmakingDbContext.Scripts'  is null.");
            }
            var script = await _context.Scripts.FindAsync(id);
            if (script != null)
            {
                _context.Scripts.Remove(script);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScriptExists(int id)
        {
          return (_context.Scripts?.Any(e => e.ScriptID == id)).GetValueOrDefault();
        }
    }
}
