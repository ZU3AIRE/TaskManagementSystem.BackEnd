using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mime;
using TaskManagementSystem.Database.Entities;
using TaskManagementSystem.Database.Migrations;
using TaskManagementSystem.WebApi.Database;
using TaskManagementSystem.WebApi.Database.Entities;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileSavingController : ControllerBase
    {
        private readonly AppDbContext db;
        private readonly IWebHostEnvironment environment;


        public FileSavingController(AppDbContext db, IWebHostEnvironment _environment)
        {
            this.db = db;
            this.environment = _environment;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.FileSavings.ToArray());
        }

        // Source Code from the Website https://code-maze.com/upload-files-dot-net-core-angular/
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImg()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                var folderName = Path.Combine("wwwroot", "Uploads");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var fileEntity = new FileSaving
                    {
                        Path = dbPath,
                        FileName = fileName,
                    };

                    db.FileSavings.Add(fileEntity);
                    await db.SaveChangesAsync();

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error : {ex}");
            }
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var file = db.FileSavings.Find(id);
            if (file == null)
            {
                return Ok(false);
            }
            db.SaveChanges();
            return Ok(true);
        }

    }
}
