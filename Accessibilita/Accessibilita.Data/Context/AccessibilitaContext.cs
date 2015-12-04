using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilita.Data.Entities;

namespace Accessibilita.Data.Context
{
    public class AccessibilitaContext : DbContext
    {
        public AccessibilitaContext() : base("AccessibilitaDB")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("tb_account", "application");
            modelBuilder.Entity<Place>().ToTable("tb_place", "application");
            modelBuilder.Entity<Rate>().ToTable("tb_rate", "application");
            modelBuilder.Entity<RateType>().ToTable("tb_rate_type", "application");           
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<RateType> RateTypes { get; set; }
    }
}
