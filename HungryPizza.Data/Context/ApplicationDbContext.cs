using HungryPizza.Business.Models;
using HungryPizza.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HungryPizza.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoPizza> PedidoPizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.Entity<Pizza>()
                .HasData(
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Sabor = "3 Queijos",
                        Valor = 50
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Sabor = "Frango com requeijão",
                        Valor = 59.99m
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Sabor = "Mussarela",
                        Valor = 42.50m
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Sabor = "Calabresa",
                        Valor = 42.50m
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Sabor = "Pepperoni",
                        Valor = 55
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Sabor = "Portuguesa",
                        Valor = 45
                    },
                    new Pizza
                    {
                        Id = Guid.NewGuid(),
                        Sabor = "Veggie",
                        Valor = 59.99m
                    }
                );

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
