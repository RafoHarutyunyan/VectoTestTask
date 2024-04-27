using Microsoft.AspNetCore.Http;
using VectoTask.Core.Enums;

namespace VectoTask.ImageProcessor.Commands
{
    public class ProcessImage
    {
        public IFormFile File { get; set; }
        public List<PluginType> PluginTypes { get; set; } = new List<PluginType>();
        public int Radius { get; set; }

    }
}
