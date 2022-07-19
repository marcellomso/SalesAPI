using Microsoft.EntityFrameworkCore;
using Sales.Data.Persistence.Map;
using Sales.Domain.Entities;

namespace Sales.Data.Persistence
{
    public class SalesDataContext : DbContext
    {
        public DbSet<Produto>? Produtos { get; set; }


        public SalesDataContext(DbContextOptions<SalesDataContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        //    optionsBuilder
        //        .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SalesDB;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
        }
    }
}
