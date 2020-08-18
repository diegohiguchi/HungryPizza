using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizza.Mappings
{
    public class PizzaMapping : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.Property(c => c.Sabor)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Pizzas");
        }
    }
}
