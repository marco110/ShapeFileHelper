using System;
using System.IO;
using System.Collections.Generic;

namespace ShapeFileHelper
{
    public abstract class ShapeFile
    {
        private string filePath, fileName, fileLength;

        public string FileLength
        {
            get { return fileLength; }
            set { fileLength = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public ShapeFile(string filePath)
        {
            this.FilePath = filePath;
        }

        public void ReadShapeFile() { }

        public void WriteShapeFile() { }

        public void SaveShapeFile(Shape shape) { }
    }
}
