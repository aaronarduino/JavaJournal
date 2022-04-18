using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JavaJournal.Data;
using JavaJournal.Models;

namespace JavaJournal.Controllers
{
    public class TastingController : Controller
    {
        private readonly TastingEntryDbContext _context;

        public TastingController(TastingEntryDbContext context)
        {
            _context = context;
        }

        // GET: Tasting
        public async Task<IActionResult> Index()
        {
            var vm = await _context.TastingEntry.Include(e => e.BeanPreset).ToListAsync();
            return View(vm);
        }

        // GET: Tasting/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tastingEntry = await _context.TastingEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tastingEntry == null)
            {
                return NotFound();
            }

            return View(tastingEntry);
        }

        // GET: Tasting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EntryDate,BeanPreset")] TastingEntry tastingEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tastingEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tastingEntry);
        }

        // GET: Tasting/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tastingEntry = await _context.TastingEntry.FindAsync(id);
            if (tastingEntry == null)
            {
                return NotFound();
            }
            return View(tastingEntry);
        }

        // POST: Tasting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Name,EntryDate")] TastingEntry tastingEntry)
        {
            if (id != tastingEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tastingEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TastingEntryExists(tastingEntry.Id))
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
            return View(tastingEntry);
        }

        // GET: Tasting/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tastingEntry = await _context.TastingEntry
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tastingEntry == null)
            {
                return NotFound();
            }

            return View(tastingEntry);
        }

        // POST: Tasting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var tastingEntry = await _context.TastingEntry.FindAsync(id);
            _context.TastingEntry.Remove(tastingEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TastingEntryExists(uint id)
        {
            return _context.TastingEntry.Any(e => e.Id == id);
        }
    }
}
