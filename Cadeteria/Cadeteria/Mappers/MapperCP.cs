using AutoMapper;
using Cadeteria.Models;
using Cadeteria.ViewModels.Cadete;
using Cadeteria.ViewModels.Pedido;
using Cadeteria.ViewModels.Usuario;

namespace Cadeteria.Mappers
{
    public class MapperCP : Profile
    {
        public MapperCP()
        {
            CreateMap<CadeteModel, CadeteViewModel>().ReverseMap();
            CreateMap<PedidoModel, PedidoViewModel>().ReverseMap();
            CreateMap<UsuarioModel, UsuarioViewModel>().ReverseMap();
        }
    }
}
