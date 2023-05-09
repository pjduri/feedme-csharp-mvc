using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using feedme_csharp_mvc.Data;
using feedme_csharp_mvc.Models;
using Microsoft.AspNetCore.Authorization;

namespace feedme_csharp_mvc.Controllers
{
    public class ListOptionsController : Controller
    {
        private readonly FeedMeDbContext _context;

        public ListOptionsController(FeedMeDbContext context)
        {
            _context = context;
        }

        // GET: ListOptions
        public async Task<IActionResult> Index()
        {
            var feedMeDbContext = _context.options.Include(l => l.ChoiceList);
            return View(await feedMeDbContext.ToListAsync());
        }

        // GET: ListOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.options == null)
            {
                return NotFound();
            }

            var listOption = await _context.options
                .Include(l => l.ChoiceList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOption == null)
            {
                return NotFound();
            }

            return View(listOption);
        }

        // GET: ListOptions/Create
        public IActionResult Create()
        {
            ViewData["ChoiceListId"] = new SelectList(_context.choiceLists, "Id", "Id");
            return View();
        }

        // POST: ListOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ChoiceListId")] ListOption listOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChoiceListId"] = new SelectList(_context.choiceLists, "Id", "Id", listOption.ChoiceListId);
            return View(listOption);
        }

        // GET: ListOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.options == null)
            {
                return NotFound();
            }

            var listOption = await _context.options.FindAsync(id);
            if (listOption == null)
            {
                return NotFound();
            }
            ViewData["ChoiceListId"] = new SelectList(_context.choiceLists, "Id", "Id", listOption.ChoiceListId);
            return View(listOption);
        }

        // POST: ListOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ChoiceListId")] ListOption listOption)
        {
            if (id != listOption.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOptionExists(listOption.Id))
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
            ViewData["ChoiceListId"] = new SelectList(_context.choiceLists, "Id", "Id", listOption.ChoiceListId);
            return View(listOption);
        }

        // GET: ListOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.options == null)
            {
                return NotFound();
            }

            var listOption = await _context.options
                .Include(l => l.ChoiceList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOption == null)
            {
                return NotFound();
            }

            return View(listOption);
        }

        // POST: ListOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.options == null)
            {
                return Problem("Entity set 'FeedMeDbContext.options'  is null.");
            }
            var listOption = await _context.options.FindAsync(id);
            if (listOption != null)
            {
                _context.options.Remove(listOption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOptionExists(int id)
        {
          return (_context.options?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
