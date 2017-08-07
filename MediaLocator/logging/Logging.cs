using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Documents;
using System.IO;
namespace MediaLocator.logging
{
    class Logging
    {
        public static void AppendToLogFile(List<FileModification> logList)
        {
            if (File.Exists(@"C:\\test.txt"))
            {

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\test.txt", true);
                int i = logList.Count - 1;
                file.WriteLine("Modification Time: " + logList[i].Date + "Filename: " + logList[i].FileName + " Extension: " + logList[i].Extension + " Modification method: " + logList[i].ModificationMethod);

                file.Close();
            }
            if (File.Exists(@"C:\\test.txt") != true)
            {
                File.Create(@"C:\\test.txt");
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\test.txt", true);
                int i = logList.Count - 1;            
                file.WriteLine("Modification Time: " + logList[i].Date + "Filename: " + logList[i].FileName + " Extension: " + logList[i].Extension + " Modification method: " + logList[i].ModificationMethod);    
            file.Close();
            }
        }
        public static void CreateSessionLog(List<FileModification> logList)
        {
            
                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\test" + DateTime.Now + ".txt", true);
                for (int i = 0; i < logList.Count; i++)
                {
                    file.WriteLine("Modification Time: " + logList[i].Date + "Filename: " + logList[i].FileName + " Extension: " + logList[i].Extension + " Modification method: " + logList[i].ModificationMethod);
                }
                file.Close();
           
        }
        }
            }
    

