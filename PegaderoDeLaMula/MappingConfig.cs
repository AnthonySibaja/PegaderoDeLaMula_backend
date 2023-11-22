using AutoMapper;
using PegaderoDeLaMula.Models;
using PegaderoDeLaMula.Models.Dto;

namespace PegaderoDeLaMula
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappinConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ClienteDto, Cliente>();
                config.CreateMap<Cliente, ClienteDto>();
                config.CreateMap<TipoProductoDto, TipoProducto>();
                config.CreateMap<TipoProducto, TipoProductoDto>();
                config.CreateMap<DetallesDto, Detalles>();
                config.CreateMap<Detalles, DetallesDto>();
                config.CreateMap<InventarioDto, Inventario>();
                config.CreateMap<Inventario, InventarioDto>();
                config.CreateMap<RecomendacionesDto, Recomendaciones>(); 
                config.CreateMap<Recomendaciones, RecomendacionesDto>();
            });

            return mappinConfig;
        }
    }
}
