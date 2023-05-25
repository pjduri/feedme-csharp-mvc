using feedme_csharp_mvc.Models;
using Microsoft.Extensions.Options;

namespace feedme_csharp_mvc.ViewModels
{
    public class ChoiceListDetailViewModel
    {
        public int? ChoiceListId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ListOption>? Options { get; set; }
        public ListOption? RandomOption { get; set; }

        public void PickRandomOption()
        {
            var random = new Random();
            var randomIndex = random.Next(0, Options.Count);

            RandomOption = Options[randomIndex];
        }

        public ChoiceListDetailViewModel(ChoiceList theChoiceList)
        {
            ChoiceListId = theChoiceList.Id;
            Name = theChoiceList.Name;
            Description = theChoiceList.Description;
            Options = theChoiceList.Options;
            RandomOption = null;
        }
    }
}
