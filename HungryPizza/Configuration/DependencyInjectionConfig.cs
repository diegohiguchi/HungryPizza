using HungryPizza.Business.Interfaces;
using HungryPizza.Business.Notificacoes;
using HungryPizza.Business.Services;
using HungryPizza.Data;
using HungryPizza.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HungryPizza.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoPizzaRepository, PedidoPizzaRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
