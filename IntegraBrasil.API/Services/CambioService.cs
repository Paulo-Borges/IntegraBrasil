using AutoMapper;
using IntegraBrasil.API.Interfaces;

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
    }
}
