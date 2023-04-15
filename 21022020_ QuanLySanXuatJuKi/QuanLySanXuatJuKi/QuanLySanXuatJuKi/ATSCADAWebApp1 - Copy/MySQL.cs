using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Data.SqlClient;
namespace ATSCADAWebApp
{
    public class MySQL
    {
        public string ChuoiKetnoiMySQL_Ser = "Server = localhost ; Uid =root ;Pwd= 100100; Database=emin";
        static MySqlConnection connectmysql;
        /// <summary>
        /// method ket noi CSDL server.103.48.195.37
        /// </summary>
        /// <returns>tra ve GOOD hoac BAD.</returns>
        public string KetnoiMySQL_ser()
        {
            try
            {
                connectmysql = new MySqlConnection(ChuoiKetnoiMySQL_Ser);
                connectmysql.Open();
                return "GOOD";
            }
            catch { return "BAD"; }
        }

        public string NgatKetnoiMySQL()
        {
            try
            {
                connectmysql.Dispose();
                return "GOOD";
            }
            catch { return "BAD"; }

        }

        public DataTable DocMySQL_dothi(string tenb)
        {
            try
            {
                DataTable Table = new DataTable();
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM " + tenb + " where DateTime >=  '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "' ORDER BY DateTime DESC LIMIT 100", connectmysql);
                ad.Fill(Table);

                DataColumn dc = new DataColumn("DateTime", typeof(DateTime));
                TableReturn.Columns.Add(dc);
                dc = new DataColumn("Temp_Sensor1", typeof(double));
                TableReturn.Columns.Add(dc);
                dc = new DataColumn("Humi_Sensor1", typeof(double));
                TableReturn.Columns.Add(dc);
                dc = new DataColumn("Temp_Sensor2", typeof(double));
                TableReturn.Columns.Add(dc);
                dc = new DataColumn("Humi_Sensor2", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("3thucte", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("4kehoach", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("4thucte", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("5kehoach", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("5thucte", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("6kehoach", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("6thucte", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("7kehoach", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("7thucte", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("8kehoach", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("8thucte", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("9kehoach", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("9thucte", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("10kehoach", typeof(double));
                //TableReturn.Columns.Add(dc);
                //dc = new DataColumn("10thucte", typeof(double));
                TableReturn.Columns.Add(dc);
                for (int i = 0; i < Table.Rows.Count; i++)
                {
                    DataRow dr = TableReturn.NewRow();
                    dr[0] = Table.Rows[Table.Rows.Count - 1 - i][0];
                    dr[1] = Table.Rows[Table.Rows.Count - 1 - i][1];
                    dr[2] = Table.Rows[Table.Rows.Count - 1 - i][2];
                    dr[3] = Table.Rows[Table.Rows.Count - 1 - i][3];
                    dr[4] = Table.Rows[Table.Rows.Count - 1 - i][4];
                    dr[5] = Table.Rows[Table.Rows.Count - 1 - i][5];
                    dr[6] = Table.Rows[Table.Rows.Count - 1 - i][6];
                    dr[7] = Table.Rows[Table.Rows.Count - 1 - i][7];
                    dr[8] = Table.Rows[Table.Rows.Count - 1 - i][8];
                    dr[0] = Table.Rows[Table.Rows.Count - 1 - i][9];
                    dr[1] = Table.Rows[Table.Rows.Count - 1 - i][10];
                    //dr[2] = Table.Rows[Table.Rows.Count - 1 - i][11];
                    //dr[3] = Table.Rows[Table.Rows.Count - 1 - i][12];
                    //dr[4] = Table.Rows[Table.Rows.Count - 1 - i][13];
                    //dr[5] = Table.Rows[Table.Rows.Count - 1 - i][14];
                    //dr[6] = Table.Rows[Table.Rows.Count - 1 - i][15];
                    //dr[7] = Table.Rows[Table.Rows.Count - 1 - i][16];
                    //dr[8] = Table.Rows[Table.Rows.Count - 1 - i][17];
                    //dr[6] = Table.Rows[Table.Rows.Count - 1 - i][18];
                    //dr[7] = Table.Rows[Table.Rows.Count - 1 - i][19];
                    //dr[8] = Table.Rows[Table.Rows.Count - 1 - i][20];
                    TableReturn.Rows.Add(dr);
                }
                return TableReturn;
            }
            catch { return null; }
        }
        public DataTable Doc_line(string tenbang, string tg1, string tg2)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM " + tenbang + " WHERE  DateTime >= '" + tg1 + "' AND DateTime <= '" + tg2 + "'", connectmysql);
                ad.Fill(TableReturn);
                return TableReturn;
            }
            catch { return null; }
        }
        public DataTable Doc_lS(string tenbang, string LINE, string tg1, string tg2)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM " + tenbang + " WHERE  thoigian >= '" + tg1 + "' AND thoigian <= '" + tg2 + "' AND line='" + LINE + "' ", connectmysql);
                ad.Fill(TableReturn);
                return TableReturn;
            }
            catch { return null; }
        }

        /// <summary>
        /// method doc databases tren server.
        /// </summary>
        /// <param name="tenbang">ten bang can doc.</param>
        /// <returns>tra ve datatable, neu = null la loi.</returns>
        public DataTable DocMySQL(string tenbang)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM " + tenbang, connectmysql);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }

        public DataTable DocMySQL_caidat(string tenvung)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM caidat where idvung = '" + tenvung + "'", connectmysql);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }
        public DataTable DocMySQL_gtweb(string tenvung)
        {
            try
            {
                DataTable TableReturn = new DataTable();
                MySqlDataAdapter ad = new MySqlDataAdapter("SELECT * FROM gtweb where idvung = '" + tenvung + "'", connectmysql);
                ad.Fill(TableReturn);

                return TableReturn;
            }
            catch { return null; }
        }

        /// <summary>
        /// method ghi du lieu nhiet do vao bang "kholanh" tren server.
        /// </summary>
        /// <param name="MangGiaTRi"></param>
        /// <returns>tra ve GOOD hoac BAD.</returns>
        public string Ghi_lichsu_muctieu(string line, string giatri)
        {
            try
            {


                string MySqlCmd = "insert into ls_target values(now(),'" + line + "','" + giatri + "')";

                MySqlCommand cmd = new MySqlCommand(MySqlCmd, connectmysql);
                cmd.ExecuteNonQuery();
                return "GOOD";
            }
            catch { return "BAD"; }

        }
        // 
        public string Ghi_lichsu_actual(string line, string gtrcu, string gtrmoi, string lydo)
        {
            try
            {


                string MySqlCmd = "insert into ls_actual values(now(),'" + line + "','" + gtrcu + "','" + gtrmoi + "','" + lydo + "')";

                MySqlCommand cmd = new MySqlCommand(MySqlCmd, connectmysql);
                cmd.ExecuteNonQuery();
                return "GOOD";
            }
            catch { return "BAD"; }

        }

        /// <summary>
        /// method cap nhat lai cac cot  khi co du thay doi nguonf cao, thap tren server.
        /// </summary>
        /// <returns>tra ve GOOD hoac BAD.</returns>
        public string CapnhatDulieu(string kh1, string kh2, string kh3, string kh4, string kh5, string kh6, string kh7, string kh8, string kh9, string kh10)
        {
            try
            {
                string MysqlCmd = "update kehoach set  " + kh1 + " = '" + kh2 + "' , " + kh3 + " = '" + kh4 + "'," + kh5 + " = '" + kh6 + "'," + kh7 + " = '" + kh8 + " = '" + kh9 + " = '" + kh10 + "' ";
                MySqlCommand cmd = new MySqlCommand(MysqlCmd, connectmysql);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                return "GOOD";
            }
            catch { return "BAD"; }
        }
        public string CapnhatDulieu_serial()
        {
            try
            {
                string MysqlCmd = "update thongso set khoa = 'Off', mokhoa = 501 ";
                MySqlCommand cmd = new MySqlCommand(MysqlCmd, connectmysql);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                return "GOOD";
            }
            catch { return "BAD"; }
        }

    }
}
