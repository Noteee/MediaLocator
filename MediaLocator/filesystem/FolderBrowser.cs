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
        public static ArrayList getFileList(string sDir, string dir)
        {

            int dirLenght = dir.Length;

            ArrayList files = new ArrayList();
            try
            {
                
                foreach (string fi in Directory.GetFiles(sDir))
                {
                    files.Add(Path.GetFileName(fi));
                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        string path = Path.GetDirectoryName(f);
                        string foldersPath = path.Substring(dirLenght + 1, path.Length - dirLenght - 1);
                        files.Add(Path.Combine(foldersPath, Path.GetFileName(f)));

                    }
                    getFileList(d, dir);
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
