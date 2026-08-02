using AutoMapper;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Mappings
{
    public class EnderecoMapping : Profile
    {
        public EnderecoMapping() 
        { 
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<EnderecoResponse, EnderecoModel>();
            CreateMap<EnderecoModel, EnderecoResponse>();
        }
    }
}
