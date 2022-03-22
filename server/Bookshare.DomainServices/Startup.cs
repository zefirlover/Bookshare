using Bookshare.DomainServices.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;

namespace Bookshare.DomainServices
{
    public static class Startup
    {
        public static IServiceCollection AddDomainServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BookshareDbContext>(
                options =>
                {
                    options.UseNpgsql(
                        configuration.GetConnectionString(ConnectionStrings.Local),
                        x => x.MigrationsAssembly(typeof(Startup).Assembly.GetName().FullName));
                }, ServiceLifetime.Transient)
                .AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<BookshareDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<Compiler, PostgresCompiler>();
            return services;
        }

        private static class Marker
        {
        }
    }
}
