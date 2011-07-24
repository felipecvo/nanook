namespace Nanook {
    using System;
    using System.IO;

    public class FileManager {
        public static string PublicTmp {
            get {
                return System.Web.HttpContext.Current.Server.MapPath("/tmp");
            }
        }

        public static string Save(string path, string fileName, Stream content) {
            var fullPath = GetAvailableFullPath(path, fileName);
            
            using (var fileStream = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write)) {
                byte[] buffer = new byte[8 * 1024];
                int len;
                while ((len = content.Read(buffer, 0, buffer.Length)) > 0) {
                    fileStream.Write(buffer, 0, len);
                }
            }
            
            return fullPath;
        }

        public static string GetAvailableFullPath(string path, string fileName) {
            if (File.Exists(Path.Combine(path, fileName))) {
                var newFileName = string.Format("{0}-{1}{2}", Path.GetFileNameWithoutExtension(fileName),
                                                              DateTime.Now.Second,
                                                              Path.GetExtension(fileName).ToLower());

                return GetAvailableFullPath(path, newFileName);
            }
    
            return Path.Combine(path, fileName);
        }
    }
}