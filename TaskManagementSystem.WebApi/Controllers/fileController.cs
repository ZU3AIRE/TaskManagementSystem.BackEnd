using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using TaskManagementSystem.Database;
using TaskManagementSystem.Database.Entities;

namespace TaskManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class fileController : ControllerBase
    {
        private readonly AppDbContext db;

        public fileController(AppDbContext _db)
        {
            db = _db;
        }

        [HttpPost]
        public IActionResult UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName!.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var fileEntity = new ImageFile
                    {

                        name = fileName,
                        path = dbPath
                    };
                    db.ImageFiles.Add(fileEntity);
                    db.SaveChanges();
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.ImageFiles.ToList());
            //}
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var image = db.ImageFiles.FirstOrDefault(x => x.ImageFileId == id && x.IsActive == true);
            if (image != null)
            {
                image.IsActive = false;
                db.ImageFiles.Update(image);
                db.SaveChanges();

                return Ok (true);
            }
            else
            {
                return Ok (false);
            }
        }
    }
}
