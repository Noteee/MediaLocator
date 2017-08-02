using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator.filesystem
{
    class FolderBrowser
    {
        public static ArrayList getFileList(string sDir)
        {
            ArrayList files = new ArrayList();
            try
            {
                foreach (string fi in Directory.GetFiles(sDir))
                {
                    files.Add(fi);
                }

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

        public static ArrayList GetFilteredList(Enum FilterType, string filePath)
        {
            ArrayList filteredList = new ArrayList();

            foreach (string file in Directory.GetFiles(filePath))
            {
                filteredList.Add(Path.GetFileName(file));

            }


            return filteredList;
        }
    }
}
