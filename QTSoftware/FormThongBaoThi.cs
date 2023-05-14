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

namespace QTSoftware
{
    public partial class FormThongBaoThi : DevExpress.XtraEditors.XtraForm
    {
        String idname;
        public FormThongBaoThi(String name)
        {
            InitializeComponent();
            idname = name;
        }

        private void FormThongBaoThi_Load(object sender, EventArgs e)
        {
            lbl_name.Text = idname;
            lbl_thoigian.Text = "30 Phút";
            lbl_ngaythi.Text=DateTime.Now.Day+"/"+DateTime.Now.Month+"/"+DateTime.Now.Year;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_mon.SelectedItem.Equals("Java Cơ Bản"))
            {
                FromThi ft = new FromThi(idname, "Java Cơ Bản");
                ft.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("C# Chưa Có Câu Hỏi Hãy Thi Môn Java");
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}