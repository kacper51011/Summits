using Conferences.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Conferences.Api.Extensions
{
    public static class DbExtensions
    {
        public static IServiceCollection RegisterDb(this IServiceCollection services)
        {
            var server = "conferencesdb";
            var user = "SA";
            var database = "conferences";
            var password = "ExamplePassword123";


            services.AddDbContext<ApplicationDbContext>(c =>
            {
                c.UseSqlServer($"Data Source={server};Initial Catalog={database};User ID={user};Password={password}; TrustServerCertificate=True;Encrypt=True;MultiSubnetFailover=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("Flights.Api"));

            });

            return services;
        } 
    }
}
