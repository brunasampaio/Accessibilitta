using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accessibilitta.Data.Entities;

namespace Accessibilitta.Data.Context
{
    public class AccessibilittaContext : DbContext
    {
        public AccessibilittaContext() : base("AccessibilittaDB")
        {

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("tb_account", "application");
            modelBuilder.Entity<Place>().ToTable("tb_place", "application");
            modelBuilder.Entity<Tip>().ToTable("tb_tip", "application");
            modelBuilder.Entity<Rate>().ToTable("tb_rate", "application");            
        }
    }
}
