using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BT3_1112199
{
    public partial class Form1 : Form
    {
        Clock myClock = new Clock();
        bool Pause_click = false;
        SoundPlayer music;
        public Form1()
        {
            InitializeComponent();
            myClock.Parent = this;
            myClock.Location = new Point(65, 50);
            myClock.Clock_Handler += new Clock.Clock_Xyly(Xu_ly);
            music = new SoundPlayer(Properties.Resources.Audio);
        }

        void Xu_ly()
        {
            music.Play();
            if (MessageBox.Show("Hết giờ!") == System.Windows.Forms.DialogResult.OK)
                music.Stop();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Button_Pause.Enabled = Button_Stop.Enabled = false;
            
        }

        void Check_Textbox()
        {
            if (Text_Min.Text == "")
                Text_Min.Text = "00";
            if (Text_Sec.Text == "")
                Text_Sec.Text = "00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check_Textbox();
            Button_Pause.Text = "Pause";
            Pause_click = myClock.boolPause = false;
            if (Check_Time() == 1)
            {
                if (myClock.Set_Time(Convert.ToInt32(Text_Min.Text), Convert.ToInt32(Text_Sec.Text)) == 1)
                {
                    myClock.Start();
                    Button_Pause.Enabled = Button_Stop.Enabled = true;
                }
                else
                {
                    Text_Min.Text = Text_Sec.Text = "1";
                }
            }
        }

        int Check_Time()
        {
            int i = 0, j=0;
            try 
            {
                i = Convert.ToInt32(Text_Min.Text);
                j = Convert.ToInt32(Text_Min.Text);
            }
            catch
            {
                MessageBox.Show("Nhập thời gian không hợp lệ!");
                return 0;
            }
            return 1;
        }
        private void Button_Stop_Click(object sender, EventArgs e)
        {
            myClock.Stop();
            Text_Min.Text = Text_Sec.Text = "00";
        }

        private void Button_Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nguyễn Duy Nguyên - 1112199", "Information");
        }

        private void Button_Clock_Click(object sender, EventArgs e)
        {
            myClock.System_Clock();
        }

        private void Text_Min_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Button_Pause_Click(object sender, EventArgs e)
        {
            if (Pause_click == false)
            {
                Button_Pause.Text = "Resume";
                Pause_click = true;
            }
            else
            {
                Button_Pause.Text = "Pause";
                Pause_click = false;
            }

            myClock.Pause();
        }
    }
}
