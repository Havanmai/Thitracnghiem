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
    public partial class Formketquathi : DevExpress.XtraEditors.XtraForm
    {
        int Scaudung, ScauSai;
        float Diem;
        String MaTS;
        public Formketquathi(int Socaudung,int Socausai,float diem,String Mats)
        {
            InitializeComponent();
            Scaudung = Socaudung;
            ScauSai = Socausai;
            Diem = diem;
            MaTS = Mats;
        }

        private void Formketquathi_Load(object sender, EventArgs e)
        {
            label3.Text = Diem.ToString() + "/100";
            label7.Text = Scaudung.ToString();
            label6.Text = ScauSai.ToString();
            LuuKetquathi();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        private void LuuKetquathi()
        {
            try
            {
                SqlConnection con = new SqlConnection(StringConnectionSql.StrConnect);
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "INSERT_KQ";
                String ngaythi = DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
                //Bắt đầu Insert Nè
                cmd.Parameters.Add(new SqlParameter("@sMATHISINH", MaTS));
                cmd.Parameters.Add(new SqlParameter("@sNGAYTHI", ngaythi));
                cmd.Parameters.Add(new SqlParameter("@sSOCAUDUNG", Scaudung));
                cmd.Parameters.Add(new SqlParameter("@sSOCAUSAI", ScauSai));
                cmd.Parameters.Add(new SqlParameter("@sDIEM", Diem));
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi Dữ Liệu Sẽ Không Được Lưu" + e);
            }

        }
    }
}