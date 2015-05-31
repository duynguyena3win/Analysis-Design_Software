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

namespace WAO_Player.Control
{
    /// <summary>
    /// Interaction logic for Search_Tool.xaml
    /// </summary>
    public partial class Search_Tool : UserControl
    {
        public delegate void Click(string ley_search);
        public event Click Click_Search;
        public string Text_Search;
        public Search_Tool()
        {
            InitializeComponent();
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Search.Text != null)
            {
                Text_Search = TextBox_Search.Text;
                Click_Search(TextBox_Search.Text);
            }
        }
    }
}
