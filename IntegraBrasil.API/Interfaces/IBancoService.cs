using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Interfaces
{
    public interface IBancoService
    {
        // Usa o metodo do DTO e atualiza o nome   
        Task<ResponseGenerico<List<BancoResponse>>> BuscarTodos();

        Task<ResponseGenerico<BancoResponse>> BuscarBanco(string codigoBanco);
    }
}
