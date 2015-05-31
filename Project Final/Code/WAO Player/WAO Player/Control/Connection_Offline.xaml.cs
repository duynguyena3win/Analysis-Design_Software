using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using TagLib;
using WAO_Player.Class;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Resources;
using System.ComponentModel;
using WAO_Player.Process;

namespace WAO_Player.Control
{
    /// <summary>
    /// Interaction logic for Connection_Offline.xaml
    /// </summary>
    public partial class Connection_Offline : UserControl, INotifyPropertyChanged
    {
        XML Read_XML = new XML();

        
        // Current Index in List Song of Artist
        int Current_Index_Artist = -1;

        public delegate void Double_Click_Song(int index, Song Item_Song);
        public delegate void Double_Click_Video(int index, Video Item_Video);

        public delegate void Event_Click_Song(int index, Song Output);
        public delegate void Event_Click_Video(int index, Video Output);
        
        public delegate void MenuItemClick_AddSong(Song Output);
        public event MenuItemClick_AddSong AddSong;

        public event Event_Click_Song Select_Item_Song;
        public event Event_Click_Video Select_Item_Video;

        public event Double_Click_Song Double_Click_List_Song;
        public event Double_Click_Video Double_Click_List_Video;

        public delegate void MenuItemClick_AddListSong(List<Song> Output);
        public event MenuItemClick_AddListSong AddListSong;

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void Change_Song(Song Output);
        public event Change_Song Changed;

        public delegate void Add_Playlist();
        public event Add_Playlist Add_PlaylistSong;

        public Connection_Offline()
        {
            InitializeComponent();
            this.DataContext = this;
            Init_Control();
            List_Collection.List_Artist_Offline = Read_XML.Get_List_Artist();

        }

        public void Init_Control()
        {
            XmlDataProvider xmlpro = new XmlDataProvider();
            string user = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            xmlpro.Source = new Uri(user + "\\Documents\\WAO Player\\Infor.xml");
            // Binding of List Song
            Binding bd = new Binding();
            bd.Mode = BindingMode.TwoWay;
            bd.XPath = "/WAO_PLAYER/List_Song_Offline/*";
            List_Song.DataContext = xmlpro;
            List_Song.SetBinding(ListView.ItemsSourceProperty, bd);
            
            // Binding of List Artist
            Binding bd1 = new Binding();
            bd1.Mode = BindingMode.TwoWay;
            bd1.XPath = "/WAO_PLAYER/List_Artist_Offline/*";
            List_Aritist.DataContext = xmlpro;
            List_Aritist.SetBinding(ListView.ItemsSourceProperty, bd1);

            // Binding of List Video
            Binding bd2 = new Binding();
            bd2.Mode = BindingMode.TwoWay;
            bd2.XPath = "/WAO_PLAYER/List_Video_Offline/*";
            List_Video.DataContext = xmlpro;
            List_Video.SetBinding(ListView.ItemsSourceProperty, bd2);
            
        }

        public void Set_Item_Searching()
        {
            List_Search.ItemsSource = null;
            List_Search.Items.Clear();
            List_Search.ItemsSource = List_Collection.List_Song_Search;
        }

        public void Clear_Data()
        {
            List_Collection.List_Song_Offline.Clear();
            List_Collection.List_Video_Offline.Clear();
            List_Collection.List_Artist_Offline.Clear();
        }
        
        private void TabItem_Song_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        // Double Click vào danh sách các bài hát
        private void List_Song_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Double_Click_List_Song(2,List_Collection.List_Song_Offline[List_Song.SelectedIndex]);
        }

        private void List_Song_Artist_MouseEnter(object sender, MouseEventArgs e)
        {
            ListViewItem lv = (ListViewItem)sender;
            lv.Foreground = Brushes.Blue;
        }

        private void List_Song_Artist_MouseLeave(object sender, MouseEventArgs e)
        {
            ListViewItem lv = (ListViewItem)sender;
            lv.Foreground = Brushes.YellowGreen;
        }

        // Double Click vào danh sách bài hát của nghệ sĩ
        private void List_Song_Artist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Current_Index_Artist >= 0)
                Double_Click_List_Song(2,List_Collection.List_Artist_Offline[Current_Index_Artist].List_Song_Artist[List_Song_Artist.SelectedIndex]);
        }

        // Double Click vào danh sách các nghệ sĩ
        private void List_Aritist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Current_Index_Artist = List_Aritist.SelectedIndex;
            List_Song_Artist.DataContext = List_Collection.List_Artist_Offline[Current_Index_Artist].List_Song_Artist;
            Total_Song.Text = "Total Song: " + List_Collection.List_Artist_Offline[Current_Index_Artist].List_Song_Artist.Count;
        }

        // Double Click vào danh sách các video
        private void List_Video_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Double_Click_List_Video(2, List_Collection.List_Video_Offline[List_Video.SelectedIndex]);
        }

        //Click vào danh sách các bài hát
        private void List_Song_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Select_Item_Song(1, List_Collection.List_Song_Offline[List_Song.SelectedIndex]);
        }

        //Click vào danh sách các video
        private void List_Video_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Select_Item_Video(1, List_Collection.List_Video_Offline[List_Video.SelectedIndex]);
        }

        //Click vào danh sách nghệ sĩ
        private void List_Aritist_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }


        // Click vào danh sách bài hát của nghệ sĩ
        private void List_Song_Artist_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (List_Aritist.SelectedIndex < 0)
                return;
            Select_Item_Song(1,List_Collection.List_Artist_Offline[List_Aritist.SelectedIndex].List_Song_Artist[List_Song_Artist.SelectedIndex]);
        }

        // Click vào danh sách các bài hát trong Search
        private void List_Search_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Select_Item_Song(1, List_Collection.List_Song_Search[List_Search.SelectedIndex]);
        }

        // Double CLick vào danh sách các bài hát trong Search
        private void List_Search_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Double_Click_List_Song(2, List_Collection.List_Song_Search[List_Search.SelectedIndex]);
        }

        // Menu Item click Play this song
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Select_Item_Song(1, List_Collection.List_Song_Offline[List_Song.SelectedIndex]);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AddSong(List_Collection.List_Song_Offline[List_Song.SelectedIndex]);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            List_Video_MouseDoubleClick(null, null);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            List_Aritist_MouseDoubleClick(null, null);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
           // AddListSong(List_Collection.List_Artist_Offline[List_Aritist.SelectedIndex].List_Song_Artist);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Add_PlaylistSong();
        }

        private void List_Song_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Changed(List_Collection.List_Song_Offline[List_Song.SelectedIndex]);
        }

        private void List_Song_Artist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Changed(List_Collection.List_Artist_Offline[List_Aritist.SelectedIndex].List_Song_Artist[List_Song_Artist.SelectedIndex]);
        }

        private void List_Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Changed(List_Collection.List_Song_Search[List_Search.SelectedIndex]);
        }
    }
}
