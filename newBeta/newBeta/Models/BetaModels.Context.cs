﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace newBeta.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities1 : DbContext
    {
        public Entities1()
            : base("name=Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProjectUsers> ProjectUsers { get; set; }
        public virtual DbSet<Subtasks> Subtasks { get; set; }
        public virtual DbSet<TaskConnections> TaskConnections { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
    }
}
