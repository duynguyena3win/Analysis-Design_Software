using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace QuanLyQuanAn
{
    /// <summary>
    /// Interaction logic for OtherWork.xaml
    /// </summary>
    public partial class OtherWork : Window, INotifyPropertyChanged
    {
        string Quan;
        int Type;
        QuanAn qa = new QuanAn();

        public QuanAn NewValue
        {
            get { return qa; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Name_control
        {
            get { return Type; }
            set
            {
                Type = value;
                if (Type == 0)
                    Label_ControlName = "Thêm Quán Ăn";
                else
                    Label_ControlName = "Cập Nhật Quán";
            }
        }

        string label_ControlName;

        public string Label_ControlName
        {
            get { return label_ControlName; }
            set { label_ControlName = value; OnPropertyChanged("Label_ControlName"); }
        }
        public OtherWork(int type, string quan)
        {
            this.DataContext = this;
            InitializeComponent();
            Name_control = type;
            Quan = quan;
        }

        public OtherWork()
        {
            this.DataContext = this;
            InitializeComponent();
            Name_control = 1;
        }

        public void SetValue(QuanAn QA)
        {
            Text_Ten.Text = QA.Ten;
            Text_Duong.Text = QA.DiaDiem.Duong;
            Text_Soban.Text = QA.SoBan.ToString();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            QuanAn temp = new QuanAn();
            temp.Ten = Text_Ten.Text;
            temp.DiaDiem = new Diadiem() { Duong = Text_Duong.Text, Quan = Quan };
            temp.SoBan = Convert.ToInt32(Text_Soban.Text);
            qa = temp;
            DialogResult = true;
            Close();
        }

        void Check_Enable()
        {
            if (Text_Ten.Text != string.Empty && Text_Duong.Text != string.Empty
                && Text_Soban.Text != string.Empty)
            {
                Btn_Ok.IsEnabled = true;
                Btn_Cancel.IsEnabled = true;
            }
            else
            {
                Btn_Ok.IsEnabled = false;
                Btn_Cancel.IsEnabled = false;
            }
            
        }
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Text_Ten_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Enable();
        }

        private void Text_Duong_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Enable();
        }

        private void Text_Soban_TextChanged(object sender, TextChangedEventArgs e)
        {
            Check_Enable();
        }


    }
}
