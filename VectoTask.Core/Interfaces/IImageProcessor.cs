
namespace VectoTask.Core.Interfaces
{
    public interface IImageProcessor
    {
        Task AddImageAsync(CustomImage image);
        Task<object> ApplyEffectsAsync();
    }
}
