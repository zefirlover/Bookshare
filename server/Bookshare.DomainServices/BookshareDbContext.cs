using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bookshare.Domain.Contracts;
using Bookshare.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookshare.DomainServices
{
    public class BookshareDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Library> Libraries { get; set; }

#pragma warning disable 8618
        public BookshareDbContext(DbContextOptions<BookshareDbContext> options)
            : base(options)
#pragma warning restore 8618
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(BookshareDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            UpdateDates();

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateDates();

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateDates();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateDates();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateDates()
        {
            var now = DateTime.UtcNow;

            var entries = ChangeTracker
                .Entries()
                .Where(x => x.Entity is IWithDateCreated);

            foreach (var entry in entries)
            {
                var entity = (IWithDateCreated)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.SetDateCreated(now);
                }
                else
                {
                    entry.Property(nameof(IWithDateCreated.DateCreated)).IsModified = false;
                }
            }

            var modifiedEntries = ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .OfType<IWithDateModified>();

            foreach (var entity in modifiedEntries)
            {
                entity.SetDateModified(now);
            }
        }
    }
}
