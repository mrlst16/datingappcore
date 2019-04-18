using DatingAppCore.Repo.Reviewing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Configuration
{
    public static class Config_Reviews
    {
        public static void Apply(ModelBuilder mb)
        {
            mb.Entity<Review>().ToTable("Reviews");
            mb.Entity<UserReviewBadge>().ToTable("UserReviewBadges");

            mb.Entity<Review>().HasKey(x => x.ID);
            mb.Entity<UserReviewBadge>().HasKey(x => x.ID);

            mb.Entity<Review>()
                .HasMany(x => x.Badges)
                .WithOne(x => x.Review)
                .HasForeignKey(x => x.ReviewID);
        }
    }
}
