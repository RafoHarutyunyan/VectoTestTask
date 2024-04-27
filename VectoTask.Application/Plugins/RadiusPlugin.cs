using System.Drawing;
using System.Drawing.Drawing2D;
using VectoTask.Core;
using VectoTask.Core.Enums;
using VectoTask.Core.Interfaces;

namespace VectoTask.ImageProcessor.Plugins
{
    public class RadiusPlugin : IPlugin
    {
        public PluginType Type => PluginType.Radius;

        public int Radius { get; set; }

        public RadiusPlugin(int radius)
        {
            Radius = radius;
        }

        public async Task<string> ApplyAsync(CustomImage image)
        {
            Bitmap bmp = new Bitmap(image.Path);

            Bitmap radiusImage = ApplyRadius(bmp, Radius);
            var fileName = Path.Combine(
                Path.GetDirectoryName(image.Path),
                string.Concat(Path.GetFileNameWithoutExtension(image.Path), "_radius_", Guid.NewGuid(), Path.GetExtension(image.Path))
            );
            radiusImage.Save(fileName);
            Console.WriteLine($"Applied radius effect with radius {Radius} to image '{image.Path}'.");
            await Task.CompletedTask;
            return fileName;
        }

        private Bitmap ApplyRadius(Bitmap image, int radius)
        {
            

            Bitmap circularImage = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(circularImage))
            {
                g.Clear(Color.White); 

                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(radius, radius, circularImage.Width, circularImage.Height);

                g.SetClip(path);

                g.DrawImage(image, 0, 0, circularImage.Width, circularImage.Height);
            }

            return circularImage;
        }
    }
}
