using System.Drawing;
using VectoTask.Core;
using VectoTask.Core.Enums;
using VectoTask.Core.Interfaces;

namespace VectoTask.ImageProcessor.Plugins
{
    public class ResizePlugin : IPlugin
    {
        public PluginType Type => PluginType.Resize;

        public async Task<string> ApplyAsync(CustomImage image)
        {
            Bitmap bmp = new Bitmap(image.Path);

            int newWidth = 100; 
            int newHeight = 100; 
            Bitmap resizedImage = new Bitmap(bmp, newWidth, newHeight);
            
            var fileName = Path.Combine(
                Path.GetDirectoryName(image.Path),
                           string.Concat(Path.GetFileNameWithoutExtension(image.Path), "_resized_",Guid.NewGuid(),Path.GetExtension(image.Path))
            );
            resizedImage.Save(fileName);
            Console.WriteLine($"Resized image '{image.Path}' to {newWidth}x{newHeight} pixels.");
            await Task.CompletedTask;
            return fileName;
        }
    }
}
