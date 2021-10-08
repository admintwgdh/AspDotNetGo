using AspDotNetGo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace AspDotNetGo.Common
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DbSet<Student> Student { get; set; }
        public IConfiguration Configuration { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(Configuration["ConnectionStrings:MySQL"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Student>(entity =>
            //{
            //    entity.HasKey(e => e.IdCard);
            //    entity.Property(e => e.Name).IsRequired();
            //});
        }
    }
}
