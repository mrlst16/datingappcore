using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingAppCore.Repo.EF.Logging;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.Repo.Configuration
{
    public class Config_Logging
    {
        public static void Apply(ModelBuilder mb)
        {
            mb.Entity<TraceLog>().ToTable("TraceLogs");
            mb.Entity<RequestLog>().ToTable("RequestLogs");

            mb.Entity<TraceLog>().HasKey(x => x.ID);
            mb.Entity<RequestLog>().HasKey(x => x.ID);
        }
    }
}