using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator.logging
{
    class Logging
    {
        public void makeLogFile(string logData)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);
            file.WriteLine(logData);
            file.Close();
        }
    }
}
