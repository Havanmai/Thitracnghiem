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
namespace QTSoftware
{
    public partial class LichsuThi : Form
    {
        public LichsuThi()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LichsuThi_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = getLichsuthi().Tables[0];
        }
        DataSet getLichsuthi()
        {
            DataSet data = new DataSet();

            try {

                SqlConnection con = new SqlConnection(StringConnectionSql.StrConnect);

                con.Open();

                String Query = "SELECT * FROM KETQUA";
                SqlCommand cmd = new SqlCommand(Query, con);

                SqlDataAdapter Adap = new SqlDataAdapter(cmd);

                Adap.Fill(data);

                con.Close();
            }
            catch (Exception ex)
            {

            }

            return data;
        }
    }
}
