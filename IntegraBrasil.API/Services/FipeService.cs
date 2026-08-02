using AutoMapper;
using IntegraBrasil.API.Interfaces;

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
    }
}
