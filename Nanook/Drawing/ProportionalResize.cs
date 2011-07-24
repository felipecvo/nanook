namespace Nanook.Drawing {
    using System.Drawing;

    public class ProportionalResize : Resizer {
        public ProportionalResize(int maxWidth, int maxHeight) : base(0, 0) {
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
        }

        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }

        public override Image Execute(Image source) {
            switch (ImageOrientation.Get(source)) {
                case MediaOrientation.Portrait:
                    Height = MaxHeight;
                    Width = (int)(((float)MaxHeight / source.Height) * (float)source.Width);
                   break;
                case MediaOrientation.Landscape:
                default:
                    Width = MaxWidth;
                    Height = (int)(((float)MaxWidth / source.Width) * (float)source.Height);
                    break;
            }

            return base.Execute(source);
        }
    }
}