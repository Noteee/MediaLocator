using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLocator.enums;

namespace MediaLocator.filesystem
{
    class FolderBrowser
    {
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

                FileInfo[] collection = new DirectoryInfo(sDir).GetFiles();
                foreach (var fileinfo in collection)
                {
                    files.Add(fileinfo.Name);
                }
                   
                
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return files;
        }
        public static ArrayList GetFilteredList(ArrayList formatList,string filePath)
        {
            ArrayList filteredList = new ArrayList();

           
                FileInfo[] collection = new DirectoryInfo(filePath).GetFiles();
                    foreach (var fileinfo in collection)
                    {
                        foreach(var extension in formatList)
                        {
                            if(fileinfo.Extension.ToUpper().Equals("." + extension.ToString().ToUpper()))
                            {
                                filteredList.Add(fileinfo.Name);
                                Console.WriteLine(fileinfo.Name);
                            
                            }
                        }
                        
                    }
                           


            return filteredList;
        }

    }
}
