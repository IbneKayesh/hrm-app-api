using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Ignore<EMPLOYEE>();
            //modelBuilder.Ignore<DEPARTMENT>();

            //modelBuilder.Entity<EMPLOYEE>().ToTable("EMPLOYEE");
            //modelBuilder.Entity<DEPARTMENT>().ToTable("DEPARTMENT");
        }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENT { get; set; }
    }
}