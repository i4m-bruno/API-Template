using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.UF;

namespace API.Domain.interfaces.Services.Cep
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> GetMunicipio(Guid municipioId);
        Task<MunicipioDto> GetMunicipioByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> ListMunicipios();
        Task<MunicipioDtoCreateResult> CreateMunicipio(MunicipioDtoCreate municipioDto);
        Task<MunicipioDtoUpdateResult> UpdateMunicipio(MunicipioDtoUpdate municipioDto);
        Task<bool> DeleteMunicipio(Guid municipioId);
    }
}
