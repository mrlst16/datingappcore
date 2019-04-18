using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.Repo.Logging;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.Repo.Configuration
{
    public class Config_Logging
    {
        public static void Apply(ModelBuilder mb)
        {
            mb.Entity<TraceLog>().ToTable("TraceLogs");

            mb.Entity<TraceLog>().HasKey(x=>x.ID);
        }
    }
}
