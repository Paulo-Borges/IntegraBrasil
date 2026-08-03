using AutoMapper;
using IntegraBrasil.API.DTOs;
using IntegraBrasil.API.Models;

namespace IntegraBrasil.API.Interfaces
{
    public interface ICambioService
    {
        Task<ResponseGenerico<List<CambioModel>>> BuscarCambio();
    }
}
