using VectoTask.Core.Enums;
using VectoTask.Core.Interfaces;
using VectoTask.ImageProcessor.Plugins;

namespace VectoTask.ImageProcessor
{
    public class PluginManager
    {
        public List<IPlugin> Plugins { get; private set; } = new List<IPlugin>();

        public void LoadPlugins(List<PluginType> pluginTypes,int radius)
        {
           
            if (pluginTypes.Any(x => x == PluginType.Resize))
            {
                Plugins.Add(new ResizePlugin());
            }
            if (pluginTypes.Any(x => x == PluginType.Blur))
            {
                Plugins.Add(new BlurPlugin());
            }
            if (pluginTypes.Any(x => x == PluginType.Radius))
            {
                Plugins.Add(new RadiusPlugin(radius));
            }
            
        }
    }
}
