using Pitang.Sms.Treino.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.Sms.Treino.Repository.Contracts
{
    public interface IUsersRepository : IRepository<UserModel>
    {
        public bool UsernameExists(string username);
        public bool EmailExists(string email);
    }

   
}
