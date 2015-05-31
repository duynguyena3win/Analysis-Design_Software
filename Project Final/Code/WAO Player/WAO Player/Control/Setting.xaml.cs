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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Windows.Forms;
using WAO_Player.Process;

namespace WAO_Player.Control
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting
    {
        XML Read_XML = new XML();
        public delegate void Set_Background(string path);
        public event Set_Background Change_Background;

        public Setting()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Get_Folder_XML();
        }
        void Get_Folder_XML()
        {
            List<String> List = new List<string>();
            List = Read_XML.Get_Folder_XML();
            for (int i = 0; i < List.Count; i++)
            {
                System.Windows.Controls.ListViewItem tb = Create_ItemList(List[i]);
                List_Folder.Items.Add(tb);
            }
        }

        System.Windows.Controls.ListViewItem Create_ItemList(string Text)
        {
            System.Windows.Controls.ListViewItem temp = new System.Windows.Controls.ListViewItem();
            temp.Foreground = Brushes.Blue;
            temp.Content = Text;
            return temp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Read_XML.Save_Folder(List_Folder);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.Controls.ListViewItem tb = Create_ItemList(fbd.SelectedPath);
                List_Folder.Items.Add(tb);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (List_Folder.SelectedIndex < 0)
                return;
            List_Folder.Items.Remove(List_Folder.Items[List_Folder.SelectedIndex]);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All File|*.*|PNG File|*.png|BMP File|*.bmp|JPG File|*.jpg";
            ofd.Title = "Chossen BackGround Image";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage SourceImage = new BitmapImage();
                SourceImage.BeginInit();
                SourceImage.UriSource = new Uri(ofd.FileName);
                SourceImage.EndInit();
                Image_Back.Source = SourceImage;
                Border_Back.Visibility = System.Windows.Visibility.Hidden;
                Change_Background(ofd.FileName);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Border_Back.Visibility = System.Windows.Visibility.Visible;
            Change_Background(null);
        }
    }
}
