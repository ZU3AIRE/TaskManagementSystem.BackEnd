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

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadImg()
        {
            try
            {
                string fileUrl = Request.Form["fileUrl"];

                if (!string.IsNullOrEmpty(fileUrl))
                {
                    var fileName = GenerateUniqueFileName();

                    if (fileUrl.StartsWith("data:"))
                    {
                        var base64Data = fileUrl.Substring(fileUrl.IndexOf(',') + 1);
                        var fileBytes = Convert.FromBase64String(base64Data);
                        var extension = fileUrl.Substring(fileUrl.IndexOf('/') + 1, fileUrl.IndexOf(';') - fileUrl.IndexOf('/') - 1);
                        fileName += "." + extension;


                        var folderName = Path.Combine("wwwroot", "Uploads");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        await System.IO.File.WriteAllBytesAsync(fullPath, fileBytes);

                        var fileEntity = new FileSaving
                        {
                            Path = dbPath,
                            FileName = fileName,
                        };
                        db.FileSavings.Add(fileEntity);
                        await db.SaveChangesAsync();

                        return Ok(new { dbPath });
                    }
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }
        }
        private string GenerateUniqueFileName()
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var random = new Random().Next(1000, 9999);
            var fileName = $"{timestamp}_{random}";

            return fileName;
        }
        [HttpGet]
        public IActionResult GetFileNames()
        {
            var fileNames = db.FileSavings.Select(x => x.FileName).ToList();
            return Ok(fileNames);
        }

        [HttpGet]
        public IActionResult GetAllImages()
        {
            var fileEntities = db.FileSavings.ToList();
            return Ok(fileEntities);
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
