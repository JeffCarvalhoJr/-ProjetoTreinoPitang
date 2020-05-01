using System;
using System.Collections.Generic;
using System.Text;
using Pitang.Sms.Treino.Entities;
using Pitang.Sms.Treino.Repository.Contracts;
using Pitang.Sms.Treino.Repository.Impl.EFRepository;

namespace Pitang.Sms.Treino.Repository.Impl.Impl
{
    class MessagesRepository : Repository<Message>, IMessagesRepository
    {
        public MessagesRepository(DataContext dbContext) : base(dbContext)
        {

        }
    }
}
