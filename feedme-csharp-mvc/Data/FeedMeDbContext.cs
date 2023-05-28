using feedme_csharp_mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace feedme_csharp_mvc.Data
{
    public class FeedMeDbContext : IdentityDbContext<IdentityUser, IdentityRole, string> 
    {
        public DbSet<ChoiceList>? ChoiceLists {get; set;}
        public DbSet<ListOption>? Options { get; set;}
        public DbSet<ChoiceListLayout>? ChoiceListLayouts { get; set;}

        public FeedMeDbContext(DbContextOptions<FeedMeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChoiceListLayout>()
                .HasMany(c => c.ChoiceLists)
                .WithOne(op => op.ChoiceListLayout);

            modelBuilder.Entity<ChoiceList>()
                .HasOne(cll => cll.ChoiceListLayout)
                .WithMany(c => c.ChoiceLists);

            modelBuilder.Entity<ChoiceList>()
                .HasMany(c => c.Options)
                .WithOne(op => op.ChoiceList);

            modelBuilder.Entity<ListOption>()
                .HasOne(op => op.ChoiceList)
                .WithMany(options => options.Options);

            base.OnModelCreating(modelBuilder);
        }
    }
}
