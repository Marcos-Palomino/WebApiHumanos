using Microsoft.EntityFrameworkCore;
using WebApiHumanos.Data.Configurations;
using WebApiHumanos.Models;

namespace HumanOperationsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Humano> Humanos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HumanoConfiguration());
        }
    }
}
