using AutoMapper;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Interfaces;

namespace IntegraBrasil.API.Services
{
    public class EnderecoService : IEnderecoService
    {

        private readonly IMapper _mapper;

        private readonly IBrasilApi _brasilApi;


        public EnderecoService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }
        public async Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep)
        {
            var endereco = await _brasilApi.BuscarEnderecoPorCEP(cep);
            return _mapper.Map<ResponseGenerico<EnderecoResponse>>(endereco);
        }
    }
}
