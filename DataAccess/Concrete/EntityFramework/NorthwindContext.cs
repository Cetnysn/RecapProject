using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=master;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        //public DbSet<Personel> Personels { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // fluent mapping
        //    // modelBuilder.HasDefaultSchema("dbo");
        //    modelBuilder.Entity<Personel>().ToTable("Employees");

        //    modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeID");
        //    modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");
        //    modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");
        //}
    }
}
