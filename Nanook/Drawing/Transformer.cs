namespace Nanook.Drawing {
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;

    public class Transformer : IDisposable {
        private List<Command> commands = new List<Command>();

        public Transformer(string path) {
            CurrentImage = new Bitmap(path);
        }

        public Transformer(Stream stream) {
            CurrentImage = new Bitmap(stream);
        }

        public Image CurrentImage { get; protected set; }

        public List<Command> Commands {
            get {
                return commands;
            }
        }

        public void Execute() {
            Commands.ForEach(delegate(Command item) {
                var image = item.Execute(CurrentImage);
                CurrentImage.Dispose();
                CurrentImage = image;
            });
        }

        void IDisposable.Dispose() {
            CurrentImage.Dispose();
        }
    }
}

