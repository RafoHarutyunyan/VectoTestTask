using VectoTask.Core;
using VectoTask.Core.Interfaces;
using VectoTask.ImageProcessor.DTO;

namespace VectoTask.ImageProcessor
{
    public class ImageProcessor : IImageProcessor
    {
        public List<CustomImage> Images { get; } = new List<CustomImage>();

        public async Task AddImageAsync(CustomImage image)
        {
            Images.Add(image);
            await Task.CompletedTask;
        }
        
        public async Task<object> ApplyEffectsAsync()
        {
            List<ProcessImageDto> dto = new List<ProcessImageDto>();
            foreach (var image in Images)
            {
               var urls = await ApplyPlugins(image);
                dto.Add(new ProcessImageDto
                {
                    OriginalFileName = image.OriginalFileName,
                    GeneratedFilePaths = urls
                });
            }
            
            return dto;
        }

        private async Task<List<string>> ApplyPlugins(CustomImage image)
        {
            PluginManager pluginManager = new PluginManager();
            pluginManager.LoadPlugins(image.PluginTypes,image.Radius);
            List<string> result = new List<string>();
            foreach (var plugin in pluginManager.Plugins)
            {
                var newPath = await plugin.ApplyAsync(image);
                result.Add(newPath);
            }
            return result;
        }
    }
}
