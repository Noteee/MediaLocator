using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Documents;

namespace MediaLocator.logging
{
    class Logging
    {
        public void makeLogFile(List<FileModification> logList)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);
            for(int i = 0; i < logList.Count;i++)
            {
                file.WriteLine("Filename: " + logList[i].FileName + " Extension: " + logList[i].Extension + " Modification method: " + logList[i].ModificationMethod);
            }
            file.Close();
        }
    }
}
