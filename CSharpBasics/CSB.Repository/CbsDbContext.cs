using CSB.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSB.Repository
{
    public class CbsDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; }

        public DbSet<Address> Addresses { get; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
