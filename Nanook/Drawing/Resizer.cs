namespace Nanook.Drawing {
    using System.Drawing;

    public class Resizer : Command {
        public Resizer(int width, int height) {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public override Image Execute(Image source) {
            var resized = new Bitmap(Width, Height);
            using (var graphics = GetGraphics(resized)) {
                graphics.DrawImage(source, 0, 0, Width, Height);
            }
            return resized;
        }
    }
}