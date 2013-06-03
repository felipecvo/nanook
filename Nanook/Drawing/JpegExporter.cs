namespace Nanook.Drawing {
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public class JpegExporter : Command {
        public JpegExporter(Stream stream, byte quality) {
            Quality = quality;
            OutputStream = stream;
        }

        public JpegExporter(string path, byte quality) {
            Quality = quality;
            Path = path;
        }

        private byte quality;
        public byte Quality {
            get { return quality; }
            set {
                if (value > 100 || value < 0) {
                    quality = 100;
                } else {
                    quality = value;
                }
            }
        }
        public string Path { get; set; }
        public Stream OutputStream { get; set; }

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

            if (string.IsNullOrEmpty(Path)) {
                source.Save(OutputStream, Codec, encoderParams);
            } else {
                source.Save(Path, Codec, encoderParams);
            }
            
            return source;
        }
    }
}
