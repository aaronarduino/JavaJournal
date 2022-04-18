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
    public class BeanPresetController : Controller
    {
        private readonly TastingEntryDbContext _context;

        public BeanPresetController(TastingEntryDbContext context)
        {
            _context = context;
        }

        // GET: BeanPreset
        public async Task<IActionResult> Index()
        {
            return View(await _context.BeanPreset.ToListAsync());
        }

        // GET: BeanPreset/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beanPreset = await _context.BeanPreset
                .FirstOrDefaultAsync(m => m.BeanPresetId == id);
            if (beanPreset == null)
            {
                return NotFound();
            }

            return View(beanPreset);
        }

        // GET: BeanPreset/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeanPreset/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BeanPresetId,PresetName,Name,Roastery,Origin,BeanType,Roast,Grind")] BeanPreset beanPreset)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beanPreset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beanPreset);
        }

        // GET: BeanPreset/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beanPreset = await _context.BeanPreset.FindAsync(id);
            if (beanPreset == null)
            {
                return NotFound();
            }
            return View(beanPreset);
        }

        // POST: BeanPreset/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("BeanPresetId,PresetName,Name,Roastery,Origin,BeanType,Roast,Grind")] BeanPreset beanPreset)
        {
            if (id != beanPreset.BeanPresetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beanPreset);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeanPresetExists(beanPreset.BeanPresetId))
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
            return View(beanPreset);
        }

        // GET: BeanPreset/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beanPreset = await _context.BeanPreset
                .FirstOrDefaultAsync(m => m.BeanPresetId == id);
            if (beanPreset == null)
            {
                return NotFound();
            }

            return View(beanPreset);
        }

        // POST: BeanPreset/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var beanPreset = await _context.BeanPreset.FindAsync(id);
            _context.BeanPreset.Remove(beanPreset);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeanPresetExists(uint id)
        {
            return _context.BeanPreset.Any(e => e.BeanPresetId == id);
        }
    }
}
