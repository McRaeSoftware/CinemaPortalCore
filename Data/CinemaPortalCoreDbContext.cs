using CinemaPortalCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaPortalCore.Data
{
    public class CinemaPortalCoreDbContext : DbContext
    {
        public CinemaPortalCoreDbContext(DbContextOptions<CinemaPortalCoreDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees{ get; set; }
    }
}
