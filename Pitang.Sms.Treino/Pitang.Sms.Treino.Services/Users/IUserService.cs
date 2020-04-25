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
        public UserModel AddUser(UserModel newUser);
        public IEnumerable<UserModel> GetUsers();
        public Task <IEnumerable<UserModel>> GetUsersAsync();
        public void DeleteUser(UserModel currentUser);
        public void UnDeleteUser(UserModel currentUser);

    }
}
