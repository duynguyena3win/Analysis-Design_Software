using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using WAO_Player.Class;

namespace WAO_Player.Process
{
    
    public class XML
    {
        XDocument doc;
        String Path_Document;
        public XML()
        {
            Init_Create_XML();
        }

        void Init_Create_XML()
        {
            Path_Document = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Directory.CreateDirectory(Path_Document + "\\Documents\\WAO Player");

            String[] Files = Directory.GetFiles(Path_Document + "\\Documents\\WAO Player");
            Path_Document += "\\Documents\\WAO Player\\Infor.xml";
            int Count = Files.Count<String>();

            for (int i = 0; i < Count; i++)
            {
                if (System.IO.Path.GetFileName(Files[i]) == "Infor.xml")
                    return;
            }

            XElement wao_player = new XElement("WAO_PLAYER",
                new XElement("Background", new XAttribute("path", "null")),
                new XElement("Folder_Container", new XElement("Folder", new XAttribute("path", "C:\\Users\\Public\\Music"))),
                new XElement("List_Song_Offline"),
                new XElement("List_Artist_Offline"),
                new XElement("List_Video_Offline"),
                new XElement("List_Video_Online"),
                new XElement("List_Playlist"),
                new XElement("List_Playlist_Online"));
            wao_player.Save(Path_Document);
        }
        public void RemoveNode(string nameElement, string nameChildElement)
        {
            doc = new XDocument();
            doc = XDocument.Load(Path_Document);
            var ele_Remove = from element in doc.Elements("WAO_PLAYER").Elements(nameElement).Elements(nameChildElement)
                                  select element;
            ele_Remove.Remove();
            doc.Save(Path_Document);
        }
        public List<Video> Get_List_Video()
        {
            doc = new XDocument();
            List<Video> List_Out = new List<Video>();
            doc = XDocument.Load(Path_Document);

            var ele_Video_Remove = from element in doc.Elements("WAO_PLAYER").Elements("List_Video_Offline").Elements("Video")
                                   select element;
            ele_Video_Remove.Remove();

            var elementFolder = from element in doc.Elements("WAO_PLAYER").Elements("Folder_Container").Elements("Folder")
                                select element;
            foreach (var node in elementFolder)
            {
                List<Video> List_Temp = new List<Video>();
                List_Temp = Read_Information_Video(node.Attribute("path").Value);
                for (int i = 0; i < List_Temp.Count; i++)
                {
                    List_Out.Add(List_Temp[i]);
                }
            }
            doc.Save(Path_Document);
            return List_Out;
        }
        List<Video> Read_Information_Video(string path)
        {
            String[] Files = Directory.GetFiles(path);
            int Count = Files.Count<String>();
            List<Video> List_Video_Offline = new List<Video>();
            for (int i = 0; i < Count; i++)
            {
                string type = System.IO.Path.GetExtension(Files[i]).ToLower();
                if (type == ".mp4" || type == ".avi")
                {
                    Video V = new Video(Files[i]);
                    if (V.isHave != false)
                    {
                        List_Video_Offline.Add(V);
                        XElement node = doc.Element("WAO_PLAYER").Element("List_Video_Offline");
                        XElement song = new XElement("Video");
                        song.Add(new XAttribute("Name_Video", V.Name_Video));
                        song.Add(new XAttribute("Type", V.Type));
                        song.Add(new XAttribute("Genre", V.Genre));
                        song.Add(new XAttribute("Lenght", V.Lenght.ToString()));
                        song.Add(new XAttribute("URL", V.URL));
                        node.Add(song);
                    }
                }
            }
            return List_Video_Offline;
        }
        public List<Song> Get_List_Song()
        {
            doc = new XDocument();
            List<Song> List_Out = new List<Song>();
            doc = XDocument.Load(Path_Document);
            var ele_Song_Remove = from element in doc.Elements("WAO_PLAYER").Elements("List_Song_Offline").Elements("Song")
                                  select element;
            ele_Song_Remove.Remove();
            var elementFolder = from element in doc.Elements("WAO_PLAYER").Elements("Folder_Container").Elements("Folder")
                                select element;
            foreach (var node in elementFolder)
            {
                List<Song> List_Temp = new List<Song>();
                List_Temp = Read_Information_Song(node.Attribute("path").Value);
                for (int i = 0; i < List_Temp.Count; i++)
                {
                    List_Out.Add(List_Temp[i]);
                }
            }
            doc.Save(Path_Document);
            return List_Out;
        }
        List<Song> Read_Information_Song(string path)
        {
            String[] Files = Directory.GetFiles(path);
            int Count = Files.Count<String>();
            List<Song> List_Song_Offline = new List<Song>();
            for (int i = 0; i < Count; i++)
            {
                string type = System.IO.Path.GetExtension(Files[i]).ToLower();
                if (type == ".mp3" || type == ".wav" || type == ".wma")
                {
                    Song S = new Song(Files[i]);
                    if (S.isHave != false)
                    {
                        List_Song_Offline.Add(S);
                        XElement node = doc.Element("WAO_PLAYER").Element("List_Song_Offline");
                        XElement song = new XElement("Song");
                        song.Add(new XAttribute("Name_Song", S.Name_Song));
                        song.Add(new XAttribute("Name_Artist", S.Name_Artist));
                        song.Add(new XAttribute("Name_Album", S.Name_Album));
                        song.Add(new XAttribute("Genre", S.Genre));
                        song.Add(new XAttribute("Lenght", S.Lenght.ToString()));
                        song.Add(new XAttribute("URL", S.URL));
                        node.Add(song);
                    }
                }
            }
            return List_Song_Offline;
        }
        
        public void Create_XML_Video_Online()
        {
            doc = XDocument.Load(Path_Document);
            XElement node = doc.Element("WAO_PLAYER").Element("List_Video_Online");
            for (int i = 0; i < List_Collection.List_Video_Online.Count; i++)
            {
                XElement video = new XElement("Video");
                video.Add(new XAttribute("Name", "Video Online"));
                video.Add(new XAttribute("ImageSmall", List_Collection.List_Video_Online[i].ImageSmall));
                video.Add(new XAttribute("ImageLarge", List_Collection.List_Video_Online[i].ImageLarge));
                video.Add(new XAttribute("URL", List_Collection.List_Video_Online[i].URL));
                node.Add(video);
            }
            doc.Save(Path_Document);
        }
        public void Create_XML_Playlist_Online()
        {
            doc = XDocument.Load(Path_Document);
            RemoveNode("List_Playlist_Online", "Playlist");
            XElement node = doc.Element("WAO_PLAYER").Element("List_Playlist_Online");
            for (int i = 0; i < List_Collection.List_Playlist_Online.Count; i++)
            {
                XElement playlist = new XElement("Playlist");
                playlist.Add(new XAttribute("Name_Playlist", List_Collection.List_Playlist_Online[i].Name_Playlist));
                playlist.Add(new XAttribute("Name_Artist", List_Collection.List_Playlist_Online[i].Name_Artist));
                playlist.Add(new XAttribute("Image_Playlist", List_Collection.List_Playlist_Online[i].Image_Playlist));
                node.Add(playlist);
            }
            doc.Save(Path_Document);
        }
        public void Create_XML_Playlist()
        {
            doc = XDocument.Load(Path_Document);
            RemoveNode("List_Playlist", "Playlist");
            XElement node = doc.Element("WAO_PLAYER").Element("List_Playlist");
            for (int i = 0; i < List_Collection.List_Playlist.Count; i++)
            {
                XElement playlist = new XElement("Playlist");
                playlist.Add(new XAttribute("Name_Playlist", List_Collection.List_Playlist[i].Name_Playlist));
                playlist.Add(new XAttribute("Image_Playlist", Picture.PLAYLIST_UNKNOW));
                playlist.Add(new XAttribute("ID", i));
                for(int j=0;j<List_Collection.List_Playlist[i].Song_Playlist.Count;i++)
                {
                    XElement song = new XElement("Song");
                    song.Add(new XAttribute("Name_Song", List_Collection.List_Playlist[i].Song_Playlist[j].Name_Song));
                    song.Add(new XAttribute("Name_Artist", List_Collection.List_Playlist[i].Song_Playlist[j].Name_Artist));
                    song.Add(new XAttribute("URL", List_Collection.List_Playlist[i].Song_Playlist[j].URL));
                    playlist.Add(song);
                }
                node.Add(playlist);
            }
            doc.Save(Path_Document);
        }
        public void Get_List_Playlist()
        {
            List_Collection.List_Playlist = new List<Playlist>();
            doc = new XDocument();
            doc = XDocument.Load(Path_Document);
            var ele_node = from element in doc.Elements("WAO_PLAYER").Elements("List_Playlist").Elements("Playlist")
                             select element;
            foreach (var node in ele_node)
            {
                Playlist temp = new Playlist();
                temp.ID = node.Attribute("ID").Value;
                temp.Name_Playlist = node.Attribute("Name_Playlist").Value;
                
                
                var ele_Song_node = from element in doc.Elements("WAO_PLAYER").Elements("List_Playlist").Elements("Playlist").Elements("Song")
                               where element.Parent.Attribute("ID").Value == temp.ID
                               select element;
                foreach (var n in ele_Song_node)
                {
                    Song temp_Song = new Song();
                    temp_Song.Name_Song = n.Attribute("Name_Song").Value;
                    temp_Song.Name_Artist = n.Attribute("Name_Artist").Value;
                    temp_Song.URL = n.Attribute("URL").Value;
                    temp.Song_Playlist.Add(temp_Song);
                }
                List_Collection.List_Playlist.Add(temp);
            }
            doc.Save(Path_Document);
        }
        public List<Artist> Get_List_Artist()
        {
            List<string> name_artist = new List<string>();
            List<Artist> List_Out = new List<Artist>();
            doc = XDocument.Load(Path_Document);
            var ele_Artist = from element in doc.Elements("WAO_PLAYER").Elements("List_Artist_Offline").Elements("Artist")
                             select element;
            foreach (var e in ele_Artist)
            {
                IEnumerable<Song> temp = List_Collection.List_Song_Offline.Where(s => s.Name_Artist == e.Attribute("Name").Value);
                Artist A = new Artist(e.Attribute("Name").Value, temp);
                List_Out.Add(A);
            }
            return List_Out;
        }
        public void Init_List_Artist()
        {
            doc = XDocument.Load(Path_Document);
            List<string> name_artist = new List<string>();
            var elementFolder = from element in doc.Elements("WAO_PLAYER").Elements("List_Song_Offline").Elements("Song")
                                select element;
            foreach (var e in elementFolder)
            {
                int index = name_artist.IndexOf(e.Attribute("Name_Artist").Value);
                if (index < 0)
                {
                    name_artist.Add(e.Attribute("Name_Artist").Value);
                }
            }

            var elementRemove = from element in doc.Elements("WAO_PLAYER").Elements("List_Artist_Offline").Elements("Artist")
                                select element;
            elementRemove.Remove();

            XElement node = doc.Element("WAO_PLAYER").Element("List_Artist_Offline");
            for (int i = 0; i < name_artist.Count; i++)
                node.Add(new XElement("Artist", new XAttribute("Name", name_artist[i])));
            doc.Save(Path_Document);
        }
        public Brush Set_Background()
        {
            Brush temp;
            XDocument doc = XDocument.Load(Path_Document);
            XElement node = doc.Element("WAO_PLAYER").Element("Background");
            string path = node.Attribute("path").Value;
            if (path == null || path == "null")
            {
                temp = System.Windows.Media.Brushes.Black;
            }
            else
            {
                try
                {
                    temp = new ImageBrush(new BitmapImage(new Uri(path)));
                }
                catch
                {
                    temp = System.Windows.Media.Brushes.Black;
                }
            }
            return temp;
        }
        public void Save_Background(string path)
        {
            XDocument doc = XDocument.Load(Path_Document);
            XElement node = doc.Element("WAO_PLAYER").Element("Background");
            if (path == null || path == "null")
            {
                node.SetAttributeValue("path", "null");
            }
            else
            {
                try
                {
                    node.SetAttributeValue("path", path);
                }
                catch
                {
                    node.SetAttributeValue("path", "null");
                }
            }
            doc.Save(Path_Document);
        }
        public List<String> Get_Folder_XML()
        {
            List<String> temp = new List<string>();

            XDocument doc = XDocument.Load(Path_Document);
            var Ele_Folder = from element in doc.Elements("WAO_PLAYER").Elements("Folder_Container").Elements("Folder")
                             select element;
            foreach (XElement node in Ele_Folder)
            {
                temp.Add(node.Attribute("path").Value);
            }
            return temp;
        }
        public void Save_Folder(System.Windows.Controls.ListView List_Folder)
        {
            XDocument doc = XDocument.Load(Path_Document);

            var Ele_Folder = from element in doc.Elements("WAO_PLAYER").Elements("Folder_Container").Elements("Folder")
                             select element;
            Ele_Folder.Remove();

            XElement node = doc.Element("WAO_PLAYER").Element("Folder_Container");
            foreach (System.Windows.Controls.ListViewItem item in List_Folder.Items)
            {
                XElement Folder = new XElement("Folder",
                    new XAttribute("path", item.Content.ToString()));
                node.Add(Folder);
            }
            doc.Save(Path_Document);
        }
    }
}
