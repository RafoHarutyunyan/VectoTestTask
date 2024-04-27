using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectoTask.ImageProcessor.DTO;

namespace VectoTask.ImageProcessor.Services
{
    public interface ICommonService
    {
        Task<List<PluginDto>> GetPluginTypesAsync();
    }
}
