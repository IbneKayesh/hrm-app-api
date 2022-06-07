using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hrm_app_api.Models
{
    public class hrmappDbContext : DbContext
    {
        public hrmappDbContext() : base("name=OracleDbContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NGAPP");
        }
        public DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public DbSet<DEPARTMENT> DEPARTMENT { get; set; }
    }
}