using System;
using System.Threading.Tasks;
using API.Domain.Dtos.Cep;

namespace API.Domain.interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> GetCepById(Guid cepId);
        Task<CepDto> GetCepByNumber(string number);
        Task<CepDtoCreateResult> CreateCep(CepDtoCreate cepDto);
        Task<CepDtoUpdateResult> UpdateCep(CepDtoUpdate cepDto);
        Task<bool> DeleteCep(Guid cepId);
    }
}
