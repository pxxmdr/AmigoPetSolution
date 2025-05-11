using AmigoPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmigoPet.Data.Context
{
    public class AmigoPetContext : DbContext
    {
        public AmigoPetContext(DbContextOptions<AmigoPetContext> options) : base(options) { }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<CareReminder> CareReminders { get; set; }
        public DbSet<ItemChecklist> ItemChecklists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
