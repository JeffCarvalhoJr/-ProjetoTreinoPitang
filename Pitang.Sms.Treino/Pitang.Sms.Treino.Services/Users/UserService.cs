using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pitang.Sms.Treino.Data.DataContext;
using Pitang.Sms.Treino.Entities;
using Pitang.Smsm.Treino.DTO;

namespace Pitang.Sms.Treino.Services.Users
{
    public class UserService
    {
       
       public async Task AddUser(DataContext context, UserModel newUser)
        {
            context.Users.Add(newUser);
            await context.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetUsers(DataContext context)
        { 
            var userList = await context.Users.ToListAsync();
            return userList;
        }


     
    }
}
