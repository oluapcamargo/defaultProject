using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using V1.DefaultProject.Domain.Entities;
using V1.DefaultProject.Persistence.ModelConfiguration.Table;

namespace V1.DefaultProject.Persistence.Context
{
    public class V1DefaultProjectContext : DbContext
    {
        public V1DefaultProjectContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyTableConfiguration();
        }
    }
}
