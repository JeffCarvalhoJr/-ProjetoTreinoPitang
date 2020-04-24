using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Sms.Treino.Entities;
using Pitang.Sms.Treino.Repository.Contracts;
using Pitang.Sms.Treino.Repository.Impl.EFRepository;
using Pitang.Sms.Treino.Services.Users;

namespace Pitang.Sms.Treino.Services.Impl.Users
{
    public class UserService : IUserService
    {
        private IRepository<UserModel> usersRepository;

        public UserService(IRepository<UserModel> usersRepository) {
            this.usersRepository = usersRepository;
        }
       
       public async Task<UserModel> AddUser(UserModel newUser)
        {
            return await usersRepository.AddAsync(newUser);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            if (usersRepository.FindAll().Count() == 0 || usersRepository.FindAll() == null)
            {
                return null;
            }

            return usersRepository.FindAll().ToList();
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
