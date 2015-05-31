using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WAO_Player.Class;
using WAO_Player.Music_Online_NCT;
using WAO_Player.Process;
using WAO_Player.Video_Youtube;

namespace WAO_Player.Control
{
    /// <summary>
    /// Interaction logic for Connection_Online.xaml
    /// </summary>
    public partial class Connection_Online : UserControl, INotifyPropertyChanged
    {
        List_Collection List_Collection;
        ReadHTML Reader_HTML = new ReadHTML();
        XML Read_XML = new XML();
        public delegate void Event_Click_Song(int index, Song Output);
        public delegate void Event_Click_Video(int index, Video Output);

        public delegate void Double_Click_Song(int index, Song Output);
        public delegate void Double_Click_Video(int index, int Output);

        public event Event_Click_Song Select_Item_Song;
        public event Event_Click_Video Select_Item_Video;

        public delegate void MenuItemClick_AddSong(Song Output);
        public event MenuItemClick_AddSong AddSong;

        public delegate void MenuItemClick_AddListSong(List<Song> Output);
        public event MenuItemClick_AddListSong AddListSong;

        public delegate void Change_Song(Song Output);
        public event Change_Song Changed;

        public delegate void Add_Playlist();
        public event Add_Playlist Add_PlaylistSong;

        public event Double_Click_Song Double_Song;
        public event Double_Click_Video Double_Video;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public delegate void Change(string path);
        public event Change BeginWait;
        short Num_Page;
        // Biến dùng binding
        string _searchkey;
        
        public string Searchkey
        {
            get { return _searchkey; }
            set { _searchkey = value; OnPropertyChanged("Searchkey"); }
        }
        bool Default = true;
        string song_Click;

        public string SongClick
        {
            get { return song_Click; }
            set { song_Click = value; OnPropertyChanged("SongClick"); }
        }
        public Connection_Online()
        {
            this.DataContext = this;
            InitializeComponent();
            Picture_Server.Source = new BitmapImage(new Uri(Picture.NCT_LOGO));
            Picture_Video_Server.Source = new BitmapImage(new Uri(Picture.YOUTUBE_LOGO));
            Picture_Playlist_Server.Source = new BitmapImage(new Uri(Picture.NCT_PLAYLIST_LOGO));

            Init_Control();
            Init_Var();
        }
        public void Default_Control()
        {
            //RadioBtn.IsChecked = true;
            //RadioButton_Checked(null, null);
            //Radio_NewPlaylist.IsChecked = true;
            //RadioButton_Album_Checked(null, null);
        }
        public void Init_Control()
        {
            XmlDataProvider xmlpro = new XmlDataProvider();
            string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            xmlpro.Source = new Uri(user + "\\Documents\\WAO Player\\Infor.xml");

            // Binding of List Video
            Binding bd1 = new Binding();
            bd1.XPath = "/WAO_PLAYER/List_Video_Online/*";
            bd1.Mode = BindingMode.TwoWay;
            List_Video_Online.DataContext = xmlpro;
            List_Video_Online.SetBinding(ListView.ItemsSourceProperty, bd1);

            
            // Binding of List Playlist
            Binding bd2 = new Binding();
            bd2.XPath = "/WAO_PLAYER/List_Playlist_Online/*";
            bd2.Mode = BindingMode.TwoWay;
            List_Playlist_Online.DataContext = xmlpro;
            List_Playlist_Online.SetBinding(ListView.ItemsSourceProperty, bd2);
        }

        bool Check_Internet()
        {
            if (SourceWeb.IsConnectedToInternet() == false)
            {
                MessageBox.Show("Cheack your connect with Internet !!!");
                return false;
            }
            return true;
        }
        public void Searching_Online(string key_search)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Visible;
            Searchkey = key_search;
            BeginWait("Searching Songs key " + key_search + " . . .");
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Song_Online = Reader_HTML.Search_Songs(key_search, 1);
            });
            thread.Start();
            thread.Join();
            List_Song_Online.ItemsSource = List_Collection.List_Song_Online;
            //Add_List_Music_Online(List_Collection.List_Song_Online);
        }
        void Init_Var()
        {
            List_Collection = new Process.List_Collection();
        }
        public void Add_List_Music_Online(List<Song> List)
        {
            List_Collection.List_Song_Online = List;
        }
        private void List_Song_Online_MouseEnter(object sender, MouseEventArgs e)
        {
            ListViewItem lv = (ListViewItem)sender;
            lv.Foreground = Brushes.Blue;
        }
        private void List_Song_Online_MouseLeave(object sender, MouseEventArgs e)
        {
            ListViewItem lv = (ListViewItem)sender;
            lv.Foreground = Brushes.Yellow;
        }

        // Double Click vào danh sách các Song
        private void List_Song_Online_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SongClick = List_Collection.List_Song_Online[List_Song_Online.SelectedIndex].Name_Song;
            Double_Song(2, List_Collection.List_Song_Online[List_Song_Online.SelectedIndex]);
        }

        //Click vào danh sách các bài hát
        private void List_Song_Online_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SongClick = List_Collection.List_Song_Online[List_Song_Online.SelectedIndex].Name_Song;
            Select_Item_Song(1, List_Collection.List_Song_Online[List_Song_Online.SelectedIndex]);
        }

        
        //Click vào danh sách các Video của Album
        private void List_Video_Online_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Select_Item_Video(1, List_Collection.List_Video_Online[List_Video_Online.SelectedIndex]);
        }

        //Click vào danh sách các bài hát của Album
        private void List_Song_Album_Online_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Select_Item_Song(1, null);
        }

        // Double Click vào danh sách các bài hát của Album
        private void List_Song_Album_Online_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SongClick = List_Collection.List_Song_Playlist[List_Song_Playlist_Online.SelectedIndex].Name_Song;
            Double_Song(2, List_Collection.List_Song_Playlist[List_Song_Playlist_Online.SelectedIndex]);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Visible;
            BeginWait("Searching New Songs . . .");
            Searchkey = "New Songs";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Song_Online = Reader_HTML.LoadNewSongs(1);
            });
            thread.Start();
            thread.Join();
            List_Song_Online.ItemsSource = List_Collection.List_Song_Online;
        }
        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Hidden;
            BeginWait("Searching Top20 VPop . . .");
            Searchkey = "Top20 VPop";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Song_Online = Reader_HTML.LoadTop20Songs(0);
            });
            thread.Start();
            thread.Join();
            List_Song_Online.ItemsSource = List_Collection.List_Song_Online;
        }
        private void RadioButton_Checked2(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Hidden;
            BeginWait("Searching Top20 US-UK . . .");
            Searchkey = "Top20 US-UK";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Song_Online = Reader_HTML.LoadTop20Songs(1);
            });
            thread.Start();
            thread.Join();
            List_Song_Online.ItemsSource = List_Collection.List_Song_Online;
        }
        private void RadioButton_Checked3(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Hidden;
            BeginWait("Searching Top20 KPop . . .");
            Searchkey = "Top20 KPop";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Song_Online = Reader_HTML.LoadTop20Songs(2);
            });
            thread.Start();
            thread.Join();
            List_Song_Online.ItemsSource = List_Collection.List_Song_Online;
        }

        private void Button_More_Click(object sender, RoutedEventArgs e)
        {
            Num_Page++;
            List<Song> List = new List<Song>();
            if (RadioBtn.IsChecked == true)
            {
                BeginWait("Searching More New Songs . . .");
                Read_XML.RemoveNode("List_Song_Online", "Song");
                Thread thread = new Thread(delegate()
                {
                    List = Reader_HTML.LoadNewSongs(Num_Page);
                });
                thread.Start();
                thread.Join();
                for (int i = 0; i < List.Count; i++)
                    List_Collection.List_Song_Online.Add(List[i]);

                List_Song_Online.ItemsSource = List_Collection.List_Song_Online;
            }
            else
            {
                BeginWait("Searching More Song . . .");
                Thread thread = new Thread(delegate()
                {
                    List = Reader_HTML.Search_Songs(Searchkey, Num_Page);
                });
                thread.Start();
                thread.Join();
                for (int i = 0; i < List.Count; i++)
                    List_Collection.List_Song_Online.Add(List[i]);
                List_Song_Online.ItemsSource = List_Collection.List_Song_Online;
            }
        }

        // Double Click vào danh sách các Video
        private void List_Video_Online_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Double_Video(2, List_Video_Online.SelectedIndex);
        }

        public void Init_Data_First()
        {
            if (Default != true)
                return;
            Default = false;
            Default_Control();
        }

        // Checked of Radio Album
        private void RadioButton_Album_Checked(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Visible;
            BeginWait("Searching New Playlist . . .");
            Searchkey = "New Songs";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Playlist_Online = Reader_HTML.LoadNewAlbums(1);
            });
            thread.Start();
            thread.Join();
            Read_XML.Create_XML_Playlist_Online();
            Init_Control();
        }

        private void RadioButton_Album_Checked1(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Hidden;
            BeginWait("Searching Top20 VPop Playlist . . .");
            Searchkey = "Top20 VPop";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Playlist_Online = Reader_HTML.LoadTop20Albums(0);
            });
            thread.Start();
            thread.Join();
            
            Read_XML.Create_XML_Playlist_Online();
            Init_Control();
        }
        private void RadioButton_Album_Checked2(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Hidden;
            BeginWait("Searching Top20 US-UK Playlist . . .");
            Searchkey = "Top20 US-UK";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Playlist_Online = Reader_HTML.LoadTop20Albums(9);
            });
            thread.Start();
            thread.Join();
            
            Read_XML.Create_XML_Playlist_Online();
            Init_Control();
        }
        private void RadioButton_Album_Checked3(object sender, RoutedEventArgs e)
        {
            if (Check_Internet() == false) return;
            Button_More.Visibility = System.Windows.Visibility.Hidden;
            BeginWait("Searching Top20 KPop Playlist . . .");
            Searchkey = "Top20 KPop";
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Playlist_Online = Reader_HTML.LoadTop20Albums(10);
            });
            thread.Start();
            thread.Join();
            Read_XML.Create_XML_Playlist_Online();
            Init_Control();
        }

        private void List_Playlist_Online_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BeginWait("Searching List Song in Playlist . . .");
            List_Song_Playlist_Online.Items.Clear();
            int index = List_Playlist_Online.SelectedIndex;
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Song_Playlist = ReadHTML.LoadSongFromPlaylistSelected(List_Collection.List_Playlist_Online[index]);
            });
            thread.Start();
            thread.Join();
            for (int i = 0; i < List_Collection.List_Song_Playlist.Count; i++)
            {
                ListViewItem lv = new ListViewItem();
                lv.Content = List_Collection.List_Song_Playlist[i].Name_Song;
                List_Song_Playlist_Online.Items.Add(lv);
            }
        }

        void Get_List_Song_From_Playlist(int i)
        {
            Thread thread = new Thread(delegate()
            {
                List_Collection.List_Song_Playlist = ReadHTML.LoadSongFromPlaylistSelected(List_Collection.List_Playlist_Online[i]);
            });
            thread.Start();
            thread.Join();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List_Song_Online_MouseDoubleClick(null, null);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddSong(List_Collection.List_Song_Online[List_Song_Online.SelectedIndex]);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            List_Playlist_Online_MouseDoubleClick(null, null);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Get_List_Song_From_Playlist(List_Playlist_Online.SelectedIndex);
            List_Collection.List_Song_Playlist = List_Collection.List_Song_Playlist;
            AddListSong(List_Collection.List_Song_Playlist);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            AddSong(List_Collection.List_Song_Playlist[List_Song_Playlist_Online.SelectedIndex]);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            SongClick = List_Collection.List_Song_Playlist[List_Song_Playlist_Online.SelectedIndex].Name_Song;
            Double_Song(2, List_Collection.List_Song_Playlist[List_Song_Playlist_Online.SelectedIndex]);
        }

        private void List_Song_Online_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Changed(List_Collection.List_Song_Online[List_Song_Online.SelectedIndex]);
            }
            catch
            {
            }
        }

        private void List_Song_Playlist_Online_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Changed(List_Collection.List_Song_Playlist[List_Song_Playlist_Online.SelectedIndex]);
            }
            catch
            {
            }
        }

    }
}
