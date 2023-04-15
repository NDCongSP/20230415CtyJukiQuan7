using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySanXuatJuKi
{
    public partial class Report : Form
    {
        string ConectionString = "";
        string _Path = "";
        string query;
        public Report()
        {
            InitializeComponent();
            ConectionString = Properties.Settings.Default.juki_giamsatthoigiankhoConnectionString;
            Debug.WriteLine(ConectionString);

            _Path = Directory.GetCurrentDirectory();

            comboBox1.Text = comboBox1.Items[0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTableDuLieuBaoCao = new DataTable();
                MySqlConnection conn;

                DataTableDuLieuBaoCao.Clear();

                if (string.IsNullOrEmpty(comboBox2.Text))
                {
                    query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi,ThoiGianKetThucQuaTrinh,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiCaiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TimeFrom.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TimeTo.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";
                }
                else
                {
                    if (comboBox1.Text == "LOT")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi,ThoiGianKetThucQuaTrinh,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiCaiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeLot = '{comboBox2.Text}' and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TimeFrom.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                       $" and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TimeTo.Text).ToString("yyyy-MM-dd 23:59:59")}' and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";
                    }
                    else if (comboBox1.Text == "Sản Phẩm")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi,ThoiGianKetThucQuaTrinh,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiCaiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeSanPham = '{comboBox2.Text}' " +
                       $"and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TimeFrom.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TimeTo.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";
                    }
                }

                conn = new MySqlConnection(ConectionString);
                conn.Open();
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
                dataGridViewReport.DataSource = DataTableDuLieuBaoCao;
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable DataTableDuLieuBaoCao = new DataTable();
                MySqlConnection conn;
                DataTableDuLieuBaoCao.Clear();

                comboBox2.Items.Clear();
                comboBox2.Text = "";

                if (comboBox1.Text == "All")
                {
                    comboBox2.Items.Clear();
                }
                else if (comboBox1.Text == "LOT")
                {
                    conn = new MySqlConnection(ConectionString);
                    conn.Open();
                    //string query = "";
                    //DataTable DataTableDuLieuBaoCao = new DataTable();
                    //DataTable DataTableBangSoLop = new DataTable();

                    string query = $"SELECT MaBarCodeLot FROM dulieuvabaocao group by MaBarCodeLot;";
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
                    if (DataTableDuLieuBaoCao != null && DataTableDuLieuBaoCao.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataTableDuLieuBaoCao.Rows.Count; i++)
                        {
                            comboBox2.Items.Add(DataTableDuLieuBaoCao.Rows[i][0].ToString());
                        }
                    }
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
                else
                {
                    conn = new MySqlConnection(ConectionString);
                    conn.Open();
                    //string query = "";
                    //DataTable DataTableDuLieuBaoCao = new DataTable();
                    //DataTable DataTableBangSoLop = new DataTable();

                    string query = $"SELECT MaBarCodeSanPham FROM dulieuvabaocao group by MaBarCodeSanPham;";
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
                    if (DataTableDuLieuBaoCao != null && DataTableDuLieuBaoCao.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataTableDuLieuBaoCao.Rows.Count; i++)
                        {
                            comboBox2.Items.Add(DataTableDuLieuBaoCao.Rows[i][0].ToString());
                        }
                    }
                    comboBox2.Text = comboBox2.Items[0].ToString();
                }
            }
            catch { }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                #region Lọc Data
                DataTable DataTableDuLieuBaoCao = new DataTable();
                MySqlConnection conn;

                DataTableDuLieuBaoCao.Clear();

                if (string.IsNullOrEmpty(comboBox2.Text))
                {
                    query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi,ThoiGianKetThucQuaTrinh,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiCaiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TimeFrom.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TimeTo.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";
                }
                else
                {
                    if (comboBox1.Text == "LOT")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi,ThoiGianKetThucQuaTrinh,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiCaiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeLot = '{comboBox2.Text}' and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TimeFrom.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                       $" and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TimeTo.Text).ToString("yyyy-MM-dd 23:59:59")}' and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";
                    }
                    else if (comboBox1.Text == "Sản Phẩm")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi,ThoiGianKetThucQuaTrinh,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiCaiDat, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeSanPham = '{comboBox2.Text}' " +
                       $"and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TimeFrom.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TimeTo.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";
                    }
                }

                conn = new MySqlConnection(ConectionString);
                conn.Open();
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
                #endregion

                ExportExcel(TimeFrom.Text, TimeTo.Text, DataTableDuLieuBaoCao);
            }
            catch { }
        }

        private void ExportExcel(string FromTime, string ToTime, DataTable dt)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "Report_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");
                saveDialog.Filter = "Excel(.xlsx)|*.xlsx";

                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    var newFile = new FileInfo(exportFilePath);
                    //D:\ATPro\DangLam\31102019 QuanLySanXuatJuKiOK\QuanLySanXuatJuKi\QuanLySanXuatJuKi\QuanLySanXuatJuKi\bin\Debug\BAO CAO
                    //var fs = File.Open($"D:\\ATPro\\DangLam\\31102019 QuanLySanXuatJuKiOK\\QuanLySanXuatJuKi\\QuanLySanXuatJuKi\\QuanLySanXuatJuKi\\bin\\Debug\\BAO CAO\\Template.xlsx", FileMode.OpenOrCreate);
                    var fs = File.Open($"{_Path}\\BAO CAO\\Template.xlsx", FileMode.OpenOrCreate);
                    using (var package = new ExcelPackage(fs))
                    {
                        //ghet sheet
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];


                        //vung bat dau dien data
                        worksheet.Cells["A5"].LoadFromDataTable(dt,false);
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Font.Size = 11;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Fill.BackgroundColor.SetColor(Color.White);

                        //toa border
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                        var modelCells = worksheet.Cells["A5"];
                        var modelRows = dt.Rows.Count + 4;
                        string modelRange = "A5:Q" + modelRows.ToString();
                        var modelTable = worksheet.Cells[modelRange];

                        // Assign borders
                        modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        modelTable.Style.Font.Size = 11;
                        modelTable.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        modelTable.Style.Fill.BackgroundColor.SetColor(Color.White);

                        //worksheet.Cells["A1"].Style.Font.Size = 20;
                        //worksheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        //worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(Color.AliceBlue);
                        worksheet.Cells["F2"].Value = $"Từ ngày: {FromTime}  Đến ngày: {ToTime}";

                        //worksheet.Cells["A1:L1"].Merge = true;
                        //worksheet.Cells["A1"].Value = $"{TieuDe}";
                        //worksheet.Cells["A1"].Style.Font.Bold = true;
                        //worksheet.Cells["A1"].Style.Font.Size = 30;

                        //worksheet.Cells["A2:A3"].Merge = true;
                        //worksheet.Cells["A2"].Value = $"BATCH NO";
                        //worksheet.Cells["A2"].Style.Font.Bold = true;
                        //worksheet.Cells["A2"].Style.Font.Size = 13;

                        //worksheet.Cells[worksheet.Dimension.Address].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Font.Bold = true;
                        //worksheet.Cells[worksheet.Dimension.Address].Style.Font.Name = "Segoe UI";

                        // worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();


                        worksheet.Cells.AutoFitColumns();
                        worksheet.Protection.IsProtected = false;
                        worksheet.Protection.AllowSelectLockedCells = false;
                        package.SaveAs(newFile);
                        fs.Dispose();

                    }
                }
            }
            catch { }
        }
    }
}
