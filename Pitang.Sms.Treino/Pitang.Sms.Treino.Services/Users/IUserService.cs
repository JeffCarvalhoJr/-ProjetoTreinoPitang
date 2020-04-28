using Pitang.Sms.Treino.Entities;
using Pitang.Sms.Treino.Repository.Impl.EFRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pitang.Sms.Treino.Services.Users
{
    public interface IUserService
    {
        public Task <UserModel> AddUserAsync(UserModel newUser);
        public Task <IEnumerable<UserModel>> GetUsersAsync();
        public void Delete(int currentUser);
        public void UnDelete(int currentUser);
        public UserModel Update(UserModel updatedUser);

    }
}
