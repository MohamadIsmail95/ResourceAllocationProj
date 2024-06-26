using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ResourceAllocationProject.Models
{
    public class AppDbContext:DbContext
    {

        public DbSet<AliMointorPlan> AliMointorPlans { get; set; }
        public DbSet<AliMonitor> AliMonitors { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

    }
}
