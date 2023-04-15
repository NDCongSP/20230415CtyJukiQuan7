using QuanLySanXuatJuKi.DAO;
using System;
using System.Drawing;
using System.Timers;
using System.Web;
using System.Web.UI.WebControls;

namespace ATSCADAWebApp
{
    public partial class Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((string)Session["Login"] != "True")
            //{
            //    Response.Redirect("~/Default.aspx");
            //}
            
            GridView2.DataSource = DuLieuVaBaoCaoDAO.Instance.GetDataTableView();
            GridView2.DataBind();

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
  
            // string t=  HttpUtility.HtmlDecode(e.Row.Cells[11].Text.ToString());
            // string val = DataBinder.Eval(e.Row.DataItem, "TrangThai").ToString();
            if (HttpUtility.HtmlDecode(e.Row.Cells[12].Text.ToString()) == "TrangThai")
            {
                e.Row.BackColor = Color.Aqua;

            }
            else
            {
                e.Row.BackColor = Color.Orchid;

            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.RowIndex == 0)
            //        e.Row.Style.Add("height", "50px");
            //}



        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {

            //GridView1.DataBind();
            //GridView2.DataBind();

            //UpdatePanel1.Update();
            //UpdatePanel2.Update();


        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if (HttpUtility.HtmlDecode(e.Row.Cells[11].Text.ToString()) == "Chuyển Tiếp")
                //{
                //    e.Row.BackColor = Color.Red;

                //}
                //else
                //{
                //    e.Row.BackColor = Color.Yellow;

                //}
                if ((HttpUtility.HtmlDecode(e.Row.Cells[12].Text.ToString()) == "Đang Phơi"))
                {
                    e.Row.BackColor = Color.Tomato;
                }
                else if ((HttpUtility.HtmlDecode(e.Row.Cells[12].Text.ToString()) == "Sắp Khô"))
                {
                    e.Row.BackColor = Color.Yellow;
                }

                else if ((HttpUtility.HtmlDecode(e.Row.Cells[12].Text.ToString()) == "Đã Khô" && Convert.ToInt16(e.Row.Cells[7].Text.ToString()) != Convert.ToInt16(e.Row.Cells[8].Text.ToString())))
                {
                    e.Row.BackColor = Color.Green;
                }
                else if ((HttpUtility.HtmlDecode(e.Row.Cells[12].Text.ToString()) == "Đã Khô" && Convert.ToInt16(HttpUtility.HtmlDecode(e.Row.Cells[7].Text.ToString())) == Convert.ToInt16(HttpUtility.HtmlDecode(e.Row.Cells[8].Text.ToString()))))
                {
                    e.Row.BackColor = Color.DeepSkyBlue;
                }
                else
                {
                    e.Row.BackColor = Color.Aqua;

                }



            }
            catch 
            {

            }

        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
           
            GridView2.DataBind();

            //UpdatePanel1.Update();
            //UpdatePanel2.Update();

        }
    }




}