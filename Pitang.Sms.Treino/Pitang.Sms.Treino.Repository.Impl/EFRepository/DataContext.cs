using Microsoft.EntityFrameworkCore;
using Pitang.Sms.Treino.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pitang.Sms.Treino.Repository.Impl.EFRepository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
          : base(options) { }

        public DbSet<UserModel> Users { get; set; }
    }
}
