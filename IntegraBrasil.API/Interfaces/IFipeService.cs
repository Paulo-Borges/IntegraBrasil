using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Interfaces
{
    public interface IFipeService
    {
        Task<ResponseGenerico<FipeModel>> BuscarFipe(string veiculo);
    }
}
