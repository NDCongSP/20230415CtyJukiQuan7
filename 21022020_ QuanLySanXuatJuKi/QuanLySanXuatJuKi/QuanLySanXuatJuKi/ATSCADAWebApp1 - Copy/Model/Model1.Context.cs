﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATSCADAWebApp.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hvacdatabaseEntities : DbContext
    {
        public hvacdatabaseEntities()
            : base("name=hvacdatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<account> accounts { get; set; }
        public DbSet<alarmlog> alarmlogs { get; set; }
        public DbSet<alarmsetting> alarmsettings { get; set; }
    }
}
