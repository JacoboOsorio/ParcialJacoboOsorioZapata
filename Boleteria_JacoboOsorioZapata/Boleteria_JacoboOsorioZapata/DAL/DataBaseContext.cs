using Microsoft.EntityFrameworkCore;
using Boleteria_JacoboOsorioZapata.DAL.Entities;

namespace Boleteria_JacoboOsorioZapata.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext>options) : base(options)
        {

        }

        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tickets>().HasIndex(c => c.Id).IsUnique();
        }
    }
}
