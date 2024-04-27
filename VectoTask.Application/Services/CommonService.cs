using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectoTask.Core.Enums;
using VectoTask.ImageProcessor.DTO;

namespace VectoTask.ImageProcessor.Services
{
    public class CommonService : ICommonService
    {

        public async Task<List<PluginDto>> GetPluginTypesAsync()
        {
            await Task.CompletedTask;
            return Enum.GetValues(typeof(PluginType))
                .Cast<PluginType>()
                .Select(enumValue => new PluginDto
                {
                    Value = (int)enumValue,
                    Label = Enum.GetName(enumValue)
                }).ToList();
        }

    }
}