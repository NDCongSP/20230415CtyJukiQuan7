using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuatJuKi.DAO
{
    public class MaBarCodeDAO
    {
        private static MaBarCodeDAO instance;

        public static MaBarCodeDAO Instance
        {
            get { if (instance == null) instance = new MaBarCodeDAO(); return MaBarCodeDAO.instance; }
            private set { MaBarCodeDAO.instance = value; }
        }

        private MaBarCodeDAO() { }

        public List<MaBarCode> GetListMaBarCodeTheoTrangThai()
        {
            List<MaBarCode> listMaBarCode = new List<MaBarCode>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM MaBarCode");

            foreach (DataRow item in data.Rows)
            {
                MaBarCode info = new MaBarCode(item);
                listMaBarCode.Add(info);
            }

            return listMaBarCode;
        }



        internal bool UpdateTrangThaiMaCode(int iD, string trangThai)
        {
          //string  trangThai = "0";

            string query = string.Format("UPDATE MaBarCode SET `TrangThai` = '{0}' WHERE `id`='{1}'", trangThai, iD);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        internal bool UpdateTrangThaiTheoSanPhamVaLot(string maBarCodeSanpham, string maBarCodeLot, string trangthaimacode)
        {
            string query = string.Format("UPDATE MaBarCode SET `TrangThai` = '{0}' WHERE `MaBarCodeSanPham`='{1}' and `maBarCodeLot`='{2}'", trangthaimacode, maBarCodeSanpham, maBarCodeLot);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        internal void DeleteTrangThaiTheoSanPhamVaLot(string maBarCodeSanpham, string maBarCodeLot)
        {
            DataProvider.Instance.ExecuteQuery("delete FROM MaBarCode WHERE MaBarCodeSanPham= '" + maBarCodeSanpham + "' and MaBarCodeLot= '" + maBarCodeLot + "'");


        }
    }
}
