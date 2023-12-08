using Microsoft.EntityFrameworkCore;

namespace Policy.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {
        }
        public DbSet<MasterPolicy> MasterPolicy { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterPolicy>().HasKey(x => x.PID);
            base.OnModelCreating(modelBuilder);
        }
    }

}
