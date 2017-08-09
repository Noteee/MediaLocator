using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MediaLocator.enums
{
    class VideoFormats : Formats
    {
        public enum videoFormats
        {
            WEBM, MKV, AVI, FLV, MOV, WMV, AMV, M4V
        }

        public static ArrayList getVideoFormatList()
        {
            ArrayList videoFormatList = new ArrayList();
            foreach (var value in Enum.GetValues(typeof(videoFormats)))
            {
                videoFormatList.Add(value);
            }
            return videoFormatList;
        }

    }
    }
