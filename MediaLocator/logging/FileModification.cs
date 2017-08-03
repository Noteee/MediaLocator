using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator.logging
{
    class FileModification
    {
        private string fileName;
        private string extension;
        private string modificationMethod;

        public FileModification(string fileName, string extension, string modificationMethod)
        {
            this.fileName = fileName;
            this.extension = extension;
            this.modificationMethod = modificationMethod;
        }


    }
}
