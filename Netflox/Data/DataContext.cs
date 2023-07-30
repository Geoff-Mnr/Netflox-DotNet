using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Netflox.Models;
using Netflox.Pages.Admin.Profils;
using System.Configuration;

namespace Netflox.Data
{
    public class DataContext : IdentityDbContext<MainUsers>
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

      
        public DbSet<Movie> Movies { get; set; }

        
        public DbSet<MainUsers> MainUsers { get; set; }

        public DbSet<Profiles> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(movie =>
            {
                movie.HasKey(x => x.MovieID);
            });

            modelBuilder.Entity<Profiles>(profil =>
            {
                profil.HasKey(x => x.ProfilID);
              
                profil.HasOne(x => x.MainUsers)
                    .WithMany(x => x.Profiles)
                    .HasForeignKey(x => x.MainUsersId)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
