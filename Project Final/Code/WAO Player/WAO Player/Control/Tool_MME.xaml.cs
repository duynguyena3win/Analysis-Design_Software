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
    /// Interaction logic for Tool_MME.xaml
    /// </summary>
    public partial class Tool_MME : UserControl
    {
        public delegate void Close();
        public event Close Close_Window;
        public Tool_MME()
        {
            InitializeComponent();
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void max_Click(object sender, RoutedEventArgs e)
        {
            if (max.Content != "2")
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
                max.Content = "2";
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
                max.Content = "1";
            }
        }
    }
}
