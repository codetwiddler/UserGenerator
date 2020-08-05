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
    }
}
