using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT3_1112199
{
    public partial class Clock : UserControl
    {
        int Min;
        int Sec;
        int MiliSec;

        public bool boolPause = false;
        bool boolStart = false;
        bool End_Time = false;
        bool System_clock = false;

        public delegate void Clock_Xyly();

        public event Clock_Xyly Clock_Handler;

        public Clock()
        {
            InitializeComponent();
            Init_Clock();
            Min = Sec = 10;
            MiliSec = 99;
            
        }

        public int Minute
        {
            get
            {
                return Min;
            }
            set
            {
                if (value < 0)
                    Min += 0;
                else
                    if (value > 99)
                        Min = 99;
                    else
                        Min += value;
            }
        }

        public int Second
        {
            get
            {
                return Sec;
            }
            set
            {
                if (value < 0)
                    Sec = 0;
                else
                    if (value > 60)
                    {
                        Min += Sec / 60;
                        Sec = Sec % 60;
                    }
                    else
                        Sec = value;
            }
        }

        public int Set_Time(int min, int sec)
        {

            if (min < 0 || sec < 0)
            {
                MessageBox.Show("Nhập thời gian không hợp lệ!");
                return 0;
            }
            Fix_Time(min,sec);
            Update_Clock();
            return 1;
        }

        public void System_Clock()
        {
            System_clock = true;
            System_Timer.Start();
        }

        public void Start()
        {
            Timer.Start();
            System_Timer.Start();
            System_clock = false;
            boolStart = true;
        }

        public void Pause()
        {
            if (boolPause == false && boolStart == true)
            {
                Timer.Stop();
                boolPause = true;
            }
            else
                if (boolStart == true)
                {
                    boolPause = false;
                    Timer.Start();
                }
        }

        public void Stop()
        {
            Timer.Stop();
            boolStart = false;
            Init_Clock();
        }

        void Update_Clock()
        {
            Pic_MiliSec_S.Image = List_Image.Images[MiliSec % 10];
            Pic_MiliSec_F.Image = List_Image.Images[MiliSec / 10];

            Pic_Sec_S.Image = List_Image.Images[Sec % 10];
            Pic_Sec_F.Image = List_Image.Images[Sec / 10];

            Pic_Min_S.Image = List_Image.Images[Min % 10];
            Pic_Min_F.Image = List_Image.Images[Min / 10];
        }

        void Fix_Time(int min, int sec)
        {
            Sec = sec % 60;
            int o_min = sec / 60;
            Min = (min + o_min) % 100;
            
        }

        void Update_Time()
        {
            
            if (End_Time == true)
                return;
            if (--MiliSec < 0 )
            {
                if (--Sec < 0)
                {
                    if (--Min < 0)
                    {
                        Min = 0;
                        Timer.Stop();
                        End_Time = true;
                    }
                    if (End_Time == true)
                        Sec = 0;
                    else
                        Sec = 60;
                }
                if (End_Time == true)
                    MiliSec = 0;
                else
                    MiliSec = 99;
            }

        }

        void Init_Clock()
        {
            Min = Sec = MiliSec = 0;
            Pic_Min_F.Image = Pic_Min_S.Image = Pic_Sec_F.Image = Pic_Sec_S.Image = Pic_MiliSec_F.Image = Pic_MiliSec_S.Image = List_Image.Images[0];
        }

        private void Clock_Load(object sender, EventArgs e)
        {

        
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Update_Time();
            Update_Clock();
            if (boolStart == true && Min == 0 && Sec == 0 && MiliSec == 0 && End_Time == true)
            {
                Clock_Handler();
                End_Time = false;
            }
            
        }

        private void System_Timer_Tick(object sender, EventArgs e)
        {
            if (System_clock == true)
            {
                Pic_MiliSec_S.Image = List_Image.Images[DateTime.Now.Second % 10];
                Pic_MiliSec_F.Image = List_Image.Images[DateTime.Now.Second / 10];

                Pic_Sec_S.Image = List_Image.Images[DateTime.Now.Minute % 10];
                Pic_Sec_F.Image = List_Image.Images[DateTime.Now.Minute / 10];

                Pic_Min_S.Image = List_Image.Images[DateTime.Now.Hour % 10];
                Pic_Min_F.Image = List_Image.Images[DateTime.Now.Hour / 10];
            }
        }


    }
}
