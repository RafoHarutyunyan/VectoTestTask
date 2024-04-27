using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectoTask.ImageProcessor.DTO
{
    public class ProcessImageDto
    {
        public string OriginalFileName { get; set; }
        public List<string> GeneratedFilePaths { get; set; }
    }
}
