using feedme_csharp_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace feedme_csharp_mvc.ViewModels
{
    public class AddChoiceListLayoutViewModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Must start with at least two lists")]
        public string? List1Name { get; set; }

        [Required(ErrorMessage = "Must start with at least two lists")]
        public string? List2Name { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? List1Description { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? List2Description { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? List1Option1Name { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? List1Option2Name { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? List2Option1Name { get; set; }

        [Required(ErrorMessage = "Must start with at least two options")]
        public string? List2Option2Name { get; set; }

        public List<ChoiceList> ChoiceLists { get; set; }
        public List<ListOption> List1Options { get; set; }
        public List<ListOption> List2Options { get; set; }

        public AddChoiceListLayoutViewModel()
        {
            ChoiceLists = new List<ChoiceList>();
            List1Options = new List<ListOption>();
            List2Options = new List<ListOption>();
        }
    }
}
