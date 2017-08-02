using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLocator.filesystem;

namespace MediaLocator.filesystem
{
    class FolderBrowser
    {
        private string path;
        public void getFolder()
        {
            // use FolderBrowserDialog for browsing
            // then path should equals the browsed path
        }
        public string getPath(string path)
        {

            return path;
        }
        public static ArrayList getFileList(string sDir)
        {
            ArrayList files = new ArrayList();
            try
            {

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        files.Add(f);
                    }
                    getFileList(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return files;
        }

    }
}
