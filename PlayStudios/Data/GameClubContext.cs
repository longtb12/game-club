using Microsoft.EntityFrameworkCore;
using PlayStudios.Models;

namespace PlayStudios.Data
{
    public class GameClubContext : DbContext
    {
        public DbSet<GameClub> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }

        public GameClubContext(DbContextOptions<GameClubContext> options) : base(options) { }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }
        }

    }
}
