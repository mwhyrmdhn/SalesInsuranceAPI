using Microsoft.EntityFrameworkCore;

namespace Master.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) 
            : base(options)
        {
        }
        public DbSet<MasterUser> MUser { get; set; } = null!;
        public DbSet<ActivityLog> ActivityLog { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterUser>().HasKey(x => x.MID);
            base.OnModelCreating(modelBuilder);
        }


    }

}
