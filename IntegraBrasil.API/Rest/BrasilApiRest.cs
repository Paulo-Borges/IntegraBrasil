using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Models;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace IntegraBrasil.API.Rest
{
    public class BrasilApiRest : IBrasilApi
    {
        public Task<ResponseGenerico<CambioModel>> BuscarCambio(string moeda)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCEP(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");

            var response = new ResponseGenerico<EnderecoModel>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErrosRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }

            return response;
        }

        public Task<ResponseGenerico<FipeModel>> BuscarFipe(string veiculo)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseGenerico<BancoModel>> BuscarBanco(string codigoBanco)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/{codigoBanco}");

            var response = new ResponseGenerico<BancoModel>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<BancoModel>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErrosRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }

            return response;
        }

        public async Task<ResponseGenerico<List<BancoModel>>> BuscarTodosBancos()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/banks/v1/");

            var response = new ResponseGenerico<List<BancoModel>>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<BancoModel>>(contentResp);

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseBrasilApi.StatusCode;
                    response.ErrosRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }

            return response;
        }
    }
}
