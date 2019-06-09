using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_Ships.Models
{
    public class ShipsContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }
        public ShipsContext(DbContextOptions<ShipsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
