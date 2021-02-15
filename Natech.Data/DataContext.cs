using Microsoft.EntityFrameworkCore;
using Natech.Data.Entities;
using System;

namespace Natech.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
