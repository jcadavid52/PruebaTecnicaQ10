using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Infrastructure.DataSource
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }

    }
}
