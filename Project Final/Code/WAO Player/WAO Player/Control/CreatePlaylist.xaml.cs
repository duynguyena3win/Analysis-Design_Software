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
using WAO_Player.Process;

namespace WAO_Player.Control
{
    /// <summary>
    /// Interaction logic for CreatePlaylist.xaml
    /// </summary>
    public partial class CreatePlaylist : Window
    {
        public CreatePlaylist()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextBox.Text == string.Empty)
                Btn_OK.IsEnabled = false;
            else
                Btn_OK.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.DialogResult = false;
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            Class.Playlist temp = new Class.Playlist();
            temp.Name_Playlist = TextBox.Text;
            List_Collection.List_Playlist.Add(temp);
            this.DialogResult = true;
        }
    }
}
