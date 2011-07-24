namespace Nanook.Drawing {
    using System.Drawing;

    public class ShrinkWithMinSize : Resizer {
        public ShrinkWithMinSize(int minWidth, int minHeight) : base(0, 0) {
            MinWidth = minWidth;
            MinHeight = minHeight;
        }

        public int MinWidth { get; set; }
        public int MinHeight { get; set; }

        public override Image Execute(Image source) {
            Width = MinWidth;
            Height = ReduceHeight(source.Size, MinWidth);
            
            if (Height < MinHeight) {
                Height = MinHeight;
                Width = ReduceWidth(source.Size, MinHeight);
            }
            
            return base.Execute(source);
        }

        public int ReduceWidth(Size size, int height) {
            return (height * size.Width) / size.Height;
        }

        public int ReduceHeight(Size size, int width) {
            return (width * size.Height) / size.Width;
        }
    }
}
//
//1980 - 131
//1080 - 71x
//x = (1080*131/1980)

//1980 - 139x
//1080 - 76
//x = (76*1980)/1080
        
//1080 - 131
//1980 - 240x
//x = (1980*131)/1080
        
//1080 - 41x
//1980 - 76
//x = (1080*76)/1980