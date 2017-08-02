using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
//using HundredMilesSoftware.UltraID3Lib;
using NAudio.Wave;

namespace MediaLocator.filesystem
{
    class MediaFunctions
    {

       /* public List<string> ViewMp3Tags(string path)
        {
            List<string> tags = new List<string>();
            UltraID3 data = new UltraID3();
            data.Read(path);
            tags.Add(data.Title);
            tags.Add(data.Artist);
            tags.Add(data.Album);
            tags.Add(data.Duration.ToString());
            tags.Add(data.Year.ToString());
            tags.Add(data.TrackNum.ToString());
            tags.Add(data.Genre);
            return tags;



        }

        public void SetTitle(string path, string newTitle)
        {
            UltraID3 data = new UltraID3();
            data.Read(path);
            data.Title = newTitle;
            data.Write();
        }

        public void SetArtist(string path, string newArtist)
        {
            UltraID3 data = new UltraID3();
            data.Read(path);
            data.Artist = newArtist;
            data.Write();
        }

        public void SetAlbum(string path, string newAlbum)
        {
            UltraID3 data = new UltraID3();
            data.Read(path);
            data.Album = newAlbum;
            data.Write();
        }


        public void SetYear(string path, short newYear)
        {
            UltraID3 data = new UltraID3();
            data.Read(path);
            data.Year = newYear;
            data.Write();
        }

        public void Combine(string[] mp3Files, string mp3OuputFile)
        {
            using (var w = new BinaryWriter(File.Create(mp3OuputFile)))
            {
                new List<string>(mp3Files).ForEach(f => w.Write(File.ReadAllBytes(f)));
            }
        }

        public void SplitMp3(string mp3Path, int splitLength)
        {
            var mp3Dir = Path.GetDirectoryName(mp3Path);
            var mp3File = Path.GetFileName(mp3Path);
            var splitDir = Path.Combine(mp3Dir,Path.GetFileNameWithoutExtension(mp3Path));
            Directory.CreateDirectory(splitDir);

            int splitI = 0;
            int secsOffset = 0;

            using (var reader = new Mp3FileReader(mp3Path))
            {   
                FileStream writer = null;       
                Action createWriter = new Action(() => {
                    writer = File.Create(Path.Combine(splitDir,Path.ChangeExtension(mp3File,(++splitI).ToString("D4") + ".mp3")));
                });

                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {           
                    if (writer == null) createWriter();

                    if ((int)reader.CurrentTime.TotalSeconds - secsOffset >= splitLength)
                    {   
                        // time for a new file
                        writer.Dispose();
                        createWriter();
                        secsOffset = (int)reader.CurrentTime.TotalSeconds;              
                    }

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                }

                if(writer != null) writer.Dispose();
            }

        }*/
        
        

    }
}
