using Microsoft.AspNetCore.Mvc;
using VectoTask.ImageProcessor.Commands;
using VectoTask.ImageProcessor.Services;

namespace VectoTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageProcessorController : ControllerBase
    {
        private readonly IImageProcessService _imageProcessService;
        private readonly ICommonService _commonService;
        public ImageProcessorController(IImageProcessService imageProcessService, ICommonService commonService)
        {
            _imageProcessService = imageProcessService;
            _commonService = commonService;
        }
        [HttpPost("process-image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ProcessImage([FromForm]List<ProcessImage> image)
        {
           var data = await _imageProcessService.ProcessAsync(image);
            return Ok(data);
        }

        [HttpGet("plugin-types")]
        public async Task<IActionResult> GetPlugins()
        {
            var data = await _commonService.GetPluginTypesAsync();
            return Ok(data);
        }
    }
}
