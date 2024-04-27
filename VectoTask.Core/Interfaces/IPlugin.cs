using VectoTask.Core.Enums;

namespace VectoTask.Core.Interfaces
{
    public interface IPlugin
    {
        PluginType Type { get; }
        Task<string> ApplyAsync(CustomImage image);
    }
}
