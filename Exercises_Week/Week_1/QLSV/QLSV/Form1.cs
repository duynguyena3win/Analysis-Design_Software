using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLSV
{
    public partial class Form1 : Form
    {
        SqlConnection Connection;
        DataSet DS;
        SqlDataAdapter DA;
        string Connect_String = "Data Source=DUYNGUYEN-PC\\SQLEXPRESS; Initial Catalog=QLSV; Integrated Security=true";
        bool Bool_Them = true;
        bool Bool_Sua = true;
        bool Bool_Tim = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            Connection = new SqlConnection(Connect_String);
            Load_Data();
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void Lock_Text()
        {
            Text_Hoten.Enabled = false;
            Text_MSSV.Enabled = false;
            Text_ChNganh.Enabled = false;
        }

        public void Unlock_Text()
        {
            Text_Hoten.Enabled = true;
            Text_MSSV.Enabled = true;
            Text_ChNganh.Enabled = true;
        }

        private void Load_Data()
        {

            string query = "select * from SinhVien";
            DS = new DataSet();
            Lock_Text();
            try
            {
                
                Connection.Open();
                DA = new SqlDataAdapter(query, Connection);
                DA.Fill(DS, "SinhVien");
                Data_Grid.DataSource = DS.Tables["SinhVien"];

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (Connection != null)
                    Connection.Close();
            }
        }

        private void Button_Them_Click(object sender, EventArgs e)
        {

            if(Bool_Them == false)
            {
                Connection.Open();
                string Insert_String = "insert int SinhVien values (N'" + Text_Hoten.Text 
                    + "',N'" + Text_MSSV.Text + "',N'" + Text_ChNganh.Text + "')";
                SqlCommand Insert_Command = new SqlCommand(Insert_String, Connection);
                Insert_Command.ExecuteNonQuery();

                Insert_Command.Parameters.Add("Hoten", SqlDbType.NVarChar, 30);
                Insert_Command.Parameters.Add("MSSV", SqlDbType.Int);
                Insert_Command.Parameters.Add("CN", SqlDbType.NVarChar, 20);

                Insert_Command.Parameters["Hoten"].Value = Text_Hoten.Text;
                Insert_Command.Parameters["MSSV"].Value = Convert.ToInt32(Text_MSSV.Text);
                Insert_Command.Parameters["CN"].Value = Text_ChNganh.Text;

                
                // Config Button
                Button_Them.Text = "Thêm";
                Button_Sua.Enabled = true;
                Button_Timkiem.Enabled = true;
                Button_Xoa.Enabled = true;
                Load_Data();
                Lock_Text();
                Bool_Them = true;
                //

                Connection.Close();
            }
            else
            {
                Button_Sua.Enabled = false;
                Button_Timkiem.Enabled = false;
                Button_Xoa.Enabled = false;
                Button_Them.Text = "Lưu";
                Bool_Them = false;
                Unlock_Text();
            }
            
        }

        private void Data_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            Text_Hoten.Text = Data_Grid.Rows[dong].Cells[0].Value.ToString();
            Text_MSSV.Text = Data_Grid.Rows[dong].Cells[1].Value.ToString();
            Text_ChNganh.Text = Data_Grid.Rows[dong].Cells[2].Value.ToString();
        }

        private void Button_Sua_Click(object sender, EventArgs e)
        {
            if (Bool_Sua == false)
            {
                Connection.Open();
                string Sua_String = "UPDATE	SinhVien set hoten = N'" + Text_Hoten.Text + "', chnganh = N'"
                    + Text_ChNganh.Text + "' WHERE mssv = " + Text_MSSV.Text;
                SqlCommand Sua_Command = new SqlCommand(Sua_String, Connection);
                if (Connection == null)
                    MessageBox.Show("NULL");
                Sua_Command.ExecuteNonQuery();
                Connection.Close();

                Bool_Sua = true;
                Button_Them.Enabled = true;
                Button_Timkiem.Enabled = true;
                Button_Xoa.Enabled = true;
                Button_Sua.Text = "Sửa";
                Lock_Text();
                Load_Data();
                Connection.Close();
            }
            else
            {
                Unlock_Text();
                Button_Sua.Text = "Lưu";
                Button_Them.Enabled = false;
                Button_Timkiem.Enabled = false;
                Button_Xoa.Enabled = false;
                Bool_Sua = false;
            }
        }

        private void Button_Xoa_Click(object sender, EventArgs e)
        {
            Connection.Open();
            string Sua_String = "delete from SinhVien where mssv = " + Text_MSSV.Text;
            SqlCommand Sua_Command = new SqlCommand(Sua_String, Connection);
            
            Sua_Command.ExecuteNonQuery();
            Connection.Close();
            Load_Data();
        }

        private void Button_Timkiem_Click(object sender, EventArgs e)
        {
            string query;
            if (Bool_Tim == false)
            {
                if (Text_ChNganh.Text != "" && Text_Hoten.Text != "" && Text_MSSV.Text != "")
                {
                    query = "select * from SinhVien where hoten = N'" + Text_Hoten.Text
                        + "' and mssv =" + Text_MSSV.Text + " and chnganh = N'" + Text_ChNganh.Text + "'";
                }
                else
                    if (Text_Hoten.Text != "" && Text_MSSV.Text != "")
                    {
                        query = "select * from SinhVien where hoten = N'" + Text_Hoten.Text
                            + "' and mssv =" + Text_MSSV.Text;
                    }
                    else
                        if (Text_ChNganh.Text != "" && Text_Hoten.Text != "")
                        {
                            query = "select * from SinhVien where hoten = N'" + Text_Hoten.Text
                                + "' and chnganh = N'" + Text_ChNganh.Text + "'";
                        }
                        else
                            if (Text_ChNganh.Text != "" && Text_MSSV.Text != "")
                            {
                                query = "select * from SinhVien where  mssv =" + Text_MSSV.Text + " and chnganh = N'" + Text_ChNganh.Text + "'";
                            }
                            else
                                if (Text_ChNganh.Text != "")
                                {
                                    query = "select * from SinhVien where chnganh = N'" + Text_ChNganh.Text + "'";
                                }
                                else
                                    if (Text_Hoten.Text != "")
                                    {
                                        query = "select * from SinhVien where hoten = N'" + Text_Hoten.Text + "'";
                                    }
                                    else
                                        query = "select * from SinhVien where  mssv =" + Text_MSSV.Text;

                DS = new DataSet();
                try
                {
                    Connection.Open();
                    DA = new SqlDataAdapter(query, Connection);
                    DA.Fill(DS, "SinhVien");
                    Data_Grid.DataSource = DS.Tables["SinhVien"];
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (Connection != null)
                        Connection.Close();
                    Bool_Tim = true;
                    Button_Them.Enabled = true;
                    Button_Sua.Enabled = true;
                    Button_Xoa.Enabled = true;
                    Button_Timkiem.Text = "Tìm kiếm";
                }
            }
            else
            {
                Unlock_Text();
                Button_Timkiem.Text = "Tìm";
                Button_Them.Enabled = false;
                Button_Sua.Enabled = false;
                Button_Xoa.Enabled = false;
                Bool_Tim = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.Dispose();
            DS.Dispose();
            DA.Dispose();
            this.Dispose();
        }
    }
}
