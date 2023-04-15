using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuatJuKi.DTO
{
    public class MaBarCode
    {
        public MaBarCode(int id, string MaBarCodeSanpham, string MaBarCodeLot, string MaBarCodeXe, string MaBarCodeCot, string TrangThai)
        {
            this.ID = ID;
            this.MaBarCodeSanpham = MaBarCodeSanpham;
            this.MaBarCodeLot = MaBarCodeLot;
            this.MaBarCodeXe = MaBarCodeXe;
            this.MaBarCodeCot = MaBarCodeCot;
            this.MaBarCodeNguoi = MaBarCodeNguoi;

            this.TrangThai = TrangThai;

        }

        public MaBarCode(DataRow row)
        {
            this.ID = (int)row["id"];
            this.MaBarCodeSanpham = row["MaBarCodeSanpham"].ToString();
            this.MaBarCodeLot = row["MaBarCodeLot"].ToString();
            this.MaBarCodeXe = row["MaBarCodeXe"].ToString();
            this.MaBarCodeCot = row["MaBarCodeCot"].ToString();
            this.MaBarCodeNguoi = row["MaBarCodeNguoi"].ToString();

            this.TrangThai = row["TrangThai"].ToString();

        }
        private string _TrangThai;

        public string TrangThai
        {
            get { return _TrangThai; }
            set { _TrangThai = value; }
        }

        private string _MaBarCodeNguoi;

        public string MaBarCodeNguoi
        {
            get { return _MaBarCodeNguoi; }
            set { _MaBarCodeNguoi = value; }
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

        private string _MaBarCodeSanpham;

        public string MaBarCodeSanpham
        {
            get { return _MaBarCodeSanpham; }
            set { _MaBarCodeSanpham = value; }
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
