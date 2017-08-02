using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator.enums
{
    class PictureFormats : Formats
    {
        public enum pictureFormats
        {
            JPG, PNG, GIF, BMP
        }

        public static ArrayList getPictureFormats()
        {
            ArrayList videoFormatList = new ArrayList();
            foreach (var value in Enum.GetValues(typeof(pictureFormats)))
            {
                videoFormatList.Add(value);
            }
            return videoFormatList;
        }
    }
}
