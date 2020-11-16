using DatingAppCore.Repo.EF.Matching;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Repo.Configuration
{
    public class Config_Matches
    {
        public static void Apply(ModelBuilder mb)
        {
            mb.Entity<Match>().ToTable("Matches");
            mb.Entity<Swipe>().ToTable("Swipes");

            mb.Entity<Match>().HasKey(x => x.ID);
            mb.Entity<Swipe>().HasKey(x => x.ID);
        }
    }
}
