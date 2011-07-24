using System.Drawing;
using System.Drawing.Imaging;
namespace Nanook.Drawing {
    using System;

    public class JpegExporter : Command {
        public JpegExporter(string path, byte quality) {
            Quality = quality;
            if (Quality > 100)
                Quality = 100;
            Path = path;
        }

        public byte Quality { get; set; }
        public string Path { get; set; }

        private static ImageCodecInfo encoderInfo;
        public static ImageCodecInfo Codec {
            get {
                if (encoderInfo == null) {
                    var codecs = ImageCodecInfo.GetImageEncoders();

                    for (int i = 0; i < codecs.Length; i++)
                        if (codecs[i].MimeType == "image/jpeg")
                            encoderInfo = codecs[i];
                    
                    if (encoderInfo == null)
                        throw new Exception("JPEG ImageCodecInfo not found");
                }

                return encoderInfo;
            }
        }

        public override Image Execute(Image source) {
            var qualityParam = new EncoderParameter(Encoder.Quality, (long)Quality);
            
            var encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;
            
            source.Save(Path, Codec, encoderParams);
            
            return source;
        }
    }
}
