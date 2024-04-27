using System.Drawing;
using System.Drawing.Imaging;
using VectoTask.Core;
using VectoTask.Core.Enums;
using VectoTask.Core.Interfaces;

namespace VectoTask.ImageProcessor.Plugins
{
    public class BlurPlugin : IPlugin
    {
        public PluginType Type => PluginType.Blur;

        public async Task<string> ApplyAsync(CustomImage image)
        {
            Bitmap bmp = new Bitmap(image.Path);

            Bitmap blurredImage = ApplyBlur(bmp, image.Radius);
            var fileName = Path.Combine(
                Path.GetDirectoryName(image.Path),
                string.Concat(Path.GetFileNameWithoutExtension(image.Path), "_blur_", Guid.NewGuid(), Path.GetExtension(image.Path))
            );
            blurredImage.Save(fileName);
            Console.WriteLine($"Applied blur effect to image '{image.Path}'.");
            await Task.CompletedTask;
            return fileName;
        }
        private Bitmap ApplyBlur(Bitmap image, int radius)
        {
            Bitmap blurredImage = (Bitmap)image.Clone();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color blurredColor = CalculateBlurredPixel(image, x, y, radius);
                    blurredImage.SetPixel(x, y, blurredColor);
                }
            }

            return blurredImage;
        }

        private Color CalculateBlurredPixel(Bitmap image, int x, int y, int radius)
        {
            double r = 0, g = 0, b = 0;
            int blurPixelCount = 0;

            for (int offsetX = -radius; offsetX <= radius; offsetX++)
            {
                for (int offsetY = -radius; offsetY <= radius; offsetY++)
                {
                    int newX = x + offsetX;
                    int newY = y + offsetY;

                    // Ensure that the pixel is within the image bounds
                    if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                    {
                        Color pixel = image.GetPixel(newX, newY);
                        r += pixel.R;
                        g += pixel.G;
                        b += pixel.B;
                        blurPixelCount++;
                    }
                }
            }

            // Calculate the average color of the surrounding pixels
            r /= blurPixelCount;
            g /= blurPixelCount;
            b /= blurPixelCount;

            return Color.FromArgb((int)r, (int)g, (int)b);
        }
    }
}
