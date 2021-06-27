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
        public CbsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; }

        public DbSet<Address> Addresses { get; }

        public DbSet<Phone> Phones { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<FamilyMember> FamilyMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
