namespace Nanook.Drawing {
    using System.Drawing;

    public class CenteredCrop : Croper {
        public CenteredCrop(int width, int height) : base(new CropInfo()) {
            Width = width;
            Height = height;
        }
  
        public int Width { get; set; }
        public int Height { get; set; }

        public override Image Execute(Image source) {
            Info.X1 = (source.Width - Width) / 2;
            Info.X2 = Info.X1 + Width;
            Info.Y1 = (source.Height - Height) / 2;
            Info.Y2 = Info.Y1 + Height;
            
            System.Console.WriteLine("WIDTH: {0} - {1} - {2} ({3}, {4})", source.Width, Width, Info.Width, Info.X1, Info.X2);
            System.Console.WriteLine("HEIGHT: {0} - {1} - {2} ({3}, {4})", source.Height, Height, Info.Height, Info.Y1, Info.Y2);
            
            return base.Execute(source);
        }
    }
}