using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;


namespace Sales.Data.Persistence.Map
{
    public class ItemConfiguracao : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Quantidade).IsRequired();
            builder.Property(i => i.PrecoUnitario).IsRequired();

            builder.Ignore(i => i.ValorTotal);
            builder.Ignore(i => i.Notifications);
        }
    }
}
