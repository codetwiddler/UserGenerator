using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserGenerator.Entities;

namespace UserGenerator.Repositories
{
    public class UserGeneratorDbContext : DbContext
    {
        public UserGeneratorDbContext(DbContextOptions<UserGeneratorDbContext> options)
            : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
