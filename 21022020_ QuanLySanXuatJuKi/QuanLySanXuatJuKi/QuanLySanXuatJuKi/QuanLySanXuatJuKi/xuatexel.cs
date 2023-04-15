using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Web;
using excel=  Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;

namespace QuanLySanXuatJuKi
{
    public class xuatexel
    {
        public void Export_alarm(DataTable dt, string thoigian, string title)
        {
            //try

            //{


                //Tạo các đối tượng Excel

                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

                Microsoft.Office.Interop.Excel.Workbooks oBooks;

                Microsoft.Office.Interop.Excel.Sheets oSheets;

                Microsoft.Office.Interop.Excel.Workbook oBook;

                Microsoft.Office.Interop.Excel.Worksheet oSheet;

                //Tạo mới một Excel WorkBook 

                oExcel.Visible = false;

                oExcel.DisplayAlerts = false;

                oExcel.Application.SheetsInNewWorkbook = 1;

                oBooks = oExcel.Workbooks;

            // oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            //  oBook = oExcel.Workbooks.Open(@"C:\BAO CAO\PMDataReport.xls");
            string rootDir = AppDomain.CurrentDomain.BaseDirectory;
                oBook = oExcel.Workbooks.Open(rootDir+ "BAO CAO\\PMDataReport - Copy.xls");


                oSheets = oBook.Worksheets;

                oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

                //oSheet.Name = sheetName;

                // Tạo phần đầu nếu muốn

                Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "Q1");

                head.MergeCells = true;

                head.Value2 = title;

                head.Font.Bold = true;

                head.Font.Name = "Cambria";

                head.Font.Size = "18";

                head.Font.ColorIndex = 30;
                head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Tạo tiêu đề cột 
                Microsoft.Office.Interop.Excel.Range c10 = oSheet.get_Range("A2", "Q2");
                c10.MergeCells = true;
                c10.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                c10.Value2 = thoigian;
               // c10.ColumnWidth = 15.0;



                //Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

                //cl1.Value2 = "Thời Gian Kết Thúc Quá Trình";

                //cl1.ColumnWidth = 20.0;

                //Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

                //cl2.Value2 = "Mã Sản Phẩm";

                //cl2.ColumnWidth = 20.0;

                //Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

                //cl3.Value2 = "Tên Sản Phẩm Tiếng Anh";

                //cl3.ColumnWidth = 30.0;
                //Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

                //cl4.Value2 = "Tên Sản Phẩm Tiếng Việt";
                //cl4.ColumnWidth = 30.0;


                //Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

                //cl5.Value2 = "Mã Lot";

                //cl5.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

                //cl6.Value2 = "Số Lớp Hiện Tại";

                //cl6.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

                //cl7.Value2 = "Số Lớp Kết Thúc";

                //cl7.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

                //cl8.Value2 = "Tên Cát Nhúng Hiện Tại";

                //cl8.ColumnWidth = 20.0;

                //Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

                //cl9.Value2 = "Thời Gian Bắt Đầu Nhúng";

                //cl9.ColumnWidth = 20.0;

                //Microsoft.Office.Interop.Excel.Range c20 = oSheet.get_Range("J3", "J3");

                //c20.Value2 = "Số Thời Gian Nhúng Thực Tế";

                //c20.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range c21 = oSheet.get_Range("K3", "K3");

                //c21.Value2 = "Thời Gian Bắt Đầu Phơi";

                //c21.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range c22 = oSheet.get_Range("L3", "L3");

                //c22.Value2 = "Số Thời Gian Phơi Đặt";

                //c22.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range c23 = oSheet.get_Range("M3", "M3");

                //c23.Value2 = "Số Thời Gian Phơi Thực Tế";

                //c23.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range c24 = oSheet.get_Range("N3", "N3");

                //c24.Value2 = "Mã Xe";

                //c24.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range c25 = oSheet.get_Range("O3", "O3");

                //c25.Value2 = "Mã Cột";

                //c25.ColumnWidth = 20.0;
                //Microsoft.Office.Interop.Excel.Range c26 = oSheet.get_Range("P3", "P3");

                //c26.Value2 = "Người Thực Hiện";

                //c26.ColumnWidth = 25.0;

                //Microsoft.Office.Interop.Excel.Range c27 = oSheet.get_Range("Q3", "Q3");

                //c27.Value2 = "Trạng Thái Sản Phẩm";

                //c27.ColumnWidth = 20.0;













                Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "Q3");

                rowHead.Font.Bold = true;
                // Kẻ viền

                rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Thiết lập màu nền

              //  rowHead.Interior.ColorIndex = 15;

                rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                // Tạo mẳng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,

                // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.

                object[,] arr = new object[dt.Rows.Count, dt.Columns.Count];

                //Chuyển dữ liệu từ DataTable vào mảng đối tượng

                for (int r = 0; r < dt.Rows.Count; r++)
                {

                    DataRow dr = dt.Rows[r];

                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        if (c == 0)
                        {
                            arr[r, c] = "'" + dr[c].ToString();

                        }
                        else
                        {
                            arr[r, c] = dr[c].ToString();

                        }
                    }
                }

                //Thiết lập vùng điền dữ liệu

                int rowStart = 4;

                int columnStart = 1;

                int rowEnd = rowStart + dt.Rows.Count - 1;

                int columnEnd = dt.Columns.Count;

                // Ô bắt đầu điền dữ liệu

                Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

                // Ô kết thúc điền dữ liệu

                Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

                // Lấy về vùng điền dữ liệu

                Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

                //Điền dữ liệu vào vùng đã thiết lập

                range.Value = arr;

                // Kẻ viền

                range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

                // Căn giữa cột STT

                Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

                Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

                oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;




            ////Tổng điện năng
            //Microsoft.Office.Interop.Excel.Range _sum = oSheet.Range["D" + (rowEnd + 1).ToString(), "D" + (rowEnd + 1).ToString()];
            //_sum.Select();
            //_sum.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            //_sum.Font.Bold = false;
            //// Kẻ viền
            //_sum.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            ////oSheet.Cells[26, 2] = "=SUM(D4:D26)";
            ////string t = "=sum(" + _mCol + _iRow.ToString() + ":" + _mCol + rowEnd + ")";
            ////_sum.Value = t;
            //_sum.Value = "=sum(" + "D" + rowStart + ":" + "D" + rowEnd + ")";

            //Microsoft.Office.Interop.Excel.Range _avgI = oSheet.Range["C" + (rowEnd + 1).ToString(), "C" + (rowEnd + 1).ToString()];
            //_avgI.Select();
            //_avgI.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            //_avgI.Font.Bold = false;
            //// Kẻ viền
            //_avgI.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            ////oSheet.Cells[26, 2] = "=SUM(D4:D26)";
            //_avgI.Value = "=AVERAGE(" + "C" + rowStart + ":" + "C" + rowEnd + ")";

            //Microsoft.Office.Interop.Excel.Range _avgV = oSheet.Range["B" + (rowEnd + 1).ToString(), "B" + (rowEnd + 1).ToString()];
            //_avgV.Select();
            //_avgV.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            //_avgV.Font.Bold = false;
            //// Kẻ viền
            //_avgV.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            ////oSheet.Cells[26, 2] = "=SUM(D4:D26)";
            //_avgV.Value = "=AVERAGE(" + "B" + rowStart + ":" + "B" + rowEnd + ")";

            //Microsoft.Office.Interop.Excel.Range Tong = oSheet.Range["A" + (rowEnd + 1).ToString(), "A" + (rowEnd + 1).ToString()];
            //Tong.Select();
            //Tong.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            //Tong.Font.Bold = false;
            //// Kẻ viền
            //Tong.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            ////oSheet.Cells[26, 2] = "=SUM(D4:D26)";
            //Tong.Value = "Sum and Average";






            //string rr = "A3:A" + (rowEnd).ToString() + ", Q3:D" + (rowEnd).ToString();
            //Microsoft.Office.Interop.Excel.Range _Chartrange = oSheet.Range[rr];
            ////Microsoft.Office.Interop.Excel.Range _Chartrange = _objSheets[1].Range["A3:A" + (_iRow + _mRow - 1).ToString(), "F3:F" + (_iRow + _mRow - 1).ToString()];
            //Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Microsoft.Office.Interop.Excel.ChartObjects)oSheet.ChartObjects(Type.Missing);
            //Microsoft.Office.Interop.Excel.ChartObject myChart = (Microsoft.Office.Interop.Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
            ////myChart.Chart.PlotArea.c = System.Drawing.Color.LightYellow;


            //myChart.Border.Color = (int)Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
            //Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;
            //chartPage.SetSourceData(_Chartrange, Type.Missing);

            //chartPage.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlColumnClustered;

            //Microsoft.Office.Interop.Excel.Axis xAxis = (Microsoft.Office.Interop.Excel.Axis)chartPage.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory, Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary);
            //Microsoft.Office.Interop.Excel.Axis yAxis = (Microsoft.Office.Interop.Excel.Axis)chartPage.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue, Microsoft.Office.Interop.Excel.XlAxisGroup.xlPrimary);
            //yAxis.CrossesAt = yAxis.MinimumScale;
            ////xAxis.Border.Color = (int)Microsoft.Office.Interop.Excel.XlRgbColor.rgbDarkRed;
            //chartPage.Location(Microsoft.Office.Interop.Excel.XlChartLocation.xlLocationAsNewSheet, Type.Missing);




            ////luu
            //oBook.SaveAs(@"D:\BAO CAO ATPRO\PMDataReport.xls", excel.XlFileFormat.xlWorkbookNormal,
            //   null, null, false, false,
            //   excel.XlSaveAsAccessMode.xlExclusive,
            //   false, false, false, false, false);
            //luu
            // oBook.SaveAs(@"C:\BAO CAO\PMDataReport.xls", excel.XlFileFormat.xlWorkbookNormal,

            oBook.SaveAs(rootDir + "BAO CAO\\PMDataReport.xls", excel.XlFileFormat.xlExcel12,
                   null, null, false, false,
                   excel.XlSaveAsAccessMode.xlExclusive,
                   false, false, false, false, false);

            //_objBook.SaveAs(_Path + _ReportName + ".xls",
            //                       Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12);
            oBook.Close(false, false, false);

            oExcel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
        //}
        //    catch
        //    {

              
        //    }

        }






    }

}
