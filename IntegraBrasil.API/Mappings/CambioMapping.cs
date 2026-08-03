using AutoMapper;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Mappings
{
    public class CambioMapping : Profile
    {
        public CambioMapping()
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<CambioResponse, CambioModel>();
            CreateMap<CambioModel, CambioResponse>();
        }
    }
}
