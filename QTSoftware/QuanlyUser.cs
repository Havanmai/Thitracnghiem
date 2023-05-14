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
    public partial class Quanlyuser : DevExpress.XtraEditors.XtraForm
    {
        public Quanlyuser()
        {
            InitializeComponent();
        }
        //load luôn dữ liệu vào data girdview
        private void Quanlyuser_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = GetData().Tables[0];
        }
       
        private DataSet GetData()
        {
            DataSet data = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(StringConnectionSql.StrConnect);
                con.Open();
                String Query = "SELECT MATHISINH,NGAYSINH,NGAYGIANHAP,DIACHI,GMAIL FROM THISINHX";
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lõi :" + ex);
                // DataGridViewRow
            }
            return data;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow SelectRow = dataGridView1.Rows[index];
                textEdit1.Text = SelectRow.Cells[0].Value.ToString();
                dateEdit1.Text = SelectRow.Cells[1].Value.ToString();
                dateEdit2.Text = SelectRow.Cells[2].Value.ToString();
                textEdit5.Text = SelectRow.Cells[3].Value.ToString();
                textEdit6.Text = SelectRow.Cells[4].Value.ToString();
              
            }
            catch (Exception ex)
            {
                //Giấu BUG :)))
                // MessageBox.Show("Lỗi " + ex);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text.Equals(""))
            {
                MessageBox.Show("Mã Thí Sinh Không Hợp lệ");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(StringConnectionSql.StrConnect);
                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "DELETE_THISINH";

                    cmd.Parameters.Add(new SqlParameter("@sMATHISNH", textEdit1.Text.Trim()));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa Thành công Mã" + textEdit1.Text.Trim());
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thí Sinh Không thể Xóa, Thí Sinh này không tồn tại");
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = GetData().Tables[0];
        }
    }
}