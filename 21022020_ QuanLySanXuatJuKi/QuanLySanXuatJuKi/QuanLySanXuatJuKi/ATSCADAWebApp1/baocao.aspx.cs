using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLySanXuatJuKi.DAO;
using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATSCADAWebApp
{
    public partial class baocao : System.Web.UI.Page
    {
        #region Main Static Objects - THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED OR MODIFIED
        /// <summary>
        /// THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED
        /// </summary>
        static iDriverWeb Driver = new iDriverWeb();
        static List<Control> allControls = new List<Control>();
        static SetDriver SD = new SetDriver();
        #endregion
        MySQL_Method MysqlCMD = new MySQL_Method();//tao doi tuong mysql cmd
        xuatexel exl = new xuatexel();
        // string ChuoiData = "";
        static DataTable dt = new DataTable();
        static DataTable dt1 = new DataTable();
        string texttt = "ALL";

        string ConectionString = "server=localhost;user id=root;password=100100;persistsecurityinfo=True;database=juki_giamsatthoigiankho";
        string _Path = "";
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Basic Operations - THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED  OR MODIFIED
            /// <summary>
            /// THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED
            /// </summary>
            //Attach Realtime driver for all iControls            
            allControls.Clear();
            SD.SetDriverForiWebTools(Page.Controls, allControls, Driver);
            #endregion

            #region Authentication Settings - THESE LINES ARE FROM ATPROCORP, SHOULD BE MODIFIED
            //If this page is only for Admin Users
            //if ((string)Session["Role"] != "Admin")
            //{
            //  //  Response.Redirect("~/Login.aspx");
            //}
            ////If this page is for Admin and Operator Users
            //if ((string)Session["Role"] != "Operator" && (string)Session["Role"] != "Admin")
            //{
            //   // Response.Redirect("~/Login.aspx");
            //}
            //if ((string)Session["Login"] != "True")
            //{
            //     Response.Redirect("~/Default.aspx");
            //}
            #endregion
            List<BangNhapSoLop> list = new List<BangNhapSoLop>();
            list = BangNhapSoLopDAO.Instance.GetListBatchNumber();
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn;
                dt.Clear();
                #region Query data
                if (DropDownList1.Text == "ALL" || DropDownList1.Text == "all" || DropDownList1.Text == "")
                {
                    if (TextBox2.Text != "" && TextBox1.Text != "")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc as SoLopTieuChuan,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung as ThoiDiemBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi as ThoiDiemBatDauPhoi,ThoiGianKetThucQuaTrinh as ThoiDiemKetThucPhoi,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiTieuChuan, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TextBox2.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TextBox1.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";

                        conn = new MySqlConnection(ConectionString);
                        conn.Open();
                        try
                        {
                            MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                            Adapter.Fill(dt);
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (System.Exception)
                        {
                            dt = null;
                            conn.Close();
                            conn.Dispose();
                        }

                        if (dt != null && dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('CHECK IN THE TIME DATE!!!!');</script>");
                        }
                    }
                }
                else if (DropDownList1.Text == "Lọc Theo Mã Sản Phẩm")
                {
                    if (TextBox2.Text != "" && TextBox1.Text != "")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc as SoLopTieuChuan,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung as ThoiDiemBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi as ThoiDiemBatDauPhoi,ThoiGianKetThucQuaTrinh as ThoiDiemKetThucPhoi,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiTieuChuan, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeSanPham = '{TextBox3.Text}' " +
                       $"and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TextBox2.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TextBox1.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";

                        conn = new MySqlConnection(ConectionString);
                        conn.Open();
                        try
                        {
                            MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                            Adapter.Fill(dt);
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (System.Exception)
                        {
                            dt = null;
                            conn.Close();
                            conn.Dispose();
                        }

                        if (dt != null && dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('CHECK IN THE TIME DATE!!!!');</script>");
                        }
                    }
                }
                else if (DropDownList1.Text == "Lọc Theo Mã LOT")
                {
                    if (TextBox2.Text != "" && TextBox1.Text != "" && TextBox3.Text.Contains("WP"))
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                         $"SoLopKetThuc as SoLopTieuChuan,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung as ThoiDiemBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                         $"ThoiGianBatDauPhoi as ThoiDiemBatDauPhoi,ThoiGianKetThucQuaTrinh as ThoiDiemKetThucPhoi,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiTieuChuan, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                        $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeLot = '{TextBox3.Text}' and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TextBox2.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                      $" and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TextBox1.Text).ToString("yyyy-MM-dd 23:59:59")}' and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";

                        conn = new MySqlConnection(ConectionString);
                        conn.Open();
                        try
                        {
                            MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                            Adapter.Fill(dt);
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (System.Exception)
                        {
                            dt = null;
                            conn.Close();
                            conn.Dispose();
                        }

                        if (dt != null && dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('CHECK IN THE TIME DATE!!!!');</script>");
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('TIMES SELECT,PLEASE !!!!');</script>");
                }
                #endregion
            }
            catch { }
        }

        private void ExportExcel(string FromTime, string ToTime, DataTable dt)
        {
            try
            {
                _Path = "C:\\BAO CAO\\";
                if (!Directory.Exists(_Path))
                {
                    _Path = "C:\\BAO CAO\\";
                    if (!Directory.Exists(_Path))
                    {
                        _Path = "C:\\";
                    }
                }

                //Check availability
                if (File.Exists(_Path + "Report" + ".xlsx"))
                {
                    try
                    {
                        File.Delete(_Path + "Report" + ".xlsx");
                    }
                    catch { }
                }

                try
                {

                    foreach (var item in System.Diagnostics.Process.GetProcessesByName("Excel"))
                    {
                        if (item.MainWindowTitle == "Template.xlsx - Excel")
                        {
                            item.Kill();
                            Thread.Sleep(500);
                        }
                    }
                }
                catch { }

                string exportFilePath = $"C:\\BAO CAO\\Report.xlsx";
                var newFile = new FileInfo(exportFilePath);
                //D:\ATPro\DangLam\31102019 QuanLySanXuatJuKiOK\QuanLySanXuatJuKi\QuanLySanXuatJuKi\QuanLySanXuatJuKi\bin\Debug\BAO CAO
                //var fs = File.Open($"D:\\ATPro\\DangLam\\31102019 QuanLySanXuatJuKiOK\\QuanLySanXuatJuKi\\QuanLySanXuatJuKi\\QuanLySanXuatJuKi\\bin\\Debug\\BAO CAO\\Template.xlsx", FileMode.OpenOrCreate);
                var fs = File.Open($"{_Path}\\Template.xlsx", FileMode.Open);
                using (var package = new ExcelPackage())
                {
                    //ghet sheet
                    package.Load(fs);
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];


                    //vung bat dau dien data
                    worksheet.Cells["A5"].LoadFromDataTable(dt, false);
                    //toa border
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


                    worksheet.Cells.AutoFitColumns();
                    worksheet.Protection.IsProtected = false;
                    worksheet.Protection.AllowSelectLockedCells = false;
                    package.SaveAs(newFile);
                    fs.Dispose();

                }

            }
            catch { }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Button80_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn;
                dt.Clear();
                #region Query data
                if (DropDownList1.Text == "ALL" || DropDownList1.Text == "all" || DropDownList1.Text == "")
                {
                    if (TextBox2.Text != "" && TextBox1.Text != "")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc as SoLopTieuChuan,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung as ThoiDiemBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi as ThoiDiemBatDauPhoi,ThoiGianKetThucQuaTrinh as ThoiDiemKetThucPhoi,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiTieuChuan, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TextBox2.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TextBox1.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";

                        conn = new MySqlConnection(ConectionString);
                        conn.Open();
                        try
                        {
                            MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                            Adapter.Fill(dt);
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (System.Exception)
                        {
                            dt = null;
                            conn.Close();
                            conn.Dispose();
                        }

                        if (dt != null && dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('CHECK IN THE TIME DATE!!!!');</script>");
                        }
                    }
                }
                else if (DropDownList1.Text == "Lọc Theo Mã Sản Phẩm")
                {
                    if (TextBox2.Text != "" && TextBox1.Text != "")
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                        $"SoLopKetThuc as SoLopTieuChuan,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung as ThoiDiemBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                        $"ThoiGianBatDauPhoi as ThoiDiemBatDauPhoi,ThoiGianKetThucQuaTrinh as ThoiDiemKetThucPhoi,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiTieuChuan, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                       $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeSanPham = '{TextBox3.Text}' " +
                       $"and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TextBox2.Text).ToString("yyyy-MM-dd 00:00:00")}' and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TextBox1.Text).ToString("yyyy-MM-dd 23:59:59")}' " +
                       $"and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";

                        conn = new MySqlConnection(ConectionString);
                        conn.Open();
                        try
                        {
                            MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                            Adapter.Fill(dt);
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (System.Exception)
                        {
                            dt = null;
                            conn.Close();
                            conn.Dispose();
                        }

                        if (dt != null && dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('CHECK IN THE TIME DATE!!!!');</script>");
                        }
                    }
                }
                else if (DropDownList1.Text == "Lọc Theo Mã LOT")
                {
                    if (TextBox2.Text != "" && TextBox1.Text != "" && TextBox3.Text.Contains("WP"))
                    {
                        query = $"SELECT MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,MaBarCodeXe as Xe,MaBarCodeCot as Cot," +
                         $"SoLopKetThuc as SoLopTieuChuan,SoLopHienTai,TenCatNhungHienTai as TenCatNhung,ThoiGianBatDauNhung as ThoiDiemBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi, ThoiGianBatDauNhung) as ThoiGianNhung," +
                         $"ThoiGianBatDauPhoi as ThoiDiemBatDauPhoi,ThoiGianKetThucQuaTrinh as ThoiDiemKetThucPhoi,MAKETIME(sothoigiankho, 0, 0) as ThoiGianPhoiTieuChuan, TIMEDIFF(ThoiGianKetThucQuaTrinh, ThoiGianBatDauPhoi) as ThoiGianPhoiThucTe," +
                        $"MaBarCodeNguoi as NhanVien,TrangThaiDen as TrangThai FROM dulieuvabaocao " +
                       $"where MaBarCodeLot = '{TextBox3.Text}' and ThoiGianKetThucQuaTrinh >='{DateTime.Parse(TextBox2.Text).ToString("yyyy-MM-dd 00:00:00")}'" +
                      $" and ThoiGianKetThucQuaTrinh <='{DateTime.Parse(TextBox1.Text).ToString("yyyy-MM-dd 23:59:59")}' and (TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành');";

                        conn = new MySqlConnection(ConectionString);
                        conn.Open();
                        try
                        {
                            MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
                            Adapter.Fill(dt);
                            conn.Close();
                            conn.Dispose();
                        }
                        catch (System.Exception)
                        {
                            dt = null;
                            conn.Close();
                            conn.Dispose();
                        }

                        if (dt != null && dt.Rows.Count != 0)
                        {
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('CHECK IN THE TIME DATE!!!!');</script>");
                        }
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('TIMES SELECT,PLEASE !!!!');</script>");
                }
                #endregion

                if (dt.Rows.Count != 0)
                {
                    //tao file excel

                    ExportExcel(TextBox2.Text, TextBox1.Text, dt);

                    string tye = string.Empty;
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = tye;
                    Response.AddHeader("content-disposition", "attachment; filename= REPORT.xlsx");
                    Response.TransmitFile(@"C:\BAO CAO\Report.xlsx");

                    Response.Flush(); //
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Lỗi, vui lòng kiểm tra lại!');</script>");
                }
            }
            catch
            { Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Lỗi, vui lòng kiểm tra lại!');</script>"); }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            string[] catmang = new string[2];
            catmang = Calendar2.SelectedDate.ToString("yyyy-MM-dd HH:mm:ss").Split(' ');
            TextBox1.Text = catmang[0] + " 23:59:59";
            Calendar2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MySqlConnection conn;
            //dt.Clear();

            //DropDownList2.Items.Clear();
            //DropDownList2.Text = "";

            //if (DropDownList1.Text == "ALL" || DropDownList1.Text == "all" || DropDownList1.Text == "")
            //{
            //    DropDownList2.Items.Clear();
            //}
            //else if (DropDownList1.Text == "Lọc Theo Mã LOT")
            //{
            //    conn = new MySqlConnection(ConectionString);
            //    conn.Open();
            //    //string query = "";
            //    //DataTable dt = new DataTable();
            //    //DataTable DataTableBangSoLop = new DataTable();

            //    string query = $"SELECT MaBarCodeLot FROM dulieuvabaocao group by MaBarCodeLot;";
            //    try
            //    {
            //        MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
            //        Adapter.Fill(dt);
            //        conn.Close();
            //        conn.Dispose();
            //    }
            //    catch (System.Exception)
            //    {
            //        dt = null;
            //        conn.Close();
            //        conn.Dispose();
            //    }
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            DropDownList2.Items.Add(dt.Rows[i][0].ToString());
            //        }
            //    }
            //    DropDownList2.Text = DropDownList2.Items[0].ToString();
            //}
            //else
            //{
            //    conn = new MySqlConnection(ConectionString);
            //    conn.Open();
            //    //string query = "";
            //    //DataTable dt = new DataTable();
            //    //DataTable DataTableBangSoLop = new DataTable();

            //    string query = $"SELECT MaBarCodeSanPham FROM dulieuvabaocao group by MaBarCodeSanPham;";
            //    try
            //    {
            //        MySqlDataAdapter Adapter = new MySqlDataAdapter(query, conn);
            //        Adapter.Fill(dt);
            //        conn.Close();
            //        conn.Dispose();
            //    }
            //    catch (System.Exception)
            //    {
            //        dt = null;
            //        conn.Close();
            //        conn.Dispose();
            //    }
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            DropDownList2.Items.Add(dt.Rows[i][0].ToString());
            //        }
            //    }
            //    DropDownList2.Text = DropDownList2.Items[0].ToString();
            //}
            //Debug.WriteLine(DropDownList2.Items.Count);
            //UpdatePanel1.Update();
        }
    }
}