using dlluploaderwebapi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dlluploaderwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DllUploaderController : ControllerBase
    {
        private readonly UploaderdbContext _uploaderdbContext;
        public DllUploaderController(UploaderdbContext uploaderdbContext)
        {
            _uploaderdbContext = uploaderdbContext;
        }


        [HttpPost("delete")]
        public string GetDllVersionFromFormFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            string tempFilePath = @"E:\sample.dll";

            using (var fileStream = new FileStream(tempFilePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(tempFilePath);
            string version = versionInfo.FileVersion;

            FileInfo fileInfo = new FileInfo(tempFilePath);

            fileInfo.Delete();

            return version;
        }



        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            // Get the file name and extension
            string fileName = Path.GetFileName(file.FileName);
            string fileExtension = Path.GetExtension(fileName);


            //TO GET THE FILE VERSION
            

            byte[] fileData;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileData = memoryStream.ToArray();
                //FileVersionInfo fileVersion =  FileVersionInfo(fileData);
         
                _uploaderdbContext.UploadedDlls.Add(new UploadedDll
                {
                    FileName = GetDllVersionFromFormFile(file),
                    FileUploaded = fileData,
                });

            }

            _uploaderdbContext.SaveChanges();


            return Ok("File uploaded successfully.");
        }


        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            // Retrieve the file data from the database or any other source based on the provided ID
            byte[] fileData = _uploaderdbContext.UploadedDlls.Where(e => e.Id == id).FirstOrDefault().FileUploaded;

            if (fileData == null)
            {
                return NotFound("File not found");
            }

            // Set the file name and content type
            string fileName = "example.dll";
            string contentType = "application/octet-stream"; // Or the appropriate MIME type for your file

            
            // Return the file as a downloadable attachment
            return File(fileData, contentType, fileName);
        }
    }

    public class FileModel
    {
        public string FileName { get; set; }

        public byte[] FileData { get; set; }
    }
}
