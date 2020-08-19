using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserGenerator.Entities;

namespace UserGenerator.Repositories
{
    public class UserRepositoryDbContext : DbContext
    {
        public UserRepositoryDbContext(DbContextOptions<UserRepositoryDbContext> options)
            : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(k => k.Id);
            modelBuilder.Entity<Person>().Property(p => p.NameFirst).IsUnicode().HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.NameLast).IsUnicode().HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.MarkerWord).IsUnicode().HasMaxLength(512).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.MarkedForDelete).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.CreatedTimestamp).IsRequired();
        }
    }
}
