namespace Nanook.Drawing {
    using System.Drawing;

    public class Croper : Command {
        public Croper(CropInfo info) {
            Info = info;
        }

        public CropInfo Info { get; set; }

        #region implemented abstract members of Nanook.Drawing.Command

        public override Image Execute(Image source) {
            if (Info == null) return source;

            var croped = new Bitmap(Info.Width, Info.Height);
            using (var graphics = GetGraphics(croped)) {
                graphics.DrawImage(source, new Rectangle(0, 0, Info.Width, Info.Height), Info.X1, Info.Y1, Info.Width, Info.Height, GraphicsUnit.Pixel);
            }
            return croped;
        }
        
        #endregion
    }
}

