using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using BusinessLayer.Juki_giamsatthoigiankho;

namespace QuanLySanXuatJuKi
{
    public partial class UpdateData : Form
    {
        //DataTable DataTableDuLieuBaoCao = new DataTable();
        //DataTable DataTableBangSoLop = new DataTable();
        //DateTime StartPhoi, KetThucKeHoach, KetThucThucTe;
        //double TongSoLop = 0, LopHienTai = 0, ThoiGianPhoi = 0;
        //string query = "";
        //TimeSpan ThoiGianCongThem;
        //MySqlConnection conn;

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTableDuLieuBaoCao = new DataTable();
                DataTable DataTableBangSoLop = new DataTable();
                DateTime StartPhoi, KetThucKeHoach, KetThucThucTe;
                double TongSoLop = 0, LopHienTai = 0, ThoiGianPhoi = 0;
                string query = "";
                TimeSpan ThoiGianCongThem;
                MySqlConnection conn;

                #region short ra các mã LOT đang ở trạng thái "Chuyển Tiếp"
                DataTableDuLieuBaoCao.Clear();
                DataTableBangSoLop.Clear();

                conn = new MySqlConnection(ConectionString);

                Debug.WriteLine(ConectionString);
                conn.Open();
                //string query = "";
                //DataTable DataTableDuLieuBaoCao = new DataTable();
                //DataTable DataTableBangSoLop = new DataTable();

                query = $"select * from bangnhapsolop";
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableBangSoLop);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }
                #region tao câu query theo các điều kiện lọc
                if (checkBoxTDCL.Checked == false)
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        query = $"drop table if exists temp1;" +
                            $"drop table if exists temp2;" +
                            $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                            $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                            $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                            $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                            $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null) and MaBarCodeLot = '{textBox1.Text.TrimEnd()}'";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao where MaBarCodeLot = '{textBox1.Text.TrimEnd()}'" +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                    else
                    {
                        query = $"drop table if exists temp1;" +
                           $"drop table if exists temp2;" +
                           $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                           $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                           $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                           $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                           $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null)";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao " +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        query = $"drop table if exists temp1;" +
                            $"drop table if exists temp2;" +
                            $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                            $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                            $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                            $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                            $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null) and MaBarCodeLot = '{textBox1.Text.TrimEnd()}' " +
                            $"and ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTDCL.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                            $" and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTDCL.Text).ToString("yyyy-MM-dd 23:59:59")}'";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao where MaBarCodeLot = '{textBox1.Text.TrimEnd()}'" +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                    else
                    {
                        query = $"drop table if exists temp1;" +
                           $"drop table if exists temp2;" +
                           $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                           $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                           $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                           $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                           $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null) and " +
                           $"ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTDCL.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                            $" and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTDCL.Text).ToString("yyyy-MM-dd 23:59:59")}'";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao " +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                }
                #endregion
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableDuLieuBaoCao);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }
                Debug.WriteLine(DataTableDuLieuBaoCao.Rows.Count);
                dataGridView3.DataSource = DataTableDuLieuBaoCao;
                //dataGridView2.DataSource = DataTableBangSoLop;
                #endregion
            }
            catch { }
        }

        //nut nhan cap nhat so lop phoi vao databases
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTableDuLieuBaoCao = new DataTable();
                DataTable DataTableBangSoLop = new DataTable();
                DateTime BatDauNhung, StartPhoi, KetThucKeHoach, KetThucThucTe;
                double TongSoLop = 0, SoLopZircon = 0, SoLopCat = 0, SoLopSiru = 1, LopHienTai = 0, ThoiGianPhoi = 0;
                string query = "";
                TimeSpan ThoiGianCongThem;
                MySqlConnection conn;

                #region short ra các mã LOT đang ở trạng thái "Chuyển Tiếp"
                DataTableDuLieuBaoCao.Clear();
                DataTableBangSoLop.Clear();

                conn = new MySqlConnection(ConectionString);

                Debug.WriteLine(ConectionString);
                conn.Open();
                //string query = "";
                //DataTable DataTableDuLieuBaoCao = new DataTable();
                //DataTable DataTableBangSoLop = new DataTable();

                #region tao câu query theo các điều kiện lọc
                if (checkBoxTDCL.Checked == false)
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        query = $"drop table if exists temp1;" +
                            $"drop table if exists temp2;" +
                            $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                            $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                            $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                            $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                            $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null) and MaBarCodeLot = '{textBox1.Text.TrimEnd()}'";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao where MaBarCodeLot = '{textBox1.Text.TrimEnd()}'" +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                    else
                    {
                        query = $"drop table if exists temp1;" +
                           $"drop table if exists temp2;" +
                           $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                           $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                           $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                           $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                           $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null)";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao " +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBox1.Text))
                    {
                        query = $"drop table if exists temp1;" +
                            $"drop table if exists temp2;" +
                            $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                            $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                            $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                            $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                            $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null) and MaBarCodeLot = '{textBox1.Text.TrimEnd()}' " +
                            $"and ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTDCL.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                            $" and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTDCL.Text).ToString("yyyy-MM-dd 23:59:59")}'";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao where MaBarCodeLot = '{textBox1.Text.TrimEnd()}'" +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                    else
                    {
                        query = $"drop table if exists temp1;" +
                           $"drop table if exists temp2;" +
                           $"create temporary table temp2 SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, SoLopHienTai, SoThoiGianKho, SoLopKetThuc, MaBarCodeLot, ThoiGianBatDauNhung, ThoiGianBatDauPhoi, ThoiGianKetThucKho, ThoiGianKetThucQuaTrinh," +
                           $"MaBarCodeXe, MaBarCodeCot, MaBarCodeNguoi, TenCatNhungHienTai, TenCatNhungTiepTheo, TrangThaiDen " +
                           $"FROM dulieuvabaocao order by SoLopHienTai desc;" +
                           $"create temporary table temp1 select temp2.*, count(*) as SoHang  from temp2 group by MaBarCodeLot;" +
                           $"select * from temp1 where(SoHang<SoLopKetThuc or SoLopKetThuc is null) and " +
                           $"ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTDCL.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                            $" and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTDCL.Text).ToString("yyyy-MM-dd 23:59:59")}'";
                        //query = $"drop table if exists temp;" +
                        //    $"create temporary table temp SELECT TenSanPhamTiengViet, TenSanPhamTiengAnh, MaBarCodeSanPham, max(SoLopHienTai) as SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh," +
                        //    $"MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen, count(*) as SoHang " +
                        //    $"FROM dulieuvabaocao " +
                        //    $"group by MaBarCodeLot;" +
                        //    $"select* from temp where SoHang < SoLopKetThuc; ";
                    }
                }
                #endregion
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableDuLieuBaoCao);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }

                dataGridView3.DataSource = DataTableDuLieuBaoCao;
                //dataGridView2.DataSource = DataTableBangSoLop;
                #endregion

                if (DataTableDuLieuBaoCao != null || DataTableDuLieuBaoCao.Rows.Count > 0)
                {
                    #region Tao thông tin của tất cả các lớp còn lại cuat Lot vào các properties kiểu Distionary
                    for (int i = 0; i < DataTableDuLieuBaoCao.Rows.Count; i++)
                    {
                        try
                        {
                            //lây data về tên lớp và thời gian phơi cho các lớp để tính toán tự động add lớp vào DB
                            DataTableBangSoLop.Clear();
                            query = $"Select * From bangnhapsolop WHERE MaBarCodeSanPham='{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'";//short theo ma barcode san pham
                            Debug.WriteLine(query);
                            conn = new MySqlConnection(ConectionString);
                            conn.Open();
                            try
                            {
                                MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                                Adapter.Fill(DataTableBangSoLop);
                                conn.Close();
                                conn.Dispose();
                                Debug.WriteLine("thành công");
                            }
                            catch (System.Exception)
                            {
                                conn.Close();
                                conn.Dispose();
                                Debug.WriteLine("thất bại");
                            }

                            if (DataTableBangSoLop != null && DataTableBangSoLop.Rows.Count > 0)
                            {
                                SoLopZircon = double.Parse(DataTableBangSoLop.Rows[0][3].ToString().Split('_')[0]);
                                SoLopCat = double.Parse(DataTableBangSoLop.Rows[0][3].ToString().Split('_')[1]) - 1;
                                TongSoLop = Int16.Parse(DataTableBangSoLop.Rows[0][4].ToString());
                            }
                            //tạo Distionary các mốc thời gian để add thông số cho các lớp còn lại
                            Dictionary<String, DateTime> ThoiGianBatDauNhung = new Dictionary<String, DateTime>();
                            Dictionary<String, DateTime> ThoiGianBatDauCacLop = new Dictionary<String, DateTime>();
                            Dictionary<String, DateTime> ThoiGianKetThucCacLopKeHoach = new Dictionary<String, DateTime>();
                            Dictionary<String, DateTime> ThoiGianKetThucCacLop = new Dictionary<String, DateTime>();

                            Dictionary<String, int> ThoiGianKhoCuaLop = new Dictionary<String, int>();

                            //chứa tên của lớp
                            //Zircon (tối đa 4 lớp): Zircon Lần 1, Zircon Lần 2, Zircon Lần 3, Zircon Lần 4
                            //Cát (tối đa 9 lớp): 
                            // - 1 lớp: 0.1~0.3
                            // - 2 lớp: 0.3~0.7 Lần 1,0.3~0.7 Lần 2
                            // - 6 lớp: 0.7~1.0 Lần 1,0.7~1.0 Lần 2, 0.7~1.0 Lần 3, 0.7~1.0 Lần 4, 0.7~1.0 Lần 5, 0.7~1.0 Lần 6
                            //Siru (1 lớp)
                            Dictionary<String, String> TenCatNhungHientai = new Dictionary<String, String>();
                            Dictionary<String, String> TenCatNhungTiepTheo = new Dictionary<String, String>();

                            //lấy ra số lớp hiện tại, và tổng số lớp
                            LopHienTai = Int16.Parse(DataTableDuLieuBaoCao.Rows[i][3].ToString());
                            BatDauNhung = Convert.ToDateTime(DataTableDuLieuBaoCao.Rows[i][7]?.ToString());
                            //StartPhoi = Convert.ToDateTime(DataTableDuLieuBaoCao.Rows[i][8]?.ToString());
                            //KetThucKeHoach = Convert.ToDateTime(DataTableDuLieuBaoCao.Rows[i][9]?.ToString());
                            //KetThucThucTe = Convert.ToDateTime(DataTableDuLieuBaoCao.Rows[i][10]?.ToString());

                            #region  vòng lặp để add các thông số của các lớp còn lại vào các Distionary, bắt đầu từ lớp hiện tại
                            for (int j = (int)LopHienTai; j <= TongSoLop; j++)
                            {
                                if (j <= SoLopZircon)
                                {
                                    //add thoi gian kho cua lop
                                    ThoiGianKhoCuaLop.Add(j.ToString(), int.Parse(DataTableBangSoLop.Rows[0][(int)(4 + j)].ToString()));

                                    //add tên lớp vào
                                    TenCatNhungHientai.Add(j.ToString(), $"ZIRCON Lần {j}");
                                    if (j < SoLopZircon)
                                    {
                                        TenCatNhungTiepTheo.Add(j.ToString(), $"ZIRCON Lần {j + 1}");
                                    }
                                    else
                                    {
                                        TenCatNhungTiepTheo.Add(j.ToString(), $"0.1~0.3");
                                    }


                                    //add thoi gian bat dau nhung vao
                                    //ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    ThoiGianBatDauNhung.Add(j.ToString(), BatDauNhung);

                                    //add thoi gian bat dau phoi
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 15, 0);
                                    ThoiGianBatDauCacLop.Add(j.ToString(), ThoiGianBatDauNhung[j.ToString()].Add(ThoiGianCongThem));

                                    //add thoi gian ket thuc ke hoach
                                    //ThoiGianCongThem = new System.TimeSpan(0, int.Parse(DataTableBangSoLop.Rows[0][(int)(4 + j)].ToString()), 0, 0);
                                    ThoiGianCongThem = new System.TimeSpan(0, ThoiGianKhoCuaLop[j.ToString()], 0, 0);
                                    ThoiGianKetThucCacLopKeHoach.Add(j.ToString(), ThoiGianBatDauCacLop[j.ToString()].Add(ThoiGianCongThem));

                                    //add thoi gian ket thuc phoi
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    KetThucThucTe = ThoiGianKetThucCacLopKeHoach[j.ToString()].Add(ThoiGianCongThem);
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    BatDauNhung = KetThucThucTe.Add(ThoiGianCongThem);
                                    ThoiGianKetThucCacLop.Add(j.ToString(), KetThucThucTe);

                                }
                                else if (j > SoLopZircon && j <= SoLopCat + SoLopZircon)
                                {
                                    int Solop = j - (int)SoLopZircon;
                                    //add thoi gian kho cua lop
                                    ThoiGianKhoCuaLop.Add(j.ToString(), int.Parse(DataTableBangSoLop.Rows[0][(int)(8 + Solop)].ToString()));

                                    //add tên lớp vào
                                    if (Solop == 1)
                                    {
                                        TenCatNhungHientai.Add(j.ToString(), $"0.1~0.3");
                                        TenCatNhungTiepTheo.Add(j.ToString(), $"0.3~0.7 Lần 1");
                                    }
                                    else if (Solop > 1 && Solop <= 3)
                                    {
                                        if (Solop < 3)
                                        {
                                            TenCatNhungHientai.Add(j.ToString(), $"0.3~0.7 Lần {Solop - 1}");
                                            TenCatNhungTiepTheo.Add(j.ToString(), $"0.3~0.7 Lần {Solop}");
                                        }
                                        else if (Solop == 3)
                                        {
                                            TenCatNhungHientai.Add(j.ToString(), $"0.3~0.7 Lần {Solop - 1}");
                                            TenCatNhungTiepTheo.Add(j.ToString(), $"0.7~1.0 Lần 1");
                                        }
                                        else if (Solop == SoLopCat)
                                        {
                                            TenCatNhungHientai.Add(j.ToString(), $"0.3~0.7 Lần {Solop - 1}");
                                            TenCatNhungTiepTheo.Add(j.ToString(), $"SIRU");
                                        }
                                    }
                                    else if (Solop > 3 && Solop <= 9)
                                    {
                                        if (Solop < SoLopCat)
                                        {
                                            TenCatNhungHientai.Add(j.ToString(), $"0.7~1.0 Lần {Solop - 3}");
                                            TenCatNhungTiepTheo.Add(j.ToString(), $"0.7~1.0 Lần {Solop - 2}");
                                        }
                                        else
                                        {
                                            TenCatNhungHientai.Add(j.ToString(), $"0.7~1.0 Lần {Solop - 3}");
                                            TenCatNhungTiepTheo.Add(j.ToString(), $"SIRU");
                                        }

                                    }

                                    //add thoi gian bat dau nhung vao
                                    //ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    //ThoiGianBatDauNhung.Add(j.ToString(), KetThucThucTe.Add(ThoiGianCongThem));
                                    ThoiGianBatDauNhung.Add(j.ToString(), BatDauNhung);

                                    //add thoi gian bat dau phoi
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 15, 0);
                                    ThoiGianBatDauCacLop.Add(j.ToString(), ThoiGianBatDauNhung[j.ToString()].Add(ThoiGianCongThem));

                                    //add thoi gian ket thuc ke hoach
                                    //ThoiGianCongThem = new System.TimeSpan(0, int.Parse(DataTableBangSoLop.Rows[0][(int)(8 + Solop)].ToString()), 0, 0);
                                    ThoiGianCongThem = new System.TimeSpan(0, ThoiGianKhoCuaLop[j.ToString()], 0, 0);
                                    ThoiGianKetThucCacLopKeHoach.Add(j.ToString(), ThoiGianBatDauCacLop[j.ToString()].Add(ThoiGianCongThem));

                                    //add thoi gian ket thuc phoi
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    KetThucThucTe = ThoiGianKetThucCacLopKeHoach[j.ToString()].Add(ThoiGianCongThem);
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    BatDauNhung = KetThucThucTe.Add(ThoiGianCongThem);
                                    ThoiGianKetThucCacLop.Add(j.ToString(), KetThucThucTe);
                                }
                                else
                                {
                                    //add thoi gian kho cua lop
                                    ThoiGianKhoCuaLop.Add(j.ToString(), int.Parse(DataTableBangSoLop.Rows[0][18].ToString()));

                                    //add tên lớp vào
                                    TenCatNhungHientai.Add(j.ToString(), $"SIRU");
                                    TenCatNhungTiepTheo.Add(j.ToString(), "");

                                    //add thoi gian bat dau nhung vao
                                    //ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    //ThoiGianBatDauNhung.Add(j.ToString(), KetThucThucTe.Add(ThoiGianCongThem));
                                    ThoiGianBatDauNhung.Add(j.ToString(), BatDauNhung);

                                    //add thoi gian bat dau phoi
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 15, 0);
                                    ThoiGianBatDauCacLop.Add(j.ToString(), ThoiGianBatDauNhung[j.ToString()].Add(ThoiGianCongThem));

                                    //add thoi gian ket thuc ke hoach
                                    //ThoiGianCongThem = new System.TimeSpan(0, int.Parse(DataTableBangSoLop.Rows[0][18].ToString()), 0, 0);
                                    ThoiGianCongThem = new System.TimeSpan(0, ThoiGianKhoCuaLop[j.ToString()], 0, 0);
                                    ThoiGianKetThucCacLopKeHoach.Add(j.ToString(), ThoiGianBatDauCacLop[j.ToString()].Add(ThoiGianCongThem));

                                    //add thoi gian ket thuc phoi
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    KetThucThucTe = ThoiGianKetThucCacLopKeHoach[j.ToString()].Add(ThoiGianCongThem);
                                    ThoiGianCongThem = new System.TimeSpan(0, 0, 5, 0);
                                    BatDauNhung = KetThucThucTe.Add(ThoiGianCongThem);
                                    ThoiGianKetThucCacLop.Add(j.ToString(), KetThucThucTe);
                                }
                                Debug.WriteLine($"MaBarCodeSanPham = {DataTableDuLieuBaoCao.Rows[i][2].ToString()} - Ma LOT = {DataTableDuLieuBaoCao.Rows[i][6].ToString()} - bat dau xu ly tu lop {LopHienTai}");
                                //Debug.WriteLine($"Lop {LopHienTai} - Nhung {DataTableDuLieuBaoCao.Rows[i][7].ToString()} - Start {StartPhoi}  -Du Kien {DataTableDuLieuBaoCao.Rows[i][9].ToString()} - Stop {DataTableDuLieuBaoCao.Rows[i][10].ToString()}");
                                Debug.WriteLine($"Lop {j} - Nhung {ThoiGianBatDauNhung[j.ToString()]} - Start {ThoiGianBatDauCacLop[j.ToString()]} -Thoi Gian Phoi {ThoiGianKhoCuaLop[j.ToString()]} -Du Kien {ThoiGianKetThucCacLopKeHoach[j.ToString()]} - Stop {ThoiGianKetThucCacLop[j.ToString()]} - Ten Lơp Hien Tai {TenCatNhungHientai[j.ToString()]} - Ten Lơp Ke Tiep {TenCatNhungTiepTheo[j.ToString()]}");
                                Debug.WriteLine($"-----------------------------------------------------");
                            }
                            #endregion

                            #region kiểm tra thời gian của các lớp so với thời gian hiện tại để insert lớp vào databases
                            foreach (KeyValuePair<string, DateTime> kvp in ThoiGianKetThucCacLop)
                            {
                                if (kvp.Key != LopHienTai.ToString())
                                {
                                    //kvp.Key, kvp.Value;
                                    //neu thời gian kết thúc thực tế của từng lớp mà nhỏ hơn thời gian hiện tại thì mới insert lớp đó vào DB, với các thông số đầy đủ
                                    if (DateTime.Now > kvp.Value)
                                    {
                                        if (double.Parse(kvp.Key) < TongSoLop)
                                        {
                                            //query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                            //    $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                            //    $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                            //    $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}','{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}'" +
                                            //    $",'{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Chuyển Tiếp');" +
                                            //    $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                            query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham," +
                                                $"SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi" +
                                                $",ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo" +
                                                $",TrangThaiDen) " +
                                               $"VALUES ('{DataTableBangSoLop.Rows[0][1].ToString()}','{DataTableBangSoLop.Rows[0][2].ToString()}','{DataTableBangSoLop.Rows[0][0].ToString()}'" +
                                               $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}','{DataTableDuLieuBaoCao.Rows[i][12].ToString()}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Chuyển Tiếp');" +
                                               $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }
                                        else
                                        {
                                            //query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                            //    $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                            //    $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                            //    $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                            //    $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Hoàn Thành');" +
                                            //    $"DELETE FROM mabarcode WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                            query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham," +
                                                $"SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi" +
                                                $",ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo" +
                                                $",TrangThaiDen) " +
                                               $"VALUES ('{DataTableBangSoLop.Rows[0][1].ToString()}','{DataTableBangSoLop.Rows[0][2].ToString()}','{DataTableBangSoLop.Rows[0][0].ToString()}'" +
                                               $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}','{DataTableDuLieuBaoCao.Rows[i][12].ToString()}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Hoàn Thành');" +
                                               $"DELETE FROM mabarcode WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }

                                        conn = new MySqlConnection(ConectionString);
                                        conn.Open();
                                        //try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Dispose();
                                            Debug.WriteLine("Update thành công");
                                        }
                                        //catch (System.Exception)
                                        //{
                                        //    conn.Close();
                                        //    conn.Dispose();
                                        //    Debug.WriteLine("Update thất bại");
                                        //}
                                    }
                                    //nếu thời gian kết thúc lớn hơn thời gian hiện tại và thời gian bắt đầu nhỏ hơn thời gian hiện tại --> đang trong quá trình phơi
                                    //insert 1 dòng data vào nhưng để trống cột ThoiGianKetThucQuaTrinh
                                    //sau đó Break
                                    else if (DateTime.Now < kvp.Value && ThoiGianBatDauCacLop[kvp.Key] < DateTime.Now)
                                    {
                                        //insert
                                        //if (double.Parse(kvp.Key) < TongSoLop)
                                        {
                                            //query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                            //    $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                            //    $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                            //    $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}',NULL,'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                            //    $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Đang Phơi');" +
                                            //    $"UPDATE mabarcode SET TrangThai='3' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                            query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham," +
                                                $"SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi" +
                                                $",ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo" +
                                                $",TrangThaiDen) " +
                                               $"VALUES ('{DataTableBangSoLop.Rows[0][1].ToString()}','{DataTableBangSoLop.Rows[0][2].ToString()}','{DataTableBangSoLop.Rows[0][0].ToString()}'" +
                                               $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}',NULL,'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Đang Phơi');" +
                                               $"UPDATE mabarcode SET TrangThai='3' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }
                                        //else
                                        //{
                                        //    query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                        //        $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                        //        $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                        //        $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                        //        $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}',NULL,'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                        //        $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Đang Phơi');" +
                                        //        $"UPDATE mabarcode SET TrangThai='3' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        //}

                                        conn = new MySqlConnection(ConectionString);
                                        conn.Open();
                                        //try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Dispose();
                                            Debug.WriteLine("Update thành công");
                                        }
                                        //catch (System.Exception)
                                        //{
                                        //    conn.Close();
                                        //    conn.Dispose();
                                        //    Debug.WriteLine("Update thất bại");
                                        //}
                                        break;
                                    }
                                    //nếu thời gian bắt đầu nhỏ hơn thời gian hiện tại, thì chỉ insert dòng dữ liệu để chờ đăng ký phơi 
                                    //sau đó Breaak
                                    else if (ThoiGianBatDauCacLop[kvp.Key] > DateTime.Now)
                                    {
                                        //insert
                                        //if (double.Parse(kvp.Key) < TongSoLop)
                                        {
                                            query = $"INSERT INTO dulieuvabaocao (MaBarCodeSanPham,SoLopHienTai,MaBarCodeLot,ThoiGianBatDauNhung) " +
                                                $"VALUES ('{DataTableBangSoLop.Rows[0][0].ToString()}',{kvp.Key},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}');" +
                                                $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }
                                        //else
                                        //{
                                        //    query = $"INSERT INTO dulieuvabaocao (MaBarCodeSanPham,SoLopHienTai,MaBarCodeLot,ThoiGianBatDauNhung) " +
                                        //        $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][2].ToString()}',{kvp.Key},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}');" +
                                        //        $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        //}

                                        conn = new MySqlConnection(ConectionString);
                                        conn.Open();
                                        //try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Dispose();
                                            Debug.WriteLine("Update thành công");
                                        }
                                        //catch (System.Exception)
                                        //{
                                        //    conn.Close();
                                        //    conn.Dispose();
                                        //    Debug.WriteLine("Update thất bại");
                                        //}
                                        break;
                                    }
                                }
                                else
                                {
                                    //kvp.Key, kvp.Value;
                                    //neu thời gian kết thúc thực tế của từng lớp mà nhỏ hơn thời gian hiện tại thì mới insert lớp đó vào DB, với các thông số đầy đủ
                                    if (DateTime.Now > kvp.Value)
                                    {
                                        query = $"DELETE FROM dulieuvabaocao WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}' and SoLopHienTai='{kvp.Key}'";
                                        conn = new MySqlConnection(ConectionString);
                                        conn.Open();
                                        //try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Dispose();
                                            Debug.WriteLine("Update thành công");
                                        }

                                        if (double.Parse(kvp.Key) < TongSoLop)
                                        {
                                            //query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                            //    $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                            //    $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                            //    $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}','{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}'" +
                                            //    $",'{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Chuyển Tiếp');" +
                                            //    $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                            query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham," +
                                                $"SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi" +
                                                $",ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo" +
                                                $",TrangThaiDen) " +
                                               $"VALUES ('{DataTableBangSoLop.Rows[0][1].ToString()}','{DataTableBangSoLop.Rows[0][2].ToString()}','{DataTableBangSoLop.Rows[0][0].ToString()}'" +
                                               $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}','{DataTableDuLieuBaoCao.Rows[i][12].ToString()}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Chuyển Tiếp');" +
                                               $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }
                                        else
                                        {
                                            //query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                            //    $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                            //    $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                            //    $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                            //    $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Hoàn Thành');" +
                                            //    $"DELETE FROM mabarcode WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                            query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham," +
                                                $"SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi" +
                                                $",ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo" +
                                                $",TrangThaiDen) " +
                                               $"VALUES ('{DataTableBangSoLop.Rows[0][1].ToString()}','{DataTableBangSoLop.Rows[0][2].ToString()}','{DataTableBangSoLop.Rows[0][0].ToString()}'" +
                                               $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}','{DataTableDuLieuBaoCao.Rows[i][12].ToString()}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Hoàn Thành');" +
                                               $"DELETE FROM mabarcode WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }

                                        conn = new MySqlConnection(ConectionString);
                                        conn.Open();
                                        //try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Dispose();
                                            Debug.WriteLine("Update thành công");
                                        }
                                        //catch (System.Exception)
                                        //{
                                        //    conn.Close();
                                        //    conn.Dispose();
                                        //    Debug.WriteLine("Update thất bại");
                                        //}
                                    }
                                    //nếu thời gian kết thúc lớn hơn thời gian hiện tại và thời gian bắt đầu nhỏ hơn thời gian hiện tại --> đang trong quá trình phơi
                                    //insert 1 dòng data vào nhưng để trống cột ThoiGianKetThucQuaTrinh
                                    //sau đó Break
                                    else if (DateTime.Now < kvp.Value && ThoiGianBatDauCacLop[kvp.Key] < DateTime.Now)
                                    {
                                        //insert
                                        //if (double.Parse(kvp.Key) < TongSoLop)
                                        {
                                            //query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                            //    $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                            //    $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                            //    $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                            //    $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}',NULL,'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                            //    $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Đang Phơi');" +
                                            //    $"UPDATE mabarcode SET TrangThai='3' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                            query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham," +
                                                $"SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung,ThoiGianBatDauPhoi" +
                                                $",ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo" +
                                                $",TrangThaiDen) " +
                                               $"VALUES ('{DataTableBangSoLop.Rows[0][1].ToString()}','{DataTableBangSoLop.Rows[0][2].ToString()}','{DataTableBangSoLop.Rows[0][0].ToString()}'" +
                                               $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                               $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}',NULL,'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                               $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Đang Phơi');" +
                                               $"UPDATE mabarcode SET TrangThai='3' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }
                                        //else
                                        //{
                                        //    query = $"INSERT INTO dulieuvabaocao (TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot" +
                                        //        $",ThoiGianBatDauNhung,ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen) " +
                                        //        $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][0].ToString()}','{DataTableDuLieuBaoCao.Rows[i][1].ToString()}','{DataTableDuLieuBaoCao.Rows[i][2].ToString()}'" +
                                        //        $",{kvp.Key},{ThoiGianKhoCuaLop[kvp.Key]},{TongSoLop},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}'" +
                                        //        $",'{ThoiGianBatDauCacLop[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}','{ThoiGianKetThucCacLopKeHoach[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}',NULL,'{DataTableDuLieuBaoCao.Rows[i][11].ToString()}'" +
                                        //        $",'{DataTableDuLieuBaoCao.Rows[i][12].ToString()}','{DataTableDuLieuBaoCao.Rows[i][13].ToString()}','{TenCatNhungHientai[kvp.Key]}','{TenCatNhungTiepTheo[kvp.Key]}','Đang Phơi');" +
                                        //        $"UPDATE mabarcode SET TrangThai='3' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        //}

                                        conn = new MySqlConnection(ConectionString);
                                        conn.Open();
                                        //try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Dispose();
                                            Debug.WriteLine("Update thành công");
                                        }
                                        //catch (System.Exception)
                                        //{
                                        //    conn.Close();
                                        //    conn.Dispose();
                                        //    Debug.WriteLine("Update thất bại");
                                        //}
                                        break;
                                    }
                                    //nếu thời gian bắt đầu nhỏ hơn thời gian hiện tại, thì chỉ insert dòng dữ liệu để chờ đăng ký phơi 
                                    //sau đó Breaak
                                    else if (ThoiGianBatDauCacLop[kvp.Key] > DateTime.Now)
                                    {
                                        //insert
                                        //if (double.Parse(kvp.Key) < TongSoLop)
                                        {
                                            query = $"INSERT INTO dulieuvabaocao (MaBarCodeSanPham,SoLopHienTai,MaBarCodeLot,ThoiGianBatDauNhung) " +
                                                $"VALUES ('{DataTableBangSoLop.Rows[0][0].ToString()}',{kvp.Key},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}');" +
                                                $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        }
                                        //else
                                        //{
                                        //    query = $"INSERT INTO dulieuvabaocao (MaBarCodeSanPham,SoLopHienTai,MaBarCodeLot,ThoiGianBatDauNhung) " +
                                        //        $"VALUES ('{DataTableDuLieuBaoCao.Rows[i][2].ToString()}',{kvp.Key},'{DataTableDuLieuBaoCao.Rows[i][6].ToString()}','{ThoiGianBatDauNhung[kvp.Key].ToString("yyyy-MM-dd HH:mm:ss")}');" +
                                        //        $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][6].ToString()}'";
                                        //}

                                        conn = new MySqlConnection(ConectionString);
                                        conn.Open();
                                        //try
                                        {
                                            MySqlCommand cmd = new MySqlCommand(query, conn);
                                            cmd.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Dispose();
                                            Debug.WriteLine("Update thành công");
                                        }
                                        //catch (System.Exception)
                                        //{
                                        //    conn.Close();
                                        //    conn.Dispose();
                                        //    Debug.WriteLine("Update thất bại");
                                        //}
                                        break;
                                    }
                                }

                            }
                            #endregion
                        }
                        catch { }
                    }
                    #endregion
                }
            }
            catch { }
        }


        string ConectionString;

        public UpdateData()
        {
            InitializeComponent();
            ConectionString = Properties.Settings.Default.juki_giamsatthoigiankhoConnectionString;
            try
            {
                #region Comment
                DataTable DataTableDuLieuBaoCao = new DataTable();
                DataTable DataTableBangSoLop = new DataTable();
                DateTime StartPhoi, KetThucKeHoach, KetThucThucTe;
                double TongSoLop = 0, LopHienTai = 0, ThoiGianPhoi = 0;
                string query = "";
                TimeSpan ThoiGianCongThem;
                MySqlConnection conn;
                DataTableDuLieuBaoCao.Clear();
                DataTableBangSoLop.Clear();

                conn = new MySqlConnection(ConectionString);

                Debug.WriteLine(ConectionString);
                conn.Open();
                //string query = "";
                //DataTable DataTableDuLieuBaoCao = new DataTable();
                //DataTable DataTableBangSoLop = new DataTable();

                query = $"select * from bangnhapsolop;SET SQL_SAFE_UPDATES = 0;";
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableBangSoLop);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }


                //if (!string.IsNullOrEmpty(txtLot.Text))
                //{
                //    if (checkBox1.Checked == true)
                //    {
                //        query = $"select * from dulieuvabaocao where ThoiGianBatDauPhoi>='{Convert.ToDateTime(TimeTO.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and ThoiGianBatDauPhoi<='{Convert.ToDateTime(TimeFROM.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                //    }
                //    else
                //    {
                //        query = $"select * from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                //    }
                //}
                //else
                //{
                //    if (checkBox1.Checked == true)
                //    {
                //        query = $"select * from dulieuvabaocao where ThoiGianBatDauPhoi>='{Convert.ToDateTime(TimeTO.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and ThoiGianBatDauPhoi<='{Convert.ToDateTime(TimeFROM.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and TrangThaiDen='Đã Khô'";
                //    }
                //    else
                //    {
                //        query = $"select * from dulieuvabaocao where TrangThaiDen='Đã Khô'";
                //    }
                //}

                if (!string.IsNullOrEmpty(txtLot.Text))
                {
                    query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                        $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                        $"from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                }
                else
                {
                    query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                        $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                        $"from dulieuvabaocao where TrangThaiDen='Đã Khô'";
                }
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableDuLieuBaoCao);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }

                dataGridView1.DataSource = DataTableDuLieuBaoCao;
                //dataGridView2.DataSource = DataTableBangSoLop;
                #endregion
            }
            catch { }
        }

        private void btnTruyVan_Click(object sender, EventArgs e)
        {
            try
            {
                #region Comment
                DataTable DataTableDuLieuBaoCao = new DataTable();
                DataTable DataTableBangSoLop = new DataTable();
                DateTime StartPhoi, KetThucKeHoach, KetThucThucTe;
                double TongSoLop = 0, LopHienTai = 0, ThoiGianPhoi = 0;
                string query = "";
                TimeSpan ThoiGianCongThem;
                MySqlConnection conn;
                DataTableDuLieuBaoCao.Clear();
                DataTableBangSoLop.Clear();

                conn = new MySqlConnection(ConectionString);

                Debug.WriteLine(ConectionString);
                conn.Open();
                //string query = "";
                //DataTable DataTableDuLieuBaoCao = new DataTable();
                //DataTable DataTableBangSoLop = new DataTable();

                query = $"select * from bangnhapsolop";
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableBangSoLop);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }


                //if (!string.IsNullOrEmpty(txtLot.Text))
                //{
                //    if (checkBox1.Checked == true)
                //    {
                //        query = $"select * from dulieuvabaocao where ThoiGianBatDauPhoi>='{Convert.ToDateTime(TimeTO.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and ThoiGianBatDauPhoi<='{Convert.ToDateTime(TimeFROM.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                //    }
                //    else
                //    {
                //        query = $"select * from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                //    }
                //}
                //else
                //{
                //    if (checkBox1.Checked == true)
                //    {
                //        query = $"select * from dulieuvabaocao where ThoiGianBatDauPhoi>='{Convert.ToDateTime(TimeTO.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and ThoiGianBatDauPhoi<='{Convert.ToDateTime(TimeFROM.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and TrangThaiDen='Đã Khô'";
                //    }
                //    else
                //    {
                //        query = $"select * from dulieuvabaocao where TrangThaiDen='Đã Khô'";
                //    }
                //}

                if (checkBoxTD.Checked == false)
                {
                    if (!string.IsNullOrEmpty(txtLot.Text))
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                    }
                    else
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where TrangThaiDen='Đã Khô'";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtLot.Text))
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTD.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                            $" and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTD.Text).ToString("yyyy-MM-dd 23:59:59")}' and TrangThaiDen='Đã Khô'";
                    }
                    else
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTD.Text).ToString("yyyy-MM-dd 00:00:00")}' " +
                            $"and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTD.Text).ToString("yyyy-MM-dd 23:59:59")}' and TrangThaiDen='Đã Khô'";
                    }
                }
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableDuLieuBaoCao);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }

                dataGridView1.DataSource = DataTableDuLieuBaoCao;
                //dataGridView2.DataSource = DataTableBangSoLop;
                #endregion
            }
            catch { }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show(DataTableDuLieuBaoCao.Rows.Count.ToString());
                #region Comment
                DataTable DataTableDuLieuBaoCao = new DataTable();
                DataTable DataTableBangSoLop = new DataTable();
                DateTime StartPhoi, KetThucKeHoach, KetThucThucTe;
                double TongSoLop = 0, LopHienTai = 0, ThoiGianPhoi = 0;
                string query = "";
                TimeSpan ThoiGianCongThem;
                MySqlConnection conn;
                DataTableDuLieuBaoCao.Clear();
                DataTableBangSoLop.Clear();

                conn = new MySqlConnection(ConectionString);

                Debug.WriteLine(ConectionString);
                conn.Open();
                //string query = "";
                //DataTable DataTableDuLieuBaoCao = new DataTable();
                //DataTable DataTableBangSoLop = new DataTable();

                query = $"select * from bangnhapsolop";
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableBangSoLop);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }


                //if (!string.IsNullOrEmpty(txtLot.Text))
                //{
                //    if (checkBox1.Checked == true)
                //    {
                //        query = $"select * from dulieuvabaocao where ThoiGianBatDauPhoi>='{Convert.ToDateTime(TimeTO.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and ThoiGianBatDauPhoi<='{Convert.ToDateTime(TimeFROM.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                //    }
                //    else
                //    {
                //        query = $"select * from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                //    }
                //}
                //else
                //{
                //    if (checkBox1.Checked == true)
                //    {
                //        query = $"select * from dulieuvabaocao where ThoiGianBatDauPhoi>='{Convert.ToDateTime(TimeTO.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and ThoiGianBatDauPhoi<='{Convert.ToDateTime(TimeFROM.Text).ToString("yyyy-MM-dd HH:mm:ss")}' and TrangThaiDen='Đã Khô'";
                //    }
                //    else
                //    {
                //        query = $"select * from dulieuvabaocao where TrangThaiDen='Đã Khô'";
                //    }
                //}

                //if (!string.IsNullOrEmpty(txtLot.Text))
                //{
                //    query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                //        $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                //        $"from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                //}
                //else
                //{
                //    query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                //        $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                //        $"from dulieuvabaocao where TrangThaiDen='Đã Khô'";
                //}
                if (checkBoxTD.Checked == false)
                {
                    if (!string.IsNullOrEmpty(txtLot.Text))
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and TrangThaiDen='Đã Khô'";
                    }
                    else
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where TrangThaiDen='Đã Khô'";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtLot.Text))
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where MaBarCodeLot='{txtLot.Text.Trim()}' and ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTD.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                            $" and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTD.Text).ToString("yyyy-MM-dd 23:59:59")}' and TrangThaiDen='Đã Khô'";
                    }
                    else
                    {
                        query = $"select enSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFromTD.Text).ToString("yyyy-MM-dd 00:00:00")}' " +
                            $"and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeToTD.Text).ToString("yyyy-MM-dd 23:59:59")}' and TrangThaiDen='Đã Khô'";
                    }
                }
                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableDuLieuBaoCao);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }

                dataGridView1.DataSource = DataTableDuLieuBaoCao;
                //dataGridView2.DataSource = DataTableBangSoLop;
                #endregion
                if (DataTableDuLieuBaoCao != null || DataTableDuLieuBaoCao.Rows.Count > 0)
                {
                    for (int i = 0; i < DataTableDuLieuBaoCao.Rows.Count; i++)
                    {

                        LopHienTai = Int16.Parse(DataTableDuLieuBaoCao.Rows[i][4].ToString());
                        ThoiGianPhoi = Int16.Parse(DataTableDuLieuBaoCao.Rows[i][5].ToString());
                        TongSoLop = Int16.Parse(DataTableDuLieuBaoCao.Rows[i][6].ToString());

                        StartPhoi = Convert.ToDateTime(DataTableDuLieuBaoCao.Rows[i][9].ToString());
                        KetThucKeHoach = Convert.ToDateTime(DataTableDuLieuBaoCao.Rows[i][10].ToString());
                        ThoiGianCongThem = new System.TimeSpan(0, int.Parse(DataTableDuLieuBaoCao.Rows[i][5].ToString()), 5, 0);

                        if (DateTime.Now > KetThucKeHoach)//cot thời gian kho của lớp, cột index 5 trong bang dulieubaocao
                        {
                            #region update thời gian kết thúc quá trình
                            // Thêm một khoảng thời gian.
                            //lấy thời gian bắt đầu phơi, cọng thêm thời gian phơi, để update thời gian kết thúc quá trình
                            // Một khoảng thời gian. 
                            // 0 giờ + 5 phút
                            //ThoiGianCongThem = new System.TimeSpan(0, int.Parse(DataTableDuLieuBaoCao.Rows[i][5].ToString()), 5, 0);
                            DateTime ThoiGianLog = Convert.ToDateTime(DataTableDuLieuBaoCao.Rows[i][9].ToString()).Add(ThoiGianCongThem);

                            Debug.WriteLine("Cap nhat thoi gian ket thuc qua trinh");

                            //Kiểm tra xem nếu số lớp chưa phải là lớp cuối cùng thì update cot TrangThaiDen = Chuyển Tiếp . nếu là lớp cuối cùng thì updata cột TrangThaiDen = Hoàn Thành
                            if (Double.Parse(DataTableDuLieuBaoCao.Rows[i][4].ToString()) < TongSoLop)
                            {
                                query = $"UPDATE dulieuvabaocao SET ThoiGianKetThucQuaTrinh='{ThoiGianLog.ToString("yyyy-MM-dd HH:mm:ss")}',TrangThaiDen='{"Chuyển Tiếp"}' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][7].ToString()}';" +
                                    $"UPDATE mabarcode SET TrangThai='0' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][7].ToString()}'";
                            }
                            else
                            {
                                query = $"UPDATE dulieuvabaocao SET ThoiGianKetThucQuaTrinh='{ThoiGianLog.ToString("yyyy-MM-dd HH:mm:ss")}',TrangThaiDen='{"Hoàn Thành"}' WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][7].ToString()}';" +
                                    $"DELETE FROM mabarcode WHERE MaBarCodeLot='{DataTableDuLieuBaoCao.Rows[i][7].ToString()}'";
                            }

                            conn = new MySqlConnection(ConectionString);
                            conn.Open();
                            try
                            {
                                MySqlCommand cmd = new MySqlCommand(query, conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                conn.Dispose();
                                Debug.WriteLine("Update thành công");
                            }
                            catch (System.Exception)
                            {
                                conn.Close();
                                conn.Dispose();
                                Debug.WriteLine("Update thất bại");
                            }
                            #endregion
                        }
                        else
                        {
                            Debug.WriteLine("Chua Phoi xong");
                        }

                    }
                }
            }
            catch { }
        }

        private void UpdateData_Load(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                #region Comment
                DataTable DataTableDuLieuBaoCao = new DataTable();
                DataTable DataTableBangSoLop = new DataTable();
                DateTime StartPhoi, KetThucKeHoach, KetThucThucTe;
                double TongSoLop = 0, LopHienTai = 0, ThoiGianPhoi = 0;
                string query = "";
                TimeSpan ThoiGianCongThem;
                MySqlConnection conn;
                DataTableDuLieuBaoCao.Clear();
                DataTableBangSoLop.Clear();

                conn = new MySqlConnection(ConectionString);

                Debug.WriteLine(ConectionString);
                conn.Open();

                if (checkBoxCT.Checked == false)
                {
                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        query = $"select TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where MaBarCodeLot='{textBox2.Text.Trim()}'";
                    }
                    else
                    {
                        query = $"select TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(textBox2.Text))
                    {
                        query = $"select TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao where MaBarCodeLot='{textBox2.Text.Trim()}' and (ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFROMCT.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeTOCT.Text).ToString("yyyy-MM-dd 23:59:59")}')";
                    }
                    else
                    {
                        query = $"select TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeSanPham,SoLopHienTai,SoThoiGianKho,SoLopKetThuc,MaBarCodeLot,ThoiGianBatDauNhung" +
                            $",ThoiGianBatDauPhoi,ThoiGianKetThucKho,ThoiGianKetThucQuaTrinh,MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen " +
                            $"from dulieuvabaocao Where ThoiGianBatDauNhung >= '{DateTime.Parse(TimeFROMCT.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianBatDauNhung <= '{DateTime.Parse(TimeTOCT.Text).ToString("yyyy-MM-dd 23:59:59")}'";
                    }
                }

                try
                {
                    MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                    Adapter.Fill(DataTableDuLieuBaoCao);
                    conn.Close();
                    conn.Dispose();
                }
                catch (System.Exception)
                {
                    DataTableDuLieuBaoCao = null;
                    conn.Close();
                    conn.Dispose();
                }

                dataGridView2.DataSource = DataTableDuLieuBaoCao;
                //dataGridView2.DataSource = DataTableBangSoLop;
                #endregion
            }
            catch { }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int current_row = ((DataGridView)sender).CurrentCell.RowIndex;//lay index cua dong hien tai

                string query = "";
                MySqlConnection conn;

                conn = new MySqlConnection(ConectionString);

                query = $"Update dulieuvabaocao SET TenSanPhamTiengViet='{((DataGridView)sender).Rows[current_row].Cells[0].Value?.ToString()}',TenSanPhamTiengAnh='{((DataGridView)sender).Rows[current_row].Cells[1].Value?.ToString()}',MaBarCodeSanPham='{((DataGridView)sender).Rows[current_row].Cells[2].Value?.ToString()}'" +
                   $",SoLopHienTai={((DataGridView)sender).Rows[current_row].Cells[3].Value?.ToString()},SoThoiGianKho={((DataGridView)sender).Rows[current_row].Cells[4].Value?.ToString()}" +
                   $",SoLopKetThuc={((DataGridView)sender).Rows[current_row].Cells[5].Value?.ToString()},MaBarCodeLot='{((DataGridView)sender).Rows[current_row].Cells[6].Value?.ToString()}'" +
                   $",ThoiGianBatDauNhung='{DateTime.Parse(((DataGridView)sender).Rows[current_row].Cells[7].Value?.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'" +
                   $",ThoiGianBatDauPhoi='{DateTime.Parse(((DataGridView)sender).Rows[current_row].Cells[8].Value?.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'" +
                   $",ThoiGianKetThucKho='{DateTime.Parse(((DataGridView)sender).Rows[current_row].Cells[9].Value?.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'" +
                   $",ThoiGianKetThucQuaTrinh='{DateTime.Parse(((DataGridView)sender).Rows[current_row].Cells[10].Value?.ToString()).ToString("yyyy-MM-dd HH:mm:ss")}'" +
                   $",MaBarCodeXe='{((DataGridView)sender).Rows[current_row].Cells[11].Value?.ToString()}',MaBarCodeCot='{((DataGridView)sender).Rows[current_row].Cells[12].Value?.ToString()}'" +
                   $",MaBarCodeNguoi='{((DataGridView)sender).Rows[current_row].Cells[13].Value?.ToString()}',TenCatNhungHienTai='{((DataGridView)sender).Rows[current_row].Cells[14].Value?.ToString()}'" +
                   $",TenCatNhungTiepTheo='{((DataGridView)sender).Rows[current_row].Cells[15].Value?.ToString()}',TrangThaiDen='{((DataGridView)sender).Rows[current_row].Cells[16].Value?.ToString()}' " +
                   $"where MaBarCodeLot='{((DataGridView)sender).Rows[current_row].Cells[6].Value?.ToString()}' and SoLopHienTai={((DataGridView)sender).Rows[current_row].Cells[3].Value?.ToString()}";

                conn = new MySqlConnection(ConectionString);
                conn.Open();

                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    Debug.WriteLine($"Update LOT {((DataGridView)sender).Rows[current_row].Cells[6].Value?.ToString()} thành công | {current_row}");
                }
                catch (System.Exception)
                {
                    conn.Close();
                    conn.Dispose();
                    Debug.WriteLine("Update thất bại");
                }
            }
            catch { }
        }
    }
}
