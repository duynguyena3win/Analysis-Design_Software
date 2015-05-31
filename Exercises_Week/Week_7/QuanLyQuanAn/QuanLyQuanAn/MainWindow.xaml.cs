using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyQuanAn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(Init_Data())
                Init_For_ComboBox();
        }

        bool Init_Data()
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Title = "CHỌN FILE DỮ LIỆU";
            ofd.Filter = "XML Data|*.xml";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataXML.Path_Data = ofd.FileName;
                return true;
            }
            return false;
        }

        void Init_For_ComboBox()
        {
            List<string> Item_Combo = new List<string>();
            Item_Combo = DataXML.Read_DataXML();
            for (int i=0; i < Item_Combo.Count; i++)
            {
                Cb_Quan.Items.Add(Item_Combo[i]);
            }
        }

        void Set_Result_ListView(string key)
        {
            List<QuanAn> LQA = DataXML.Read_QuanAn_XML(key);
            Binding bd = new Binding();
            string xpath = string.Format("/QLQA/QUANAN[@Quan='{0}']", key);
            bd.XPath = xpath;
            List_Quan.DataContext = ContentData();
            List_Quan.SetBinding(ListView.ItemsSourceProperty, bd);
        }
        XmlDataProvider ContentData()
        {
            XmlDataProvider temp = new XmlDataProvider();
            temp.Source = new Uri(DataXML.Path_Data);
            return temp;
        }

        private void Cb_Quan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox temp = (ComboBox)sender;
            Set_Result_ListView((string)temp.SelectedItem);
            Btn_Remove.IsEnabled = true;
            Btn_Update.IsEnabled = true;
        }

        private void List_Quan_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            OtherWork OW = new OtherWork(0, (string)Cb_Quan.SelectedItem);
            if (OW.ShowDialog() == true)
            {
                DataXML.Add_Node_Data(OW.NewValue);
                MessageBox.Show("Thêm quán thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Set_Result_ListView((string)Cb_Quan.SelectedItem);
            }
            else
                MessageBox.Show("Thêm quán không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn xóa quán này ko?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                DataXML.Remove(List_Quan.SelectedIndex,(string) Cb_Quan.SelectedItem);
                Set_Result_ListView((string)Cb_Quan.SelectedItem);
            }

        }

        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            OtherWork OW = new OtherWork();
            QuanAn QA = new QuanAn();
            QA = DataXML.Get_Node_Data(List_Quan.SelectedIndex, (string)Cb_Quan.SelectedItem);
            OW.SetValue(QA);
            if (OW.ShowDialog() == true)
            {
                DataXML.Update_Data(QA, OW.NewValue);
                MessageBox.Show("Cập nhật quán thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                Set_Result_ListView((string)Cb_Quan.SelectedItem);
            }
            else
                MessageBox.Show("Cập nhật quán không thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
