﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Group5Project.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Group5Project.Models.Recognition> Recognitions { get; set; }

        public System.Data.Entity.DbSet<Group5Project.Models.CoreValues> CoreValues { get; set; }
    }
}