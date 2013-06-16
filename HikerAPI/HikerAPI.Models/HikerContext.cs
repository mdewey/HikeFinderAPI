using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HikerAPI.Models
{
    class HikerContext : DbContext
    {
        public HikerContext() : base("DefaultConnection") { }
        public HikerContext(String connectionString) : base(connectionString) { }

        //Tables
        public DbSet<User> Users { get; set; }
        public DbSet<Trails> Trails { get; set; }
        public DbSet<UserTrails> UserTrails { get; set; }
        public DbSet<Point> Points { get; set; }

                
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {}


    }
}


        