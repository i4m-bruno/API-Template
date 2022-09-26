using System;
using System.Threading.Tasks;
using API.Domain.entities;

namespace API.Domain.interfaces.Services.User
{
    public interface ILoginService
    {
        Task<Object> FindByLogin(UserEntity user);
    }
}
