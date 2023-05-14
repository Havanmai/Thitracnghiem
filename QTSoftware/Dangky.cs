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
    public partial class Dangky : DevExpress.XtraEditors.XtraForm
    {
        public Dangky()
        {
            InitializeComponent();
        }
        //Hàm Kiểm tra Tài khoản Đã tồn Tại hay chưa 
        private bool kiemtratontai()
        {
            bool tatkt = false;
            string Name = txt_Taikhoan.Text;
            SqlConnection con2 = new SqlConnection(StringConnectionSql.StrConnect);
            con2.Open();
            SqlCommand cmd = new SqlCommand("Select Username from TAIKHOAN", con2);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                if (Name == r.GetString(0))
                {
                    tatkt = true;
                    break;
                }
            }
            con2.Close();
            return tatkt;
        } 
        //  Khi dang ky Ta can Them du lieu vao Hai bang :v
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_Taikhoan.Text.Trim().Equals("") || txt_Matkhau.Text.Trim().Equals("") || txt_Email.Text.Trim().Equals("")||
                txt_ngaysinh.Text.Trim().Equals("") || txt_Adress.Text.Trim().Equals(""))
            {
                MessageBox.Show("Thông Tin Đã đủ chưa , Thiếu kìa ");
            }else{
            if (kiemtratontai() == true)
            {
                MessageBox.Show("Không thể đăng ký, Người dùng đã tồn tại");
            }
            else
            {
                try
                {


                    DateTime today = DateTime.Now;
                    String year = Convert.ToString(today.Year);
                    String month = Convert.ToString(today.Month);
                    String day = Convert.ToString(today.Day);
                    //mở Cổng kết Nối Với Database
                    SqlConnection con = new SqlConnection(StringConnectionSql.StrConnect);
                    con.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Tên PROC
                    cmd.CommandText = "INSERT_USER";
                    cmd.Parameters.Add(new SqlParameter("@sUsername", txt_Taikhoan.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@sPassword", txt_Matkhau.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@srole", false));
                    cmd.Parameters.Add(new SqlParameter("@sMATHISINH", txt_Taikhoan.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@sNGAYGIANHAP", month + "/" + day + "/" + year));
                    cmd.Parameters.Add(new SqlParameter("@sGMAIL", txt_Email.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@sNGAYSINH", txt_ngaysinh.Text.Trim()));
                    cmd.Parameters.Add(new SqlParameter("@sDIACHI", txt_Adress.Text.Trim()));

                    //Thực thi Stored Procedure
                    cmd.ExecuteNonQuery();
                    con.Close();
                
                    MessageBox.Show("Đăng Ký Thành Công Đăng Nhập Nào");
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Lỗi EX" + x);
                }
              }

            }
        }
    }
}