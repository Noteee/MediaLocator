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
        static string[] pictures = Enum.GetNames(typeof(PictureFormats.pictureFormats));
        static string [] videos = Enum.GetNames(typeof(VideoFormats.videoFormats));
        static string[] musics = Enum.GetNames(typeof(MusicFormats.musicFormats));
        public static ArrayList getFileList(string sDir, string dir)
        {

            int dirLenght = dir.Length;

            ArrayList files = new ArrayList();
            try
            {
                
                foreach (string fi in Directory.GetFiles(sDir))
                {
                     foreach(string ex in pictures)
                     {

                         if (ex.Equals(Path.GetExtension(fi).Substring(1, Path.GetExtension(fi).Length-1).ToUpper()))
                         {
                             files.Add(Path.GetFileName(fi));
                         }
                     }
                    foreach (string ex in musics)
                    {

                        if (ex.Equals(Path.GetExtension(fi).Substring(1, Path.GetExtension(fi).Length - 1).ToUpper()))
                        {
                            files.Add(Path.GetFileName(fi));
                        }
                    }
                    foreach (string ex in videos)
                    {

                        if (ex.Equals(Path.GetExtension(fi).Substring(1, Path.GetExtension(fi).Length - 1).ToUpper()))
                        {
                            files.Add(Path.GetFileName(fi));
                        }
                    }

                }

                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        string path = Path.GetDirectoryName(f);
                        string foldersPath = path.Substring(dirLenght + 1, path.Length - dirLenght - 1);
                        string getPath = Path.Combine(foldersPath, Path.GetFileName(f));

                        foreach (string ex in pictures)
                        {

                            if (ex.Equals(Path.GetExtension(f).Substring(1, Path.GetExtension(f).Length - 1).ToUpper()))
                            {
                                files.Add(getPath);
                            }
                        }
                        foreach (string ex in musics)
                        {

                            if (ex.Equals(Path.GetExtension(f).Substring(1, Path.GetExtension(f).Length - 1).ToUpper()))
                            {
                                files.Add(getPath);
                            }
                        }
                        foreach (string ex in videos)
                        {

                            if (ex.Equals(Path.GetExtension(f).Substring(1, Path.GetExtension(f).Length - 1).ToUpper()))
                            {
                                files.Add(getPath);
                            }
                        }

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

        public static ArrayList GetFilteredList(string[] formats, string sDir, string dir)
        {
            int dirLenght = dir.Length;

            ArrayList filteredList = new ArrayList();

            foreach (string fi in Directory.GetFiles(sDir))
            {
                foreach (string ex in formats)
                {

                    if (ex.Equals(Path.GetExtension(fi).Substring(1, Path.GetExtension(fi).Length - 1).ToUpper()))
                    {
                        filteredList.Add(Path.GetFileName(fi));
                    }
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        string path = Path.GetDirectoryName(f);
                        string foldersPath = path.Substring(dirLenght + 1, path.Length - dirLenght - 1);
                        string getPath = Path.Combine(foldersPath, Path.GetFileName(f));

                        foreach (string ex in formats)
                        {

                            if (ex.Equals(Path.GetExtension(f).Substring(1, Path.GetExtension(f).Length - 1).ToUpper()))
                            {
                                filteredList.Add(getPath);
                            }
                        }
                    }
                    getFileList(d, dir);

                }
                   
                }
            return filteredList;
        }

        public static string [] getPictures ()
        {
            return pictures;
        }
        public static string[] getMusics()
        {
            return musics;
        }
        public static string[] getVideos()
        {
            return videos;
        }
    }
}
