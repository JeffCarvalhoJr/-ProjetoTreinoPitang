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
        public DbSet<UserProfile> UsersProfiles { get; set; }
        public DbSet<Contacts> UserContacts { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> UserMessages { get; set; }
        public DbSet<Story> UserStory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
            .HasOne(b => b.UserProfile)
            .WithOne(i => i.User)
            .HasForeignKey<UserProfile>(b => b.Id);

            modelBuilder.Entity<UserModel>()
                 .HasMany(b => b.ChatRooms)
                 .WithOne()
                 .HasForeignKey(e => e.Id);

            modelBuilder.Entity<Chat>()
                .HasMany(b => b.Users);

            

        }
    }
}
