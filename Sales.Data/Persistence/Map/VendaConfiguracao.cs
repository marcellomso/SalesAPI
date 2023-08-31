using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Data.Persistence.Map;

public class VendaConfiguracao : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.HasKey(v => v.Id);
        builder.Property(v => v.DataHora).IsRequired();
        builder.Property(v => v.TotalVenda).IsRequired();
        builder.Property(v => v.TotalPago).IsRequired();
        builder.Property(v => v.Troco).IsRequired();
        builder.Property(v => v.Status).IsRequired();

        builder.Ignore(v => v.Notifications);
    }
}
