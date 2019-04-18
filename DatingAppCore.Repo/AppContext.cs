using System;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCore.Repo
{
    public class AppContext : DbContext
    {
        private DbSet<Test> tests;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=DatingAppCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
        }

        
    }
}
