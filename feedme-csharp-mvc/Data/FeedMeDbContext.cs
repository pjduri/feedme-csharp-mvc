﻿using feedme_csharp_mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace feedme_csharp_mvc.Data
{
    public class FeedMeDbContext : IdentityDbContext<IdentityUser, IdentityRole, string> 
    {
        DbSet<ChoiceList> choiceLists {get; set;}
        DbSet<Option> options { get; set;}

        public FeedMeDbContext(DbContextOptions<FeedMeDbContext> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChoiceList>()
                .HasMany(c => c.Options)
                .WithOne(op => op.ChoiceList);

            modelBuilder.Entity<Option>()
                .HasOne(op => op.ChoiceList)
                .WithMany(options => options.Options);

            base.OnModelCreating(modelBuilder);
        }
    }
}
