using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Interfaces
{
    public interface IEnderecoService
    {

        // Tem que usar o DTO  ---------x------x---------
        Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);
    }
}
