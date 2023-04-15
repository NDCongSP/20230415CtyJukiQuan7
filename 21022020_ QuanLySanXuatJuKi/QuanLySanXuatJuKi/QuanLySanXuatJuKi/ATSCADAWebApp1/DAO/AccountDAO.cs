using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuatJuKi.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            //var list = hasData.ToString();
            //list.Reverse();

            // string query = "USP_Login userName , passWord";
            string query = "select * from account where UserName='" + userName + "' and password = '"+ hasPass + "'";

            //DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, hasPass /*list*/});
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
           // byte[] temp = ASCIIEncoding.ASCII.GetBytes(passWord);
            //byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass); //kí tự sang ascii
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp); //ascii sang md5
            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            string T = hasData.ToString();
            byte[] temp1 = ASCIIEncoding.ASCII.GetBytes(newPass); //kí tự sang ascii
            byte[] hasDataNew = new MD5CryptoServiceProvider().ComputeHash(temp1); //ascii sang md5

            string hasPassnew = "";

            foreach (byte item in hasDataNew)
            {
                hasPassnew += item;
            }
            // int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[]{userName, displayName, pass, newPass});


            int result = DataProvider.Instance.ExecuteNonQuery("CALL USP_UpdateAccount ('"+userName+ "' , '" + displayName + "'  , '" + hasPass + "'  , '" + hasPassnew + "')");

            //CALL productpricing(@SoThoiGianKholow,
            //        @SoThoiGianKhohigh,
            //        @SoThoiGianKhoaverage);


            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type FROM Account");
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAccount(string name, string displayName, int type)
        {
            string query = string.Format("INSERT Account ( UserName, DisplayName, Type, password )VALUES  ( '{0}', '{1}', {2}, '{3}')", name, displayName, type, "1962026656160185351301320480154111117132155");
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string displayName, int type)
        {
            string query = string.Format("UPDATE Account SET DisplayName = '{1}', Type = {2} WHERE UserName = '{0}'", name, displayName, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where UserName = '{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool ResetPassword(string name)
        {
            string query = string.Format("update account set password = '1962026656160185351301320480154111117132155' where UserName = '{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
