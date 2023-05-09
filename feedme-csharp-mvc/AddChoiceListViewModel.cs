using feedme_csharp_mvc.Models;
using System.ComponentModel.DataAnnotations;

namespace feedme_csharp_mvc
{
    public class AddChoiceListViewModel
    {
        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(55, ErrorMessage = "Character limit exceeded")]
        public string? Name { get; set; }

        [StringLength(255, ErrorMessage = "Character limit exceeded")]
        public string? Description { get; set; }

        public AddChoiceListViewModel()
        {
        }
    }
}
