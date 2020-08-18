using HungryPizza.Business.Models;
using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizza.Mappings
{
    public class PedidoPizzaMapping : IEntityTypeConfiguration<PedidoPizza>
    {
        public void Configure(EntityTypeBuilder<PedidoPizza> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(f => f.Pizza)
                .WithMany(p => p.PedidoPizzas)
                .HasForeignKey(x => x.PizzaId);

            builder.HasOne(f => f.Pedido)
              .WithMany(p => p.PedidoPizzas)
              .HasForeignKey(x => x.PedidoId);

            builder.ToTable("PedidoPizzas");
        }
    }
}
