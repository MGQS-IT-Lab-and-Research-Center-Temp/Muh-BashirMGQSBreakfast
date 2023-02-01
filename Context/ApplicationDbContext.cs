using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGQSBreakfast.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace MGQSBreakfast.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Breakfast> Breakfasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Breakfast>(e => e.Property(o => o.StartDateTime).HasColumnType("datetime(6)").HasConversion<DateTime>());
            modelBuilder.Entity<Breakfast>(e => e.Property(o => o.EndDateTime).HasConversion<DateTime>().HasColumnType("datetime(6)"));
        }
    }
}