using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using feedme_csharp_mvc.Data;
using feedme_csharp_mvc.Models;
using feedme_csharp_mvc.ViewModels;

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
            return _context.ChoiceLists != null ?
                        View(await _context.ChoiceLists.ToListAsync()) :
                        Problem("Entity set 'FeedMeDbContext.ChoiceLists'  is null.");
        }

        // GET: ChoiceLists/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.ChoiceLists == null)
            {
                return NotFound();
            }

            ChoiceList? choiceList = _context.ChoiceLists
                .Include(cl => cl.Options)
                .FirstOrDefault(c => c.Id == id);

            if (choiceList == null)
            {
                return NotFound();
            }

            ChoiceListDetailViewModel viewModel = new ChoiceListDetailViewModel(choiceList);

            return View(viewModel);
        }
        
        public IActionResult DetailsPartial(int? id)
        {
            if (id == null || _context.ChoiceLists == null)
            {
                return NotFound();
            }

            ChoiceList? choiceList = _context.ChoiceLists
                .Include(cl => cl.Options)
                .FirstOrDefault(c => c.Id == id);

            if (choiceList == null)
            {
                return NotFound();
            }

            ChoiceListDetailViewModel viewModel = new ChoiceListDetailViewModel(choiceList);

            return PartialView("../Views/Shared/_ChoiceListDetailPartial", viewModel);
        }

        // GET: ChoiceLists/Create
        public IActionResult Create()
        {
            AddChoiceListViewModel addChoiceListViewModel = new AddChoiceListViewModel(_context.ChoiceListLayouts.ToList());
            return View(addChoiceListViewModel);
        }

        // POST: ChoiceLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description, Option1Name, Option2Name, ChoiceListLayoutId")] AddChoiceListViewModel addChoiceListViewModel)
        {
            if (ModelState.IsValid)
            {
                ListOption option1 = new ListOption(addChoiceListViewModel.Option1Name);
                ListOption option2 = new ListOption(addChoiceListViewModel.Option2Name);

                ChoiceListLayout? listLayout = await _context.ChoiceListLayouts.FindAsync(addChoiceListViewModel.ChoiceListLayoutId);

                ChoiceList choiceList = new ChoiceList
                {
                    Name = addChoiceListViewModel.Name,
                    Description = addChoiceListViewModel.Description,
                    Options = new List<ListOption>
                    {
                        option1,
                        option2
                    },
                    ChoiceListLayout = listLayout
                };

                listLayout.ChoiceLists ??= new List<ChoiceList>();

                listLayout.ChoiceLists.Add(choiceList);

                _context.ChoiceLists.Add(choiceList);
                await _context.SaveChangesAsync();
                //return Json(new { success = true });
                return Redirect("Index");
            }
            //return NoContent();
            return View(addChoiceListViewModel);
        }

        [HttpGet]
        public IActionResult GetRandomOption(int id)
        {
            // Retrieve the ChoiceList from the database based on the provided id
            var choiceList = _context.ChoiceLists.FirstOrDefault(c => c.Id == id);

            if (choiceList == null)
            {
                return NotFound();
            }

            // Get the list of options from the ChoiceList
            var options = choiceList.Options;

            if (options.Count == 0)
            {
                return NoContent();
            }

            // Generate a random index
            var random = new Random();
            var randomIndex = random.Next(0, options.Count);

            // Retrieve the randomly selected option
            ListOption randomOption = options[randomIndex];

            // Redirect to the details page of the random option
            return View(randomOption);
        }


        //[HttpGet]
        //public IActionResult Random(int id)
        //{
        //    var choiceList = _context.choiceLists.FirstOrDefault(c => c.Id == id);

        //    if (choiceList == null)
        //    {
        //        return NotFound();
        //    }

        //    var options = choiceList.Options;

        //    if (options.Count == 0)
        //    {
        //        return NoContent();
        //    }

        //    var random = new Random();
        //    var randomIndex = random.Next(0, options.Count);

        //    var randomOption = options[randomIndex];

        //    return View(randomOption);
        //}



        // GET: ChoiceLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChoiceLists == null)
            {
                return NotFound();
            }

            var choiceList = await _context.ChoiceLists.FindAsync(id);
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
            if (id == null || _context.ChoiceLists == null)
            {
                return NotFound();
            }

            var choiceList = await _context.ChoiceLists
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
            if (_context.ChoiceLists == null || _context.Options == null)
            {
                return Problem("Entity set 'FeedMeDbContext.choiceLists'  is null.");
            }

            ChoiceList choiceList = await _context.ChoiceLists.FindAsync(id);
            if (choiceList != null)
            {
                List<ListOption> options = await _context.Options.Where(o => o.ChoiceListId == choiceList.Id).ToListAsync();
                foreach (ListOption option in options)
                {
                    _context.Options.Remove(option);
                }
                _context.ChoiceLists.Remove(choiceList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChoiceListExists(int id)
        {
          return (_context.ChoiceLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
