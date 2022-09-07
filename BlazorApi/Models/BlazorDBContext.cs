using BlazorModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorApi.Models
{
    public partial class BlazorDBContext : DbContext
    { 
        public BlazorDBContext(DbContextOptions<BlazorDBContext> options)
           : base(options)
        {

        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Nationality> Nationalities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
               new Company { Id = 1, CompanyName = "Webenit", DOJ = new DateTime(1983, 1, 1) }
           );

            modelBuilder.Entity<Nationality>().HasData(
               new Nationality { Id = 1, Name = "India" }
           );
             
        } 
    }
}
