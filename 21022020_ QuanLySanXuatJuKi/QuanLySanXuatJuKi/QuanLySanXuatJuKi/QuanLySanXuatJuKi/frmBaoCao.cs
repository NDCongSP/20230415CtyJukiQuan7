using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using QuanLySanXuatJuKi.DAO;
using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLySanXuatJuKi
{

    public partial class frmBaoCao : Form
    {
        static DataTable dt = new DataTable();

        private string sql;

        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCao();


        }
        void LoadProductCodeIntoCombobox(ComboBox cb)
        {

            List<BangNhapSoLop> list = new List<BangNhapSoLop>();
            list = BangNhapSoLopDAO.Instance.GetListBatchNumber();
            //cb.DataSource = list;
            ////list.Add();
            //cb.DisplayMember = "TenSanPham";
            foreach (BangNhapSoLop lists in list)
            {
                comboBox1.Items.Add(lists.MaBarCodeSanPham);
            }

        }

        private void LoadBaoCao()
        {

            //Khai báo câu lệnh SQL
            // String sql = "Select * from DuLieuVaBaoCao Where ThoiGianKetThucQuaTrinh >='" + TimeTO.Value.ToString() + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM.Value.ToString() + "'";
            if (comboBox1.Text == "ALL")
            {
                sql = "Select * from DuLieuVaBaoCao where ThoiGianKetThucQuaTrinh >= '" + TimeTO.Value.ToString("yyyy-MM-dd 00:00:00") + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM.Value.ToString("yyyy-MM-dd 23:59:59") + "' order by mabarcodelot asc";

            }
            if (comboBox1.Text == "Lọc Theo Mã Sản Phẩm")
            {
                sql = "Select * from DuLieuVaBaoCao where MaBarCodeSanPham = '" + textBox1.Text + "' and ThoiGianKetThucQuaTrinh >= '" + TimeTO.Value.ToString("yyyy-MM-dd 00:00:00") + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM.Value.ToString("yyyy-MM-dd 23:59:59") + "' order by mabarcodelot asc";

            }
            if (comboBox1.Text == "Lọc Theo Mã LOT")
            {
                sql = "Select * from DuLieuVaBaoCao where MaBarCodeLot = '" + textBox1.Text + "' and ThoiGianKetThucQuaTrinh >= '" + TimeTO.Value.ToString("yyyy-MM-dd 00:00:00") + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM.Value.ToString("yyyy-MM-dd 23:59:59") + "' order by mabarcodelot asc";

            }





            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;password=100100;database=juki_giamsatthoigiankho;";
            con.Open();
            DataSet ds = new DataSet();
            // MySqlDataAdapter adp = new MySqlDataAdapter(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter();
            adp.SelectCommand = new MySqlCommand(sql, con);
            adp.Fill(ds);


            //Khai báo chế độ xử lý báo cáo, trong trường hợp này lấy báo cáo ở local
            rpvBaoCao.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            //Đường dẫn báo cáo
            rpvBaoCao.LocalReport.ReportPath = "Report2.rdlc";

            ReportParameter[] reportpara = new ReportParameter[]
            {
                    new ReportParameter("ReportParameter1",TimeTO.Value.ToString("dd/MM/yyyy 00:00:00")),
                new ReportParameter("ReportParameter2",TimeFROM.Value.ToString("dd/MM/yyyy 23:59:59"))
            };
            rpvBaoCao.LocalReport.SetParameters(reportpara);


            //Nếu có dữ liệu
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Tạo nguồn dữ liệu cho báo cáo
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];
                //Xóa dữ liệu của báo cáo cũ trong trường hợp người dùng thực hiện câu truy vấn khác
                rpvBaoCao.LocalReport.DataSources.Clear();
                //  rpvBaoCao.ShowParameterPrompts
                //Add dữ liệu vào báo cáo
                rpvBaoCao.LocalReport.DataSources.Add(rds);
                //Refresh lại báo cáo
                rpvBaoCao.RefreshReport();
            }
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            //load 1 list mã sản phẩm
           // LoadProductCodeIntoCombobox(comboBox1);
            comboBox1.Items.Add("ALL");
            comboBox1.Items.Add("Lọc Theo Mã Sản Phẩm");
            comboBox1.Items.Add("Lọc Theo Mã LOT");


            comboBox1.Text = "ALL";

            // TODO: This line of code loads data into the 'juki_giamsatthoigiankhoDataSet.dulieuvabaocao' table. You can move, or remove it, as needed.
            //this.dulieuvabaocaoTableAdapter.Fill(this.juki_giamsatthoigiankhoDataSet.dulieuvabaocao);
            LoadBaoCao();
            this.rpvBaoCao.RefreshReport();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "ALL")
                {
                    if (Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss") != "" && Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss") != "")
                    {
                        if (Convert.ToDateTime(Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss")) > Convert.ToDateTime(Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss")))
                        {
                            //if (MysqlCMD.ketnoi_server() == "Good")
                            //{
                            //}

                            //  dt = MysqlCMD.Doc_Exl(Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss"), Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss"));
                            dt = DuLieuVaBaoCaoDAO.Instance.GetDataTableReport(Convert.ToDateTime(TimeTO.Value).ToString("yyyy-MM-dd 00:00:00"), Convert.ToDateTime(TimeFROM.Value).ToString("yyyy-MM-dd 23:59:59"));

                            //if (dt != null && dt.Rows.Count != 0)
                            //{
                            //    GridView1.DataSource = dt;
                            //    GridView1.DataBind();
                            //    // MysqlCMD.NgatKetnoiMySQL();
                            //    // Bt_dowload1.Enabled = true;
                            //}

                        }
                    }
                }
                else if (comboBox1.Text != "ALL")
                {
                    if (Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss") != "" && Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss") != "")
                    {
                        if (Convert.ToDateTime(Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss")) > Convert.ToDateTime(Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss")))
                        {
                            //if (MysqlCMD.ketnoi_server() == "Good")
                            //{
                            //}
                            // dt = MysqlCMD.Doc_Exl(Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss"), Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss"));
                            // dt = DuLieuVaBaoCaoDAO.Instance.GetDataTableReport2(comboBox1.Text, Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss"), Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss"));
                            dt = DuLieuVaBaoCaoDAO.Instance.GetDataTableReport2(comboBox1.Text, Convert.ToDateTime(TimeTO.Value).ToString("yyyy-MM-dd HH:mm:ss"), Convert.ToDateTime(TimeFROM.Value).ToString("yyyy-MM-dd HH:mm:ss"));
                            //if (dt != null && dt.Rows.Count != 0)
                            //{
                            //    GridView1.DataSource = dt;
                            //    GridView1.DataBind();
                            //    // MysqlCMD.NgatKetnoiMySQL();
                            //    // Bt_dowload1.Enabled = true;
                            //}

                        }
                    }
                }

                xuatexel exl = new xuatexel();

                exl.Export_alarm(dt, "From : " + Convert.ToDateTime(TimeTO.Value).ToString("dd/MM/yyyy HH:mm:ss") + "        To : " + Convert.ToDateTime(TimeFROM.Value).ToString("dd/MM/yyyy HH:mm:ss"), "DATA REPORT");


                try
                {
                    string rootDir = AppDomain.CurrentDomain.BaseDirectory;

                    System.Diagnostics.Process.Start(rootDir + "BAO CAO\\PMDataReport.xls");
                }
                catch { }

            }
            catch 
            {

            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UpdateData NewForm = new UpdateData();
            NewForm.ShowDialog();
        }
    }
}
