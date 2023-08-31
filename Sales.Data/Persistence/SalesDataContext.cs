using Microsoft.EntityFrameworkCore;
using Sales.Data.Persistence.Map;
using Sales.Domain.Entities;

namespace Sales.Data.Persistence;

public class SalesDataContext : DbContext
{
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Venda>? Vendas { get; set; }
    public DbSet<Item>? Itens { get; set; }

    public SalesDataContext(DbContextOptions<SalesDataContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
        modelBuilder.ApplyConfiguration(new VendaConfiguracao());
        modelBuilder.ApplyConfiguration(new ItemConfiguracao());
    }

    public void Update()
    {
        if (Database.CanConnect())
            Database.Migrate();
    }
}
