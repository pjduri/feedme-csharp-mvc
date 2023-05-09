using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using feedme_csharp_mvc.Data;
using feedme_csharp_mvc.Models;

namespace feedme_csharp_mvc.Controllers
{
    public class ChoiceListsController : Controller
    {
        private readonly FeedMeDbContext _context;

        public ChoiceListsController(FeedMeDbContext context)
        {
            _context = context;
        }

        // GET: ChoiceLists
        public async Task<IActionResult> Index()
        {
              return _context.choiceLists != null ? 
                          View(await _context.choiceLists.ToListAsync()) :
                          Problem("Entity set 'FeedMeDbContext.choiceLists'  is null.");
        }

        // GET: ChoiceLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.choiceLists == null)
            {
                return NotFound();
            }

            var choiceList = await _context.choiceLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (choiceList == null)
            {
                return NotFound();
            }

            return View(choiceList);
        }

        // GET: ChoiceLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChoiceLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] ChoiceList choiceList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(choiceList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(choiceList);
        }

        // GET: ChoiceLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.choiceLists == null)
            {
                return NotFound();
            }

            var choiceList = await _context.choiceLists.FindAsync(id);
            if (choiceList == null)
            {
                return NotFound();
            }
            return View(choiceList);
        }

        // POST: ChoiceLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ChoiceList choiceList)
        {
            if (id != choiceList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(choiceList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChoiceListExists(choiceList.Id))
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
            return View(choiceList);
        }

        // GET: ChoiceLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.choiceLists == null)
            {
                return NotFound();
            }

            var choiceList = await _context.choiceLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (choiceList == null)
            {
                return NotFound();
            }

            return View(choiceList);
        }

        // POST: ChoiceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.choiceLists == null)
            {
                return Problem("Entity set 'FeedMeDbContext.choiceLists'  is null.");
            }
            var choiceList = await _context.choiceLists.FindAsync(id);
            if (choiceList != null)
            {
                _context.choiceLists.Remove(choiceList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoiceListExists(int id)
        {
          return (_context.choiceLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
