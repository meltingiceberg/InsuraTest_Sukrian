using Microsoft.EntityFrameworkCore;
using Test_BusinessLogic;

namespace Test_DataAccess
{
    public class CitizenDbContext : DbContext
    {
        public CitizenDbContext(DbContextOptions<CitizenDbContext> options) : base(options) { }

        public virtual DbSet<Citizen> Citizens { get; set; }
    }
}