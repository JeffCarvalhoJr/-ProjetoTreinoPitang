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

            modelBuilder.Entity<UserProfile>()
                .HasOne(b => b.User)
                .WithOne(i => i.UserProfile)
                .HasForeignKey<UserModel>(b => b.Id);

            modelBuilder.Entity<UserModel>()
                .HasOne(b => b.Story)
                .WithOne(i => i.Owner)
                .HasForeignKey<UserModel>(b => b.Id);

            modelBuilder.Entity<Story>()
              .HasOne(b => b.Owner)
              .WithOne(i => i.Story)
              .HasForeignKey<Story>(b => b.Id);

            modelBuilder.Entity<UserModel>()
                .HasOne(b => b.Contacts)
                .WithOne(i => i.Owner)
                .HasForeignKey<UserModel>(b => b.Id);

            modelBuilder.Entity<Contacts>()
                .HasOne(b => b.Owner)
                .WithOne(i => i.Contacts)
                .HasForeignKey<Contacts>(b => b.Id);

            modelBuilder.Entity<Contacts>()
                .HasMany(b => b.ContactBook);

            modelBuilder.Entity<UserModel>()
                 .HasMany(b => b.ChatRooms)
                 .WithOne()
                 .HasForeignKey(e => e.Id);

            modelBuilder.Entity<Chat>()
                .HasMany(b => b.Users);

            modelBuilder.Entity<Chat>()
                .HasMany(b => b.Messages)
                .WithOne()
                .HasForeignKey(e => e.Id);

            modelBuilder.Entity<Message>()
                .HasOne(b => b.SourceChat)
                .WithMany(i => i.Messages)
                .HasForeignKey(b => b.Id);

        }
    }
}
