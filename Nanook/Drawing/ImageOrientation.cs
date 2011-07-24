namespace Nanook.Drawing {
    using System.Drawing;

    public class ImageOrientation {
        public static MediaOrientation Get(Image image) {
            if (image.Width > image.Height) {
                return MediaOrientation.Landscape;
            } else if (image.Height > image.Width) {
                return MediaOrientation.Portrait;
            } else {
                return MediaOrientation.Square;
            }
        }
    }
}