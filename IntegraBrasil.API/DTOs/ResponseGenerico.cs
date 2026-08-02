using System.Dynamic;
using System.Net;

namespace IntegraBrasil.API.DTOs
{
    public class ResponseGenerico<T> where T : class
    {
        public HttpStatusCode CodigoHttp { get; set; }
        public T? DadosRetorno { get; set; }
        public ExpandoObject? ErrosRetorno { get; set; }
    }
}
