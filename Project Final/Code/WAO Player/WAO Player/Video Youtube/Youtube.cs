using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WAO_Player.Class;

namespace WAO_Player.Video_Youtube
{
    class Youtube
    {
        #region Data
        private const string SEARCH = "http://gdata.youtube.com/feeds/api/videos?q={0}&alt=rss&&max-results=20&v=1";
        #endregion

        #region Load Videos From Feed
        /// <summary>
        /// Returns a List<see cref="YouTubeInfo">YouTubeInfo</see> which represent
        /// the YouTube videos that matched the keyWord input parameter
        /// </summary>
        public static List<Video> LoadVideosKey(string keyWord)
        {
            try
            {
                var xraw = XElement.Load(string.Format(SEARCH, keyWord));
                var xroot = XElement.Parse(xraw.ToString());
                var links = (from item in xroot.Element("channel").Descendants("item")
                             select new Video
                             {
                                 URL = item.Element("link").Value,
                                 ImageSmall = GetEmbedUrlFromLink(item.Element("link").Value),
                                 ImageLarge = GetThumbNailUrlFromLink(item),
                             }).Take(20);

                return links.ToList<Video>();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message, "ERROR");
            }
            return null;
        }


        #endregion

        #region Private Methods

        /// <summary>
        /// Simple helper methods that tunrs a link string into a embed string
        /// for a YouTube item. 
        /// turns 
        /// http://www.youtube.com/watch?v=hV6B7bGZ0_E
        /// into
        /// http://www.youtube.com/embed/hV6B7bGZ0_E
        /// </summary>
        private static string GetEmbedUrlFromLink(string link)
        {
            try
            {
                string embedUrl = link.Substring(0, link.IndexOf("&")).Replace("watch?v=", "embed/");
                return embedUrl;
            }
            catch
            {
                return link;
            }
        }


        private static string GetThumbNailUrlFromLink(XElement element)
        {

            XElement group = null;
            XElement thumbnail = null;
            string thumbnailUrl = @"../Images/logo.png";

            foreach (XElement desc in element.Descendants())
            {
                if (desc.Name.LocalName == "group")
                {
                    group = desc;
                    break;
                }
            }

            if (group != null)
            {
                foreach (XElement desc in group.Descendants())
                {
                    if (desc.Name.LocalName == "thumbnail")
                    {
                        thumbnailUrl = desc.Attribute("url").Value.ToString();
                        break;
                    }
                }
            }

            return thumbnailUrl;
        }

        #endregion
    }
}
