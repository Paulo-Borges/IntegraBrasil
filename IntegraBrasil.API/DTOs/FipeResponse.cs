using System.Text.Json.Serialization;

namespace IntegraBrasil.API.DTOs
{
    public class FipeResponse
    {
        public string? Valor { get; set; }

        public string? Marca { get; set; }

        public string? Modelo { get; set; }

        public int? AnoModelo { get; set; }
        public string? MesReferencia { get; set; }
        public int? TipoVeiculo { get; set; }
        public string? DataConsulta { get; set; }
        [JsonIgnore]
        public string? Combustivel { get; set; }
        [JsonIgnore]
        public string? CodigoFipe { get; set; }
        [JsonIgnore]
        public string? SiglaCombustivel { get; set; }

    }
}
