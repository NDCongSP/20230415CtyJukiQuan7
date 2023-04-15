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
    public class BangNhapSoLopDAO
    {
        private static BangNhapSoLopDAO instance;

        public static BangNhapSoLopDAO Instance
        {
            get { if (instance == null)instance = new BangNhapSoLopDAO(); return BangNhapSoLopDAO.instance; }
            private set { BangNhapSoLopDAO.instance = value; }
        }

        private BangNhapSoLopDAO() { }

        public List<BangNhapSoLop> GetBatchNumberByProductCodeID(int id)
        {
            List<BangNhapSoLop> list = new List<BangNhapSoLop>();
          //  string query = "select * from BangNhapSoLop where idProductCode = " + id;
            string query = "select * from BangNhapSoLop where id = " + id;


            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BangNhapSoLop BatchNumber = new BangNhapSoLop(item);
                list.Add(BatchNumber);
            }

            return list;
        }

        public List<BangNhapSoLop> GetListBatchNumber()
        {
            List<BangNhapSoLop> list = new List<BangNhapSoLop>();

            string query = "select * from BangNhapSoLop";

           // string query = "SELECT id as idd, MaBarCodeSanPham as tt FROM juki_giamsatthoigiankho.bangnhapsolop";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BangNhapSoLop BatchNumber = new BangNhapSoLop(item);
                list.Add(BatchNumber);
            }

            return list;
        }

        public List<BangNhapSoLop> SearchBatchNumberByName(string name)
        {                     

            List<BangNhapSoLop> list = new List<BangNhapSoLop>();

            //string query = string.Format("SELECT * FROM BangNhapSoLop WHERE fuConvertToUnsign1(name) LIKE N'%' + fuConvertToUnsign1(N'{0}') + '%'", name);
            //string query = string.Format("SELECT* FROM BangNhapSoLop WHERE fuConvertToUnsign1(name) LIKE '%' + CONCAT(fuConvertToUnsign1('{0}'), '%')", name);
            string query = string.Format("SELECT* FROM BangNhapSoLop WHERE MaBarCodeSanPham = '{0}'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BangNhapSoLop BatchNumber = new BangNhapSoLop(item);
                list.Add(BatchNumber);
            }

            return list;
        }

        public BangNhapSoLop GetBangNhapSoLopByMaSanPham(string MaSanPham)
        {
            BangNhapSoLop bangNhapSoLop = null;

            string query = "select * from BangNhapSoLop where BangNhapSoLop = '" + MaSanPham + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                bangNhapSoLop = new BangNhapSoLop(item);
                return bangNhapSoLop;
            }

            return bangNhapSoLop;
        }

        public List<BangNhapSoLop> GetListBangNhapSoLopByMaSanPham(string MaSanPham)
        {
            List<BangNhapSoLop> list = new List<BangNhapSoLop>();

            string query = "select * from BangNhapSoLop where MaBarCodeSanPham = '" + MaSanPham + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BangNhapSoLop BatchNumber = new BangNhapSoLop(item);
                list.Add(BatchNumber);
            }

            return list;
        }

        public bool InsertBatchNumber( string MaBarCodeSanPham, string TenSanPhamTiengViet, string TenSanPhamTiengAnh, string LopNhung, int TongLopNhung, int Zircon01, int Zircon02 , int Zircon03, int Zircon04, int CatL01, int CatL02, int CatL03, int CatL04, int CatL05, int CatL06, int CatL07, int CatL08, int CatL09, int SIRU)
        {
            // string query = string.Format("INSERT BangNhapSoLop ( name, idProductCode, SoThoiGianKho )VALUES  ('{0}', '{1}', '{2}')", name, id, SoThoiGianKho);
           // string query = string.Format("INSERT BangNhapSoLop(`TenSanPham`, `MaBarCodeSanPham`, `SoLopKetThuc`, `SoLopHienTai`, `SoThoiGianKho`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", TenSanPham, MaBarCodeSanPham, SoLopKetThuc, SoLopHienTai, SoThoiGianKho);


            string query = "INSERT INTO `BangNhapSoLop` (`MaBarCodeSanPham`, `TenSanPhamTiengViet`, `TenSanPhamTiengAnh`, `LopNhung`, `TongLopNhung`, `Zircon01`, `Zircon02`, `Zircon03`,  `Zircon04`, `CatL01`, `CatL02`, `CatL03`, `CatL04`, `CatL05`, `CatL06`, `CatL07`, `CatL08`, `CatL09`, `SIRU`) " +
                            " VALUES('" + MaBarCodeSanPham + "', '" + TenSanPhamTiengViet
                              + "','" + TenSanPhamTiengAnh + "', '" + LopNhung + "','" + TongLopNhung
                              + "','" + Zircon01 + "', '" + Zircon02 + "', '" + Zircon03
                              + "', '" + Zircon04 + "', '" + CatL01 + "', '" + CatL02
                              + "', '" + CatL03 + "', '" + CatL04 + "', '" + CatL05
                              + "', '" + CatL06 + "', '" + CatL07 + "', '" + CatL08
                              + "', '" + CatL09 + "', '" + SIRU + "')";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateBatchNumber(string MaBarCodeSanPham, string TenSanPhamTiengViet, string TenSanPhamTiengAnh, string LopNhung, int TongLopNhung, int Zircon01, int Zircon02, int Zircon03, int Zircon04, int CatL01, int CatL02, int CatL03, int CatL04, int CatL05, int CatL06, int CatL07, int CatL08, int CatL09, int SIRU)
      //  public bool UpdateBatchNumber(string TenSanPham, string MaBarCodeSanPham, int SoLopKetThuc, int SoLopHienTai, float SoThoiGianKho, int id)
        {
            //string query = string.Format("UPDATE BangNhapSoLop SET name = '{0}', idProductCode = '{1}', SoThoiGianKho = '{2}' WHERE id = '{3}'", name, id, SoThoiGianKho, idBatchNumber);

           // string query = string.Format("UPDATE BangNhapSoLop SET `TenSanPham` = '{0}', `MaBarCodeSanPham` = '{1}', `SoLopKetThuc` = '{2}', `SoLopHienTai` = '{3}', `SoThoiGianKho` = '{4}' WHERE `id`='{5}'", TenSanPham, MaBarCodeSanPham, SoLopKetThuc, SoLopHienTai, SoThoiGianKho, id);

            string query = string.Format("UPDATE `bangnhapsolop` SET `TenSanPhamTiengViet`='{1}', `TenSanPhamTiengAnh`='{2}', `LopNhung`='{3}', `TongLopNhung`='{4}', `Zircon01`='{5}', `Zircon02`='{6}', `Zircon03`='{7}', `Zircon04`='{8}', `CatL01`='{9}', `CatL02`='{10}', `CatL03`='{11}', `CatL04`='{12}', `CatL05`='{13}', `CatL06`='{14}', `CatL07`='{15}', `CatL08`='{16}', `CatL09`='{17}', `SIRU`='{18}'" +
                " WHERE `MaBarCodeSanPham`='{0}'", MaBarCodeSanPham, TenSanPhamTiengViet,  TenSanPhamTiengAnh,  LopNhung,  TongLopNhung,  Zircon01,  Zircon02,  Zircon03,  Zircon04,  CatL01,  CatL02,  CatL03,  CatL04,  CatL05,  CatL06,  CatL07,  CatL08,  CatL09, SIRU);


            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool InsertBatchNumberExcel(string MaBarCodeSanPham, string TenSanPhamTiengAnh, string TenSanPhamTiengViet, string LopNhung, string TongLopNhung, string Zircon01, string Zircon02, string Zircon03, string Zircon04, string CatL01, string CatL02, string CatL03, string CatL04, string CatL05, string CatL06, string CatL07, string CatL08, string CatL09, string SIRU)
        {
            // string query = string.Format("INSERT BangNhapSoLop ( name, idProductCode, SoThoiGianKho )VALUES  ('{0}', '{1}', '{2}')", name, id, SoThoiGianKho);
            // string query = string.Format("INSERT BangNhapSoLop(`TenSanPham`, `MaBarCodeSanPham`, `SoLopKetThuc`, `SoLopHienTai`, `SoThoiGianKho`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", TenSanPham, MaBarCodeSanPham, SoLopKetThuc, SoLopHienTai, SoThoiGianKho);



            string query = "INSERT INTO `BangNhapSoLop` (`MaBarCodeSanPham`, `TenSanPhamTiengAnh`, `TenSanPhamTiengViet`, `LopNhung`, `TongLopNhung`, `Zircon01`, `Zircon02`, `Zircon03`,  `Zircon04`, `CatL01`, `CatL02`, `CatL03`, `CatL04`, `CatL05`, `CatL06`, `CatL07`, `CatL08`, `CatL09`, `SIRU`) " +
                            " VALUES(" + MaBarCodeSanPham + ", " + TenSanPhamTiengAnh
                              + ", " + TenSanPhamTiengViet + ", " + LopNhung + ", " + TongLopNhung
                              + ", " + Zircon01 + ", " + Zircon02 + ", " + Zircon03
                              + ", " + Zircon04 + ", " + CatL01 + ", " + CatL02
                              + ", " + CatL03 + ", " + CatL04 + ", " + CatL05
                              + ", " + CatL06 + ", " + CatL07 + ", " + CatL08
                              + ", " + CatL09 + ", " + SIRU + ")";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateBatchNumberExcel(string MaBarCodeSanPham, string TenSanPhamTiengViet, string TenSanPhamTiengAnh, string LopNhung, string TongLopNhung, string Zircon01, string Zircon02, string Zircon03, string Zircon04, string CatL01, string CatL02, string CatL03, string CatL04, string CatL05, string CatL06, string CatL07, string CatL08, string CatL09, string SIRU)
        {

            string query = string.Format("UPDATE  `bangnhapsolop` SET `TenSanPhamTiengViet`={1}, `TenSanPhamTiengAnh`={2}, `LopNhung`={3}, `TongLopNhung`={4}, `Zircon01`={5}, `Zircon02`={6}, `Zircon03`={7}, `Zircon04`={8}, `CatL01`={9}, `CatL02`={10}, `CatL03`={11}, `CatL04`={12}, `CatL05`={13}, `CatL06`={14}, `CatL07`={15}, `CatL08`={16}, `CatL09`={17}, `SIRU`={18}" +
                " WHERE `MaBarCodeSanPham`={0}", MaBarCodeSanPham, TenSanPhamTiengAnh, TenSanPhamTiengViet, LopNhung, TongLopNhung, Zircon01, Zircon02, Zircon03, Zircon04, CatL01, CatL02, CatL03, CatL04, CatL05, CatL06, CatL07, CatL08, CatL09, SIRU);


            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteBatchNumber(string MaBarCodeSanPham)
        {
            //xoá thêm sản phẩn trong bill
           // MaBarCodeDAO.Instance.DeleteBillInfoByBatchNumberID(idBatchNumber);

            string query = string.Format("Delete From BangNhapSoLop where MaBarCodeSanPham = '{0}'", MaBarCodeSanPham);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
