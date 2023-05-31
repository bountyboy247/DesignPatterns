using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CompositePatterns
{
    public interface IFileSytem
    {
        public void Display();
        public string FileName();
        public int FileSize();
    }
}
