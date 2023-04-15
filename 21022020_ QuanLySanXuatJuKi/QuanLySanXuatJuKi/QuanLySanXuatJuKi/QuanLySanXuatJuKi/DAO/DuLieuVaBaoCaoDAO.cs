using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuatJuKi.DAO
{
    public class DuLieuVaBaoCaoDAO
    {
        private static DuLieuVaBaoCaoDAO instance;

        public static DuLieuVaBaoCaoDAO Instance
        {
            get { if (instance == null) instance = new DuLieuVaBaoCaoDAO(); return DuLieuVaBaoCaoDAO.instance; }
            private set { DuLieuVaBaoCaoDAO.instance = value; }
        }


        private DuLieuVaBaoCaoDAO() { }

        internal bool Insert(string tenSanPham, string maBarCodeSanPham, int soLopHienTai, float soThoiGianKho, int soLopKetThuc, string maBarCodeLot)
        {
            // string query = string.Format("INSERT BangNhapSoLop ( name, idProductCode, SoThoiGianKho )VALUES  ('{0}', '{1}', '{2}')", name, id, SoThoiGianKho);
            string query = string.Format("INSERT DuLieuVaBaoCao(`TenSanPham`, `MaBarCodeSanPham`, `SoLopHienTai`, `SoThoiGianKho`, `SoLopKetThuc`,ThoiGianBatDauNhung, MaBarCodeLot) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', now(), '{5}')", tenSanPham, maBarCodeSanPham, soLopHienTai, soThoiGianKho,soLopKetThuc, maBarCodeLot);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        internal bool UpdateTrangThaiKho(string v, int id)
        {
            string query = string.Format("UPDATE DuLieuVaBaoCao SET `TrangThaiDen` = '{0}' WHERE `id`='{1}'", v, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

       // public object GetDataTableView { get; internal set; }
        internal DataTable GetDataTableView()
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

           // DataTable data = DataProvider.Instance.ExecuteQuery("(SELECT MaBarCodeSanPham as MaSanPham,MaBarCodeLot as MaLot,TenSanPhamTiengViet as TenTiengViet,TenSanPhamTiengAnh as TenTiengAnh,MaBarCodeCot as SoCot,MaBarCodeXe as SoXe,SoLopHienTai as LopHienTai,SoLopKetThuc as  LopTieuChuan,SoThoiGianKho as TG_KhoTieuChuan,ThoiGianKetThucKho as ThoiGianKho,TIMEDIFF(ThoiGianKetThucKho,now()) as ThoiGianConLai,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen as TrangThai FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành'  order by ThoiGianKetThucKho ASC LIMIT 3) union all (SELECT MaBarCodeSanPham,MaBarCodeLot,TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeCot,MaBarCodeXe,SoLopHienTai,SoLopKetThuc,SoThoiGianKho,ThoiGianKetThucKho,TIMEDIFF(ThoiGianKetThucKho,now()),TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Đang Phơi' or TrangThaiDen='Sắp Khô' or TrangThaiDen='Đã Khô' order by ThoiGianKetThucKho ASC)");

            DataTable data = DataProvider.Instance.ExecuteQuery("(SELECT MaBarCodeSanPham as MaSanPham,MaBarCodeLot as MaLot,TenSanPhamTiengViet as TenTiengViet,MaBarCodeCot as SoCot,MaBarCodeXe as SoXe,TenCatNhungHienTai,TenCatNhungTiepTheo,SoLopHienTai as LopHienTai,SoLopKetThuc as  LopTieuChuan,SoThoiGianKho as TG_KhoTieuChuan,ThoiGianKetThucKho as ThoiGianKho,MaBarCodeNguoi as NguoiPhuTrach,TrangThaiDen as TrangThai FROM dulieuvabaocao where TrangThaiDen='Đang Phơi' or TrangThaiDen='Sắp Khô' or TrangThaiDen='Đã Khô'  order by ThoiGianKetThucKho ASC) ");

            //foreach (DataRow item in data.Rows)
            //{
            //    DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
            //    listDuLieuVaBaoCao.Add(info);
            //}

            return data;


        }


        internal DataTable GetDataTableView2()
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            // DataTable data = DataProvider.Instance.ExecuteQuery("(SELECT MaBarCodeSanPham as MaSanPham,MaBarCodeLot as MaLot,TenSanPhamTiengViet as TenTiengViet,TenSanPhamTiengAnh as TenTiengAnh,MaBarCodeCot as SoCot,MaBarCodeXe as SoXe,SoLopHienTai as LopHienTai,SoLopKetThuc as  LopTieuChuan,SoThoiGianKho as TG_KhoTieuChuan,ThoiGianKetThucKho as ThoiGianKho,TIMEDIFF(ThoiGianKetThucKho,now()) as ThoiGianConLai,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen as TrangThai FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành'  order by ThoiGianKetThucKho ASC LIMIT 3) union all (SELECT MaBarCodeSanPham,MaBarCodeLot,TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeCot,MaBarCodeXe,SoLopHienTai,SoLopKetThuc,SoThoiGianKho,ThoiGianKetThucKho,TIMEDIFF(ThoiGianKetThucKho,now()),TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Đang Phơi' or TrangThaiDen='Sắp Khô' or TrangThaiDen='Đã Khô' order by ThoiGianKetThucKho ASC)");

            DataTable data = DataProvider.Instance.ExecuteQuery("(SELECT MaBarCodeSanPham as MaSanPham,MaBarCodeLot as MaLot,TenSanPhamTiengViet as TenTiengViet,MaBarCodeCot as SoCot,MaBarCodeXe as SoXe,TenCatNhungHienTai,TenCatNhungTiepTheo,SoLopHienTai as LopHienTai,SoLopKetThuc as  LopTieuChuan,SoThoiGianKho as TG_KhoTieuChuan,ThoiGianKetThucKho as ThoiGianKho,MaBarCodeNguoi as NguoiPhuTrach,TrangThaiDen as TrangThai FROM dulieuvabaocao where TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành'  order by ThoiGianKetThucKho DESC LIMIT 5)");

            //foreach (DataRow item in data.Rows)
            //{
            //    DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
            //    listDuLieuVaBaoCao.Add(info);
            //}

            return data;


        }


        internal List<DuLieuVaBaoCao> GetListTheothoigia(string trangthai1,string trangthai2)
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DuLieuVaBaoCao WHERE TrangThaiDen = '" + trangthai1 + "' or TrangThaiDen = '" + trangthai2 +"'");

            foreach (DataRow item in data.Rows)
            {
                DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
                listDuLieuVaBaoCao.Add(info);
            }

            return listDuLieuVaBaoCao;


        }



        internal List<DuLieuVaBaoCao> GetListTheothoigian(string trangthai1)
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DuLieuVaBaoCao WHERE TrangThaiDen = '" + trangthai1 + "'");

            foreach (DataRow item in data.Rows)
            {
                DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
                listDuLieuVaBaoCao.Add(info);
            }

            return listDuLieuVaBaoCao;


        }


        internal bool InsertSanPhamSoLot(string maBarCodeSanPham, string maBarCodeLot, int solophientai)
        {
            // string query = string.Format("INSERT BangNhapSoLop ( name, idProductCode, SoThoiGianKho )VALUES  ('{0}', '{1}', '{2}')", name, id, SoThoiGianKho);
            string query = string.Format("INSERT DuLieuVaBaoCao( `MaBarCodeSanPham`, ThoiGianBatDauNhung, MaBarCodeLot,`SoLopHienTai`) VALUES ('{0}', now(), '{1}','{2}')",  maBarCodeSanPham, maBarCodeLot, solophientai);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        internal bool UpdateSocotSoxe(string maBarCodeXe, string maBarCodeCot, string maBarCodeSanpham, string maBarCodeLot, int soLopHienTai)
        {
            string query = string.Format("UPDATE DuLieuVaBaoCao SET `MaBarCodeXe` = '{0}', `MaBarCodeCot` = '{1}' WHERE `MaBarCodeSanpham`='{2}' and `MaBarCodeLot`='{3} ' and `SoLopHienTai`='{4} '", maBarCodeXe, maBarCodeCot, maBarCodeSanpham, maBarCodeLot, soLopHienTai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

             return result > 0;
           // return result;

        }

        //internal int SelecttheoSanPhanVaSoLot(string maBarCodeSanpham, string maBarCodeLot)
        //{
        //    string query = string.Format("SELECT * FROM DuLieuVaBaoCao WHERE MaBarCodeSanpham = " + maBarCodeSanpham + " And MaBarCodeLot ="+ maBarCodeLot);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //   // return result > 0;
        //   return result;


        //}
        internal object SelecttheoSanPhanVaSoLot(string maBarCodeSanpham, string maBarCodeLot)
        {
            string query = string.Format("SELECT COUNT(*)  FROM DuLieuVaBaoCao WHERE MaBarCodeSanpham = '" + maBarCodeSanpham + "' And MaBarCodeLot = '" + maBarCodeLot + "'");
            //tra ve so row return
            object result = DataProvider.Instance.ExecuteScalar(query);

            // return result > 0;
            return result;


        }

        internal bool UpdateSocotSoxeAndSolophientai(string TenSanPhamTiengAnh, int soThoiGianKho, int soLopKetThuc, string maBarCodeXe, string maBarCodeCot, string maBarCodeSanpham, string maBarCodeLot, int soLopHienTai, string TenCatNhungHienTai, string TenCatNhungTiepTheo,string TenSanPhamTiengViet, string MaBarCodeNguoi)
        {
            // string query = string.Format("UPDATE DuLieuVaBaoCao SET `TenSanPham`= '{0}',`SoThoiGianKho` = '{1}',`soLopKetThuc` = '{2}', `MaBarCodeXe` = '{3}', `MaBarCodeCot` = '{4}' WHERE `MaBarCodeSanpham`='{5}' and `MaBarCodeLot`='{6} ' and `SoLopHienTai`='{7} '",tenSanPham,soThoiGianKho,soLopKetThuc, maBarCodeXe, maBarCodeCot, maBarCodeSanpham, maBarCodeLot, soLopHienTai);
            // string query = string.Format("UPDATE DuLieuVaBaoCao SET `TenSanPham`= '{0}',`SoThoiGianKho` = '{1}',`soLopKetThuc` = '{2}', `MaBarCodeXe` = '{3}', `MaBarCodeCot` = '{4}', `ThoiGianBatDauPhoi` = now(), `TrangThaiDen` = 'Đang Phơi' WHERE `MaBarCodeSanpham`='{5}' and `MaBarCodeLot`='{6} ' and `SoLopHienTai`='{7}'", tenSanPham, soThoiGianKho, soLopKetThuc, maBarCodeXe, maBarCodeCot, maBarCodeSanpham, maBarCodeLot, soLopHienTai);




          //  string query = string.Format("UPDATE DuLieuVaBaoCao SET `TenSanPham`= '{0}',`SoThoiGianKho` = '{1}',`soLopKetThuc` = '{2}', `MaBarCodeXe` = '{3}', `MaBarCodeCot` = '{4}', `ThoiGianBatDauPhoi` = now(), `TrangThaiDen` = 'Đang Phơi', ThoiGianKetThucKho = DATE_ADD(now(), INTERVAL {1} minute) WHERE `MaBarCodeSanpham`='{5}' and `MaBarCodeLot`='{6} ' and `SoLopHienTai`='{7}'", tenSanPham, soThoiGianKho, soLopKetThuc, maBarCodeXe, maBarCodeCot, maBarCodeSanpham, maBarCodeLot, soLopHienTai);

            //string query = string.Format("UPDATE DuLieuVaBaoCao SET `TenSanPham`= '{0}',`SoThoiGianKho` = '{1}',`soLopKetThuc` = '{2}', `MaBarCodeXe` = '{3}', `MaBarCodeCot` = '{4}', `ThoiGianBatDauPhoi` = now(), `TrangThaiDen` = 'Đang Phơi', ThoiGianKetThucKho = DATE_ADD(now(), INTERVAL {1} HOUR) WHERE `MaBarCodeSanpham`='{5}' and `MaBarCodeLot`='{6} ' and `SoLopHienTai`='{7}'", tenSanPham, soThoiGianKho, soLopKetThuc, maBarCodeXe, maBarCodeCot, maBarCodeSanpham, maBarCodeLot, soLopHienTai);


            string query = string.Format("UPDATE DuLieuVaBaoCao SET `MaBarCodeNguoi`= '{11}', `TenSanPhamTiengViet`= '{10}',`TenSanPhamTiengAnh`= '{0}',`SoThoiGianKho` = '{1}',`soLopKetThuc` = '{2}', `MaBarCodeXe` = '{3}', `MaBarCodeCot` = '{4}', `ThoiGianBatDauPhoi` = now(), `TrangThaiDen` = 'Đang Phơi', `TenCatNhungHienTai` = '{8}', `TenCatNhungTiepTheo` = '{9}', ThoiGianKetThucKho = DATE_ADD(now(), INTERVAL {1} HOUR) WHERE `MaBarCodeSanpham`='{5}' and `MaBarCodeLot`='{6} ' and `SoLopHienTai`='{7}'", TenSanPhamTiengAnh, soThoiGianKho, soLopKetThuc, maBarCodeXe, maBarCodeCot, maBarCodeSanpham, maBarCodeLot, soLopHienTai, TenCatNhungHienTai, TenCatNhungTiepTheo,TenSanPhamTiengViet, MaBarCodeNguoi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
            // return result;
        }

        internal bool UpdateTrangThaiKhoTheoSoCot(string Trangthaihoanthanh, string sobarcodecot, string trangthaidakho, string MaBarCodeSanPham, string MaBarCodeLot)
        {
            string query = string.Format("UPDATE DuLieuVaBaoCao SET `TrangThaiDen` = '{0}', `ThoiGianKetThucQuaTrinh` = now()  WHERE `MaBarCodeCot` like '%{1}%' and `TrangThaiDen`='{2}' and `MaBarCodeSanPham`='{3}' and `MaBarCodeLot`='{4}'", Trangthaihoanthanh,sobarcodecot,trangthaidakho, MaBarCodeSanPham, MaBarCodeLot);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        internal bool UpdateTrangThaiKhoTheoSanPhamVaLot(string Trangthaihoanthanh, string trangthaidakho, string MaBarCodeSanPham, string MaBarCodeLot)
        {
            string query = string.Format("UPDATE DuLieuVaBaoCao SET `TrangThaiDen` = '{0}' WHERE `TrangThaiDen`='{1}' and `MaBarCodeSanPham`='{2}' and `MaBarCodeLot`='{3}'", Trangthaihoanthanh, trangthaidakho, MaBarCodeSanPham, MaBarCodeLot);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }


        internal List<DuLieuVaBaoCao> GetListMaBarCodeTheoTrangThai(string BarcodeCot, string TrangThaiDen)
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DuLieuVaBaoCao WHERE MaBarCodeCot like '%" + BarcodeCot + "%' and (TrangThaiDen = '" + TrangThaiDen + "') ");

            foreach (DataRow item in data.Rows)
            {
                DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
                listDuLieuVaBaoCao.Add(info);
            }

            return listDuLieuVaBaoCao;
        }

        internal List<DuLieuVaBaoCao> GetListByName(string name, string v1, string v2, string v3)
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DuLieuVaBaoCao WHERE MaBarCodeCot like  '%" + name + "%' and (TrangThaiDen = '" + v1 + "' or TrangThaiDen = '" + v2 + "' or TrangThaiDen = '" + v3 + "') ");

            foreach (DataRow item in data.Rows)
            {
                DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
                listDuLieuVaBaoCao.Add(info);
            }

            return listDuLieuVaBaoCao;


        }

        internal List<DuLieuVaBaoCao> LoadListTimeMin(string name, string v1, string v2, string v3)
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM DuLieuVaBaoCao WHERE MaBarCodeCot like  '%" + name + "%' and ThoiGianKetThucKho = (select MIN(ThoiGianKetThucKho) FROM DuLieuVaBaoCao WHERE MaBarCodeCot like  '%" + name + "%' and (TrangThaiDen = '" + v1 + "' or TrangThaiDen = '" + v2 + "' or TrangThaiDen = '" + v3 + "')) and (TrangThaiDen = '" + v1 + "' or TrangThaiDen = '" + v2 + "' or TrangThaiDen = '" + v3 + "') ");



            foreach (DataRow item in data.Rows)
            {
                DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
                listDuLieuVaBaoCao.Add(info);
            }

            return listDuLieuVaBaoCao;
        }

        internal DataTable GetDataTableReport(string TimeTO, string TimeFROM)
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            // DataTable data = DataProvider.Instance.ExecuteQuery("(SELECT MaBarCodeSanPham as MaSanPham,MaBarCodeLot as MaLot,TenSanPhamTiengViet as TenTiengViet,TenSanPhamTiengAnh as TenTiengAnh,MaBarCodeCot as SoCot,MaBarCodeXe as SoXe,SoLopHienTai as LopHienTai,SoLopKetThuc as  LopTieuChuan,SoThoiGianKho as TG_KhoTieuChuan,ThoiGianKetThucKho as ThoiGianKho,TIMEDIFF(ThoiGianKetThucKho,now()) as ThoiGianConLai,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen as TrangThai FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành'  order by ThoiGianKetThucKho ASC LIMIT 3) union all (SELECT MaBarCodeSanPham,MaBarCodeLot,TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeCot,MaBarCodeXe,SoLopHienTai,SoLopKetThuc,SoThoiGianKho,ThoiGianKetThucKho,TIMEDIFF(ThoiGianKetThucKho,now()),TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Đang Phơi' or TrangThaiDen='Sắp Khô' or TrangThaiDen='Đã Khô' order by ThoiGianKetThucKho ASC)");

            // DataTable data = DataProvider.Instance.ExecuteQuery("select ThoiGianKetThucQuaTrinh,MaBarCodeSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot,SoLopHienTai,SoLopKetThuc,TenCatNhungHienTai,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi,ThoiGianBatDauNhung),ThoiGianBatDauPhoi,SoThoiGianKho,TIMEDIFF(ThoiGianKetThucQuaTrinh,ThoiGianBatDauPhoi),MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TrangThaiDen from dulieuvabaocao where ThoiGianKetThucQuaTrinh >= '" + TimeTO.Value.ToString("yyyy-MM-dd 00:00:00") + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM.Value.ToString("yyyy-MM-dd 23:59:59") + "'");


            DataTable data = DataProvider.Instance.ExecuteQuery("select MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,ThoiGianKetThucQuaTrinh as TGKetThucQuaTrinh,SoLopHienTai as LopHienTai ,SoLopKetThuc as  LopTieuChuan,TenCatNhungHienTai,ThoiGianBatDauNhung,TIME_FORMAT(TIMEDIFF(ThoiGianBatDauPhoi,ThoiGianBatDauNhung), '%H : %i') as SoTGNhungThucTe,ThoiGianBatDauPhoi,SoThoiGianKho,TIME_FORMAT(TIMEDIFF(ThoiGianKetThucQuaTrinh,ThoiGianBatDauPhoi), '%H : %i') as SoTGPhoiThucTe,MaBarCodeXe as MaXe,MaBarCodeCot as MaCot,MaBarCodeNguoi as NguoiPhuTrach,TrangThaiDen as TrangThai from dulieuvabaocao where ThoiGianKetThucQuaTrinh >= '" + TimeTO + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM + "' order by MaLOT asc");

            //foreach (DataRow item in data.Rows)
            //{
            //    DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
            //    listDuLieuVaBaoCao.Add(info);
            //}

            return data;


        }

        internal DataTable GetDataTableReport2(string malot, string TimeTO, string TimeFROM)
        {
            List<DuLieuVaBaoCao> listDuLieuVaBaoCao = new List<DuLieuVaBaoCao>();

            // DataTable data = DataProvider.Instance.ExecuteQuery("(SELECT MaBarCodeSanPham as MaSanPham,MaBarCodeLot as MaLot,TenSanPhamTiengViet as TenTiengViet,TenSanPhamTiengAnh as TenTiengAnh,MaBarCodeCot as SoCot,MaBarCodeXe as SoXe,SoLopHienTai as LopHienTai,SoLopKetThuc as  LopTieuChuan,SoThoiGianKho as TG_KhoTieuChuan,ThoiGianKetThucKho as ThoiGianKho,TIMEDIFF(ThoiGianKetThucKho,now()) as ThoiGianConLai,TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen as TrangThai FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Chuyển Tiếp' or TrangThaiDen='Hoàn Thành'  order by ThoiGianKetThucKho ASC LIMIT 3) union all (SELECT MaBarCodeSanPham,MaBarCodeLot,TenSanPhamTiengViet,TenSanPhamTiengAnh,MaBarCodeCot,MaBarCodeXe,SoLopHienTai,SoLopKetThuc,SoThoiGianKho,ThoiGianKetThucKho,TIMEDIFF(ThoiGianKetThucKho,now()),TenCatNhungHienTai,TenCatNhungTiepTheo,TrangThaiDen FROM juki_giamsatthoigiankho7.dulieuvabaocao where TrangThaiDen='Đang Phơi' or TrangThaiDen='Sắp Khô' or TrangThaiDen='Đã Khô' order by ThoiGianKetThucKho ASC)");

            // DataTable data = DataProvider.Instance.ExecuteQuery("select ThoiGianKetThucQuaTrinh,MaBarCodeSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot,SoLopHienTai,SoLopKetThuc,TenCatNhungHienTai,ThoiGianBatDauNhung,TIMEDIFF(ThoiGianBatDauPhoi,ThoiGianBatDauNhung),ThoiGianBatDauPhoi,SoThoiGianKho,TIMEDIFF(ThoiGianKetThucQuaTrinh,ThoiGianBatDauPhoi),MaBarCodeXe,MaBarCodeCot,MaBarCodeNguoi,TrangThaiDen from dulieuvabaocao where ThoiGianKetThucQuaTrinh >= '" + TimeTO.Value.ToString("yyyy-MM-dd 00:00:00") + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM.Value.ToString("yyyy-MM-dd 23:59:59") + "'");


            DataTable data = DataProvider.Instance.ExecuteQuery("select MaBarCodeSanPham as MaSanPham,TenSanPhamTiengAnh,TenSanPhamTiengViet,MaBarCodeLot as MaLOT,ThoiGianKetThucQuaTrinh as TGKetThucQuaTrinh,SoLopHienTai as LopHienTai ,SoLopKetThuc as  LopTieuChuan,TenCatNhungHienTai,ThoiGianBatDauNhung,TIME_FORMAT(TIMEDIFF(ThoiGianBatDauPhoi,ThoiGianBatDauNhung), '%H : %i') as SoTGNhungThucTe,ThoiGianBatDauPhoi,SoThoiGianKho,TIME_FORMAT(TIMEDIFF(ThoiGianKetThucQuaTrinh,ThoiGianBatDauPhoi), '%H : %i') as SoTGPhoiThucTe,MaBarCodeXe as MaXe,MaBarCodeCot as MaCot,MaBarCodeNguoi as NguoiPhuTrach,TrangThaiDen as TrangThai from dulieuvabaocao where MaBarCodeLot = '" + malot + "' and ThoiGianKetThucQuaTrinh >= '" + TimeTO + "' and ThoiGianKetThucQuaTrinh <= '" + TimeFROM + "' order by MaLOT asc");

            //foreach (DataRow item in data.Rows)
            //{
            //    DuLieuVaBaoCao info = new DuLieuVaBaoCao(item);
            //    listDuLieuVaBaoCao.Add(info);
            //}

            return data;


        }

    }
}
