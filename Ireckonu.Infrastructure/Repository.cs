using Ireckonu.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ireckonu.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCollection(List<T> entity)
        {
            await _context.Set<T>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
