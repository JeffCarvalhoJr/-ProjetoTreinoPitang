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
        private readonly IRepository<UserModel> usersRepository;

        public UserService(IRepository<UserModel> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public UserModel AddUser(UserModel newUser)
        {
            return usersRepository.Add(newUser);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            if (usersRepository.FindAll().Count() == 0 || usersRepository.FindAll() == null)
            {
                return Enumerable.Empty<UserModel>();
            }

            return usersRepository.FindBy(e => e.IsDeleted == false);
        }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            if (usersRepository.FindAll().Count() == 0 || usersRepository.FindAll() == null)
            {
                return Enumerable.Empty<UserModel>();
            }

            return await usersRepository.FindAllAsync();
        }

        public void Delete(int currentUserId)
        {
            usersRepository.Delete(currentUserId);
        }

        public void UnDelete(int currentUserId)
        {
            usersRepository.UnDelete(currentUserId);
        }

        public UserModel Update(UserModel updatedUser)
        {
            return usersRepository.Update(updatedUser); ;
        }
    }
}
