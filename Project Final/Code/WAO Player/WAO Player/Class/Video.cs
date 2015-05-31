using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAO_Player.Class
{
    public class Video
    {
        public bool isHave;
        public string Name_Video;
        public string Genre;
        public string Type;
        public TimeSpan Lenght;
        public string URL;
        public string ImageSmall;
        public string ImageLarge;
        public Video()
        {
            Lenght = new TimeSpan();
            isHave = true;
        }

        public Video(string path)
        {
            try
            {
                TagLib.File tagFile = TagLib.File.Create(path);

                Type = System.IO.Path.GetExtension(path);

                if (tagFile.Tag.FirstGenre != null)
                    Genre = tagFile.Tag.FirstGenre;
                else
                    Genre = "unknow";

                if (tagFile.Tag.Title != null)
                    Name_Video = tagFile.Tag.Title;
                else
                    Name_Video = System.IO.Path.GetFileName(path);

                Lenght = tagFile.Properties.Duration;
                //ImageSmall = tagFile.Tag.Pic
                isHave = true;
                URL = path;
            }
            catch
            {
                isHave = false;
            }
        }
    }
}
