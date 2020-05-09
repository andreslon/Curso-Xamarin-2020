using Cedesistemas.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cedesistemas.Api.Data
{
    public class CedesistemasDbContext : DbContext
    {
        public CedesistemasDbContext(DbContextOptions<CedesistemasDbContext> options) : base(options)
        { 
            this.Database.EnsureCreated(); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Restaurante> Restaurante { get; set; }
        public DbSet<Producto> Producto { get; set; }

    }
}
