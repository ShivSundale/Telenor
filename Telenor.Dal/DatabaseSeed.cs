using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telenor.Dal.Interfaces;
using Telenor.Infrastructure;

namespace Telenor.Dal
{
    public class DatabaseSeed : IDatabaseSeed
    {
        private readonly CatalogContext _context;
        public DatabaseSeed(CatalogContext context)
        {
            _context = context;
        }
        public void ClearDatabase()
        {
            var cleared = _context.Database.EnsureDeleted();
            var created = _context.Database.EnsureCreated();
            var entitiesadded = _context.SaveChanges();
        }

        public Task SaveAnyChanges()
        {
            throw new NotImplementedException();
        }

        public void SeedDatabase()
        {
            _context.EnsureSeedData();
        }
    }
}
