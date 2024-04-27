using VectoTask.Core;
using VectoTask.Core.Interfaces;
using VectoTask.ImageProcessor.Commands;

namespace VectoTask.ImageProcessor.Services
{
    public class ImageProcessService : IImageProcessService
    {
        private readonly IImageProcessor _imageProcessor;
        public ImageProcessService(IImageProcessor imageProcessor)
        {
            _imageProcessor = imageProcessor;
        }
        public async Task<object> ProcessAsync(List<ProcessImage> images)
        {
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            foreach (var image in images)
            {
                string uniqueFileName = string.Concat(Guid.NewGuid(), Path.GetExtension(image.File.FileName));
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.File.CopyToAsync(fileStream);
                }
                await _imageProcessor.AddImageAsync(new CustomImage
                {
                    Path = filePath,
                    PluginTypes = image.PluginTypes,
                    Radius = image.Radius,
                    OriginalFileName = image.File.FileName
                });
            }
            return await _imageProcessor.ApplyEffectsAsync();
        }
    }
}
