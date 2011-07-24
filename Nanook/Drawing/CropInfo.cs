namespace Nanook.Drawing {
    public class CropInfo {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Width {
            get {
                return X2 - X1;
            }
        }
        public int Height {
            get { return Y2 - Y1; }
        }
    }
}

