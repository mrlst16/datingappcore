using DatingAppCore.Repo.EF.Matching;
using DatingAppCore.Repo.EF.Members;
using DatingAppCore.Repo.Members;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Configuration
{
    public static class Config_Members
    {
        public static void Apply(ModelBuilder mb)
        {
            mb.Entity<User>().ToTable("Users");
            mb.Entity<Match>().ToTable("Matches");
            mb.Entity<UserProfileField>().ToTable("UserProfileField");
            mb.Entity<Photo>().ToTable("Photos");
            mb.Entity<PhotoData>().ToTable("PhotoData");
            mb.Entity<GrantedPermission>().ToTable("GrantedPermissions");

            mb.Entity<Match>().HasKey(x => x.ID);
            mb.Entity<User>().HasKey(x => x.ID);
            mb.Entity<UserProfileField>().HasKey(x => x.ID);
            mb.Entity<Photo>().HasKey(x => x.ID);
            mb.Entity<PhotoData>().HasKey(x => x.ID);
            mb.Entity<GrantedPermission>().HasKey(x => x.ID);

            mb.Entity<User>()
                .HasMany(x => x.Sent)
                .WithOne(x => x.Sender)
                .HasForeignKey(x => x.SenderID);

            mb.Entity<User>()
                .HasMany(x => x.Inbox)
                .WithOne(x => x.Receiver)
                .HasForeignKey(x => x.ReceiverID);

            //Remember here to think of swipes as letters, they were sent to the user, the receiver is the user and vice versa
            mb.Entity<User>()
                .HasMany(x => x.SwipesReceived)
                .WithOne(x => x.UserTo)
                .HasForeignKey(x => x.UserToID);

            mb.Entity<User>()
                .HasMany(x => x.SwipesSent)
                .WithOne(x => x.UserFrom)
                .HasForeignKey(x => x.UserFromID);

            mb.Entity<User>()
                .HasMany(x => x.ReviewReceived)
                .WithOne(x => x.Reciever)
                .HasForeignKey(x => x.ReceiverID);

            mb.Entity<User>()
                .HasMany(x => x.ReviewsSent)
                .WithOne(x => x.Sender)
                .HasForeignKey(x => x.SenderID);

            mb.Entity<User>()
                .HasMany(x => x.ReviewsSent)
                .WithOne(x => x.Sender)
                .HasForeignKey(x => x.SenderID);

            mb.Entity<UserProfileField>()
                .HasIndex(x => x.UserID);

            mb.Entity<User>()
                .HasMany(x => x.Photos)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserID);

            mb.Entity<User>()
                .HasMany(x => x.AsGrantor)
                .WithOne(x => x.Grantor)
                .HasForeignKey(x => x.GrantorID);

            mb.Entity<User>()
                .HasMany(x => x.AsGrantee)
                .WithOne(x => x.Grantee)
                .HasForeignKey(x => x.GranteeID);

            mb.Entity<UserProfileField>()
                .HasIndex(u => new { u.Name, u.UserID, u.IsSetting })
                .IsUnique();

            mb.Entity<Photo>()
                .HasOne(x => x.Data)
                .WithOne(x => x.Photo);
        }
    }
}
