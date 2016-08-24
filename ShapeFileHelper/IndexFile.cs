
namespace Thinkgeo.ShapeFileHelper {

    public class IndexFile {

        public int FileLength { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public IndexFile(string fileName) {
            this.FileName = fileName;
        }

        public void WriteIndexFile() { }

        public void ReadIndexFile() { }

        public void SaveIndexFile() { }
    }
}
