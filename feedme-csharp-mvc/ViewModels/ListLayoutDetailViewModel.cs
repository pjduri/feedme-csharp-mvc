using feedme_csharp_mvc.Models;
using System.Security.Cryptography.X509Certificates;

namespace feedme_csharp_mvc.ViewModels
{
    public class ListLayoutDetailViewModel
    {
        public List<ChoiceListLayout>? AllLayouts { get; set; }
        public int? ChoiceListLayoutId { get; set; } 
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ChoiceList>? ChoiceLists { get; set; }
        public List<ChoiceListDetailViewModel>? DetailViewModels { get; set; }
        //public Dictionary<int, List<ListOption>>? OptionsByChoiceListId { get; set; }

        public ListLayoutDetailViewModel(ChoiceListLayout listLayout)
        {
            ChoiceListLayoutId = listLayout.Id;
            Name = listLayout.Name;
            Description = listLayout.Description;
            ChoiceLists = listLayout.ChoiceLists;
            DetailViewModels = new List<ChoiceListDetailViewModel>();
            //OptionsByChoiceListId = new Dictionary<int, List<ListOption>>();
            //foreach(ChoiceList? list in listLayout.ChoiceLists)
            //{
            //    OptionsByChoiceListId[list.Id] = list.Options ?? new List<ListOption>();
            //}
        }
    }
}
