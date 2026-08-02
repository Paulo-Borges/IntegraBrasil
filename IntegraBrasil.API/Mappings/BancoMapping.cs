using AutoMapper;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Mappings
{
    public class BancoMapping : Profile
    {
        public BancoMapping() 
        {
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<BancoResponse, BancoModel>();
            CreateMap<BancoModel, BancoResponse>();

        }
    }
}
