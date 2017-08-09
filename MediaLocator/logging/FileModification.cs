using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator.logging
{

   class FileModification
    {
        private DateTime date;
        private string fileName;
        private string extension;
        private string modificationMethod;

        public FileModification(DateTime date,string fileName, string extension, string modificationMethod)
        {
            this.date = date;
            this.fileName = fileName;
            this.extension = extension;
            this.modificationMethod = modificationMethod;
        }

        public string FileName { get => fileName; set => fileName = value; }
        public string Extension { get => extension; set => extension = value; }
        public string ModificationMethod { get => modificationMethod; set => modificationMethod = value; }
        public DateTime Date { get => date; set => date = value; }

        public void addModificationToList(List<FileModification> modifList)
        {
            modifList.Add(this);
        }
    }
}
