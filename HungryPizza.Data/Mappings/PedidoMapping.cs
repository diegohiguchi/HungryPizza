using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizza.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Data)
                .IsRequired();

            //builder.OwnsMany(f => f.Pizzas)
            //    .WithOwner(p => p.Pedidos)

            builder.ToTable("Pedidos");
        }
    }
}
