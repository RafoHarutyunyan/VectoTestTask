using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectoTask.ImageProcessor.Commands;

namespace VectoTask.ImageProcessor.Services
{
    public interface IImageProcessService
    {
        Task<object> ProcessAsync(List<ProcessImage> images);
    }
}
