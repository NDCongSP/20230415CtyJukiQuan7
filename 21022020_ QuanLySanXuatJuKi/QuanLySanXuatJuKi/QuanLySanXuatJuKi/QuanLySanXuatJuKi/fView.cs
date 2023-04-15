using QuanLySanXuatJuKi.DAO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySanXuatJuKi
{
    public partial class fView : Form
    {
        public fView()
        {
            InitializeComponent();








        }

        private void fView_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;


            DGV1.DataSource = DuLieuVaBaoCaoDAO.Instance.GetDataTableView();
            //SELECT MaBarCodeSanPham,MaBarCodeLot,TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeCot,MaBarCodeXe,SoLopHienTai,SoLopKetThuc,SoThoiGianKho,ThoiGianKetThucKho,addtime(now()) FROM juki_giamsatthoigiankho7.dulieuvabaocao;
            DGV1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV1.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            //DGV1.Rows[0].Cells[0].Selected = false;
            DGV1.Rows[DGV1.RowCount - 1].Selected = true;
            DGV1.FirstDisplayedScrollingRowIndex = DGV1.Rows.Count - 1;
            //foreach (DataGridViewColumn c in DGV1.Columns)
            //{
            //    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}
           // DGV1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;




            DGV2.DataSource = DuLieuVaBaoCaoDAO.Instance.GetDataTableView2();
            //SELECT MaBarCodeSanPham,MaBarCodeLot,TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeCot,MaBarCodeXe,SoLopHienTai,SoLopKetThuc,SoThoiGianKho,ThoiGianKetThucKho,addtime(now()) FROM juki_giamsatthoigiankho7.dulieuvabaocao;
            DGV2.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV2.Font = new Font("Arial", 15F, GraphicsUnit.Pixel);
            DGV2.Rows[0].Cells[0].Selected = true;
           // DGV2.Rows[DGV2.RowCount - 1].Selected = true;
            DGV2.FirstDisplayedScrollingRowIndex = DGV2.Rows.Count - 1;
            //foreach (DataGridViewColumn c in DGV2.Columns)
            //{
            //    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //}
            //DGV2.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            DGV1.DataSource = DuLieuVaBaoCaoDAO.Instance.GetDataTableView();

            for (int i = 0; i < DGV1.RowCount; i++)
            {
                if (Convert.ToString(DGV1.Rows[i].Cells[12].Value) == "Đang Phơi")
                {
                    DGV1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToString(DGV1.Rows[i].Cells[12].Value) == "Sắp Khô")
                {
                    DGV1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (Convert.ToString(DGV1.Rows[i].Cells[12].Value) == "Đã Khô" && Convert.ToInt16(DGV1.Rows[i].Cells[7].Value) != Convert.ToInt16(DGV1.Rows[i].Cells[8].Value))
                {
                    DGV1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else if (Convert.ToString(DGV1.Rows[i].Cells[12].Value) == "Đã Khô" && Convert.ToInt16(DGV1.Rows[i].Cells[7].Value) == Convert.ToInt16(DGV1.Rows[i].Cells[8].Value))
                {
                    DGV1.Rows[i].DefaultCellStyle.BackColor = Color.DeepSkyBlue;
                }
                //else
                //{
                //    DGV1.Rows[i].DefaultCellStyle.BackColor = Color.Orchid;
                //}

            }


            DGV2.DataSource = DuLieuVaBaoCaoDAO.Instance.GetDataTableView2();

            for (int i2 = 0; i2 < DGV2.RowCount - 1; i2++)
            {
                DGV2.Rows[i2].DefaultCellStyle.BackColor = Color.Orchid;

            }
        }








    }
}

