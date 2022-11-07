using System;
using System.Threading.Tasks;
using API.Domain.entities;
using API.Domain.interfaces;

namespace API.Domain.repository.Cep
{
    public interface IMunicipioRepository : IRepository<MunicipioEntity>
    {
        Task<MunicipioEntity> GetById(Guid id);
        Task<MunicipioEntity> GetByIBGECode(int code);
    }
}
