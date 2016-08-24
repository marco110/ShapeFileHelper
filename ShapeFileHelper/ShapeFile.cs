using System;
using System.IO;
using System.Collections.Generic;

namespace ShapeFileHelper {
    public abstract class ShapeFile {
        public string FileLength { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public ShapeFile(string filePath) {
            this.FilePath = filePath;
        }

        public void ReadShapeFile() { }

        public void WriteShapeFile() { }

        public void SaveShapeFile() { }
    }
}
