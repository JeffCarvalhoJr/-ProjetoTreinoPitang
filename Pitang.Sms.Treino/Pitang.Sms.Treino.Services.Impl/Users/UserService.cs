using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitang.Sms.Treino.Entities;
using Pitang.Sms.Treino.Repository.Contracts;
using Pitang.Sms.Treino.Repository.Impl.EFRepository;
using Pitang.Sms.Treino.Services.Users;
using Utils.Exceptions;

namespace Pitang.Sms.Treino.Services.Impl.Users
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<UserModel> AddUserAsync(UserModel newUser)
        {
            ValidateUser(newUser);
            return await usersRepository.AddAsync(newUser);
        }
 
        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            if (usersRepository.FindAllAsync().Result.Count() == 0 || usersRepository.FindAllAsync().Result == null)
            {
                return Enumerable.Empty<UserModel>();
            }

            return await usersRepository.FindByAsync(e => e.IsDeleted == false);
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

        private void ValidateUser(UserModel user)
        {
            if(user == null)
            {
                throw new ExceptionBadRequest("Usuario invalido");
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                throw new ExceptionBadRequest("Email não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new ExceptionBadRequest("Username não pode ser vazio.");
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ExceptionBadRequest("Password não pode ser vazio");
            }
            if (!string.IsNullOrWhiteSpace(user.Username) && usersRepository.UsernameExists(user.Username) == true)
            {
                throw new ExceptionBadRequest("Username já existente!");
            }
            if (!string.IsNullOrWhiteSpace(user.Email) && usersRepository.EmailExists(user.Email) == true)
            {
                throw new ExceptionBadRequest("Email já existente!");
            }
        }
    }
}
