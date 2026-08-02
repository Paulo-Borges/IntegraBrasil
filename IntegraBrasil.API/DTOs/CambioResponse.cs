using System.Text.Json.Serialization;

namespace IntegraBrasil.API.DTOs
{
    public class CambioResponse
    {
        public string? Simbolo { get; set; }

        public string? Nome { get; set; }

        public string? TipoMoeda { get; set; }
    }
}
