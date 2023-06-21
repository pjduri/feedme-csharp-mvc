using feedme_csharp_mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace feedme_csharp_mvc.ViewModels
{
    public class FeedMeNowViewModel
    {
        public List<ListLayoutDetailViewModel>? ListLayouts { get; set; }

        public FeedMeNowViewModel(List<ChoiceListLayout> listLayouts)
        {
            ListLayouts = new List<ListLayoutDetailViewModel>();
            foreach(ChoiceListLayout? listLayout in listLayouts)
            {
                ListLayouts.Add(new ListLayoutDetailViewModel(listLayout));
            }
        }
        public FeedMeNowViewModel() { }
    }
}
