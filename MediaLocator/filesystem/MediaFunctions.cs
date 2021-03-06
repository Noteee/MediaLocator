﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using HundredMilesSoftware.UltraID3Lib;
using NAudio.Wave;
using System.Collections;
using System.Windows;
using MediaLocator.logging;

namespace MediaLocator.filesystem
{
    class MediaFunctions
    {

        public static List<string> ViewMp3Tags(string path)
    
        {   
            List<string> tags = new List<string>();
            UltraID3 data = new UltraID3();
            data.Read(path);
            tags.Add(data.Title);
            Console.WriteLine(data.Title);
            tags.Add(data.Artist);
            tags.Add(data.Album);
            tags.Add(data.Year.ToString());
            tags.Add(data.Duration.ToString());
            tags.Add(data.TrackNum.ToString());
            tags.Add(data.Genre);
            return tags;



        }

        public static void SetTitle(string path, string newTitle)
        {
            try
            {
                UltraID3 data = new UltraID3();
                data.Read(path);
                data.Title = newTitle;

                data.Write();
            }
            catch(Exception e) { }
        }

        public static void SetArtist(string path, string newArtist)
        {
            try
            {
                UltraID3 data = new UltraID3();
                data.Read(path);
                data.Artist = newArtist;
                data.Write();
            }
            catch (Exception e) { }
        }

        public static void SetAlbum(string path, string newAlbum)
        {
            try
            {
                UltraID3 data = new UltraID3();
                data.Read(path);
                data.Album = newAlbum;
                data.Write();
            }
            catch (Exception e) { }
        }


        public static void SetYear(string path, short newYear)
        {
            try
            {
                UltraID3 data = new UltraID3();
                data.Read(path);
                data.Year = newYear;
                data.Write();
            }
            catch (Exception e) { }
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
            if (splitLength > 0)
            {
                var mp3Dir = Path.GetDirectoryName(mp3Path);
                var mp3File = Path.GetFileName(mp3Path);
                var splitDir = Path.Combine(mp3Dir, Path.GetFileNameWithoutExtension(mp3Path));
                Directory.CreateDirectory(splitDir);

                int splitI = 0;
                int secsOffset = 0;

                using (var reader = new Mp3FileReader(mp3Path))
                {
                    FileStream writer = null;
                    Action createWriter = new Action(() => {
                        writer = File.Create(Path.Combine(splitDir, Path.ChangeExtension(mp3File, (++splitI).ToString("D4") + ".mp3")));
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
                    MessageBox.Show("Successfully exported!");

                    if (writer != null) writer.Dispose();
                }
            }
            

        }

        public void CreateM3UData(ArrayList tracks, string destination, string filename)
        {
            string allData = "#EXTM3U\n";
            try
            {
                foreach (string curr in tracks)
                {
                    UltraID3 music = new UltraID3();
                    music.Read(curr);
                    allData += "#EXTINF: " + 1 + "," + music.Artist + "-" + music.Title + "\n";
                    allData += curr + "\n";
                   
                }

                FileStream fs = new FileStream(destination + @"\" + filename + ".m3u", FileMode.OpenOrCreate);

                StreamWriter sw = new StreamWriter(fs);

                fs.Flush();

                sw.Flush();

                sw.WriteLine(allData);

                fs.Flush();

                sw.Flush();

                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }



    }
}
