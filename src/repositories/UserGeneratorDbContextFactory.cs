using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserGenerator.Repositories
{
    public class UserGeneratorDbContextFactory : IDesignTimeDbContextFactory<UserGeneratorDbContext>
    {
        private static string connectionString;
        
        public UserGeneratorDbContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public UserGeneratorDbContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                LoadConnectionString();
            }

            var builder = new DbContextOptionsBuilder<UserGeneratorDbContext>();
            builder.UseSqlServer(connectionString);

            return new UserGeneratorDbContext(builder.Options);
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
