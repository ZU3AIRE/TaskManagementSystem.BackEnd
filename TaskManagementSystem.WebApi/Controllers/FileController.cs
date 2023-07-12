using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Repositories;
using TaskManagementSystem.Repositories.Implementation;
using TaskManagementSystem.Repositories.Implementtation;

namespace TaskManagementSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository fileRepository;

        public FileController(IFileRepository _fileRepository)
        {
            fileRepository = _fileRepository;

        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var Files = fileRepository.GetAll();

            return Ok(Files);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try 
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file selected.");
                }

                string uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Store the file path in the database
                fileRepository.SaveFilePath(filePath);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while uploading the file: {ex.Message}");
            }
        }
    }

}
