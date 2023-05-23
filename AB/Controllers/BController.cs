using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AB.Data;
using AB.Models;

namespace AB.Controllers
{
    public class BController : Controller
    {
        private readonly ABContext _context;

        public BController(ABContext context)
        {
            _context = context;
        }

        // GET: B
        public async Task<IActionResult> Index()
        {
            var aBContext = _context.B.Include(b => b.A);
            return View(await aBContext.ToListAsync());
        }

        // GET: B/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.B == null)
            {
                return NotFound();
            }

            var b = await _context.B
                .Include(b => b.A)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        // GET: B/Create
        public IActionResult Create()
        {
            ViewData["AId"] = new SelectList(_context.A, "Id", "PDM");
            return View();
        }

        // POST: B/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,One,Two,Three,AId")] B b)
        {
            if (ModelState.IsValid)
            {
                _context.Add(b);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AId"] = new SelectList(_context.A, "Id", "Id", b.AId);
            return View(b);
        }

        // GET: B/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.B == null)
            {
                return NotFound();
            }

            var b = await _context.B.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            ViewData["AId"] = new SelectList(_context.A, "Id", "Id", b.AId);
            return View(b);
        }

        // POST: B/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,One,Two,Three,AId")] B b)
        {
            if (id != b.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(b);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BExists(b.Id))
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
            ViewData["AId"] = new SelectList(_context.A, "Id", "Id", b.AId);
            return View(b);
        }

        // GET: B/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.B == null)
            {
                return NotFound();
            }

            var b = await _context.B
                .Include(b => b.A)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        // POST: B/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.B == null)
            {
                return Problem("Entity set 'ABContext.B'  is null.");
            }
            var b = await _context.B.FindAsync(id);
            if (b != null)
            {
                _context.B.Remove(b);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BExists(int id)
        {
          return (_context.B?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
