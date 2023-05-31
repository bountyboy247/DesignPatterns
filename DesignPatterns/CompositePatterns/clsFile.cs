using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CompositePatterns
{
    public class clsFile : IFileSytem
    {
        private string fileName;
        private int fileSize;
        public clsFile(string fileName, int fileSize)
        {
            this.fileName = fileName;
            this.fileSize = fileSize;
        }

        public void Display()
        {
            Console.WriteLine($"File name is {fileName} and file size is {fileSize}");
        }

        public string FileName()
        {
            return fileName;
        }

        public int FileSize()
        {
          return fileSize;
        }
    }
}
