using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Ireckonu.DomainService.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveExcelData(IFormFile file);
    }
}
