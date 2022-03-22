using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Bookshare.DomainServices
{
    internal class MigrationsDbContextFactory : IDesignTimeDbContextFactory<BookshareDbContext>
    {
        public BookshareDbContext CreateDbContext(string[] args)
        {
            var connectionString = args.Any()
                ? args[0]
                : @"User ID=postgres;Password=postgres;Host=localhost;Port=5433;Database=Assessment";

            var builder = new DbContextOptionsBuilder<BookshareDbContext>();
            builder
                .UseNpgsql(connectionString);
            var context = new BookshareDbContext(builder.Options);
            return context;
        }
    }
}
