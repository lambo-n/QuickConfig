using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace QuickConfig.Core
{
    public static class IconUtilities
    {
        public static BitmapImage GetInformationIcon()
        {
            Icon systemIcon = SystemIcons.Information;
            using (var stream = new MemoryStream())
            {
                systemIcon.Save(stream);
                stream.Seek(0, SeekOrigin.Begin);
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;

            }
        }
    }
}
