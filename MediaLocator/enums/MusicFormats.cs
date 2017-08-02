using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator.enums
{
    class MusicFormats : Formats
    {
        public enum musicFormats
        {
         WAV, MP3, WMA, MP4, FLAC, M3U
        }

        public static ArrayList getMusicFormatList()
        {
            ArrayList videoFormatList = new ArrayList();
            foreach (var value in Enum.GetValues(typeof(musicFormats)))
            {
                videoFormatList.Add(value);
            }
            return videoFormatList;
        }
    }
}
