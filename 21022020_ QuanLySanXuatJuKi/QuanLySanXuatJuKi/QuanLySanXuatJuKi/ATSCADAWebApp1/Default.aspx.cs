using ATSCADAWebApp.Model;
using QuanLySanXuatJuKi.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ATSCADAWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        #region Main Static Objects - THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED OR MODIFIED
        /// <summary>
        /// THESE LINES ARE FROM ATPROCORP, SHOULD NOT BE DELETED
        /// </summary>
        static iDriverWeb Driver = new iDriverWeb();
        static List<Control> allControls = new List<Control>();
        static SetDriver SD = new SetDriver();
        #endregion

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
            if ((string)Session["Role"] != "Admin")
            {
                //Response.Redirect("~/Login.aspx");
            }
            //If this page is for Admin and Operator Users
            if ((string)Session["Role"] != "Operator" && (string)Session["Role"] != "Admin")
            {
                //Response.Redirect("~/Login.aspx");
            }
            #endregion


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //string passEncode = MD5Hash(Base64Encode(txtPassword.Text));
            //var accCount = DataProvider.Ins.DB.accounts.Where(x => x.username == txtUser.Text && x.passwords == passEncode).Count();


            //  var accCount = DataProvider.Ins.DB.accounts.Where(x => x.username == txtUser.Value && x.passwords == txtPassword.Value).Count();
            var accCount = AccountDAO.Instance.Login(txtUser.Value, txtPassword.Value);

            if (accCount)
            {

                Session["Login"] = "True";
                Response.Redirect("baocao.aspx");

                //IsLogin = true;

                //p.Close();
            }
            else
            {

                txtPassword.Value = txtUser.Value = "";
                string script = "alert(\"Sai Password\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

                //IsLogin = false;
                //MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }



        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

    }
}