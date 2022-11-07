using System.Threading.Tasks;
using API.Domain.entities;
using API.Domain.interfaces;

namespace API.Domain.repository.Cep
{
    public interface ICepRepository : IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsync(string cep);
    }
}
