namespace Nanook.Drawing {
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public abstract class Command {
        public abstract Image Execute(Image source);
        
        protected Graphics GetGraphics(Image source) {
            var graphics = Graphics.FromImage(source);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            
            return graphics;
         }
    }
}