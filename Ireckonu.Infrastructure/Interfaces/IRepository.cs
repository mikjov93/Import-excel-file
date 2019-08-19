using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ireckonu.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddCollection(List<T> entity);
    }
}
