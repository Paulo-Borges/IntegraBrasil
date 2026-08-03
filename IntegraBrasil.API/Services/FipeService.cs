using AutoMapper;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Services
{
    public class FipeService : IFipeService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public FipeService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<FipeModel>> BuscarFipe(string veiculo)
        {
            var fipe = await _brasilApi.BuscarFipe(veiculo);
            return _mapper.Map<ResponseGenerico<FipeModel>>(fipe);
        }
    }
}
