using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group5Project.Models;
using System.Data.Entity;

namespace Group5Project.DAL
{
    public class Context : DbContext
    {
        public Context() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Group5Project.Migrations.Context.Configuration>("DefaultConnection"));
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}