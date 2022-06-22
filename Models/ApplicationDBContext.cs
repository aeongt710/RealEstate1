using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstate1.Models;

namespace RealEstate1.Models
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<RealEstate1.Models.Society> Societies { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Block>(x=>
            {
                x.HasOne(a=>a.Society)
                    .WithMany(b=>b.SocietyBlocks)
                    .HasForeignKey(c=>c.SocietyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            base.OnModelCreating(builder);
        }
    }
}
