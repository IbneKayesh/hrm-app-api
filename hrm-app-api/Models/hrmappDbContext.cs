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
            modelBuilder.HasDefaultSchema("PNPLS");
        }
        public DbSet<GS_TEST> GS_TEST { get; set; }
    }
}