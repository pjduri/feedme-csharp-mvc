using feedme_csharp_mvc.Controllers;
using feedme_csharp_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace feedme_csharp_mvc.ViewModels
{
    public class AddChoiceListViewModel
    {
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(55, ErrorMessage = "Character limit exceeded")]
        public string? Name { get; set; }

        [StringLength(255, ErrorMessage = "Character limit exceeded")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? Option1Name { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? Option2Name { get; set; }

        public int ChoiceListLayoutId { get; set; }
        public ChoiceListLayout? ChoiceListLayout { get; set; }
        public List<SelectListItem>? ChoiceListLayouts { get; set; }

        public List<ListOption>? Options { get; set; }

        public AddChoiceListViewModel(List<ChoiceListLayout> listLayouts)
        {
            ChoiceListLayouts = new List<SelectListItem>();

            foreach(ChoiceListLayout listLayout in listLayouts)
            {
                ChoiceListLayouts.Add(
                    new SelectListItem
                    {
                        Value = listLayout.Id.ToString(),
                        Text = listLayout.Name
                    });
            }
            Options = new List<ListOption>();
        }

        public AddChoiceListViewModel()
        {
        }
    }
}
