using ImageDataExtract.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedMango_API.Models;
using System.Net;

namespace ImageDataExtract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //this is the image meta data controller IMD is just short for image meta data
    public class IMDController : ControllerBase
    {
        

        private readonly ApplicationDBContext _db;

        private ApiResponse _apiResponse;
        private IImageDataService _metadataService;

        public IMDController(ApplicationDBContext db, IImageDataService metadataService)
        {
            _db = db;
            _metadataService = metadataService;

        }


       

        [HttpPost("/upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            ApiResponse response = new ApiResponse();



            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                var metadata = _metadataService.ExtractMetadataFromImage(memoryStream);
                return Ok(metadata);

            }
        }


        [HttpGet("/getdata")]

        public async Task<IActionResult> GetImageData()
        {
            ApiResponse response = new ApiResponse();

            response.Result = _db;

            return Ok(_db.imageDatas);
        }

    }

}