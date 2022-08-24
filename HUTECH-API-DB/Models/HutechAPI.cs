using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Emit;

namespace HUTECH_API_DB.Models
{
    public class HutechAPI : DbContext
    {
        public HutechAPI(DbContextOptions<HutechAPI> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Database> Databases { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Database>()
            .HasOne<User>(s => s.User)
            .WithMany(g => g.Databases)
            .HasForeignKey(s => s.UserId);
        }
    }
}
