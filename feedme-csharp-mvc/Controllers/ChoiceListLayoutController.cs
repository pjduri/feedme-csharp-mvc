using feedme_csharp_mvc.Data;
using feedme_csharp_mvc.Models;
using feedme_csharp_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace feedme_csharp_mvc.Controllers
{
    public class ChoiceListLayoutController : Controller
    {
        private readonly FeedMeDbContext _context;

        public ChoiceListLayoutController(FeedMeDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (_context.ChoiceListLayouts is null)
            {
                return NotFound();
            }

            List<ChoiceListLayout> listLayouts = await _context.ChoiceListLayouts.Include(c => c.ChoiceLists).ToListAsync();

            FeedMeNowViewModel feedMeNowViewModel = new FeedMeNowViewModel(listLayouts);

            return View(feedMeNowViewModel);
            //return _context.ChoiceListLayouts != null ?
            //            View(await _context.ChoiceListLayouts.ToListAsync()) :
            //            Problem("Entity set 'FeedMeDbContext.ChoiceListLayouts'  is null.");
        }

        public IActionResult Create()
        {
            AddChoiceListLayoutViewModel addChoiceListLayoutViewModel = new();
            return View(addChoiceListLayoutViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] AddChoiceListLayoutViewModel? addChoiceListLayoutViewModel)
        {
            if (ModelState.IsValid)
            {
                ChoiceListLayout choiceListLayout = new ChoiceListLayout
                {
                    Name = addChoiceListLayoutViewModel.Name,
                    Description = addChoiceListLayoutViewModel.Description
                };

                _context.ChoiceListLayouts.Add(choiceListLayout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                //ListOption list1Option1 = new ListOption(addChoiceListLayoutViewModel.List1Option1Name);
                //ListOption list1Option2 = new ListOption(addChoiceListLayoutViewModel.List1Option2Name);
                //ListOption list2Option1 = new ListOption(addChoiceListLayoutViewModel.List2Option1Name);
                //ListOption list2Option2 = new ListOption(addChoiceListLayoutViewModel.List2Option2Name);

                //ChoiceList choiceList1 = new ChoiceList
                //{
                //    Name = addChoiceListLayoutViewModel.List1Name,
                //    Description = addChoiceListLayoutViewModel.List1Description,
                //    Options = new List<ListOption>
                //    {
                //        list1Option1,
                //        list1Option2
                //    }
                //};
                //list1Option1.ChoiceList = choiceList1;
                //list1Option2.ChoiceList = choiceList1;

                //ChoiceList choiceList2 = new ChoiceList
                //{
                //    Name = addChoiceListLayoutViewModel.List2Name,
                //    Description = addChoiceListLayoutViewModel.List2Description,
                //    Options = new List<ListOption>
                //    {
                //        list2Option1,
                //        list2Option2
                //    }
                //};
                //list2Option1.ChoiceList = choiceList2;
                //list2Option2.ChoiceList = choiceList2;

                //ChoiceListLayout choiceListLayout = new ChoiceListLayout
                //{
                //    Name = addChoiceListLayoutViewModel.Name,
                //    Description = addChoiceListLayoutViewModel.Description,
                //    ChoiceLists = new List<ChoiceList>
                //    {
                //        choiceList1,
                //        choiceList2
                //    }
                //};
                //choiceList1.ChoiceListLayout = choiceListLayout;
                //choiceList2.ChoiceListLayout = choiceListLayout;

                //_context.Options.Add(list1Option1);
                //_context.Options.Add(list1Option2);
                //_context.Options.Add(list2Option1);
                //_context.Options.Add(list2Option2);
                //_context.ChoiceLists.Add(choiceList1);
                //_context.ChoiceLists.Add(choiceList2);
            }
            return View(addChoiceListLayoutViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || _context.ChoiceListLayouts == null)
            {
                return NotFound();
            }

            ChoiceListLayout? listLayout = _context.ChoiceListLayouts
                .Include(cll => cll.ChoiceLists)
                .FirstOrDefault(ll => ll.Id == id);

            if (listLayout == null)
            {
                return NotFound();
            }

            ListLayoutDetailViewModel viewModel = new ListLayoutDetailViewModel(listLayout);

            return View(viewModel);
        }
        
        public IActionResult DetailsPartial(int? id)
        {
            if (id == null || _context.ChoiceListLayouts == null)
            {
                return NotFound();
            }

            ChoiceListLayout? listLayout = _context.ChoiceListLayouts
                .Include(cll => cll.ChoiceLists)
                .FirstOrDefault(ll => ll.Id == id);

            if (listLayout == null)
            {
                return NotFound();
            }

            ListLayoutDetailViewModel viewModel = new ListLayoutDetailViewModel(listLayout);

            return PartialView("_ListLayoutDetailsPartial", viewModel);
        }
    }
}
