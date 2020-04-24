using Pitang.Sms.Treino.Entities;
using Pitang.Sms.Treino.Repository.Contracts;
using Pitang.Sms.Treino.Repository.Impl.EFRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.Sms.Treino.Repository.Impl.Impl
{
    public class UsersRepository : Repository<UserModel>, IUsersRepository
    {

        public UsersRepository(DataContext dbContext) : base(dbContext)
        {

        }

    }
}
