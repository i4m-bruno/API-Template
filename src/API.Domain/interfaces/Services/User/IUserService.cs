using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Dtos.User;

namespace API.Domain.interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserDto> Get (Guid id);        
        Task<IEnumerable<UserDto>> List ();        
        Task<UserDtoCreateResult> Post (UserDtoCreate user);        
        Task<UserDtoUpdateResult> Put (UserDtoUpdate user);        
        Task<bool> Delete (Guid id);        
    }
}
