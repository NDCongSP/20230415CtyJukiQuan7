using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace ATSCADAWebApp
{
    public class MySQL_Method
    {
        //webform
        #region khai bao cac bien
        //static string ChuoiKetnoiMySQL_local = "Server = 103.48.194.7; Uid =coldchainteam;Pwd= coldchainteam;Database=coldchaindb";
        public string ChuoiKetnoiMySQL_server = "Server = localhost ; Uid =root ;Pwd= 100100; Database=emin";//"Server=103.48.195.37;Port=3306;Uid=plcpi_giamsat;Pwd=12345;Database=ctycpt;charset=utf8";
        MySqlConnection connectmysql_server;
        #endregion

        #region cac ham dung cho server
        /// <summary>
        /// ket noi MySQL server
        /// </summary>
        /// <returns></returns>
        public string ketnoi_server()
        {
            try
            {
                connectmysql_server = new MySqlConnection(ChuoiKetnoiMySQL_server);
                connectmysql_server.Open();
                return "Good";
            }
            catch { return "Bad"; }
        }
        public string NgatKetnoiMySQL()
        {
            try
            {
                connectmysql_server.Close();
                connectmysql_server.Dispose();
                return "Good";
            }
            catch { return "Bad"; }

        }

        public string set_SAFE_UPDATES()
        {
            try
            {
                string MysqlCmd = "SET SQL_SAFE_UPDATES = 0";
                MySqlCommand cmd = new MySqlCommand(MysqlCmd, connectmysql_server);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                return "Good";
            }
            catch { return "Bad"; }
        }

        public DataTable select_all_where(string tenbang, string dieukien)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM " + tenbang + " where " + dieukien, connectmysql_server);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }
        public DataTable select_gr(string tenbang, string dieukien)
        {
            try
            {
                if (tenbang == "1")
                {
                    tenbang = "line1";
                }
                else if (tenbang == "2")
                {
                    tenbang = "line2";
                }
                else if (tenbang == "3")
                {
                    tenbang = "line3";
                }
                else if (tenbang == "4")
                {
                    tenbang = "line4";
                }
                else if (tenbang == "5")
                {
                    tenbang = "line5";
                }
                else if (tenbang == "6")
                {
                    tenbang = "line6";
                }
                else if (tenbang == "7")
                {
                    tenbang = "line7";
                }
                else if (tenbang == "8")
                {
                    tenbang = "line8";
                }
                else if (tenbang == "9")
                {
                    tenbang = "line9";
                }
                else if (tenbang == "10")
                {
                    tenbang = "line10";
                }
                else if (tenbang == "11")
                {
                    tenbang = "line11";
                }
                else if (tenbang == "12")
                {
                    tenbang = "line12";
                }
                else if (tenbang == "13")
                {
                    tenbang = "line13";
                }
                else if (tenbang == "14")
                {
                    tenbang = "line14";
                }
                else if (tenbang == "15")
                {
                    tenbang = "line15";
                }
                else if (tenbang == "16")
                {
                    tenbang = "line16";
                }
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM "+ tenbang+ " where " + dieukien, connectmysql_server);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }
        public DataTable select_limit(string tenbang, string TenCotSort, int SoDongSelect)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM " + tenbang + " order by "+ TenCotSort+" desc limit "+ SoDongSelect.ToString(), connectmysql_server);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }
        public DataTable select_where_colum(string tenbang, string colum, string dieukien)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT " + colum + " FROM " + tenbang + " where " + dieukien, connectmysql_server);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }
        public DataTable select_All_colum(string tenbang, string colum)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT " + colum + " FROM " + tenbang, connectmysql_server);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }

        public DataTable select_all(string tenbang)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT  * FROM " + tenbang, connectmysql_server);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }

        public string select_limit1(string tenbang)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM " + tenbang + " order by thoigian desc limit 1", connectmysql_server);
                ad.Fill(TableReturn);

                return Convert.ToDateTime(TableReturn.Rows[0][0].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch { return null; }
        }

        public string upadte_cmd(string tenbang, string chuoiupdate, string where)
        {
            try
            {
                string MysqlCmd = "update " + tenbang + " set " + chuoiupdate + " where " + where;
                MySqlCommand cmd = new MySqlCommand(MysqlCmd, connectmysql_server);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                return "Good";
            }
            catch { return "Bad"; }
        }
        /// <summary>
        /// insert new record.
        /// </summary>
        /// <param name="tenbang">ten bang muon insert vao.</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string insert_cmd(string tenbang, string data)
        {
            try
            {
                string MySqlCmd = "insert into " + tenbang + " values(" + data + ")";
                MySqlCommand cmd = new MySqlCommand(MySqlCmd, connectmysql_server);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Good";
            }
            catch { return "Bad"; }
        }

        /// <summary>
        /// inset theo cot
        /// </summary>
        /// <param name="tenbang"></param>
        /// <param name="tencot">a,b,c,....</param>
        /// <param name="data">'a',b',...</param>
        /// <returns></returns>
        public string insert_cmd_cot(string tenbang, string tencot, string data)
        {
            try
            {
                string MySqlCmd = "insert into " + tenbang + " (" + tencot + ")" + " values(" + data + ")";
                MySqlCommand cmd = new MySqlCommand(MySqlCmd, connectmysql_server);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Good";
            }
            catch { return "Bad"; }
        }
        /// <summary>
        /// Xoa du lieu trong bang
        /// </summary>
        /// <param name="tenbang"></param>
        /// <returns></returns>
        public string delete_cmd(string tenbang,string dieukien)
        {
            try
            {
                string MySqlCmd = "delete from " + tenbang + " where " + dieukien;
                MySqlCommand cmd = new MySqlCommand(MySqlCmd, connectmysql_server);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return "Good";
            }
            catch { return "Bad"; }
        }
        public DataTable Doc_Exl(string tg1, string tg2)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                string tsss = "SELECT * FROM line1 WHERE  DateTime >= '" + tg1 + "' AND DateTime <= '" + tg2 + "'";
                MySqlDataAdapter ad = new MySqlDataAdapter(tsss, connectmysql_server);
                ad.Fill(TableReturn);
                return TableReturn;
            }
            catch { return null; }
        }

        #endregion

    }
}
