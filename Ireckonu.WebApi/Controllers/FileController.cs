using System;
using System.Threading.Tasks;
using Ireckonu.DomainService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ireckonu.WebApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Import Excel FIle
        /// </summary>      
        /// <response code="200">Returns path of the json file</response>
        /// <response code="400">Bad request </response>
        /// <response code="500">If a server error occurs</response>        
        [HttpPost]
        public async Task<IActionResult> ImporExcelFile(IFormFile file)
        {
            try
            {
                //file = Request.Form.Files[0];

                if (file.Length > 0)
                {
                    return Ok(await _fileService.SaveExcelData(file));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}