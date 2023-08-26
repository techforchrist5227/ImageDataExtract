using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageDataExtract.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //this is the image meta data controller IMD is just short for image meta data
    public class IMDController : ControllerBase
    {
        private readonly ImageMetaDataService _metadataService;

        public IMDController(ImageMetaDataService metadataService)
        {
            _metadataService = metadataService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
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

    }
}
