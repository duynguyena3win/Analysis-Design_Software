namespace BT3_1112199
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.Button_Pause = new System.Windows.Forms.Button();
            this.Button_Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Text_Min = new System.Windows.Forms.TextBox();
            this.Text_Sec = new System.Windows.Forms.TextBox();
            this.Button_Clock = new System.Windows.Forms.Button();
            this.Button_Info = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(35, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button_Pause
            // 
            this.Button_Pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Pause.Location = new System.Drawing.Point(143, 152);
            this.Button_Pause.Name = "Button_Pause";
            this.Button_Pause.Size = new System.Drawing.Size(88, 32);
            this.Button_Pause.TabIndex = 0;
            this.Button_Pause.Text = "Pause";
            this.Button_Pause.UseVisualStyleBackColor = true;
            this.Button_Pause.Click += new System.EventHandler(this.Button_Pause_Click);
            // 
            // Button_Stop
            // 
            this.Button_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Stop.Location = new System.Drawing.Point(254, 152);
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Size = new System.Drawing.Size(88, 32);
            this.Button_Stop.TabIndex = 1;
            this.Button_Stop.Text = "Stop";
            this.Button_Stop.UseVisualStyleBackColor = true;
            this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minute";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Info;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "ĐỒNG HỒ ĐẾM GIÂY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Second";
            // 
            // Text_Min
            // 
            this.Text_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Min.Location = new System.Drawing.Point(112, 110);
            this.Text_Min.Name = "Text_Min";
            this.Text_Min.Size = new System.Drawing.Size(48, 23);
            this.Text_Min.TabIndex = 3;
            this.Text_Min.Text = "10";
            this.Text_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Text_Min.TextChanged += new System.EventHandler(this.Text_Min_TextChanged);
            // 
            // Text_Sec
            // 
            this.Text_Sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_Sec.Location = new System.Drawing.Point(264, 110);
            this.Text_Sec.Name = "Text_Sec";
            this.Text_Sec.Size = new System.Drawing.Size(48, 23);
            this.Text_Sec.TabIndex = 3;
            this.Text_Sec.Text = "10";
            this.Text_Sec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Button_Clock
            // 
            this.Button_Clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Clock.Location = new System.Drawing.Point(69, 209);
            this.Button_Clock.Name = "Button_Clock";
            this.Button_Clock.Size = new System.Drawing.Size(101, 31);
            this.Button_Clock.TabIndex = 1;
            this.Button_Clock.Text = "Clock";
            this.Button_Clock.UseVisualStyleBackColor = true;
            this.Button_Clock.Click += new System.EventHandler(this.Button_Clock_Click);
            // 
            // Button_Info
            // 
            this.Button_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Info.Location = new System.Drawing.Point(206, 209);
            this.Button_Info.Name = "Button_Info";
            this.Button_Info.Size = new System.Drawing.Size(101, 31);
            this.Button_Info.TabIndex = 1;
            this.Button_Info.Text = "About";
            this.Button_Info.UseVisualStyleBackColor = true;
            this.Button_Info.Click += new System.EventHandler(this.Button_Info_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BT3_1112199.Properties.Resources.Theme;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.Text_Sec);
            this.Controls.Add(this.Text_Min);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Info);
            this.Controls.Add(this.Button_Clock);
            this.Controls.Add(this.Button_Stop);
            this.Controls.Add(this.Button_Pause);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ĐỒNG HỒ ĐẾM GIÂY";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Button_Pause;
        private System.Windows.Forms.Button Button_Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Text_Min;
        private System.Windows.Forms.TextBox Text_Sec;
        private System.Windows.Forms.Button Button_Clock;
        private System.Windows.Forms.Button Button_Info;
    }
}

