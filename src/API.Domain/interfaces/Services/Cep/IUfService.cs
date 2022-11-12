using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.UF;

namespace API.Domain.interfaces.Services.Cep
{
    public interface IUfService
    {
        Task<UfDto> GetUf(Guid UfId);
        Task<IEnumerable<UfDto>> ListUfs();
    }
}
