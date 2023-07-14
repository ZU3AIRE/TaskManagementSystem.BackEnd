using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost]
        public IActionResult UploadImageByUrl()
        {
            //try
            //{
            //    string fileUrl = Request.Form["fileUrl"];

            //    if (!string.IsNullOrEmpty(fileUrl))
            //    {
            //        if (!fileUrl.StartsWith("data:"))
            //        {
            //            using (var client = new HttpClient())
            //            {
            //                var response = client.GetAsync(fileUrl).Result;
            //                if (response.IsSuccessStatusCode)
            //                {
            //                    var contentType = response.Content.Headers.ContentType.MediaType;
            //                    var fileBytes = response.Content.ReadAsByteArrayAsync().Result;
            //                    var base64Data = Convert.ToBase64String(fileBytes);
            //                    fileUrl = $"data:{contentType};base64,{base64Data}";
            //                }
            //                else
            //                {
            //                    return BadRequest("Invalid file URL.");
            //                }
            //            }
            //        }

            //        var fileName = GetUniqueFileName(fileUrl);

            //        var base64DataFile = fileUrl.Substring(fileUrl.IndexOf(',') + 1);
            //        var fileBytesFile = Convert.FromBase64String(base64DataFile);
            //        var extension = fileUrl.Substring(fileUrl.IndexOf('/') + 1, fileUrl.IndexOf(';') - fileUrl.IndexOf('/') - 1);
            //        if (extension == "octet-stream")
            //        {
            //            // Check if the file is a PDF
            //            if (contentType == "application/pdf")
            //            {
            //                extension = "pdf";
            //            }
            //            else
            //            {
            //                extension = "jpeg";
            //            }
            //        }
            //        fileName += "." + extension;

            //        var folderName = Path.Combine("wwwroot", "Files");
            //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //        var fullPath = Path.Combine(pathToSave, fileName);
            //        var dbPath = Path.Combine(folderName, fileName);

            //        System.IO.File.WriteAllBytes(fullPath, fileBytesFile);

            //        var fileEntity = new ImageFile
            //        {
            //            name = fileName,
            //            path = dbPath
            //        };
            //        db.ImageFiles.Add(fileEntity);
            //        db.SaveChanges();
            //        return Ok(new { dbPath });
            //    }

            //    return BadRequest();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Internal Server Error: {ex}");
            //}
            try
            {
                string fileUrl = Request.Form["fileUrl"];

                if (!string.IsNullOrEmpty(fileUrl))
                {
                    if (!fileUrl.StartsWith("data:"))
                    {
                        using (var client = new HttpClient())
                        {
                            var response = client.GetAsync(fileUrl).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                var contentType = response.Content.Headers.ContentType.MediaType;
                                var fileBytes = response.Content.ReadAsByteArrayAsync().Result;
                                var base64Data = Convert.ToBase64String(fileBytes);
                                fileUrl = $"data:{contentType};base64,{base64Data}";
                            }
                            else
                            {
                                return BadRequest("Invalid file URL.");
                            }
                        }
                    }

                    var fileName = GetUniqueFileName(fileUrl);

                    var base64DataFile = fileUrl.Substring(fileUrl.IndexOf(',') + 1);
                    var fileBytesFile = Convert.FromBase64String(base64DataFile);
                    var extension = fileUrl.Substring(fileUrl.IndexOf('/') + 1, fileUrl.IndexOf(';') - fileUrl.IndexOf('/') - 1);
                    if (extension == "octet-stream")
                    {
                        extension = "jpeg";
                    }
                    fileName += "." + extension;

                    var folderName = Path.Combine("wwwroot", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    System.IO.File.WriteAllBytes(fullPath, fileBytesFile);

                    var fileEntity = new ImageFile
                    {

                        name = fileName,
                        path = dbPath
                    };
                    db.ImageFiles.Add(fileEntity);
                    db.SaveChanges();
                    return Ok(new { dbPath });
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex}");
            }
        }
        private string GetUniqueFileName(string fileName)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            var randomString = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
            var extension = Path.GetExtension(fileName);

            return $"{timestamp}_{randomString}{extension}";
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.ImageFiles.Where(x=>x.IsActive==true).ToList());
            //}
        }
        [HttpPost("{id}")]
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
