using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuatJuKi.DTO
{
    public class DuLieuVaBaoCao
    {
        public DuLieuVaBaoCao(int id, string TenSanPhamTiengAnh, string MaBarCodeSanpham, int SoLopHienTai, int SoThoiGianKho, int SoLopKetThuc, string MaBarCodeLot , DateTime? ThoiGianBatDauNhung, DateTime? ThoiGianBatDauPhoi, DateTime? ThoiGianKetThucKho, DateTime? ThoiGianKetThucQuaTrinh, string MaBarCodeXe, string MaBarCodeCot, string TrangThaiDen)
        {

            this.ID = ID;

            this.TenSanPhamTiengAnh = TenSanPhamTiengAnh;
            this.MaBarCodeSanpham = MaBarCodeSanpham;
            this.SoLopHienTai = SoLopHienTai;
            this.SoThoiGianKho = SoThoiGianKho;
            this.SoLopKetThuc = SoLopKetThuc;


            this.MaBarCodeLot = MaBarCodeLot;
            this.ThoiGianBatDauNhung = ThoiGianBatDauNhung;
            this.ThoiGianBatDauPhoi = ThoiGianBatDauPhoi;
            this.ThoiGianKetThucKho = ThoiGianKetThucKho;
            this.ThoiGianKetThucQuaTrinh = ThoiGianKetThucQuaTrinh;

            this.MaBarCodeXe = MaBarCodeXe;
            this.MaBarCodeCot = MaBarCodeCot;
            this.TrangThaiDen = TrangThaiDen;


        }

        public DuLieuVaBaoCao(DataRow row)
        {
            this.ID = (int)row["id"];

            this.TenSanPhamTiengAnh = row["TenSanPhamTiengAnh"].ToString();
            this.TenSanPhamTiengViet = row["TenSanPhamTiengViet"].ToString();

            this.MaBarCodeSanpham = row["MaBarCodeSanpham"].ToString();
            this.SoLopHienTai = (int)row["SoLopHienTai"];
            this.SoThoiGianKho = (int)row["SoThoiGianKho"];
            this.SoLopKetThuc = (int)row["SoLopKetThuc"];


            this.MaBarCodeLot = row["MaBarCodeLot"].ToString();
            this.ThoiGianBatDauNhung = (DateTime?)row["ThoiGianBatDauNhung"];
            this.ThoiGianBatDauPhoi = (DateTime?)row["ThoiGianBatDauPhoi"];
            this.ThoiGianKetThucKho = (DateTime?)row["ThoiGianKetThucKho"];
           // this.ThoiGianKetThucQuaTrinh = (DateTime?)row["ThoiGianKetThucQuaTrinh"];

            var ThoiGianKetThucQuaTrinh1 = row["ThoiGianKetThucQuaTrinh"];
            if (ThoiGianKetThucQuaTrinh1.ToString() != "")
            {
                this.ThoiGianKetThucQuaTrinh = (DateTime?)ThoiGianKetThucQuaTrinh1;
            }
            this.MaBarCodeNguoi = row["MaBarCodeNguoi"].ToString();


            this.MaBarCodeXe = row["MaBarCodeXe"].ToString();
            this.MaBarCodeCot = row["MaBarCodeCot"].ToString();
            this.TrangThaiDen = row["TrangThaiDen"].ToString();
            this.TenCatNhungHienTai = row["TenCatNhungHienTai"].ToString();
            this.TenCatNhungTiepTheo = row["TenCatNhungTiepTheo"].ToString();

        }

        private string _MaBarCodeNguoi;

        public string MaBarCodeNguoi
        {
            get { return _MaBarCodeNguoi; }
            set { _MaBarCodeNguoi = value; }
        }


        private string _TrangThaiDen;

        public string TrangThaiDen
        {
            get { return _TrangThaiDen; }
            set { _TrangThaiDen = value; }
        }


        private string _TenCatNhungHienTai;

        public string TenCatNhungHienTai
        {
            get { return _TenCatNhungHienTai; }
            set { _TenCatNhungHienTai = value; }
        }
        private string _TenCatNhungTiepTheo;

        public string TenCatNhungTiepTheo
        {
            get { return _TenCatNhungTiepTheo; }
            set { _TenCatNhungTiepTheo = value; }
        }


        private DateTime? _ThoiGianKetThucQuaTrinh;

        public DateTime? ThoiGianKetThucQuaTrinh
        {
            get { return _ThoiGianKetThucQuaTrinh; }
            set { _ThoiGianKetThucQuaTrinh = value; }
        }


        private DateTime? _ThoiGianKetThucKho;

        public DateTime? ThoiGianKetThucKho
        {
            get { return _ThoiGianKetThucKho; }
            set { _ThoiGianKetThucKho = value; }
        }



        private DateTime? _ThoiGianBatDauPhoi;

        public DateTime? ThoiGianBatDauPhoi
        {
            get { return _ThoiGianBatDauPhoi; }
            set { _ThoiGianBatDauPhoi = value; }
        }

        private DateTime? _ThoiGianBatDauNhung;

        public DateTime? ThoiGianBatDauNhung
        {
            get { return _ThoiGianBatDauNhung; }
            set { _ThoiGianBatDauNhung = value; }
        }



        private string _MaBarCodeCot;

        public string MaBarCodeCot
        {
            get { return _MaBarCodeCot; }
            set { _MaBarCodeCot = value; }
        }

        private string _MaBarCodeXe;

        public string MaBarCodeXe
        {
            get { return _MaBarCodeXe; }
            set { _MaBarCodeXe = value; }
        }

        private string _MaBarCodeLot;

        public string MaBarCodeLot
        {
            get { return _MaBarCodeLot; }
            set { _MaBarCodeLot = value; }
        }






        private int _SoLopKetThuc;

        public int SoLopKetThuc
        {
            get { return _SoLopKetThuc; }
            set { _SoLopKetThuc = value; }
        }



        private int _SoThoiGianKho;

        public int SoThoiGianKho
        {
            get { return _SoThoiGianKho; }
            set { _SoThoiGianKho = value; }
        }



        private int _SoLopHienTai;

        public int SoLopHienTai
        {
            get { return _SoLopHienTai; }
            set { _SoLopHienTai = value; }
        }



        private string _MaBarCodeSanpham;

        public string MaBarCodeSanpham
        {
            get { return _MaBarCodeSanpham; }
            set { _MaBarCodeSanpham = value; }
        }

        private string _TenSanPhamTiengViet;

        public string TenSanPhamTiengViet
        {
            get { return _TenSanPhamTiengViet; }
            set { _TenSanPhamTiengViet = value; }
        }


        private string _TenSanPhamTiengAnh;

        public string TenSanPhamTiengAnh
        {
            get { return _TenSanPhamTiengAnh; }
            set { _TenSanPhamTiengAnh = value; }
        }



        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
