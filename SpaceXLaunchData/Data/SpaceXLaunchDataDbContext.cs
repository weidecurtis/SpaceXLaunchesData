using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpaceXLaunchData.Models;

namespace SpaceXLaunchData.Data
{
    public class SpaceXLaunchDataDbContext : DbContext
    {
        public DbSet<Launch> Launches { get; set; }


        public SpaceXLaunchDataDbContext(DbContextOptions<SpaceXLaunchDataDbContext> options) : base(options) { }
    }
}
