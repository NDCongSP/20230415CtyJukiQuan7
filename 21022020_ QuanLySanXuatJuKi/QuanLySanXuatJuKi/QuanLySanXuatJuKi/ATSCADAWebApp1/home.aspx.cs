using QuanLySanXuatJuKi.DAO;
using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;

namespace ATSCADAWebApp
{
    public partial class home : System.Web.UI.Page
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
        private string ccccc;
        private string ttttt;
        private string ttttt2;
        private string soxexexe;

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
            //    //  Response.Redirect("~/Login.aspx");
            //}
            ////If this page is for Admin and Operator Users
            //if ((string)Session["Role"] != "Operator" && (string)Session["Role"] != "Admin")
            //{
            //    // Response.Redirect("~/Login.aspx");
            //}
            //if ((string)Session["Login"] != "True")
            //{
            //    Response.Redirect("~/Default.aspx");
            //}

            Timer1.Enabled = true;
            #endregion
        }

        void getfd()
        {
          //  var parent = this.FindControl(); // returns the object of the form containing the current usercontrol.

            List<LocationSet> tableList = LocationSetDAO.Instance.LoadTableList();
            // DuLieuVaBaoCaolist.Distinct().ToList();
            foreach (LocationSet item in tableList)
            {
                // Button btn = new Button() { Width = LocationSetDAO.TableWidth, Height = LocationSetDAO.TableHeight };
                //lấy ra 1 dong có thời gian kho ngắn nhất khi nhấp vào button
                List<DuLieuVaBaoCao> lisdataTimeMin = DuLieuVaBaoCaoDAO.Instance.LoadListTimeMin(item.Name, "Đã Khô", "Sắp Khô", "Đang Phơi");

                ccccc = "";
                if (lisdataTimeMin.Count != 0)
                {
                    //mã xe
                    ttttt = lisdataTimeMin[0].MaBarCodeXe;


                    string[] arrListStr = ttttt.Split('|');
                    //mã cột
                    ccccc = lisdataTimeMin[0].MaBarCodeCot;
                    string[] arrListStrccc = ccccc.Split('|');

                    //lặp tìm phần tử  tim so sanh so cot 
                    for (int i = 0; i < arrListStrccc.Length; i++)
                    {
                        if (arrListStrccc[i] == item.Name)
                        {
                            soxexexe = arrListStr[i];
                        }
                    }


                    ttttt2 = lisdataTimeMin[0].TrangThaiDen;
                    if (lisdataTimeMin[0].SoLopHienTai == lisdataTimeMin[0].SoLopKetThuc && ttttt2 == "Đã Khô")
                    {
                        ttttt2 = "Chuyển Tiếp";
                    }
                }
                //neu so dòng select ra = 0 thì coi như trống
                if (lisdataTimeMin.Count == 0)
                {
                    ttttt = "";
                    ttttt2 = "Trống";
                    soxexexe = "";
                }


                //tim theo ten button da khoi tao
                //  var findButton = parent.Controls.Find("btn" + item.Name, true).FirstOrDefault();
                //var btrtre = item.Name[6];

                string newstring = item.Name.Substring(item.Name.Length - 3, 3);


                #region kiểm tra mất kết nối cột đèn
                //sua cho này de đọc được nhiều channel
                //int namenew = Convert.ToInt16(newstring);//lấy ra số thứ cột 1-->70. item.Name="COT_001"
                //if (namenew <= 20)
                //{
                //    if (Driver.GetTagStatus("Channel1" + item.Name + ".NutNhanKetThuc") != "Good")
                //    {
                //        ttttt = "";
                //        ttttt2 = "Mất Kết Nối";
                //        soxexexe = "";
                //    }
                //}
                //else if (namenew > 20 && namenew <= 40)
                //{
                //    if (Driver.GetTagStatus("Channel2" + item.Name + ".NutNhanKetThuc") != "Good")
                //    {
                //        ttttt = "";
                //        ttttt2 = "Mất Kết Nối";
                //        soxexexe = "";
                //    }
                //}
                //else if (namenew > 40 && namenew <= 60)
                //{
                //    if (Driver.GetTagStatus("Channel3" + item.Name + ".NutNhanKetThuc") != "Good")
                //    {
                //        ttttt = "";
                //        ttttt2 = "Mất Kết Nối";
                //        soxexexe = "";
                //    }
                //}
                //else if (namenew > 60 && namenew <= 70)
                //{
                //    if (Driver.GetTagStatus("Channel4" + item.Name + ".NutNhanKetThuc") != "Good")
                //    {
                //        ttttt = "";
                //        ttttt2 = "Mất Kết Nối";
                //        soxexexe = "";
                //    }
                //}
                #endregion

                Button findButton = this.FindControl("Button" + newstring) as Button;
                if (findButton != null)
                {

                    // btn.Click += btn_Click;
                    //findButton.Text = item.Name + Environment.NewLine + soxexexe + Environment.NewLine + ttttt2;
                    findButton.Text = item.Name;

                    //findButton.Text = item.Name;


                    // findButton.Text = "dsd đâss";

                    //findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
                    findButton.Font.Bold = true;
                    findButton.Font.Size = 10;
                    findButton.Font.Name = "Times New Roman";
                    findButton.CommandName = item.Name;

                    // btn.Tag = item;
                    //btn.Name = "btn" + item.Name;

                    switch (ttttt2)
                    {
                        case "Trống":
                            if (findButton.BackColor != Color.White)
                            {
                                findButton.BackColor = Color.White;
                                findButton.ForeColor = Color.Black;
                            }

                            break;
                        case "Đang Phơi":
                            if (findButton.BackColor != Color.Red)
                            {
                                findButton.BackColor = Color.Red;
                                findButton.ForeColor = Color.White;

                            }


                            break;
                        case "Sắp Khô":
                            if (findButton.BackColor != Color.Yellow)
                            {
                                findButton.BackColor = Color.Yellow;
                                findButton.ForeColor = Color.Black;

                            }


                            break;

                        case "Đã Khô":
                            if (findButton.BackColor != Color.Green)
                            {
                                findButton.BackColor = Color.Green;
                                findButton.ForeColor = Color.White;
                            }

                            break;
                        case "Chuyển Tiếp":
                            if (findButton.BackColor != Color.DeepSkyBlue)
                            {
                                findButton.BackColor = Color.DeepSkyBlue;
                                findButton.ForeColor = Color.Black;

                            }


                            break;
                        //case "Mất Kết Nối":
                        //    if (findButton.BackColor != Color.Magenta)
                        //    {
                        //        findButton.BackColor = Color.Magenta;

                        //    }

                        //    break;


                        default:
                            if (findButton.BackColor != Color.White)
                            {
                                findButton.BackColor = Color.White;
                                findButton.ForeColor = Color.Black;
                            }
                            break;

                    }

                }


            }


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string tablename = ((sender as Button).CommandName);
            //lsvBill.Tag = (sender as Button).Tag;
            //sow list sản phẩm trong listview
            ShowBill(tablename);

        }
        void ShowBill(string name)
        {
           // lsvBill.Items.Clear();
            DataTable listBillInfo = DuLieuVaBaoCaoDAO.Instance.GetDataTableByName(name, "Đã Khô", "Sắp Khô", "Đang Phơi");
            GridView1.DataSource = listBillInfo;
            GridView1.DataBind();
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            getfd();
        }

        protected void Button77_Click(object sender, EventArgs e)
        {

        }
    }
}