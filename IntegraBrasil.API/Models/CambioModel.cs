using System.Text.Json.Serialization;

namespace IntegraBrasil.API.Models
{
    public class CambioModel
    {
        [JsonPropertyName("simbolo")]
        public string? Simbolo { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("tipo_moeda")]
        public string? TipoMoeda { get; set; }
    }
}
