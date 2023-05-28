using feedme_csharp_mvc.Models;
using Microsoft.Extensions.Options;

namespace feedme_csharp_mvc.ViewModels
{
    public class ChoiceListDetailViewModel
    {
        public int? ChoiceListId { get; set; }
        public string? ChoiceListName { get; set; }
        public string? ChoiceListDescription { get; set; }
        public List<string>? OptionNames { get; set; }

        public ChoiceListDetailViewModel(ChoiceList theChoiceList)
        {
            ChoiceListId = theChoiceList.Id;
            ChoiceListName = theChoiceList.Name;
            ChoiceListDescription = theChoiceList.Description;
            OptionNames = theChoiceList.Options.Select(o => o.Name).ToList();
        }
    }
}
