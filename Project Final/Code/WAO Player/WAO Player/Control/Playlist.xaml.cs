using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using WAO_Player.Class;
using WAO_Player.Process;

namespace WAO_Player.Control
{
    /// <summary>
    /// Interaction logic for Playlist.xaml
    /// </summary>
    public partial class Playlist : Window
    {
        Song Song_Added = new Song();
        public Playlist(Song temp)
        {
            InitializeComponent();
            Song_Added = temp;
            List_Playlist.ItemsSource = List_Collection.List_Playlist;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void List_Playlist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List_Playlist.SelectedIndex >= 0)
                Button_OK.IsEnabled = true;
            else
                Button_OK.IsEnabled = false;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            List_Collection.List_Playlist[List_Playlist.SelectedIndex].Song_Playlist.Add(Song_Added);
            this.Close();
        }
    }
}
