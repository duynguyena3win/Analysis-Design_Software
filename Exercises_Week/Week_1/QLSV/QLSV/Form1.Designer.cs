namespace QLSV
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
            this.Button_Them = new System.Windows.Forms.Button();
            this.Button_Sua = new System.Windows.Forms.Button();
            this.Button_Xoa = new System.Windows.Forms.Button();
            this.Button_Timkiem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Text_MSSV = new System.Windows.Forms.TextBox();
            this.Text_Hoten = new System.Windows.Forms.TextBox();
            this.Text_ChNganh = new System.Windows.Forms.TextBox();
            this.Data_Grid = new System.Windows.Forms.DataGridView();
            this.Hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Them
            // 
            this.Button_Them.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Them.Location = new System.Drawing.Point(13, 13);
            this.Button_Them.Name = "Button_Them";
            this.Button_Them.Size = new System.Drawing.Size(75, 23);
            this.Button_Them.TabIndex = 0;
            this.Button_Them.Text = "Thêm";
            this.Button_Them.UseVisualStyleBackColor = true;
            this.Button_Them.Click += new System.EventHandler(this.Button_Them_Click);
            // 
            // Button_Sua
            // 
            this.Button_Sua.Location = new System.Drawing.Point(94, 13);
            this.Button_Sua.Name = "Button_Sua";
            this.Button_Sua.Size = new System.Drawing.Size(75, 23);
            this.Button_Sua.TabIndex = 0;
            this.Button_Sua.Text = "Sửa";
            this.Button_Sua.UseVisualStyleBackColor = true;
            this.Button_Sua.Click += new System.EventHandler(this.Button_Sua_Click);
            // 
            // Button_Xoa
            // 
            this.Button_Xoa.Location = new System.Drawing.Point(175, 13);
            this.Button_Xoa.Name = "Button_Xoa";
            this.Button_Xoa.Size = new System.Drawing.Size(75, 23);
            this.Button_Xoa.TabIndex = 0;
            this.Button_Xoa.Text = "Xóa";
            this.Button_Xoa.UseVisualStyleBackColor = true;
            this.Button_Xoa.Click += new System.EventHandler(this.Button_Xoa_Click);
            // 
            // Button_Timkiem
            // 
            this.Button_Timkiem.Location = new System.Drawing.Point(256, 13);
            this.Button_Timkiem.Name = "Button_Timkiem";
            this.Button_Timkiem.Size = new System.Drawing.Size(75, 23);
            this.Button_Timkiem.TabIndex = 0;
            this.Button_Timkiem.Text = "Tìm kiếm";
            this.Button_Timkiem.UseVisualStyleBackColor = true;
            this.Button_Timkiem.Click += new System.EventHandler(this.Button_Timkiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "MSSV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ Tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chuyên Ngành";
            // 
            // Text_MSSV
            // 
            this.Text_MSSV.Location = new System.Drawing.Point(101, 45);
            this.Text_MSSV.Name = "Text_MSSV";
            this.Text_MSSV.Size = new System.Drawing.Size(161, 20);
            this.Text_MSSV.TabIndex = 2;
            // 
            // Text_Hoten
            // 
            this.Text_Hoten.Location = new System.Drawing.Point(101, 73);
            this.Text_Hoten.Name = "Text_Hoten";
            this.Text_Hoten.Size = new System.Drawing.Size(161, 20);
            this.Text_Hoten.TabIndex = 3;
            // 
            // Text_ChNganh
            // 
            this.Text_ChNganh.Location = new System.Drawing.Point(101, 102);
            this.Text_ChNganh.Name = "Text_ChNganh";
            this.Text_ChNganh.Size = new System.Drawing.Size(161, 20);
            this.Text_ChNganh.TabIndex = 4;
            // 
            // Data_Grid
            // 
            this.Data_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hoten,
            this.MSSV,
            this.CN});
            this.Data_Grid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Data_Grid.Location = new System.Drawing.Point(0, 141);
            this.Data_Grid.Name = "Data_Grid";
            this.Data_Grid.Size = new System.Drawing.Size(443, 164);
            this.Data_Grid.TabIndex = 5;
            this.Data_Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_Grid_CellContentClick);
            // 
            // Hoten
            // 
            this.Hoten.DataPropertyName = "hoten";
            this.Hoten.HeaderText = "Họ và tên";
            this.Hoten.Name = "Hoten";
            this.Hoten.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Hoten.Width = 200;
            // 
            // MSSV
            // 
            this.MSSV.DataPropertyName = "mssv";
            this.MSSV.FillWeight = 80F;
            this.MSSV.HeaderText = "MSSV";
            this.MSSV.Name = "MSSV";
            this.MSSV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CN
            // 
            this.CN.DataPropertyName = "chnganh";
            this.CN.FillWeight = 150F;
            this.CN.HeaderText = "Chuyên Ngành";
            this.CN.Name = "CN";
            this.CN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 89);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 35);
            this.button2.TabIndex = 0;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(312, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Tải Dữ Liệu Gốc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 305);
            this.Controls.Add(this.Data_Grid);
            this.Controls.Add(this.Text_ChNganh);
            this.Controls.Add(this.Text_Hoten);
            this.Controls.Add(this.Text_MSSV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Button_Timkiem);
            this.Controls.Add(this.Button_Xoa);
            this.Controls.Add(this.Button_Sua);
            this.Controls.Add(this.Button_Them);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data_Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Them;
        private System.Windows.Forms.Button Button_Sua;
        private System.Windows.Forms.Button Button_Xoa;
        private System.Windows.Forms.Button Button_Timkiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Text_MSSV;
        private System.Windows.Forms.TextBox Text_Hoten;
        private System.Windows.Forms.TextBox Text_ChNganh;
        private System.Windows.Forms.DataGridView Data_Grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CN;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

