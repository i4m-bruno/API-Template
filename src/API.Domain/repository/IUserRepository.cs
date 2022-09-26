using System.Threading.Tasks;
using API.Domain.entities;
using API.Domain.interfaces;

namespace API.Domain.repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
