using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pitang.Sms.Treino.Data.DataContext;
using Pitang.Sms.Treino.Entities;
using Pitang.Smsm.Treino.DTO;

namespace Pitang.Sms.Treino.Services.Users
{
    public class UserService
    {
        private readonly DataContext context;
       public void AddUser(UserModel newUser)
        {
            context.Users.Add(newUser);
        }


        public List<UserModel> GetUsers()
        {
            var users = context.Users.ToList();
            return users;
        }
    }
}
