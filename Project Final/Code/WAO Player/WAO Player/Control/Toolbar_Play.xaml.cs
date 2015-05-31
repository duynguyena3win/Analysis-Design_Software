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
    /// Interaction logic for Toolbar_Play.xaml
    /// </summary>
    public partial class Toolbar_Play : UserControl
    {
        public delegate void Click();
        public delegate void Volume(double value);
        public event Click Click_Play;
        public event Click Click_Previous;
        public event Click Click_Next;
        public event Click Click_Lyric;
        public event Click Click_SameMusic;
        public event Click Click_UnsameMusic;
        public event Volume Volume_Change;
        public bool Is_Play = false;
        public Toolbar_Play()
        {
            InitializeComponent();
        }

        private void Button_Previous_Click(object sender, RoutedEventArgs e)
        {
            Click_Previous();
        }

        public void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            Click_Play();
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            Click_Next();
        }

        private void Check_SameAgain_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Check_SameAgain_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void Check_Lyric_Unchecked(object sender, RoutedEventArgs e)
        {
            Click_Lyric();
        }

        private void Check_Lyric_Checked(object sender, RoutedEventArgs e)
        {
            Click_Lyric();
        }

        private void Slider_Volumne_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Volume_Change(e.NewValue/100);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Slider_Volumne.Value = 50.0;
        }


    }
}
