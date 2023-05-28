using feedme_csharp_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace feedme_csharp_mvc.ViewModels
{
    public class AddOptionViewModel
    {
        [Required(ErrorMessage = "Please enter an option")]
        [StringLength(55, MinimumLength = 1, ErrorMessage = "Entry must be between 1 and 55 characters long.")]
        public string? Name { get; set; }

        public int ChoiceListId { get; set; }
        public ChoiceList? ChoiceList { get; set; }

        public List<SelectListItem>? ChoiceLists { get; set; }

        public AddOptionViewModel(List<ChoiceList> choicelists)
        {
            ChoiceLists = new List<SelectListItem>();

            foreach (var choiceList in choicelists)
            {
                ChoiceLists.Add(
                    new SelectListItem
                    {
                        Value = choiceList.Id.ToString(),
                        Text = choiceList.Name
                    }
                );
            }
        }

        public AddOptionViewModel() { }
    }
}
