using feedme_csharp_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace feedme_csharp_mvc.Data
{
    public class FeedMeDbContext : DbContext
    {
        DbSet<ChoiceList> choiceLists {get; set;}
        DbSet<Option> options { get; set;}

        public FeedMeDbContext(DbContextOptions<FeedMeDbContext> options)
      : base(options)
        {
        }


    }
}
