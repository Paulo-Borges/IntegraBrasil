using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Interfaces
{
    public interface IBrasilApi
    {
        //Metodos
        Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCEP(string cep);

        Task<ResponseGenerico<List<BancoModel>>> BuscarTodosBancos();

        Task<ResponseGenerico<BancoModel>> BuscarBanco(string codigoBanco);

        Task<ResponseGenerico<FipeModel>> BuscarFipe(string veiculo);

        Task<ResponseGenerico<List<CambioModel>>> BuscarCambio();
    }
}
