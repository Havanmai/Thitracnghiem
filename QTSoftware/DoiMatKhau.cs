using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QTSoftware
{
    public partial class DoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public String getUS;
        public DoiMatKhau(String USERNAME)
        {
            InitializeComponent();
            getUS = USERNAME;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Button Đổi mật khẩu
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //check mk nhóe
            if (checkmkcu() == false)
            {
                MessageBox.Show("Mật Khẩu Cũ Sai =))");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(StringConnectionSql.StrConnect);
                    con.Open(); // mở kết nối  
                    // Tạo đối tượng Command
                    SqlCommand cmd = new SqlCommand();
                    //Thiết lập các thuộc tính cho đối tượng Command
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_pass";
                    // Gắn các Parameter và giá trị cho đối tượng Command
                    cmd.Parameters.Add(new SqlParameter("@sPassword", txt_newpass.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@sUsername", getUS));
                    cmd.Parameters.Add(new SqlParameter("@srole", true));
                    //Thực thi Stored Procedure
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Đổi Mật Khẩu Thành Công,Nhớ đấy đừng Quên ");
                }
                catch (Exception x)
                {
                    MessageBox.Show(x + "");
                }
                this.Close();
            }
        }

        private bool checkmkcu()
        {
            try
            {

                SqlConnection con = new SqlConnection(StringConnectionSql.StrConnect);
                con.Open();
                SqlCommand comand = new SqlCommand("Select Password from TAIKHOAN WHERE Username ='" + getUS + "'", con);
                SqlDataReader r = comand.ExecuteReader();
                r.Read();
                if (textEdit1.Text.Equals(r.GetValue(0).ToString()))
                {
                    return true; 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("loi" + ex);
            }
            return false;
        }
    }
}