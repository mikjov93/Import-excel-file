using Ireckonu.DomainModel;
using Ireckonu.DomainService.Interfaces;
using Ireckonu.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ireckonu.DomainService
{
    public class FileService : IFileService
    {
        private readonly IRepository<IruData> _repository;
        
        public FileService(IRepository<IruData> repository)
        {
            _repository = repository;           
        }

        public async Task<string> SaveExcelData(IFormFile file)
        {
            var folderName = Path.Combine("Resources");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPathJSON = Path.Combine(pathToSave, fileName + ".json");

            var records = new List<IruData>();

            using (ExcelPackage package = new ExcelPackage(file.OpenReadStream()))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int i = 2; i < rowCount + 1; i++)
                {
                    records.Add(new IruData()
                    {
                        Key = worksheet.Cells["A" + i].Value.ToString(),
                        ArticleCode = worksheet.Cells["B" + i].Value.ToString(),
                        ColorCode = worksheet.Cells["C" + i].Value.ToString(),
                        Description = worksheet.Cells["D" + i].Value.ToString(),
                        Price = double.Parse(worksheet.Cells["E" + i].Value.ToString()),
                        DiscountPrice = double.Parse(worksheet.Cells["F" + i].Value.ToString()),
                        DeliveredIn = worksheet.Cells["G" + i].Value.ToString(),
                        Q1 = worksheet.Cells["H" + i].Value.ToString(),
                        Size = int.Parse(worksheet.Cells["I" + i].Value.ToString()),
                        Color = worksheet.Cells["J" + i].Value.ToString()
                    });
                }
            }

            await _repository.AddCollection(records);

            File.WriteAllText(fullPathJSON, JsonConvert.SerializeObject(records));

            return fullPathJSON;
        }
    }
}
