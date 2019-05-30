using System;
using DatingAppCore.Dto.Members;
using DatingAppCore.DTO.Members;
using DatingAppCore.Repo.Clients;
using DatingAppCore.Repo.Configuration;
using DatingAppCore.Repo.Logging;
using DatingAppCore.Repo.Matching;
using DatingAppCore.Repo.Members;
using DatingAppCore.Repo.Messaging;
using DatingAppCore.Repo.Reviewing;
using Microsoft.EntityFrameworkCore;
using Match = DatingAppCore.Repo.Matching.Match;

namespace DatingAppCore.Repo
{
    public class AppContext : DbContext
    {
        //Members
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfileField> UserProfileFields { get; set; }
        public DbSet<Photo> Photos { get; set; }

        //Messagin
        public DbSet<Message> Messages { get; set; }

        //Reviews
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserReviewBadge> UserReviewBadges { get; set; }

        //Matching
        public DbSet<Match> Matches { get; set; }
        public DbSet<Swipe> Swipes { get; set; }

        //Clients
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAuth> ClientAuths { get; set; }

        //Logging
        public DbSet<TraceLog> TraceLogs { get; set; }

        public DbQuery<PotentialMatchDTO> PotentialMatchDTOs { get; set; }
        public DbQuery<MatchDTO> MatcheDTOs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connstr =
                "Data Source=165.22.73.20;Initial Catalog=DatingAppCore;User ID=SA;Password=Matty30!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connstr);
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DatingAppCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseNpgsql("Server=db-postgresql-nyc1-83929-do-user-5126117-0.db.ondigitalocean.com;Port=25060;Database=DatingApp;User ID=matt;Password=sslmode=Require;Trust Server Certificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Config_Clients.Apply(modelBuilder);
            Config_Logging.Apply(modelBuilder);
            Config_Matches.Apply(modelBuilder);
            Config_Members.Apply(modelBuilder);
            Config_Messaging.Apply(modelBuilder);
            Config_Reviews.Apply(modelBuilder);
        }
    }
}
