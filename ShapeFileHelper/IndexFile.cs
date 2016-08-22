
namespace ShapeFileHelper
{
    public class IndexFile
    {
        private string filePath, fileName;
        private int fileLength;

        public int FileLength
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

        public void Write() { }

        public void Read(string filePath) { }
    }
}
