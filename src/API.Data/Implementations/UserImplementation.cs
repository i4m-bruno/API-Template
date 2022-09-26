using System.Threading.Tasks;
using API.Data.Context;
using API.Data.Repository;
using API.Domain.entities;
using API.Domain.repository;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataSet;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<UserEntity>();
        }
        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataSet.FirstOrDefaultAsync(u => email.Equals(u.Email));
        }
    }
}
