using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserGenerator.Repositories
{
    public class UserRepositoryDbContextFactory : IDesignTimeDbContextFactory<UserRepositoryDbContext>
    {
        private static string connectionString;
        
        public UserRepositoryDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public UserRepositoryDbContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                LoadConnectionString();
            }

            var builder = new DbContextOptionsBuilder<UserRepositoryDbContext>();
            builder.UseSqlServer(connectionString);

            return new UserRepositoryDbContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
    }
}
