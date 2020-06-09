using Funder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Funder.Repository
{
    public class FunderDbContext : DbContext
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Media> Medias { get; set; }        
        //public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Fund> Funds { get; set; }

        public DbSet<BackedFunds> BackedFunds { get; set; }





        //public readonly static string connectionString=
        //    "Server=localhost;" +
        //    "Database=funder;" +
        //    "User id=sa;" +
        //    "Password=admin!@#123;" +
        //    "Trusted_Connection=False;MultipleActiveResultSets=true";

        public readonly static string connectionString =
                    "Data Source=localhost;" +
                    "Initial Catalog = Funder; " +
                    "Integrated Security = True;";

        public FunderDbContext(DbContextOptions<FunderDbContext> options)
                : base(options)
        { 
        
        }
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


    }
}
