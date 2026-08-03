using AutoMapper;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Services
{
    public class CambioService : ICambioService
    {
        private readonly IMapper _mapper;
        private readonly IBrasilApi _brasilApi;

        public CambioService(IMapper mapper, IBrasilApi brasilApi)
        {
            _mapper = mapper;
            _brasilApi = brasilApi;
        }

        public async Task<ResponseGenerico<List<CambioModel>>> BuscarCambio()
        {
            var cambio = await _brasilApi.BuscarCambio();
            return _mapper.Map<ResponseGenerico<List<CambioModel>>>(cambio);
        }
    }
}
