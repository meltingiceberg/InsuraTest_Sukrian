using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CitizenDbContext>
    {
        public CitizenDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../Test_API/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<CitizenDbContext>();
            var connectionString = configuration.GetConnectionString("CitizenDB");
            builder.UseSqlServer(connectionString);
            return new CitizenDbContext(builder.Options);
        }
    }
}
