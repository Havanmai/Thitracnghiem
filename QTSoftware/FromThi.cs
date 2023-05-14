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
using System.Collections;
using System.Data.SqlClient;

namespace QTSoftware
{
    public partial class FromThi : DevExpress.XtraEditors.XtraForm
    {
        // Start Code ######
        private float Diem = 0;
        //Giờ Phút Giây để load lên form
        private int gio, phut, giay;

        private String TenThiSinh;

        private int SocauDung=0, SoCauSai=0;

        private int Cauhientai=0;

        private int Socauhoi = 0;

        private int SocauNgauNhien = 20;

        String Mon;

        //Dữ Liệu Bảng dùng Để Check True False Khi chọn đáp Án
        DataTable dulieubang = new DataTable();


        public FromThi(String Hoten,String Tenmon)
        {
            InitializeComponent();
            TenThiSinh = Hoten;
            Mon = Tenmon;

        }
        void Load_DeThiThat()
        {
            try
            {
                SqlConnection cnn = new SqlConnection(StringConnectionSql.StrConnect);
                SqlDataAdapter da = new SqlDataAdapter("select CAUHOI.MACH,TENCH,A,B,C,D ,Dapan from CAUHOI,DAPAN where CAUHOI.MACH=DAPAN.MACH", cnn);
                DataTable BangQuestion = new DataTable();
                da.Fill(BangQuestion);
                TaobangRandomCauhoi(BangQuestion);
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
            giay = 1;//nhap thoi gian thi 
            phut = 30;
            gio = 0;
        }
        // Start Random Câu Hỏi 
        private void TaobangRandomCauhoi(DataTable BangCH)
        {

            try
            {
                Random rd = new Random();
                //Tạo Arraylist để chứa Các câu hỏi
                ArrayList ArrCH = new ArrayList();

                ArrCH.Clear();
                int dem = 0; int x;
                int SoCauHoiTrongBangGoc = BangCH.Rows.Count;

                while (dem < SocauNgauNhien)
                {
                    x = rd.Next(0, SoCauHoiTrongBangGoc);
                    //Contains nếu chưa trùng thì add câu hỏi vào Array câu hỏi
                    if (!ArrCH.Contains(x))
                    {
                        ArrCH.Add(x);
                        dem++;
                    }
                }

                //Xóa Câu hỏi Trong Bản Gốc Khi đã Add Vào Arr
                for (int j = SoCauHoiTrongBangGoc - 1; j >= 0; j--)
                {
                    if (!ArrCH.Contains(j))
                    {
                        BangCH.Rows.RemoveAt(j);
                    }
                }
                dulieubang = BangCH;
                dulieubang.Columns.Add("cauhoi,DAPAN");

            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi " + e);
            }

        }
        //End Random Câu Hỏi


        //Start Random Câu Trả Lời

        private void RandomCauTraloi()
        {
            try 
            { 

            Random rd = new Random();

            Socauhoi = dulieubang.Rows.Count;
            String Dapandung = "";
            String A = "", B = "", C = "", D = "";
            int DapAn;
            ArrayList ArrDapan = new ArrayList();
            for (int i = 0; i < Socauhoi; i++)
            {
                //Reset Các Biến Sau Mỗi Lần Loop
                A = "";
                B = "";
                C = "";
                D = "";
                Dapandung = "";
                DapAn = 0;
                ArrDapan.Clear();
                ArrDapan.Add(2);
                ArrDapan.Add(3);
                ArrDapan.Add(4);
                ArrDapan.Add(5);
                //Random ĐÁP ÁN A
                DapAn = rd.Next(ArrDapan.Count);
                //Load Đáp án A Vào Biến A
                A = dulieubang.Rows[i][(int)ArrDapan[DapAn]].ToString();
                //Nếu  lấy dữ liệu bảng ra so sánh Với 
                if (dulieubang.Rows[i][6].ToString().ToUpper().Contains("A") && (int)ArrDapan[DapAn] == 2 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("B") && (int)ArrDapan[DapAn] == 3 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("C") && (int)ArrDapan[DapAn] == 4 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("D") && (int)ArrDapan[DapAn] == 5)
                    Dapandung += "A";
                ArrDapan.RemoveAt(DapAn);
                //Random ĐÁP ÁN B
                DapAn = rd.Next(ArrDapan.Count);
                B = dulieubang.Rows[i][(int)ArrDapan[DapAn]].ToString();
                if (dulieubang.Rows[i][6].ToString().ToUpper().Contains("A") && (int)ArrDapan[DapAn] == 2 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("B") && (int)ArrDapan[DapAn] == 3 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("C") && (int)ArrDapan[DapAn] == 4 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("D") && (int)ArrDapan[DapAn] == 5)
                    Dapandung += "B";
                ArrDapan.RemoveAt(DapAn);
                //Random ĐÁP ÁN C
                DapAn = rd.Next(ArrDapan.Count);
                C = dulieubang.Rows[i][(int)ArrDapan[DapAn]].ToString();
                if (dulieubang.Rows[i][6].ToString().ToUpper().Contains("A") && (int)ArrDapan[DapAn] == 2 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("B") && (int)ArrDapan[DapAn] == 3 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("C") && (int)ArrDapan[DapAn] == 4 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("D") && (int)ArrDapan[DapAn] == 5)
                    Dapandung += "C";
                ArrDapan.RemoveAt(DapAn);
                //Random ĐÁP ÁN D
                DapAn = rd.Next(ArrDapan.Count);
                D = dulieubang.Rows[i][(int)ArrDapan[DapAn]].ToString();
                if (dulieubang.Rows[i][6].ToString().ToUpper().Contains("A") && (int)ArrDapan[DapAn] == 2 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("B") && (int)ArrDapan[DapAn] == 3 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("C") && (int)ArrDapan[DapAn] == 4 || dulieubang.Rows[i][6].ToString().ToUpper().Contains("D") && (int)ArrDapan[DapAn] == 5)
                    Dapandung += "D";
                ArrDapan.RemoveAt(DapAn);

                dulieubang.Rows[i][2] = A;

                dulieubang.Rows[i][3] = B;

                dulieubang.Rows[i][4] = C;

                dulieubang.Rows[i][5] = D;

                dulieubang.Rows[i][6] = Dapandung;
            }
            }catch(Exception e){

                MessageBox.Show(e+"");
            }
            }

        //Load câu hỏi Từ Bảng Dulieubang Vào Control 
        private void Load_CauHoi_VaoControl()
        {
            groupControl1.Text ="Câu Hỏi Số " +(Cauhientai + 1).ToString();
            lbl_Cauhoi.Text = dulieubang.Rows[Cauhientai][1].ToString();
            labelControl3.Text = dulieubang.Rows[Cauhientai][2].ToString();
            labelControl4.Text = dulieubang.Rows[Cauhientai][3].ToString();
            labelControl9.Text = dulieubang.Rows[Cauhientai][4].ToString();
            labelControl10.Text = dulieubang.Rows[Cauhientai][5].ToString();

            if (dulieubang.Rows[Cauhientai][7].ToString().Contains("A"))
                Radio_A.Checked = true;
            if (dulieubang.Rows[Cauhientai][7].ToString().Contains("B"))
                Radio_B.Checked = true;
            if (dulieubang.Rows[Cauhientai][7].ToString().Contains("C"))
                Radio_C.Checked = true;
            if (dulieubang.Rows[Cauhientai][7].ToString().Contains("D"))
                Radio_D.Checked = true;
        }
        private void GhiLaiDapAnTS()
        {
            string DapAnTS = "";
            if (Radio_A.Checked == true)
                DapAnTS += "A";
            if (Radio_B.Checked == true)
                DapAnTS += "B";
            if (Radio_C.Checked == true)
                DapAnTS += "C";
            if (Radio_D.Checked == true)
                DapAnTS += "D";
            dulieubang.Rows[Cauhientai][7] = DapAnTS;
        }
        private void LoadcauhoiLenFrom()
        {
            Load_DeThiThat();
            RandomCauTraloi();
            Load_CauHoi_VaoControl();
            timer1.Start();
          

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            GhiLaiDapAnTS();
            if (Cauhientai <Socauhoi-1)
            {
                GhiLaiDapAnTS();
                Radio_A.Checked = false;
                Radio_B.Checked = false;
                Radio_C.Checked = false;
                Radio_D.Checked = false;
               // simpleButton2.Enabled = true;
                Cauhientai++;
                Load_CauHoi_VaoControl();
                if (Cauhientai == 0)
                {
                  //  simpleButton2.Enabled = false;
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GhiLaiDapAnTS();
            if (Cauhientai > 0)
            {
                GhiLaiDapAnTS();
              //  simpleButton1.Enabled = true;
                Radio_A.Checked = false;
                Radio_B.Checked = false;
                Radio_C.Checked = false;
                Radio_D.Checked = false;
                Cauhientai--;
                Load_CauHoi_VaoControl();
                if (Cauhientai == 0)
                {
               //     simpleButton1.Enabled = false;
                }
            }
        }
        
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn Nộp bài  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                timer1.Stop();
                GhiLaiDapAnTS();
                SocauDung = 0;
                for (int i = 0; i < Socauhoi; i++)
                {
                    if (dulieubang.Rows[i][6].ToString().ToUpper() == dulieubang.Rows[i][7].ToString().ToUpper())
                        SocauDung++;

                }

                Diem = (float)(SocauDung * 5);
                int Socausai = SocauNgauNhien - SocauDung;
                Formketquathi kq = new Formketquathi(SocauDung,Socausai, Diem,TenThiSinh);
                kq.Show();
              //  MessageBox.Show("Đúng " + SocauDung.ToString() + " câu \n\r SAi  " + (SocauNgauNhien - SocauDung).ToString() + "  Bạn được  " + Diem.ToString() + "  điểm ");
            }
            else
            {
                return;
            }
        }
        int th = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            th--;
            giay--;
            if (giay==0)
            {
                phut--;
                if (phut==0)
                {
                    giay = 60;
                    th = giay; 
                }
                giay = 60;
              
            }
            label2.Text = gio.ToString() + " : " + phut.ToString() + " : " + giay.ToString();

            if (phut<0)
            {
                this.Close();
                label2.Text = "0:0:0";
                simpleButton1.Enabled = false;
                simpleButton2.Enabled = false;
                simpleButton3.Enabled = false;
                timer1.Stop();
                GhiLaiDapAnTS();
                SocauDung = 0;
                for (int i = 0; i < Socauhoi; i++)
                {
                    if (dulieubang.Rows[i][6].ToString().ToUpper() == dulieubang.Rows[i][7].ToString().ToUpper())
                        SocauDung++;

                }

                Diem = (float)(SocauDung * 5);
          //      MessageBox.Show("Đúng " + SocauDung.ToString() + " câu " + "  Bạn được  " + Diem.ToString() + "  điểm ");
                int Socausai = SocauNgauNhien - SocauDung;
                Formketquathi kq = new Formketquathi(SocauDung, Socausai, Diem,TenThiSinh);
                kq.Show();
            }
          
         }

        private void FromThi_Load(object sender, EventArgs e)
        {
            LoadcauhoiLenFrom();
            lbl_hoten.Text = TenThiSinh;
            lbl_mon.Text = Mon;
        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Cauhoi_Click(object sender, EventArgs e)
        {

        }

        private void lbl_hoten_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        }

    }
