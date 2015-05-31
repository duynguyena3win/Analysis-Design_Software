using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WAO_Player.Class;
using WAO_Player.Control;
using WAO_Player.Music_Online_NCT;
using WAO_Player.Process;
using WAO_Player.Video_Youtube;
namespace WAO_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window, INotifyPropertyChanged
    {
        //Các User Control của Chương trình
        Toolbar_Play UC_Toolbar_Play;    
        Tool_MME UC_Toolbar_MME;         
        Connection_Online UC_Connection_Online;
        Connection_Offline UC_Connection_Offline;
        Setting UC_Setting;
        Search_Tool UC_Search_Tool;
        MediaElement Player_Music = new MediaElement();
        Viewer ViewYoutube;
        //Các list nhạc video của chương trình

        // Biến đọc file XML, HTML
        XML Read_XML = new XML();
        ReadHTML Reader_HTML;
        
        // Biến phụ khác:
        Song NowSong_Click;
        Video NowVideo_Click;
        Song Add_Song = new Song();
        int Key_Controller;
        bool bool_Add = false;
        //string Path_Document;
        bool Is_Video = false;
        DispatcherTimer timer;
        DispatcherTimer timer2;
        
        // Các biến dùng để Binding dữ liệu:
        BitmapSource _pictureBackground;
        public BitmapSource Image_NowPlaying
        {
            
            get { return _pictureBackground; }
            set { _pictureBackground = value; OnPropertyChanged("Image_NowPlaying"); }
        }
        string _nameSong;
        public string NameOfSongPlayingNow
        {
            get { return _nameSong; }
            set
            {
                _nameSong = value;
                OnPropertyChanged("NameOfSongPlayingNow");
            }
        }

        string _nameArtist;
        public string NameOfArtistPlayingNow
        {
            get { return _nameArtist; }
            set
            {
                _nameArtist = value;
                OnPropertyChanged("NameOfArtistPlayingNow");
            }
        }

        string _lyric; // Lời của bài hát được chọn
        public string Lyric
        {
            get { return _lyric; }
            set { _lyric = value; OnPropertyChanged("Lyric"); }

        }

        string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyNaChangedme)
        {
            
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        
        /// </Collection_Offline>
        
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            Init_Binding();
        }

        private void Main_Window_Loaded(object sender, RoutedEventArgs e)
        {
            List_Collection.Init_List_Collection();
            List_Collection.Current_NowPlaying = -1;
            Init_Player();
            Init_Data_Program();
            Init_UC_Connection_Offline();
            Init_UC_Connection_Online();
            Init_UC_Toolbar_MME();
            Init_UC_Toolbar_Play();
            Init_UC_Search_Tool();
            Init_Slider_Volume();
            Init_UC_Viewer();
            UC_Connection_Offline.Init_Control();
            UC_Connection_Online.Init_Data_First();
        }
        void Release()
        {
            List_Now_Playing.Items.Clear();
            List_Collection.List_Song_Offline.Clear();
            List_Collection.List_Video_Offline.Clear();
            List_Collection.List_NowPlaying.Clear();
            List_Collection.List_Song_Search.Clear();
            List_Collection.List_Song_Online.Clear();

            UC_Connection_Offline.Clear_Data();
            UC_Connection_Offline = null;
            UC_Setting = null;
        }
        void Init_Player()
        {
            Player_Music = new MediaElement();
            Grid_MediaElement.Children.Clear();
            Grid_MediaElement.Children.Add(Player_Music);
            Player_Music.Visibility = System.Windows.Visibility.Hidden;
            Player_Music.MediaOpened += Player_Music_MediaOpened;
            Player_Music.MediaEnded += Player_Music_MediaEnded;
            Player_Music.LoadedBehavior = MediaState.Manual;
            Player_Music.UnloadedBehavior = MediaState.Manual;
            Player_Music.Stretch = Stretch.Fill;
        }
        void Init_Binding()
        {
            XmlDataProvider xmlpro = new XmlDataProvider();
            string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            xmlpro.Source = new Uri(user + "\\Documents\\WAO Player\\Infor.xml");
            // Binding of List Song
            Binding bd = new Binding();
            bd.Mode = BindingMode.TwoWay;
            bd.XPath = "/WAO_PLAYER/List_Playlist/*";
            List_Playlist.DataContext = xmlpro;
            List_Playlist.SetBinding(ListView.ItemsSourceProperty, bd);
        }

        // User Control Viewer You tube
        void Init_UC_Viewer()
        {
            ViewYoutube = new Viewer();
            Grid_Viewer.Children.Clear();
            Grid_Viewer.Children.Add(ViewYoutube);
            ViewYoutube.ClosedEvent += ViewYoutube_ClosedEvent;
        }

        void ViewYoutube_ClosedEvent(object sender, EventArgs e)
        {
            Grid_Viewer.Visibility = System.Windows.Visibility.Hidden;
        }

        // User Control Tìm kiếm
        void Init_UC_Search_Tool()
        {
            UC_Search_Tool = new Search_Tool();
            Grid_Search_Tool.Children.Clear();
            Grid_Search_Tool.Children.Add(UC_Search_Tool);
            UC_Search_Tool.Click_Search += UC_Search_Tool_Click_Search;
        }
        void Begin_Wait(string key)
        {
            Status = key;
            timer2.Start();
        }
        void End_Wait()
        {
            Status = "";
            this.Cursor = Cursors.Arrow;
        }
        void UC_Search_Tool_Click_Search(string key_search)
        {
            Begin_Wait("Searching for " + key_search + ". . .");
            
            Reader_HTML = new ReadHTML();
            if(tab.SelectedIndex == 1)
            {
                switch(TabControl_Music.SelectedIndex)
                {
                    case 0:
                        Searching_Offline(key_search);
                        UC_Connection_Offline.tab.SelectedIndex = 4;
                        break;
                    case 1:
                        switch (UC_Connection_Online.tab.SelectedIndex)
                        {
                            case 0:
                                UC_Connection_Online.Searching_Online(key_search);
                                break;
                            case 1:
                                Search_Playlist_Online(key_search);
                                break;
                            case 2:
                                Search_Video_Online(key_search);
                                break;
                        }
                        break;
                }
            }
        }        
        void Searching_Offline(string key_search)
        {
            List_Collection.List_Song_Search.Clear();
            IEnumerable<Song> temp = List_Collection.List_Song_Offline.Where(s => s.Name_Song.IndexOf(key_search) >= 0);
            foreach (Song node in temp)
            {
                List_Collection.List_Song_Search.Add(node);
            }
            UC_Connection_Offline.Set_Item_Searching();
        }

        // User Control Thanh Chơi nhạc
        void Init_UC_Toolbar_Play()
        {
            UC_Toolbar_Play = new Toolbar_Play();
            Grid_Toolbar.Children.Clear();
            Grid_Toolbar.Children.Add(UC_Toolbar_Play);
            UC_Toolbar_Play.Click_Play += UC_Toolbar_Play_Click_Play;
            UC_Toolbar_Play.Volume_Change += UC_Toolbar_Play_Volume_Change;
            UC_Toolbar_Play.Click_Next += UC_Toolbar_Play_Click_Next;
            UC_Toolbar_Play.Click_Previous += UC_Toolbar_Play_Click_Previous;
            UC_Toolbar_Play.Click_Lyric += UC_Toolbar_Play_Click_Lyric;
        }
        void UC_Toolbar_Play_Click_Lyric()
        {
            if (UC_Toolbar_Play.Check_Lyric.IsChecked == true)
            {
                Grid_Now.Visibility = System.Windows.Visibility.Hidden;
                GridLyric.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                Grid_Now.Visibility = System.Windows.Visibility.Visible;
                GridLyric.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        void UC_Toolbar_Play_Click_Previous()
        {
            if (--List_Collection.Current_NowPlaying < 0)
            {
                List_Collection.Current_NowPlaying = 0;
                if (UC_Toolbar_Play.Check_Round.IsChecked == true)
                {
                    List_Collection.Current_NowPlaying = List_Collection.List_NowPlaying.Count - 1;
                    Key_Controller = 2;
                    List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
                    Init_Open_Music(List_Collection.Get_Song_Current_ListPlay());
                    UC_Toolbar_Play_Click_Play();
                }
                return;
            }
            Player_Music.Stop();
            List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
            Init_Open_Music(List_Collection.Get_Song_Current_ListPlay());

            UC_Toolbar_Play.Is_Play = false;
            Key_Controller = 2;
            UC_Toolbar_Play_Click_Play();
        }
        void UC_Toolbar_Play_Click_Next()
        {
            if (++List_Collection.Current_NowPlaying >= List_Collection.List_NowPlaying.Count)
            {
                List_Collection.Current_NowPlaying = List_Collection.List_NowPlaying.Count - 1;
                if (UC_Toolbar_Play.Check_Round.IsChecked == true)
                {
                    List_Collection.Current_NowPlaying = 0;
                    Key_Controller = 2;
                    List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
                    Init_Open_Music(List_Collection.Get_Song_Current_ListPlay());
                    UC_Toolbar_Play_Click_Play();
                }
                return;
            }
            Player_Music.Stop();
            List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
            Init_Open_Music(List_Collection.Get_Song_Current_ListPlay());
            UC_Toolbar_Play.Is_Play = false;
            Key_Controller = 2;
            UC_Toolbar_Play_Click_Play();
        }
        void UC_Toolbar_Play_Click_Play()
        {
            //if (TabControl_Music.SelectedIndex == 0)
            //{
                if (UC_Toolbar_Play.Is_Play == false)
                {
                    Chossen_Music();
                    if (List_Collection.Current_NowPlaying == -1)
                        return;
                    UC_Toolbar_Play.Is_Play = true;
                    UC_Toolbar_Play.Button_Play.Content = ";";
                    Player_Music.Play();
                    timer.Start();
                    Key_Controller = 2;
                }
                else
                {
                    UC_Toolbar_Play.Is_Play = false;
                    UC_Toolbar_Play.Button_Play.Content = "4";
                    Player_Music.Pause();
                    Player_Music.Pause();
                    timer.Start();
                }
        }
        void UC_Toolbar_Play_Volume_Change(double value)
        {
            Player_Music.Volume = value;
        }


        // User Control Cửa sổ
        void Init_UC_Toolbar_MME()
        {
            UC_Toolbar_MME = new Tool_MME();
            Grid_Toolbar_MME.Children.Clear();
            Grid_Toolbar_MME.Children.Add(UC_Toolbar_MME);
        }
        
        // User Control Nhạc Online
        void Init_UC_Connection_Online()
        {
            UC_Connection_Online = new Connection_Online();
            Grid_Connection_Online.Children.Clear();
            Grid_Connection_Online.Children.Add(UC_Connection_Online);
            UC_Connection_Online.Select_Item_Song += UC_Connection_Online_Select_Item_Song;
            UC_Connection_Online.Select_Item_Video += UC_Connection_Online_Select_Item_Video;
            UC_Connection_Online.Double_Song += UC_Connection_Online_Double_Song;
            UC_Connection_Online.BeginWait += UC_Connection_Online_BeginWait;
            UC_Connection_Online.Double_Video += UC_Connection_Online_Double_Video;
            UC_Connection_Online.AddSong += UC_Connection_Offline_AddSong;
            UC_Connection_Online.AddListSong += UC_Connection_Online_AddListSong;
            UC_Connection_Online.Changed += UC_Connection_Offline_Changed;
            UC_Connection_Online.Add_PlaylistSong += UC_Connection_Offline_Add_PlaylistSong;
        }

        void UC_Connection_Online_AddListSong(List<Song> Output)
        {
            Add_To_List_NowPlaying(Output);
        }
        void UC_Connection_Online_Double_Video(int index,int Output)
        {
            ViewYoutube.VideoUrl = List_Collection.List_Video_Online[Output].URL;
            Grid_Viewer.Visibility = System.Windows.Visibility.Visible;
        }
        void UC_Connection_Online_BeginWait(string path)
        {
            Begin_Wait(path);
        }
        BitmapSource Init_Image(string sour)
        {
            return new BitmapImage(new Uri(sour));
        }
        void UC_Connection_Online_Double_Song(int index, Song Output)
        {
            Image_Slider.Source = Init_Image(Picture.NCT_SLIDER);
            Key_Controller = index;
            Begin_Wait("Loading Song '" + Output.Name_Song + "' . . ."); 
            int i = Check_Item(Output);

            List_Now_Playing.SelectedIndex = i;
            List_Collection.Current_NowPlaying = i;

            if (i == -1)
            {
                List_Collection.List_NowPlaying.Add(Output);                     // Thêm bài hát vào List Now Playing
                ListViewItem lvi = new ListViewItem();              //
                lvi.Content = Output.Name_Song;                  // Thêm item cho list view LNPlaying
                List_Now_Playing.Items.Add(lvi);                    //
                List_Collection.Current_NowPlaying = List_Collection.List_NowPlaying.Count - 1;
                List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
            }
            Init_Open_Music(Output);
            UC_Toolbar_Play.Is_Play = false;
            UC_Toolbar_Play_Click_Play();
        }
        void UC_Connection_Online_Select_Item_Video(int index, Video Output)
        {
            //Image_Slider.Source = Init_Image(Picture.NCT_SLIDER);
            Key_Controller = index;
            NowVideo_Click = Output;
            NowSong_Click = null;
        }
        void UC_Connection_Online_Select_Item_Song(int index, Song Output)
        {
            Image_Slider.Source = Init_Image(Picture.NCT_SLIDER);
            Key_Controller = index;
            NowSong_Click = Output;
            NowVideo_Click = null;
        }
        void Search_Video_Online(string searchkey)
        {
            if (SourceWeb.IsConnectedToInternet() == false)
            {
                MessageBox.Show("Check your connect with Internet !!!");
                return;
            }
            List_Collection.List_Video_Online = Youtube.LoadVideosKey(searchkey);
            Read_XML.Create_XML_Video_Online();
            UC_Connection_Online.Init_Control();
        }
        void Search_Playlist_Online(string searchkey)
        {
            if (SourceWeb.IsConnectedToInternet() == false)
            {
                MessageBox.Show("Check your connect with Internet !!!");
                return;
            }
            List_Collection.List_Playlist_Online = Reader_HTML.SearchPlaylists(searchkey);
            Read_XML.Create_XML_Playlist_Online();
            UC_Connection_Online.Init_Control();
        }
        
        // User Control Nhạc Offline
        void Init_UC_Connection_Offline()
        {
            UC_Connection_Offline = new Connection_Offline();
            Grid_Connection_Offline.Children.Clear();
            Grid_Connection_Offline.Children.Add(UC_Connection_Offline);
            UC_Connection_Offline.Double_Click_List_Song += UC_Connection_Offline_Double_Click_List_Song;
            UC_Connection_Offline.Double_Click_List_Video += UC_Connection_Offline_Double_Click_List_Video;
            UC_Connection_Offline.Select_Item_Song += UC_Connection_Offline_Select_Item_Song;
            UC_Connection_Offline.Select_Item_Video += UC_Connection_Offline_Select_Item_Video;
            UC_Connection_Offline.AddSong += UC_Connection_Offline_AddSong;
            UC_Connection_Offline.AddListSong += UC_Connection_Offline_AddListSong;
            UC_Connection_Offline.Changed += UC_Connection_Offline_Changed;
            UC_Connection_Offline.Add_PlaylistSong += UC_Connection_Offline_Add_PlaylistSong;
        }

        void UC_Connection_Offline_Add_PlaylistSong()
        {
            WAO_Player.Control.Playlist PL = new Control.Playlist(Add_Song);
            PL.Show();
        }

        void UC_Connection_Offline_Changed(Song Output)
        {
            if (bool_Add == true)
            {
                Add_Song = Output;
                bool_Add = false;
            }
        }

        void UC_Connection_Offline_AddListSong(List<Song> Output)
        {
            Add_To_List_NowPlaying(Output);
        }
        void UC_Connection_Offline_AddSong(Song Output)
        {
            Add_To_List_NowPlaying(Output);
        }
        void UC_Connection_Offline_Select_Item_Video(int index, Video Output)
        {
            Image_Slider.Source = Init_Image(Picture.VIDEO_SLIDER_OFFLINE);
            Key_Controller = index;
            NowVideo_Click = Output;
            NowSong_Click = null;
        }
        void UC_Connection_Offline_Select_Item_Song(int index, Song Output)
        {
            Image_Slider.Source = Init_Image(Picture.SONG_SLIDER_OFFLINE);
            Key_Controller = index;
            NowSong_Click = Output;
            NowVideo_Click = null;
        }
        void UC_Connection_Offline_Double_Click_List_Song(int index, Song Item_Song)
        {
            Image_Slider.Source = Init_Image(Picture.SONG_SLIDER_OFFLINE);
            Key_Controller = index;
            Begin_Wait("Loading Song '" + Item_Song.Name_Song + "' . . ."); 
            int i = Check_Item(Item_Song);

            List_Now_Playing.SelectedIndex = i;
            List_Collection.Current_NowPlaying = i;

            if (i == -1)
            {
                List_Collection.List_NowPlaying.Add(Item_Song);                     // Thêm bài hát vào List Now Playing
                ListViewItem lvi = new ListViewItem();              //
                lvi.Content = Item_Song.Name_Song;                  // Thêm item cho list view LNPlaying
                List_Now_Playing.Items.Add(lvi);                    //
                List_Collection.Current_NowPlaying = List_Collection.List_NowPlaying.Count - 1;
                List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
            }

            Init_Open_Music(Item_Song);
            UC_Toolbar_Play.Is_Play = false;
            UC_Toolbar_Play_Click_Play();
        }
        void UC_Connection_Offline_Double_Click_List_Video(int index, Video Item_Video)
        {
            Image_Slider.Source = Init_Image(Picture.VIDEO_SLIDER_OFFLINE);
            Begin_Wait("Loading Video '" + Item_Video.Name_Video + "' . . .");
            List_Collection.Current_NowPlaying = -2;
            Key_Controller = index;
            Init_Open_Video(Item_Video);
            UC_Toolbar_Play.Is_Play = false;
            UC_Toolbar_Play_Click_Play();
        }
        
        
        void Init_Value_Control(Song Item_Song)
        {
            if (Item_Song.Online == true)
            {
                Item_Song = ReadHTML.GetMoreSongInfo(Item_Song);
                Item_Song.Online = false;
            }
            Text_TB.Text = "";
            Slider_Time.Value = 0;
            NameOfSongPlayingNow = Item_Song.Name_Song;
            NameOfArtistPlayingNow = Item_Song.Name_Artist;
            if (Item_Song.Image_Song == null)
                Image_NowPlaying = new System.Windows.Media.Imaging.BitmapImage(new Uri(Picture.NHAC_OFFLINE));
            else
                Image_NowPlaying = new System.Windows.Media.Imaging.BitmapImage(new Uri(Item_Song.Image_Song));
            Lyric = Item_Song.Lyric_Song;
        }
        void Init_Open_Music(Song Item_Song)
        {
            UC_Toolbar_Play.Is_Play = false;
            Is_Video = false;
            Init_Value_Control(Item_Song);
            Player_Music.Source = new Uri(Item_Song.URL);
        }
        void Init_Open_Video(Video Item_Video)
        {
            Begin_Wait("Loading Video '" + Item_Video.Name_Video + "' . . .");
            UC_Toolbar_Play.Is_Play = false;
            Is_Video = true;
            Text_TB.Text = "";
            Slider_Time.Value = 0;
            Player_Music.Source = new Uri(Item_Video.URL);
        }
        void Init_Slider_Volume()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;

            timer2 = new DispatcherTimer();
            timer2.Interval = new TimeSpan(0, 0, 2);
            timer2.Tick += timer2_Tick;
        }
        void timer2_Tick(object sender, EventArgs e)
        {
            End_Wait();
            timer2.Stop();
        }
        void Init_Data_Program()
        {
            Read_XML.RemoveNode("List_Song_Online", "Song");
            Read_XML.RemoveNode("List_Searching_Offline", "Song");
            Read_XML.RemoveNode("List_Video_Online", "Video");
            Read_XML.RemoveNode("List_Playlist_Online", "Playlist");
            List_Collection.List_Song_Offline = Read_XML.Get_List_Song();
            List_Collection.List_Video_Offline = Read_XML.Get_List_Video();
            Read_XML.Init_List_Artist();
            Read_XML.Get_List_Playlist();
            this.Background = Read_XML.Set_Background();
        }
        
        void Player_Music_MediaEnded(object sender, EventArgs e)
        {
            Image_Slider.Visibility = System.Windows.Visibility.Hidden;
            if (UC_Toolbar_Play.Check_Again.IsChecked == true)
            {
                Key_Controller = 2;
                Init_Open_Music(List_Collection.Get_Song_Current_ListPlay());
                UC_Toolbar_Play_Click_Play();
                return;
            }
            
            if (++List_Collection.Current_NowPlaying >= List_Collection.List_NowPlaying.Count)
            {
                if (UC_Toolbar_Play.Check_Round.IsChecked == true)
                {
                    List_Collection.Current_NowPlaying = 0;
                    Key_Controller = 2;
                    List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
                    Init_Open_Music(List_Collection.Get_Song_Current_ListPlay());
                    UC_Toolbar_Play_Click_Play();
                }
                return;
            }
            List_Now_Playing.SelectedIndex = List_Collection.Current_NowPlaying;
            Init_Open_Music(List_Collection.Get_Song_Current_ListPlay());
            UC_Toolbar_Play_Click_Play();
        }
        void Player_Music_MediaOpened(object sender, EventArgs e)
        {
            Image_Slider.Visibility = System.Windows.Visibility.Visible;
            Player_Music.Play();
            Slider_Time.Maximum = Player_Music.NaturalDuration.TimeSpan.TotalSeconds;
        }
        

        void timer_Tick(object sender, EventArgs e)
        {
            
            string _hour, _min, _sec;
            Slider_Time.Value = Player_Music.Position.TotalSeconds;
            _hour = (Player_Music.Position.Hours < 10) ? "0" + Player_Music.Position.Hours.ToString() : Player_Music.Position.Hours.ToString();
            _min = (Player_Music.Position.Minutes < 10) ? "0" + Player_Music.Position.Minutes.ToString() : Player_Music.Position.Minutes.ToString();
            _sec = (Player_Music.Position.Seconds < 10) ? "0" + Player_Music.Position.Seconds.ToString() : Player_Music.Position.Seconds.ToString();
            Text_TB.Text = _hour + ":" + _min + ":" + _sec;
        }
        int Check_Item(Song Item)
        {
            for (int i = 0; i < List_Now_Playing.Items.Count; i++)
            {
                if (List_Collection.List_NowPlaying[i].URL == Item.URL)
                    return i;
            }
            return -1;
        }
       
        private void Slider_Time_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            timer.Start();
            int pos = Convert.ToInt32(Slider_Time.Value);
            Player_Music.Position = new TimeSpan(0, 0, pos);
        }
        private void Slider_Time_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
        }
        private void Slider_Time_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue == Slider_Time.Maximum)
            {
                Text_TB.Text = "";
                Slider_Time.Value = 0;
                NameOfArtistPlayingNow = NameOfSongPlayingNow = "";
            }
        }
        private void tab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tabs = (TabControl)sender;
            if (tabs.SelectedIndex == 0)
                Player_Music.Visibility = System.Windows.Visibility.Visible;
            else
                Player_Music.Visibility = System.Windows.Visibility.Hidden;
        }
        private void Button_Setting_Click(object sender, RoutedEventArgs e)
        {
            if (UC_Setting != null)
                return;
            UC_Setting = new Setting();
            UC_Setting.Closed += UC_Setting_Closed;
            UC_Setting.Change_Background += UC_Setting_Change_Background;
            UC_Setting.Show();
        }
        
        void UC_Setting_Change_Background(string path)
        {
            Read_XML.Save_Background(path);
            Read_XML.Set_Background();
            
        }
        void UC_Setting_Closed(object sender, EventArgs e)
        {
            Release();
            
            List_Collection.Current_NowPlaying = -1;
            Init_Data_Program();
            Init_UC_Connection_Offline();
            
        }
        private void Main_Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        void Chossen_Music()
        {
            if (Key_Controller == 1)
            {
                if (NowSong_Click != null)
                {
                    Begin_Wait("Loading Song '" + NowSong_Click.Name_Song + "' . . .");
                    Init_Open_Music(NowSong_Click);
                    int index = Check_Item(NowSong_Click);
                    if (index == -1)
                    {
                        List_Collection.List_NowPlaying.Add(NowSong_Click);
                        List_Collection.Current_NowPlaying = List_Collection.List_NowPlaying.Count - 1;
                        ListViewItem lvi = new ListViewItem();
                        lvi.Content = NowSong_Click.Name_Song;
                        List_Now_Playing.Items.Add(lvi);
                    }
                    else
                        List_Collection.Current_NowPlaying = index;
                    
                }
                if (NowVideo_Click != null)
                {
                    List_Collection.Current_NowPlaying = -2;
                    Init_Open_Video(NowVideo_Click);
                }

                UC_Toolbar_Play.Is_Play = false;
            }
        }

        private void List_Now_Playing_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Song temp = new Song();
            temp = List_Collection.GetSong_Playing(List_Now_Playing.SelectedIndex);
                        
            Begin_Wait("Loading Song '" + temp.Name_Song + "' . . .");
            Init_Open_Music(temp);
            List_Collection.Current_NowPlaying = List_Now_Playing.SelectedIndex;
            UC_Toolbar_Play_Click_Play();
        }
        private void List_Now_Playing_MouseEnter(object sender, MouseEventArgs e)
        {
            ListViewItem lv = (ListViewItem)sender;
            lv.Foreground = System.Windows.Media.Brushes.Blue;
        }
        private void List_Now_Playing_MouseLeave(object sender, MouseEventArgs e)
        {
            ListViewItem lv = (ListViewItem)sender;
            lv.Foreground = System.Windows.Media.Brushes.Yellow;
        }
        private void List_Now_Playing_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NowSong_Click = List_Collection.GetSong_Playing(List_Now_Playing.SelectedIndex);
            NowVideo_Click = null;
            Key_Controller = 1;
        }
      
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List_Now_Playing_MouseDoubleClick(null, null);
        }
        void Add_To_List_NowPlaying(Song s)
        {
            if (s != null)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Content = s.Name_Song;
                List_Collection.List_NowPlaying.Add(s);
                List_Now_Playing.Items.Add(lvi);
            }
        }

        void Add_To_List_NowPlaying(List<Song> l_s)
        {
            for (int i = 0; i < l_s.Count; i++)
            {
                if (l_s != null)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Content = l_s[i].Name_Song;
                    List_Now_Playing.Items.Add(lvi);
                }
            }
            List_Collection.AddListSongNowPlaying(l_s);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            int index = List_Now_Playing.SelectedIndex;
            if (index < 0 || index > List_Now_Playing.Items.Count)
                return;
            List_Now_Playing.Items.RemoveAt(index);
            List_Collection.List_NowPlaying.RemoveAt(index);
        }

        private void List_Song_Playlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Add_To_List_NowPlaying(List_Collection.List_Playlist[List_Playlist.SelectedIndex].Song_Playlist[List_Song_Playlist.SelectedIndex]);
            Song temp = new Song();
            temp = List_Collection.GetSong_Playing(List_Collection.List_NowPlaying.Count - 1);

            Begin_Wait("Loading Song '" + temp.Name_Song + "' . . .");
            Init_Open_Music(temp);
            List_Collection.Current_NowPlaying = List_Now_Playing.SelectedIndex;
            UC_Toolbar_Play_Click_Play();
        }

        private void List_Playlist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void List_Playlist_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            List_Song_Playlist.ItemsSource = List_Collection.List_Playlist[List_Playlist.SelectedIndex].Song_Playlist;

        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Add_To_List_NowPlaying(List_Collection.List_Playlist[List_Playlist.SelectedIndex].Song_Playlist[List_Song_Playlist.SelectedIndex]);
        }


        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            UC_Connection_Offline_Add_PlaylistSong();
        }

        private void List_Now_Playing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (bool_Add == true)

                Add_Song = List_Collection.List_NowPlaying[List_Now_Playing.SelectedIndex];
        }


        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            List_Collection.List_Playlist[List_Playlist.SelectedIndex].Song_Playlist.RemoveAt(List_Song_Playlist.SelectedIndex);
            List_Song_Playlist.ItemsSource = null;
            List_Song_Playlist.Items.Clear();
            List_Song_Playlist.ItemsSource = List_Collection.List_Playlist[List_Playlist.SelectedIndex].Song_Playlist;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Song temp = new Song();
            List_Collection.List_NowPlaying.Add(List_Collection.List_Playlist[List_Playlist.SelectedIndex].Song_Playlist[List_Song_Playlist.SelectedIndex]);
            temp = List_Collection.List_NowPlaying[List_Collection.List_NowPlaying.Count - 1];
            
            Begin_Wait("Loading Song '" + temp.Name_Song + "' . . .");
            Init_Open_Music(temp);
            ListViewItem lvi = new ListViewItem();             
            lvi.Content = temp.Name_Song;      
            List_Now_Playing.Items.Add(lvi);
            List_Now_Playing.SelectedIndex = List_Now_Playing.Items.Count - 1;
            List_Collection.Current_NowPlaying = List_Now_Playing.SelectedIndex;
            UC_Toolbar_Play_Click_Play();
        }

        private void Main_Window_Closed(object sender, EventArgs e)
        {
            Read_XML.Create_XML_Playlist();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            List_Collection.List_Playlist.RemoveAt(List_Playlist.SelectedIndex);
            Read_XML.Create_XML_Playlist();
            Init_Binding();
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            CreatePlaylist CPL = new CreatePlaylist();
            if (CPL.ShowDialog() == true)
            {
                Read_XML.Create_XML_Playlist();
                Init_Binding();
            }
        }
    }
}
