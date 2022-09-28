using System;
using System.Threading.Tasks;
using API.Domain.Dtos;

namespace API.Domain.interfaces.Services.User
{
    public interface ILoginService
    {
        Task<Object> FindByLogin(LoginDto user);
    }
}
