using System.Threading.Tasks;
using API.Domain.entities;
using API.Domain.interfaces.Services.User;
using API.Domain.repository;

namespace API.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepo;

        public LoginService(IUserRepository userRepo)
        {
            _userRepo = userRepo;   
        }

        public async Task<object> FindByLogin(UserEntity user)
        {
            var baseUser = new UserEntity();

            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _userRepo.FindByLogin(user.Email);
                
                if(baseUser == null)
                    return null;

                return baseUser;
            }

            return null;
        }
    }
}
