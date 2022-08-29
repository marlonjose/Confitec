using Confitec.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(x => x.Escolaridade).HasConversion<int>();
        } 
    }
}