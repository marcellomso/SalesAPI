using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Data.Persistence.Map
{
    public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            builder.Property(p => p.Estoque).IsRequired();
            builder.Property(p => p.Excluido).IsRequired();

            builder.Ignore(p => p.Notifications);
        }
    }
}
