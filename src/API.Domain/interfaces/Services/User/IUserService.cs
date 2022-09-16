
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.entities;

namespace API.Domain.interfaces.Services.User
{
    public interface IUserService
    {
        Task<UserEntity> Get (Guid id);        
        Task<IEnumerable<UserEntity>> List ();        
        Task<UserEntity> Post (UserEntity user);        
        Task<UserEntity> Put (UserEntity user);        
        Task<bool> Delete (Guid id);        
    }
}
