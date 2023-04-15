using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuatJuKi.DTO
{
    public class BangNhapSoLop
    {
       //// public BangNhapSoLop(int id, string name, int ProductCodeID, float SoThoiGianKho)
       // {
       //     this.ID = id;
       //     this.TenSanPham = TenSanPham;
       //     this.MaBarCodeSanPham = MaBarCodeSanPham;
       //     this.MaBarCodeSanPham = MaBarCodeSanPham;
       //     this.MaBarCodeSanPham = MaBarCodeSanPham;
       //     this.MaBarCodeSanPham = MaBarCodeSanPham;
       //     this.SoThoiGianKho = SoThoiGianKho;
       // }

        public BangNhapSoLop(DataRow row)
        {
            //this.ID = (int)row["id"];



            this.MaBarCodeSanPham = row["MaBarCodeSanPham"].ToString();
            this.TenSanPhamTiengAnh = row["TenSanPhamTiengAnh"].ToString();
            this.TenSanPhamTiengViet = row["TenSanPhamTiengViet"].ToString();
            this.LopNhung = row["LopNhung"].ToString();

            if (row["TongLopNhung"].ToString() != "")
            this.TongLopNhung = (int)row["TongLopNhung"];

            if (row["Zircon01"].ToString() != "")
                this.Zircon01 = (int)row["Zircon01"];

            if (row["Zircon02"].ToString() != "")
                this.Zircon02 = (int)row["Zircon02"];

            if (row["Zircon03"].ToString() != "")
                this.Zircon03 = (int)row["Zircon03"];

            if (row["Zircon04"].ToString() != "")
                this.Zircon04 = (int)row["Zircon04"];

            if (row["CatL01"].ToString() != "")
                this.CatL01 = (int)row["CatL01"];

            if (row["CatL02"].ToString() != "")
                this.CatL02 = (int)row["CatL02"];

            if (row["CatL03"].ToString() != "")
                this.CatL03 = (int)row["CatL03"];

            if (row["CatL04"].ToString() != "")
                this.CatL04 = (int)row["CatL04"];

            if (row["CatL05"].ToString() != "")
                this.CatL05 = (int)row["CatL05"];

            if (row["CatL06"].ToString() != "")
                this.CatL06 = (int)row["CatL06"];

            if (row["CatL07"].ToString() != "")
                this.CatL07 = (int)row["CatL07"];

            if (row["CatL08"].ToString() != "")
                this.CatL08 = (int)row["CatL08"];

            if (row["CatL09"].ToString() != "")
                this.CatL09 = (int)row["CatL09"];

            if (row["SIRU"].ToString() != "")
                this.SIRU = (int)row["SIRU"];

            //this.TongLopNhung = (int)row["TongLopNhung"];

            //this.SoThoiGianKho = (float)Convert.ToDouble(row["SoThoiGianKho"].ToString());

            // this.LopNhung = (int)row["LopNhung"];
            //this.SoThoiGianKho = ()row["SoThoiGianKho"];




        }

        //sắp xếp theo thứ tự
        //private int _ID;

        //public int ID
        //{
        //    get { return _ID; }
        //    set { _ID = value; }
        //}

        private string _MaBarCodeSanPham;

        public string MaBarCodeSanPham
        {
            get { return _MaBarCodeSanPham; }
            set { _MaBarCodeSanPham = value; }
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



        private string _LopNhung;

        public string LopNhung
        {
            get { return _LopNhung; }
            set { _LopNhung = value; }
        }

        private int _TongLopNhung;

        public int TongLopNhung
        {
            get { return _TongLopNhung; }
            set { _TongLopNhung = value; }
        }

        private int _Zircon01;

        public int Zircon01
        {
            get { return _Zircon01; }
            set { _Zircon01 = value; }
        }
        private int _Zircon02;

        public int Zircon02
        {
            get { return _Zircon02; }
            set { _Zircon02 = value; }
        }
        private int _Zircon03;

        public int Zircon03
        {
            get { return _Zircon03; }
            set { _Zircon03 = value; }
        }
        private int _Zircon04;

        public int Zircon04
        {
            get { return _Zircon04; }
            set { _Zircon04 = value; }
        }
        private int _CatL01;

        public int CatL01
        {
            get { return _CatL01; }
            set { _CatL01 = value; }
        }
        private int _CatL02;

        public int CatL02
        {
            get { return _CatL02; }
            set { _CatL02 = value; }
        }
        private int _CatL03;

        public int CatL03
        {
            get { return _CatL03; }
            set { _CatL03 = value; }
        }
        private int _CatL04;

        public int CatL04
        {
            get { return _CatL04; }
            set { _CatL04 = value; }
        }
        private int _CatL05;

        public int CatL05
        {
            get { return _CatL05; }
            set { _CatL05 = value; }
        }
        private int _CatL06;

        public int CatL06
        {
            get { return _CatL06; }
            set { _CatL06 = value; }
        }
        private int _CatL07;

        public int CatL07
        {
            get { return _CatL07; }
            set { _CatL07 = value; }
        }
        private int _CatL08;

        public int CatL08
        {
            get { return _CatL08; }
            set { _CatL08 = value; }
        }
        private int _CatL09;

        public int CatL09
        {
            get { return _CatL09; }
            set { _CatL09 = value; }
        }
        private int _SIRU;

        public int SIRU
        {
            get { return _SIRU; }
            set { _SIRU = value; }
        }

    }
}
