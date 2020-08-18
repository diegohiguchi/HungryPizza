using AutoMapper;
using HungryPizza.Business.Models;
using HungryPizza.Models;
using HungryPizza.ViewModels;

namespace HungryPizza.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoViewModel>().ReverseMap();
            CreateMap<Pedido, PedidoDetalhesViewModel>().ReverseMap();
            CreateMap<Pizza, PizzaViewModel>().ReverseMap();
            CreateMap<PedidoPizza, PedidoPizzaViewModel>().ReverseMap();
            CreateMap<PedidoPizza, PedidoPizzaDetalhesViewModel>().ReverseMap();
        }
    }
}
