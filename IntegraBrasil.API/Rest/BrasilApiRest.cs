using Azure;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Interfaces;
using IntegraBrasil.API.Models;
using System.Dynamic;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace IntegraBrasil.API.Rest
{
    public class BrasilApiRest : IBrasilApi
    {
        public async Task<ResponseGenerico<List<CambioModel>>> BuscarCambio()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cambio/v1/moedas");

            var response = new ResponseGenerico<List<CambioModel>>();
            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<List<CambioModel>>(contentResp);

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

        public async Task<ResponseGenerico<FipeModel>> BuscarFipe(string veiculo)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/fipe/preco/v1/{veiculo}");
            var response = new ResponseGenerico<FipeModel>();

            using (var client = new HttpClient())
            {
                var responseBrasilApi = await client.SendAsync(request);
                var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();

                // Se a origem FIPE bloquear (403), trate como dependência indisponível
                if (responseBrasilApi.StatusCode == HttpStatusCode.Forbidden)
                {
                    response.CodigoHttp = HttpStatusCode.ServiceUnavailable;
                    dynamic erro = new ExpandoObject();
                    erro.mensagem = "Serviço FIPE de origem bloqueou a consulta (403). Tente novamente mais tarde.";
                    erro.origem = "BrasilAPI/FIPE";
                    response.ErrosRetorno = erro;
                    return response;
                }

                response.CodigoHttp = responseBrasilApi.StatusCode;

                if (responseBrasilApi.IsSuccessStatusCode)
                {
                    // /preco/v1/{codigoFipe} costuma retornar LISTA
                    var lista = JsonSerializer.Deserialize<List<FipeModel>>(contentResp);
                    response.DadosRetorno = lista?.FirstOrDefault();
                }
                else
                {
                    var mediaType = responseBrasilApi.Content.Headers.ContentType?.MediaType;

                    if (mediaType is not null && mediaType.Contains("json"))
                    {
                        response.ErrosRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                    }
                    else
                    {
                        dynamic erro = new ExpandoObject();
                        erro.mensagem = "Resposta inválida da API FIPE.";
                        erro.conteudo = contentResp;
                        response.ErrosRetorno = erro;
                    }
                }
            }

            return response;
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
