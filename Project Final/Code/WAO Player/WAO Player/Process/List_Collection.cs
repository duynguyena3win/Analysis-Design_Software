using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAO_Player.Class;

namespace WAO_Player.Process
{
    public class List_Collection
    {
        enum Collection
        {
            Song, Video
        }

        private static List<Song> list_song_offline;
        public static List<Song> List_Song_Offline
        {
            get { return list_song_offline; }
            set { list_song_offline = value; }
        }

        private static List<Video> list_video_offline;
        public static List<Video> List_Video_Offline
        {
            get { return list_video_offline; }
            set { list_video_offline = value; }
        }

        private static List<Song> list_nowplaying;
        public static List<Song> List_NowPlaying
        {
            get { return list_nowplaying; }
            set { list_nowplaying = value; }
        }

        private static int current_nowplaying;
        public static int Current_NowPlaying
        {
            get { return current_nowplaying; }
            set { current_nowplaying = value; }
        }

        private static List<Song> list_song_online;
        public static List<Song> List_Song_Online
        {
            get { return list_song_online; }
            set { list_song_online = value; }
        }

        private static List<Video> list_video_online;
        public static List<Video> List_Video_Online
        {
            get { return list_video_online; }
            set { list_video_online = value; }
        }

        private static List<Song> list_song_suggeter;
        public static List<Song> List_Song_Suggeter
        {
            get { return list_song_suggeter; }
            set { list_song_suggeter = value; }
        }

        private static List<Song> list_song_Search_offline;
        public static List<Song> List_Song_Search
        {
            get { return list_song_Search_offline; }
            set { list_song_Search_offline = value; }
        }

        private static List<Artist> list_artist;
        public static List<Artist> List_Artist_Offline
        {
            get { return list_artist; }
            set { list_artist = value; }
        }

        private static List<Playlist> list_Playlist_Online;
        public static List<Playlist> List_Playlist_Online
        {
            get { return list_Playlist_Online; }
            set { list_Playlist_Online = value; }
        }

        private static List<Song> list_Song_Playlist;

        public static List<Song> List_Song_Playlist
        {
            get { return List_Collection.list_Song_Playlist; }
            set { List_Collection.list_Song_Playlist = value; }
        }
        public static void Init_List_Collection()
        {
            List_Song_Offline = new List<Song>();
            List_NowPlaying = new List<Song>();
            List_Song_Online = new List<Song>();
            List_Artist_Offline = new List<Artist>();
            List_Video_Online = new List<Video>();
            List_Song_Suggeter = new List<Song>();
            List_Song_Search = new List<Song>();
            List_Video_Offline = new List<Video>();
            List_Playlist_Online = new List<Playlist>();
            List_Song_Playlist = new List<Song>();

            Current_NowPlaying = -1;
        }

        private static List<Playlist> list_Playlist;

        public static List<Playlist> List_Playlist
        {
            get { return List_Collection.list_Playlist; }
            set { List_Collection.list_Playlist = value; }
        }
        
        public static int GetSize(List<Video> List)
        {
            return List.Count;
        }

        public static int GetSize(List<Song> List)
        {
            return List.Count;
        }
        public static Song GetSong_Playing(int index)
        {
            if (index < 0 || index > List_NowPlaying.Count)
                return null;
            return List_NowPlaying[index];
        }

        public static Song Get_Song_Current_ListPlay()
        {
            return List_NowPlaying[Current_NowPlaying];
        }

        public static void AddListSongNowPlaying(List<Song> temp)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i] != null)
                {
                    List_Collection.List_NowPlaying.Add(temp[i]);
                }
            }
        }
    }
}
