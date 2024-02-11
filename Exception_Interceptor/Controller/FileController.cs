using Exception_Interceptor.DB.context;
using Exception_Interceptor.DB.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exception_Interceptor.Controller
{

    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly FileDbContext _fileDbContext;

        public FileController(IWebHostEnvironment appEnvironment, FileDbContext fileDbContext)
        {
            _appEnvironment = appEnvironment;
            _fileDbContext = fileDbContext;
        }

        [HttpGet]
        [Route("entity_sync")]
        public IActionResult GetFile([FromQuery] string nameFile = "book.text")
        {
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, $"Files/{nameFile}");
            if (!System.IO.File.Exists(file_path))
            {
                return NotFound($"File {nameFile} not found.");
            }

            // Read the file line by line
            var lines = System.IO.File.ReadLines(file_path);
            int duplicateCount = 0;

            foreach (var line in lines)
            {
                // Check if the line exists in the database
                var existingRecord = _fileDbContext.MyLineRecords.FirstOrDefault(r => r.Line == line);
                if (existingRecord != null)
                {
                    // Increment the duplicate count
                    existingRecord.DuplicateCount += 1;
                    duplicateCount++;
                }
                else
                {
                    // Create a new record
                    _fileDbContext.MyLineRecords.Add(new MyLineRecord
                    {
                        Line = line,
                        CreatedAt = DateTime.Now,
                        DuplicateCount = 0
                    });
                }
            }

            // Save changes to the database
            _fileDbContext.SaveChanges();

            //Return the total count of duplicates
            return Ok($"{duplicateCount} lines had duplicates.");
            //return Ok($"{1} lines had duplicates.");
        }

        [HttpGet]
        [Route("entity_async")]
        //AI gen
        public async Task<IActionResult> GetFileAsync([FromQuery] string nameFile = "book.text")
        {
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, $"Files/{nameFile}");
            if (!System.IO.File.Exists(file_path))
            {
                return NotFound($"File {nameFile} not found.");
            }

            // Read the file line by line asynchronously
            var lines = await System.IO.File.ReadAllLinesAsync(file_path);
            int duplicateCount = 0;

            foreach (var line in lines)
            {
                // Check if the line exists in the database asynchronously
                var existingRecord = await _fileDbContext.MyLineRecords.FirstOrDefaultAsync(r => r.Line == line);
                if (existingRecord != null)
                {
                    // Increment the duplicate count
                    existingRecord.DuplicateCount += 1;
                    duplicateCount++;
                }
                else
                {
                    // Create a new record
                    _fileDbContext.MyLineRecords.Add(new MyLineRecord
                    {
                        Line = line,
                        CreatedAt = DateTime.Now,
                        DuplicateCount = 0
                    });
                }


            }

            // Save changes to the database asynchronously
            await _fileDbContext.SaveChangesAsync();

            // Return the total count of duplicates
            return Ok($"{duplicateCount} lines had duplicates.");
        }
    }

}
