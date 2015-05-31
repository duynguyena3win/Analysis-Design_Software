namespace BT3_1112199
{
    partial class Clock
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Clock));
            this.Pic_Min_F = new System.Windows.Forms.PictureBox();
            this.Pic_MiliSec_F = new System.Windows.Forms.PictureBox();
            this.Pic_Sec_S = new System.Windows.Forms.PictureBox();
            this.Pic_Sec_F = new System.Windows.Forms.PictureBox();
            this.Pic_Min_S = new System.Windows.Forms.PictureBox();
            this.Pic_MiliSec_S = new System.Windows.Forms.PictureBox();
            this.List_Image = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.System_Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Min_F)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MiliSec_F)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Sec_S)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Sec_F)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Min_S)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MiliSec_S)).BeginInit();
            this.SuspendLayout();
            // 
            // Pic_Min_F
            // 
            this.Pic_Min_F.Location = new System.Drawing.Point(3, 4);
            this.Pic_Min_F.Name = "Pic_Min_F";
            this.Pic_Min_F.Size = new System.Drawing.Size(32, 32);
            this.Pic_Min_F.TabIndex = 0;
            this.Pic_Min_F.TabStop = false;
            // 
            // Pic_MiliSec_F
            // 
            this.Pic_MiliSec_F.Location = new System.Drawing.Point(189, 4);
            this.Pic_MiliSec_F.Name = "Pic_MiliSec_F";
            this.Pic_MiliSec_F.Size = new System.Drawing.Size(32, 32);
            this.Pic_MiliSec_F.TabIndex = 1;
            this.Pic_MiliSec_F.TabStop = false;
            // 
            // Pic_Sec_S
            // 
            this.Pic_Sec_S.Location = new System.Drawing.Point(134, 4);
            this.Pic_Sec_S.Name = "Pic_Sec_S";
            this.Pic_Sec_S.Size = new System.Drawing.Size(32, 32);
            this.Pic_Sec_S.TabIndex = 2;
            this.Pic_Sec_S.TabStop = false;
            // 
            // Pic_Sec_F
            // 
            this.Pic_Sec_F.Location = new System.Drawing.Point(96, 4);
            this.Pic_Sec_F.Name = "Pic_Sec_F";
            this.Pic_Sec_F.Size = new System.Drawing.Size(32, 32);
            this.Pic_Sec_F.TabIndex = 3;
            this.Pic_Sec_F.TabStop = false;
            // 
            // Pic_Min_S
            // 
            this.Pic_Min_S.Location = new System.Drawing.Point(41, 4);
            this.Pic_Min_S.Name = "Pic_Min_S";
            this.Pic_Min_S.Size = new System.Drawing.Size(32, 32);
            this.Pic_Min_S.TabIndex = 4;
            this.Pic_Min_S.TabStop = false;
            // 
            // Pic_MiliSec_S
            // 
            this.Pic_MiliSec_S.Location = new System.Drawing.Point(227, 4);
            this.Pic_MiliSec_S.Name = "Pic_MiliSec_S";
            this.Pic_MiliSec_S.Size = new System.Drawing.Size(32, 32);
            this.Pic_MiliSec_S.TabIndex = 5;
            this.Pic_MiliSec_S.TabStop = false;
            // 
            // List_Image
            // 
            this.List_Image.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("List_Image.ImageStream")));
            this.List_Image.TransparentColor = System.Drawing.Color.Transparent;
            this.List_Image.Images.SetKeyName(0, "0.png");
            this.List_Image.Images.SetKeyName(1, "1.png");
            this.List_Image.Images.SetKeyName(2, "2.png");
            this.List_Image.Images.SetKeyName(3, "3.png");
            this.List_Image.Images.SetKeyName(4, "4.png");
            this.List_Image.Images.SetKeyName(5, "5.png");
            this.List_Image.Images.SetKeyName(6, "6.png");
            this.List_Image.Images.SetKeyName(7, "7.png");
            this.List_Image.Images.SetKeyName(8, "8.png");
            this.List_Image.Images.SetKeyName(9, "9.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(166, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(73, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = ":";
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // System_Timer
            // 
            this.System_Timer.Interval = 1000;
            this.System_Timer.Tick += new System.EventHandler(this.System_Timer_Tick);
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pic_MiliSec_S);
            this.Controls.Add(this.Pic_Min_S);
            this.Controls.Add(this.Pic_Sec_F);
            this.Controls.Add(this.Pic_Sec_S);
            this.Controls.Add(this.Pic_MiliSec_F);
            this.Controls.Add(this.Pic_Min_F);
            this.Name = "Clock";
            this.Size = new System.Drawing.Size(263, 39);
            this.Load += new System.EventHandler(this.Clock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Min_F)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MiliSec_F)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Sec_S)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Sec_F)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Min_S)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_MiliSec_S)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pic_Min_F;
        private System.Windows.Forms.PictureBox Pic_MiliSec_F;
        private System.Windows.Forms.PictureBox Pic_Sec_S;
        private System.Windows.Forms.PictureBox Pic_Sec_F;
        private System.Windows.Forms.PictureBox Pic_Min_S;
        private System.Windows.Forms.PictureBox Pic_MiliSec_S;
        private System.Windows.Forms.ImageList List_Image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer System_Timer;
        public System.Windows.Forms.Timer Timer;
    }
}
