using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CompositePatterns
{
    public class clsDirectory : IFileSytem
    {
        private string fileName;
        private int fileSize;
        private IList<IFileSytem> fileSystems;
        public clsDirectory(string filename, int size)
        {
            fileSystems= new List<IFileSytem>();
            this.fileName= filename;
            this.fileSize= size;    
        }
        public void Display()
        {
            Console.WriteLine($"Directory name is {fileName} and directory size is {fileSize}");
            foreach(var file in fileSystems)
            {
                file.Display();
            }
        }
        public string FileName()
        {
            return fileName;
        }

        public int FileSize()
        {
            foreach(var file in fileSystems)
            {
                this.fileSize += file.FileSize();
            }
            return this.fileSize;
        }
        public void AddFiles(IFileSytem file)
        {
            fileSystems.Add(file);  
        }
        public void RemoveFiles(IFileSytem file)
        {
            fileSystems.Remove(file);
        }
    }
}
