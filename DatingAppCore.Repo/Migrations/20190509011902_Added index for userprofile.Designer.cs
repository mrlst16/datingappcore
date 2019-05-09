﻿// <auto-generated />
using System;
using DatingAppCore.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatingAppCore.Repo.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20190509011902_Added index for userprofile")]
    partial class Addedindexforuserprofile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatingAppCore.Repo.Clients.Client", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Clients.ClientAuth", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClientID");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("ClientAuths");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Logging.TraceLog", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("Exception");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<int>("Level");

                    b.Property<string>("Message");

                    b.Property<string>("StackTrace");

                    b.HasKey("ID");

                    b.ToTable("TraceLogs");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Matching.Match", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<Guid>("LeftID");

                    b.Property<Guid>("RightID");

                    b.HasKey("ID");

                    b.HasIndex("LeftID");

                    b.HasIndex("RightID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Matching.Swipe", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<bool>("IsLike");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<Guid>("UserFromID");

                    b.Property<Guid>("UserToID");

                    b.HasKey("ID");

                    b.HasIndex("UserFromID");

                    b.HasIndex("UserToID");

                    b.ToTable("Swipes");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Members.GrantedPermission", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<Guid>("GranteeID");

                    b.Property<Guid>("GrantorID");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<int>("Permissions");

                    b.HasKey("ID");

                    b.HasIndex("GranteeID");

                    b.HasIndex("GrantorID");

                    b.ToTable("GrantedPermissions");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Members.Photo", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Access");

                    b.Property<string>("Caption");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<int>("Rank");

                    b.Property<string>("Url");

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Members.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClientID");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<string>("ExternalID");

                    b.Property<int>("IdType");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<double>("Lat");

                    b.Property<double>("Lon");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Members.UserProfileField", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<bool>("IsSetting");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<Guid>("UserID");

                    b.Property<string>("Value");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.HasIndex("Name", "UserID", "IsSetting")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("UserProfileField");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Messaging.Message", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<Guid>("ReceiverID");

                    b.Property<Guid>("SenderID");

                    b.HasKey("ID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Reviewing.Review", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<double>("Rating");

                    b.Property<Guid>("ReceiverID");

                    b.Property<Guid>("SenderID");

                    b.HasKey("ID");

                    b.HasIndex("ReceiverID");

                    b.HasIndex("SenderID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Reviewing.UserReviewBadge", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<Guid>("ReviewID");

                    b.HasKey("ID");

                    b.HasIndex("ReviewID");

                    b.ToTable("UserReviewBadges");
                });

            modelBuilder.Entity("DatingAppCore.Repo.Clients.ClientAuth", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Clients.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Matching.Match", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Members.User", "Left")
                        .WithMany()
                        .HasForeignKey("LeftID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatingAppCore.Repo.Members.User", "Right")
                        .WithMany()
                        .HasForeignKey("RightID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Matching.Swipe", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Members.User", "UserFrom")
                        .WithMany("SwipesSent")
                        .HasForeignKey("UserFromID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatingAppCore.Repo.Members.User", "UserTo")
                        .WithMany("SwipesReceived")
                        .HasForeignKey("UserToID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Members.GrantedPermission", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Members.User", "Grantee")
                        .WithMany("AsGrantee")
                        .HasForeignKey("GranteeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatingAppCore.Repo.Members.User", "Grantor")
                        .WithMany("AsGrantor")
                        .HasForeignKey("GrantorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Members.Photo", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Members.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Members.UserProfileField", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Members.User", "User")
                        .WithMany("Profile")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Messaging.Message", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Members.User", "Receiver")
                        .WithMany("Inbox")
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatingAppCore.Repo.Members.User", "Sender")
                        .WithMany("Sent")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Reviewing.Review", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Members.User", "Reciever")
                        .WithMany("ReviewReceived")
                        .HasForeignKey("ReceiverID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DatingAppCore.Repo.Members.User", "Sender")
                        .WithMany("ReviewsSent")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DatingAppCore.Repo.Reviewing.UserReviewBadge", b =>
                {
                    b.HasOne("DatingAppCore.Repo.Reviewing.Review", "Review")
                        .WithMany("Badges")
                        .HasForeignKey("ReviewID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
