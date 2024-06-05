using Conferences.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Infrastructure.Db
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Conference> Conferences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            if (dbCreator != null)
            {
                if (!dbCreator.CanConnect()) dbCreator.Create();
                if (!dbCreator.HasTables()) dbCreator.CreateTables();
            }
        }

    }
}
