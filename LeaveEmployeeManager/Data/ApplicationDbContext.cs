

using LeaveEmployeeManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveEmployeeManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveType>? LeaveTypes { get; set; }
        public DbSet<LeaveAllocation>? LeaveAllocations { get; set; }
    }
}