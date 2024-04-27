using VectoTask.Core.Enums;

namespace VectoTask.Core
{
    public class CustomImage
    {
        public string Path { get; set; }
        public List<PluginType> PluginTypes { get; set; }
        public int Radius { get; set; }
        public string OriginalFileName { get; set; }
    }
}
