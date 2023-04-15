using ATSCADA;
using QuanLySanXuatJuKi.DAO;
using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace QuanLySanXuatJuKi
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public bool ChotGhiTag { get; private set; }

        public string smaxe;
        public string strangthai;
        private static string smaxet;
        private static string tstrangthai;
        private string nhieumacotmaxe;
        private string soxexexe;
        private string t;


        #region tao list de xet xem viec doc ghi devices cos OK hay ko
        private List<StatusDevices> StatusDevicesList = new List<StatusDevices>();

        public class StatusDevices
        {
            public string WriteStatus { get; set; }
            public string ConnectStatus { get; set; }
            public Int16 CountDisconnect { get; set; }
        }
        #endregion

        //bắt đầu
        public fTableManager(Account acc)
        {
            InitializeComponent();

            //cho cái form loginaccount hiện nếu quyền đăng nhập là admin
            this.LoginAccount = acc;

            //tạo nhiều button
            //khởi tạo add button tự động
            LoadTable();

            //gọi sự kiện lúc timer quét
            OnPlcServiceValuesRefreshed(null, null);
            //gọi sự kiện của vtimer
            TimerScan.Instance.ValuesRefreshed += OnPlcServiceValuesRefreshed;

        }

        public fTableManager()
        {
            InitializeComponent();

            //tạo nhiều button
            //khởi tạo add button tự động
            LoadTable();

            //gọi sự kiện lúc timer quét
            OnPlcServiceValuesRefreshed(null, null);
            //gọi sự kiện của vtimer
            TimerScan.Instance.ValuesRefreshed += OnPlcServiceValuesRefreshed;

        }

        //quet doc du liệu trong database và cap nhat
        //đọc dữ liệu trong database
        private void OnPlcServiceValuesRefreshed(object sender, EventArgs e)
        {
            //quett du lieu trong mabarcode
            taodulieutrongDataAndReport();
            //update trang thai dakho sap kho
            quetthoigianketthucVaUpdatetrangthai();

        }


        //sự kiện cập nhật trang thái xuống atdriver
        private void OnPlcServiceValuesRefreshed2(object sender, EventArgs e)
        {

            if (InvokeRequired)
            {
                MethodInvoker dowork = new MethodInvoker(delegate
                {
                    thaydoimaubutton();
                });

                Invoke(dowork);
                return;
            }


        }


        private void quetthoigianketthucVaUpdatetrangthai()
        {
            List<DuLieuVaBaoCao> list = new List<DuLieuVaBaoCao>();

            //get 1 list gồm trang thai "Đang Phơi" Và "Sắp Khô"
            list = DuLieuVaBaoCaoDAO.Instance.GetListTheothoigia("Đang Phơi", "Sắp Khô");
            // list = DuLieuVaBaoCaoDAO.Instance.GetListTheothoigian("Đang Phơi");

            foreach (var item in list)
            {

                try
                {
                    DateTime t = DateTime.Now;

                    // Một khoảng thời gian. 
                    // 1 giờ + 1 phút
                    DateTime t3 = new DateTime();
                    TimeSpan aInterval = new System.TimeSpan(0, 0, 15, 0);
                    string t2 = item.ThoiGianKetThucKho.ToString();
                    if (t2 != null || t2 == "")
                    {
                        t3 = Convert.ToDateTime(t2);
                    }

                    // Trừ khoảng thời gian.
                    DateTime thoigiancon15p = t3.Subtract(aInterval);
                    //khi thoi gian ket thuc kho nho hoac bang thoi gian hien tai => ket thuc báo trạng thái hoan thanh
                    //   if (item.ThoiGianKetThucKho <= t && item.TrangThaiDen == "Sắp Khô")
                    if (item.ThoiGianKetThucKho <= t)

                    {

                        //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri 1
                        bool reset = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKho("Đã Khô", item.ID);
                        //neu row duoc tao tien hanh reset

                    }
                    //khi trang thai là 2 thì inset soxe so cot vao
                    if (t >= thoigiancon15p && t <= item.ThoiGianKetThucKho && item.TrangThaiDen == "Đang Phơi")
                    {

                        //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri 1
                        bool reset = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKho("Sắp Khô", item.ID);
                        //neu row duoc tao tien hanh reset

                    }
                }
                catch { }

            }

        }

        //quet lien tuc để lấy barcode từ các máy quét barcode qua
        private void taodulieutrongDataAndReport()
        {

            List<MaBarCode> list = new List<MaBarCode>();
            list = MaBarCodeDAO.Instance.GetListMaBarCodeTheoTrangThai();
            foreach (var item in list)
            {
                try
                {
                    //khi trang thai cua macode len 1, ĐĂNG KÝ SẢN PHẨM MỚI
                    if (item.TrangThai == "1")
                    {
                        //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri 1
                        bool reset = DuLieuVaBaoCaoDAO.Instance.InsertSanPhamSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot, 1);
                        //neu row duoc tao tien hanh reset
                        if (reset)
                        {
                            MaBarCodeDAO.Instance.UpdateTrangThaiMaCode(item.ID, "0");

                        }

                    }
                    //khi trang thai là 2 thì inset soxe so cot vao. ĐĂNG KÝ PHƠI
                    if (item.TrangThai == "2")
                    {
                        //XEM BEN TRONG DATABASE CO BAO NHIEU DONG
                        object sorow1 = DuLieuVaBaoCaoDAO.Instance.SelecttheoSanPhanVaSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                        int sorow = Convert.ToInt16(sorow1);
                        //  string[] xu = new string[10];


                        string mabarcodesanpham = item.MaBarCodeSanpham;
                        //lay ra 1 doi tuong loc tu barcodesanpham

                        //List<BangNhapSoLop> bangsolop = new List<BangNhapSoLop>();

                        var bangsolop = BangNhapSoLopDAO.Instance.GetListBangNhapSoLopByMaSanPham(mabarcodesanpham).LastOrDefault();

                        string[] str1 = new string[14] { bangsolop.Zircon01.ToString(), bangsolop.Zircon02.ToString(), bangsolop.Zircon03.ToString(), bangsolop.Zircon04.ToString(),
                                                        bangsolop.CatL01.ToString(), bangsolop.CatL02.ToString(), bangsolop.CatL03.ToString(), bangsolop.CatL04.ToString(),
                                                        bangsolop.CatL05.ToString(), bangsolop.CatL06.ToString(), bangsolop.CatL07.ToString(), bangsolop.CatL08.ToString(),
                                                        bangsolop.CatL09.ToString(), bangsolop.SIRU.ToString()};
                        string[] str3 = new string[14] { "ZIRCON Lần1", "ZIRCON Lần2", "ZIRCON Lần3", "ZIRCON Lần4",
                                                        "0.1~0.3", "0.3~0.7 Lần1", "0.3~0.7 Lần2", "0.7~1.0 Lần1",
                                                        "0.7~1.0 Lần2", "0.7~1.0 Lần3", "0.7~1.0 Lần4", "0.7~1.0 Lần5",
                                                        "0.7~1.0 Lần6", "SIRU"};



                        int i = 1;
                        string[] str2 = new string[14];
                        string[] str4 = new string[14];

                        for (int i1 = 0; i1 < str1.Length; i1++)
                        {
                            if (!string.IsNullOrEmpty(str1[i1]) && str1[i1] != "0")
                            {
                                str2[i] = str1[i1];
                                str4[i] = str3[i1];
                                i++;
                            }

                        }

                        //vietnotelai update trang thai den mau do va trang thai den "Đang Phơi"
                        if (!string.IsNullOrEmpty(str2[sorow]) && str2[sorow] != "0")
                        {
                            bool chophepreset = DuLieuVaBaoCaoDAO.Instance.UpdateSocotSoxeAndSolophientai(bangsolop.TenSanPhamTiengAnh, Convert.ToInt16(str2[sorow]), bangsolop.TongLopNhung, item.MaBarCodeXe, item.MaBarCodeCot, item.MaBarCodeSanpham, item.MaBarCodeLot, sorow, str4[sorow], str4[sorow + 1], bangsolop.TenSanPhamTiengViet, item.MaBarCodeNguoi);


                            if (chophepreset)
                            {
                                MaBarCodeDAO.Instance.UpdateTrangThaiMaCode(item.ID, "3");

                            }

                        }
                        else
                        {
                            MaBarCodeDAO.Instance.UpdateTrangThaiMaCode(item.ID, "0");
                            MessageBox.Show("Mã Sản Phẩm " + item.MaBarCodeSanpham + " bị lỗi. Xem lại sản phẩm đã nhập chưa hoặc số thời gian khô của lớp bị sai hoặc thiếu");

                        }
                        //}
                        //}
                    }
                }
                catch
                {
                    MaBarCodeDAO.Instance.UpdateTrangThaiMaCode(item.ID, "0");
                    MessageBox.Show("Mã Sản Phẩm " + item.MaBarCodeSanpham + " bị lỗi. Xem lại sản phẩm đã nhập chưa hoặc số thời gian khô của lớp bị sai hoặc thiếu");
                }

            }

        }

        #region Method

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        void LoadTable()
        {
            //xoá tất cả control có trong table
            flpTable.Controls.Clear();

            // lấy ra 1 list
            List<LocationSet> tableList = LocationSetDAO.Instance.LoadTableList();
            // DuLieuVaBaoCaolist.Distinct().ToList();
            foreach (LocationSet item in tableList)
            {
                Button btn = new Button() { Width = LocationSetDAO.TableWidth, Height = LocationSetDAO.TableHeight };
                //lấy ra 1 dong có thời gian kho ngắn nhất
                List<DuLieuVaBaoCao> lisdataTimeMin = DuLieuVaBaoCaoDAO.Instance.LoadListTimeMin(item.Name, "Đã Khô", "Sắp Khô", "Đang Phơi");

                if (lisdataTimeMin.Count != 0)
                {
                    smaxe = lisdataTimeMin[0].MaBarCodeXe;

                    strangthai = lisdataTimeMin[0].TrangThaiDen;
                    if (lisdataTimeMin[0].SoLopHienTai == lisdataTimeMin[0].SoLopKetThuc && strangthai == "Đã Khô")
                    {
                        strangthai = "Chuyển Tiếp";
                    }
                }
                if (lisdataTimeMin.Count == 0)
                {
                    smaxe = "";
                    strangthai = "Trống";
                }



                btn.Click += btn_Click;
                btn.Text = item.Name + Environment.NewLine + smaxe + Environment.NewLine + strangthai;
                btn.Font = new System.Drawing.Font("Times New Roman", 15);

                btn.Tag = item;
                btn.Name = "btn" + item.Name;

                StatusDevicesList.Add(new StatusDevices { WriteStatus = "Good", ConnectStatus = "Good", CountDisconnect = 0 });

                //switch (strangthai)
                //{
                //    case "Trống":
                //        btn.BackColor = Color.White;
                //        break;
                //    case "Đang Phơi":
                //        btn.BackColor = Color.Red;
                //        break;
                //    case "Sắp Khô":
                //        btn.BackColor = Color.Yellow;
                //        break;

                //    case "Đã Khô":
                //        btn.BackColor = Color.Green;
                //        break;
                //    case "Chuyển Tiếp":
                //        btn.BackColor = Color.DeepSkyBlue;
                //        break;


                //    default:
                //        btn.BackColor = Color.DeepSkyBlue;
                //        break;

                //}

                flpTable.Controls.Add(btn);
            }
            Debug.WriteLine(StatusDevicesList.Count);
            Debug.WriteLine(StatusDevicesList[0].WriteStatus);

        }

        void thaydoimaubutton()
        {
            var parent = this.FindForm(); // returns the object of the form containing the current usercontrol.

            List<LocationSet> tableList = LocationSetDAO.Instance.LoadTableList();
            // DuLieuVaBaoCaolist.Distinct().ToList();
            try
            {
                foreach (LocationSet item in tableList)
                {


                    // Button btn = new Button() { Width = LocationSetDAO.TableWidth, Height = LocationSetDAO.TableHeight };
                    //lấy ra 1 dong có thời gian kho ngắn nhất khi nhấp vào button
                    List<DuLieuVaBaoCao> lisdataTimeMin = DuLieuVaBaoCaoDAO.Instance.LoadListTimeMin(item.Name, "Đã Khô", "Sắp Khô", "Đang Phơi");

                    nhieumacotmaxe = "";
                    if (lisdataTimeMin.Count != 0)
                    {
                        //mã xe
                        smaxet = lisdataTimeMin[0].MaBarCodeXe;


                        string[] arrListStr = smaxet.Split('|');
                        //mã cột
                        nhieumacotmaxe = lisdataTimeMin[0].MaBarCodeCot;
                        string[] arrListStrccc = nhieumacotmaxe.Split('|');

                        //lặp tìm phần tử  tim so sanh so cot 
                        for (int i = 0; i < arrListStrccc.Length; i++)
                        {
                            if (arrListStrccc[i] == item.Name)
                            {
                                soxexexe = arrListStr[i];
                            }
                        }


                        tstrangthai = lisdataTimeMin[0].TrangThaiDen;
                        if (lisdataTimeMin[0].SoLopHienTai == lisdataTimeMin[0].SoLopKetThuc && tstrangthai == "Đã Khô")
                        {
                            tstrangthai = "Hoàn Thành";
                        }
                    }
                    //neu so dòng select ra = 0 thì coi như trống
                    if (lisdataTimeMin.Count == 0)
                    {
                        smaxet = "";
                        tstrangthai = "Trống";
                        soxexexe = "";
                    }

                    #region kiểm tra mất kết nối cột đèn
                    //sua cho này de đọc được nhiều channel
                    int namenew = Convert.ToInt16(item.Name.Substring(4, 3));//lấy ra số thứ cột 1-->70. item.Name="COT_001

                    if (namenew <= 20)
                    {
                        var tag = iDriver1.Task("Channel1" + item.Name).Tag("NutNhanKetThuc");
                        string task = tag.Task.Name;//lay ra taskName= Channel1COT_001

                        if (iDriver1.Task("Channel1" + item.Name).Tag("DenDo").Status != "Good" && iDriver1.Task("Channel1" + item.Name).Tag("DenVang").Status != "Good" && iDriver1.Task("Channel1" + item.Name).Tag("DenXanhLa").Status != "Good"
                                && iDriver1.Task("Channel1" + item.Name).Tag("DenXanhDuong").Status != "Good" && iDriver1.Task("Channel1" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect++;
                            if (StatusDevicesList[namenew - 1].CountDisconnect >= 5)
                            {
                                StatusDevicesList[namenew - 1].ConnectStatus = "Bad";
                                smaxet = "";
                                tstrangthai = "Mất Kết Nối";
                                soxexexe = "";
                                StatusDevicesList[namenew - 1].CountDisconnect = 10;
                            }
                            //smaxet = "";
                            //tstrangthai = "Mất Kết Nối";
                            //soxexexe = "";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }
                        else if (StatusDevicesList[namenew - 1].CountDisconnect != 0)
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect = 0;
                            StatusDevicesList[namenew - 1].ConnectStatus = "Good";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }

                        //goi method quet nut nhan ket thuc
                        if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                        {
                            XuLyNutNhanKetThuc(task);
                        }
                    }
                    else if (namenew > 20 && namenew <= 40)
                    {
                        //if (iDriver1.Task("Channel2" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                        //{
                        //    smaxet = "";
                        //    tstrangthai = "Mất Kết Nối";
                        //    soxexexe = "";
                        //}

                        var tag = iDriver1.Task("Channel2" + item.Name).Tag("NutNhanKetThuc");
                        string task = tag.Task.Name;//lay ra taskName= Channel1COT_001

                        if (iDriver1.Task("Channel2" + item.Name).Tag("DenDo").Status != "Good" && iDriver1.Task("Channel2" + item.Name).Tag("DenVang").Status != "Good" && iDriver1.Task("Channel2" + item.Name).Tag("DenXanhLa").Status != "Good"
                                 && iDriver1.Task("Channel2" + item.Name).Tag("DenXanhDuong").Status != "Good" && iDriver1.Task("Channel2" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect++;
                            if (StatusDevicesList[namenew - 1].CountDisconnect >= 5)
                            {
                                StatusDevicesList[namenew - 1].ConnectStatus = "Bad";
                                smaxet = "";
                                tstrangthai = "Mất Kết Nối";
                                soxexexe = "";
                                StatusDevicesList[namenew - 1].CountDisconnect = 10;
                            }
                            //smaxet = "";
                            //tstrangthai = "Mất Kết Nối";
                            //soxexexe = "";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }
                        else if (StatusDevicesList[namenew - 1].CountDisconnect != 0)
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect = 0;
                            StatusDevicesList[namenew - 1].ConnectStatus = "Good";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }
                        //goi method quet nut nhan ket thuc
                        if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                        {
                            XuLyNutNhanKetThuc(task);
                        }
                    }
                    else if (namenew > 40 && namenew <= 60)
                    {
                        //if (iDriver1.Task("Channel3" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                        //{
                        //    smaxet = "";
                        //    tstrangthai = "Mất Kết Nối";
                        //    soxexexe = "";
                        //}

                        var tag = iDriver1.Task("Channel3" + item.Name).Tag("NutNhanKetThuc");
                        string task = tag.Task.Name;//lay ra taskName= Channel1COT_001

                        if (iDriver1.Task("Channel3" + item.Name).Tag("DenDo").Status != "Good" && iDriver1.Task("Channel3" + item.Name).Tag("DenVang").Status != "Good" && iDriver1.Task("Channel3" + item.Name).Tag("DenXanhLa").Status != "Good"
                               && iDriver1.Task("Channel3" + item.Name).Tag("DenXanhDuong").Status != "Good" && iDriver1.Task("Channel3" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect++;
                            if (StatusDevicesList[namenew - 1].CountDisconnect >= 5)
                            {
                                StatusDevicesList[namenew - 1].ConnectStatus = "Bad";
                                smaxet = "";
                                tstrangthai = "Mất Kết Nối";
                                soxexexe = "";
                                StatusDevicesList[namenew - 1].CountDisconnect = 10;
                            }
                            //smaxet = "";
                            //tstrangthai = "Mất Kết Nối";
                            //soxexexe = "";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }
                        else if (StatusDevicesList[namenew - 1].CountDisconnect != 0)
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect = 0;
                            StatusDevicesList[namenew - 1].ConnectStatus = "Good";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }
                        //goi method quet nut nhan ket thuc
                        if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                        {
                            XuLyNutNhanKetThuc(task);
                        }
                    }
                    else if (namenew > 60 && namenew <= 69)
                    {
                        //if (iDriver1.Task("Channel4" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                        //{
                        //    smaxet = "";
                        //    tstrangthai = "Mất Kết Nối";
                        //    soxexexe = "";
                        //}

                        var tag = iDriver1.Task("Channel4" + item.Name).Tag("NutNhanKetThuc");
                        string task = tag.Task.Name;//lay ra taskName= Channel1COT_001

                        if (iDriver1.Task("Channel4" + item.Name).Tag("DenDo").Status != "Good" && iDriver1.Task("Channel4" + item.Name).Tag("DenVang").Status != "Good" && iDriver1.Task("Channel4" + item.Name).Tag("DenXanhLa").Status != "Good"
                              && iDriver1.Task("Channel4" + item.Name).Tag("DenXanhDuong").Status != "Good" && iDriver1.Task("Channel4" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect++;
                            if (StatusDevicesList[namenew - 1].CountDisconnect > 5)
                            {
                                StatusDevicesList[namenew - 1].ConnectStatus = "Bad";
                                smaxet = "";
                                tstrangthai = "Mất Kết Nối";
                                soxexexe = "";
                                StatusDevicesList[namenew - 1].CountDisconnect = 10;
                            }
                            //smaxet = "";
                            //tstrangthai = "Mất Kết Nối";
                            //soxexexe = "";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }
                        else if (StatusDevicesList[namenew - 1].CountDisconnect != 0)
                        {
                            StatusDevicesList[namenew - 1].CountDisconnect = 0;
                            StatusDevicesList[namenew - 1].ConnectStatus = "Good";
                            Debug.WriteLine(StatusDevicesList[namenew - 1].CountDisconnect, StatusDevicesList[namenew - 1].ConnectStatus);
                        }
                        //goi method quet nut nhan ket thuc
                        if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                        {
                            XuLyNutNhanKetThuc(task);
                        }
                    }
                    #region nguyen mẫu
                    //if (iDriver1.Task("Channel1" + item.Name).Tag("NutNhanKetThuc").Status != "Good")
                    //{
                    //    smaxet = "";
                    //    tstrangthai = "Mất Kết Nối";
                    //    soxexexe = "";
                    //}
                    #endregion
                    #endregion

                    #region xu ly mau button và update trang thai den duoi thiet bi
                    //tim theo ten button da khoi tao
                    var findButton = parent.Controls.Find("btn" + item.Name, true).FirstOrDefault();
                    if (findButton != null)
                    {

                        // btn.Click += btn_Click;
                        findButton.Text = item.Name + Environment.NewLine + soxexexe + Environment.NewLine + tstrangthai;
                        //findButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);

                        // btn.Tag = item;
                        //btn.Name = "btn" + item.Name;

                        switch (tstrangthai)
                        {
                            case "Mất Kết Nối":
                                if (findButton.BackColor != Color.Magenta)
                                {
                                    findButton.BackColor = Color.Magenta;
                                    // setcotden("Trống", item.Name);

                                }
                                break;



                            case "Trống":
                                //if (findButton.BackColor != Color.White && StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                {
                                    findButton.BackColor = Color.White;
                                    setcotden("Trống", item.Name);

                                }

                                break;
                            case "Đang Phơi":
                                //if (findButton.BackColor != Color.Red && StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                {
                                    findButton.BackColor = Color.Red;
                                    setcotden("Đang Phơi", item.Name);
                                }
                                break;
                            case "Sắp Khô":
                                //if (findButton.BackColor != Color.Yellow && StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                {
                                    findButton.BackColor = Color.Yellow;
                                    setcotden("Sắp Khô", item.Name);


                                }

                                break;

                            case "Đã Khô":
                                //if (findButton.BackColor != Color.Green && StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                {
                                    findButton.BackColor = Color.Green;
                                    setcotden("Đã Khô", item.Name);
                                }
                                break;

                            case "Hoàn Thành":
                                //if (findButton.BackColor != Color.DeepSkyBlue && StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                {
                                    findButton.BackColor = Color.DeepSkyBlue;
                                    setcotden("Hoàn Thành", item.Name);
                                }
                                break;


                            default:
                                //if (findButton.BackColor != Color.White && StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                if (StatusDevicesList[namenew - 1].ConnectStatus == "Good")
                                {
                                    findButton.BackColor = Color.White;
                                    setcotden("Trống", item.Name);
                                }
                                break;

                        }

                    }
                    #endregion
                }
            }
            catch { }

        }

        /// <summary>
        /// doc tin hieu tu nut nhan cua thiet bi de xac nhanj ket thuc phoi.
        /// </summary>
        /// <param name="task">task truyen vao. co dang Channel1COT_001.</param>
        private void XuLyNutNhanKetThuc(string task)
        {
            try
            {
                // "Channel1COT_001/NutNhanKetThuc/1"
                // string t = e.NewDisplayValue;
                //string[] arrListStr = e.NewDisplayValue.Split('/');
                //string task = arrListStr[0];
                //  arrListStr[0]= Channel1COT_001
                string chuoicot = task.Substring(task.Length - 7, 7);
                if (iDriver1.Task(task).Tag("NutNhanKetThuc").Value == "1" && (iDriver1.Task(task).Tag("DenXanhLa").Value == "1" || iDriver1.Task(task).Tag("DenXanhDuong").Value == "1"))
                {
                    List<DuLieuVaBaoCao> list = new List<DuLieuVaBaoCao>();
                    //lấy ra 1 list theo số cột và trạng thái đã khô
                    //list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai("COT_001","Đã Khô","Chuyển Tiếp");
                    list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai(chuoicot, "Đã Khô");

                    foreach (var item in list)
                    {
                        if (item.SoLopHienTai < item.SoLopKetThuc)
                        {
                            //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô
                            bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Chuyển Tiếp", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);
                            if (updatehoanthanh)
                            {
                                object sorow1 = DuLieuVaBaoCaoDAO.Instance.SelecttheoSanPhanVaSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                int sorow = Convert.ToInt16(sorow1);
                                //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri bang so count trong dòng cong 1
                                bool reset = DuLieuVaBaoCaoDAO.Instance.InsertSanPhamSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot, sorow + 1);
                                //neu row duoc tao tien hanh reset
                                if (reset)
                                {
                                    MaBarCodeDAO.Instance.UpdateTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot, "0");

                                }
                            }
                        }
                        if (item.SoLopHienTai == item.SoLopKetThuc)
                        {
                            //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô

                            ///update trang thai qua chu trinh
                            bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Hoàn Thành", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);

                            if (updatehoanthanh)
                            {
                                ///update tat ca cac trang thai hoan thanh thanh chuyen chu trinh khi so lop bang số lớp kết thúc
                                bool updatehoanthanh2 = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSanPhamVaLot("Hoàn Thành", "Chuyển Tiếp", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                MaBarCodeDAO.Instance.DeleteTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                            }
                        }
                    }
                    try
                    {
                        if (iDriver1.Task(task).Tag("NutNhanKetThuc").Status == "Good")
                        {
                            iDriver1.Task(task).Tag("NutNhanKetThuc").Value = "0";
                        }
                    }
                    catch { }

                }
            }
            catch
            {
            }
        }

        //haythaydoi
        private void setcotden(string v, string name)
        {
            //COT_001
            // lấy so sanh neu có nhiều channel


            int namenew = Convert.ToInt16(name.Substring(4, 3));
            if (namenew <= 20)
            {
                switch (v)
                {
                    case "Đang Phơi":
                        if (iDriver1.Task("Channel1" + name).Tag("DenDo").Value != "1")
                        {
                            iDriver1.Task("Channel1" + name).Tag("DenDo").Value = "1";

                            iDriver1.Task("Channel1" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenXanhDuong").Value = "0";
                        }

                        break;
                    case "Sắp Khô":
                        if (iDriver1.Task("Channel1" + name).Tag("DenVang").Value != "1")
                        {
                            iDriver1.Task("Channel1" + name).Tag("DenVang").Value = "1";
                            iDriver1.Task("Channel1" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenXanhDuong").Value = "0";
                        }
                        break;

                    case "Đã Khô":
                        if (iDriver1.Task("Channel1" + name).Tag("DenXanhLa").Value != "1")
                        {
                            iDriver1.Task("Channel1" + name).Tag("DenXanhLa").Value = "1";
                            iDriver1.Task("Channel1" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenXanhDuong").Value = "0";
                        }
                        break;
                    case "Hoàn Thành":
                        if (iDriver1.Task("Channel1" + name).Tag("DenXanhDuong").Value != "1")
                        {
                            iDriver1.Task("Channel1" + name).Tag("DenXanhDuong").Value = "1";
                            iDriver1.Task("Channel1" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenXanhLa").Value = "0";
                        }
                        break;
                    case "Trống":
                        if (iDriver1.Task("Channel1" + name).Tag("DenDo").Value == "1" || iDriver1.Task("Channel1" + name).Tag("DenVang").Value == "1"
                            || iDriver1.Task("Channel1" + name).Tag("DenXanhLa").Value == "1" || iDriver1.Task("Channel1" + name).Tag("DenXanhDuong").Value == "1")
                        {
                            iDriver1.Task("Channel1" + name).Tag("DenXanhDuong").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel1" + name).Tag("DenXanhLa").Value = "0";
                            Debug.WriteLine("Write tag trong");
                        }

                        break;

                }

            }
            //thay doichannel 2
            else if (namenew > 20 && namenew <= 40)
            {
                //channel 2
                switch (v)
                {
                    case "Đang Phơi":
                        if (iDriver1.Task("Channel2" + name).Tag("DenDo").Value != "1")
                        {
                            iDriver1.Task("Channel2" + name).Tag("DenDo").Value = "1";

                            iDriver1.Task("Channel2" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenXanhDuong").Value = "0";
                        }

                        break;
                    case "Sắp Khô":
                        if (iDriver1.Task("Channel2" + name).Tag("DenVang").Value != "1")
                        {
                            iDriver1.Task("Channel2" + name).Tag("DenVang").Value = "1";
                            iDriver1.Task("Channel2" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenXanhDuong").Value = "0";

                        }

                        break;

                    case "Đã Khô":
                        if (iDriver1.Task("Channel2" + name).Tag("DenXanhLa").Value != "1")
                        {
                            iDriver1.Task("Channel2" + name).Tag("DenXanhLa").Value = "1";
                            iDriver1.Task("Channel2" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenXanhDuong").Value = "0";

                        }


                        break;
                    case "Hoàn Thành":
                        if (iDriver1.Task("Channel2" + name).Tag("DenXanhDuong").Value != "1")
                        {
                            iDriver1.Task("Channel2" + name).Tag("DenXanhDuong").Value = "1";
                            iDriver1.Task("Channel2" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenXanhLa").Value = "0";

                        }

                        break;
                    case "Trống":
                        if (iDriver1.Task("Channel2" + name).Tag("DenDo").Value == "1" || iDriver1.Task("Channel2" + name).Tag("DenVang").Value == "1"
                            || iDriver1.Task("Channel2" + name).Tag("DenXanhLa").Value == "1" || iDriver1.Task("Channel2" + name).Tag("DenXanhDuong").Value == "1")
                        {
                            iDriver1.Task("Channel2" + name).Tag("DenXanhDuong").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel2" + name).Tag("DenXanhLa").Value = "0";

                        }
                        break;
                }
            }

            else if (namenew > 40 && namenew <= 60)
            {
                //channel 3
                switch (v)
                {
                    case "Đang Phơi":
                        if (iDriver1.Task("Channel3" + name).Tag("DenDo").Value != "1")
                        {
                            iDriver1.Task("Channel3" + name).Tag("DenDo").Value = "1";

                            iDriver1.Task("Channel3" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenXanhDuong").Value = "0";
                        }

                        break;
                    case "Sắp Khô":
                        if (iDriver1.Task("Channel3" + name).Tag("DenVang").Value != "1")
                        {
                            iDriver1.Task("Channel3" + name).Tag("DenVang").Value = "1";
                            iDriver1.Task("Channel3" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenXanhDuong").Value = "0";

                        }

                        break;

                    case "Đã Khô":
                        if (iDriver1.Task("Channel3" + name).Tag("DenXanhLa").Value != "1")
                        {
                            iDriver1.Task("Channel3" + name).Tag("DenXanhLa").Value = "1";
                            iDriver1.Task("Channel3" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenXanhDuong").Value = "0";

                        }


                        break;
                    case "Hoàn Thành":
                        if (iDriver1.Task("Channel3" + name).Tag("DenXanhDuong").Value != "1")
                        {
                            iDriver1.Task("Channel3" + name).Tag("DenXanhDuong").Value = "1";
                            iDriver1.Task("Channel3" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenXanhLa").Value = "0";

                        }

                        break;
                    case "Trống":
                        if (iDriver1.Task("Channel3" + name).Tag("DenDo").Value == "1" || iDriver1.Task("Channel3" + name).Tag("DenVang").Value == "1"
                            || iDriver1.Task("Channel3" + name).Tag("DenXanhLa").Value == "1" || iDriver1.Task("Channel3" + name).Tag("DenXanhDuong").Value == "1")
                        {
                            iDriver1.Task("Channel3" + name).Tag("DenXanhDuong").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel3" + name).Tag("DenXanhLa").Value = "0";

                        }
                        break;
                }
            }
            else if (namenew > 60 && namenew <= 69)
            {
                //channel 4
                switch (v)
                {
                    case "Đang Phơi":
                        if (iDriver1.Task("Channel4" + name).Tag("DenDo").Value != "1")
                        {
                            iDriver1.Task("Channel4" + name).Tag("DenDo").Value = "1";

                            iDriver1.Task("Channel4" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenXanhDuong").Value = "0";
                        }

                        break;
                    case "Sắp Khô":
                        if (iDriver1.Task("Channel4" + name).Tag("DenVang").Value != "1")
                        {
                            iDriver1.Task("Channel4" + name).Tag("DenVang").Value = "1";
                            iDriver1.Task("Channel4" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenXanhLa").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenXanhDuong").Value = "0";

                        }

                        break;

                    case "Đã Khô":
                        if (iDriver1.Task("Channel4" + name).Tag("DenXanhLa").Value != "1")
                        {
                            iDriver1.Task("Channel4" + name).Tag("DenXanhLa").Value = "1";
                            iDriver1.Task("Channel4" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenXanhDuong").Value = "0";

                        }


                        break;
                    case "Hoàn Thành":
                        if (iDriver1.Task("Channel4" + name).Tag("DenXanhDuong").Value != "1")
                        {
                            iDriver1.Task("Channel4" + name).Tag("DenXanhDuong").Value = "1";
                            iDriver1.Task("Channel4" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenXanhLa").Value = "0";

                        }

                        break;
                    case "Trống":
                        if (iDriver1.Task("Channel4" + name).Tag("DenDo").Value == "1" || iDriver1.Task("Channel4" + name).Tag("DenVang").Value == "1"
                            || iDriver1.Task("Channel4" + name).Tag("DenXanhLa").Value == "1" || iDriver1.Task("Channel4" + name).Tag("DenXanhDuong").Value == "1")
                        {
                            iDriver1.Task("Channel4" + name).Tag("DenXanhDuong").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenDo").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenVang").Value = "0";
                            iDriver1.Task("Channel4" + name).Tag("DenXanhLa").Value = "0";

                        }
                        break;
                }
            }
        }
        //show 1 list khi nhấn button
        void ShowBill(string name)
        {
            lsvBill.Items.Clear();
            List<DuLieuVaBaoCao> listBillInfo = DuLieuVaBaoCaoDAO.Instance.GetListByName(name, "Đã Khô", "Sắp Khô", "Đang Phơi");
            foreach (DuLieuVaBaoCao item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaBarCodeSanpham.ToString());
                lsvItem.SubItems.Add(item.MaBarCodeLot.ToString());
                lsvItem.SubItems.Add(item.TenSanPhamTiengViet.ToString());
                lsvItem.SubItems.Add(item.MaBarCodeXe.ToString());
                lsvItem.SubItems.Add(item.TenCatNhungHienTai.ToString());
                lsvItem.SubItems.Add(item.TenCatNhungTiepTheo.ToString());


                lsvItem.SubItems.Add(item.SoLopHienTai.ToString());
                lsvItem.SubItems.Add(item.SoLopKetThuc.ToString());
                lsvItem.SubItems.Add(item.SoThoiGianKho.ToString());

                lsvItem.SubItems.Add(item.ThoiGianKetThucKho.ToString());

                lsvItem.SubItems.Add(item.MaBarCodeNguoi.ToString());

                lsvItem.SubItems.Add(item.TrangThaiDen.ToString());

                //  totalSoThoiGianKho += item.ID;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");


        }
        #endregion

        #region Events
        //sự kiện buton được tạo tự động
        void btn_Click(object sender, EventArgs e)
        {

            string tablename = ((sender as Button).Tag as LocationSet).Name;
            lsvBill.Tag = (sender as Button).Tag;
            //sow list sản phẩm trong listview
            ShowBill(tablename);

        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.ShowDialog();
        }
        #endregion

        private void fTableManager_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            iDriver1.ConstructionCompleted += iDriver1_ConstructionCompleted;

        }

        //haythaydoi
        private void iDriver1_ConstructionCompleted()
        {

            try
            {
                #region khoi tao ban dau, tao su kien
                //haythaydoi thay đổi biến i bằng số cột cộng cho 1
                //for (int i = 1; i < 70; i++)
                //{
                //    //001
                //    t = i.ToString().PadLeft(3, '0');
                //    int t2 = Convert.ToInt16(t);

                //    ////haythaydoi

                //    //iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc").TagValueChanged += NutNhan_TagValueChanged;
                //    //if (iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc").Status == "Good")
                //    //{
                //    //    iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc").Value = "0";
                //    //}


                //    //haythaydoi

                //    if (t2 <= 20)
                //    {
                //        //var tag = iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc");
                //        //iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc").TagValueChanged += NutNhan_TagValueChanged;

                //        ////ky thuat lamda += (s, e) =>...
                //        //iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc").TagStatusChanged += (s, e) =>
                //        //{
                //        //    string task = tag.Task.Name;
                //        //    FTableManager_TagStatusChanged(s, e, task);
                //        //};
                //        //if (iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc").Status == "Good")
                //        //{
                //        //    iDriver1.Task("Channel1COT_" + t).Tag("NutNhanKetThuc").Value = "0";
                //        //}

                //    }
                //    else if (t2 > 20 && t2 <= 40)
                //    {
                //        //sửa channel 2
                //        var tag = iDriver1.Task("Channel2COT_" + t).Tag("NutNhanKetThuc");
                //        iDriver1.Task("Channel2COT_" + t).Tag("NutNhanKetThuc").TagValueChanged += NutNhan_TagValueChanged;
                //        iDriver1.Task("Channel2COT_" + t).Tag("NutNhanKetThuc").TagStatusChanged += (s, e) =>
                //        {
                //            string task = tag.Task.Name;
                //            FTableManager_TagStatusChanged(s, e, task);
                //        };
                //        if (iDriver1.Task("Channel2COT_" + t).Tag("NutNhanKetThuc").Status == "Good")
                //        {
                //            iDriver1.Task("Channel2COT_" + t).Tag("NutNhanKetThuc").Value = "0";
                //        }
                //    }
                //    else if (t2 > 40 && t2 <= 60)
                //    {
                //        //sửa channel 3
                //        var tag = iDriver1.Task("Channel3COT_" + t).Tag("NutNhanKetThuc");
                //        iDriver1.Task("Channel3COT_" + t).Tag("NutNhanKetThuc").TagValueChanged += NutNhan_TagValueChanged;
                //        iDriver1.Task("Channel3COT_" + t).Tag("NutNhanKetThuc").TagStatusChanged += (s, e) =>
                //        {
                //            string task = tag.Task.Name;
                //            FTableManager_TagStatusChanged(s, e, task);
                //        };
                //        if (iDriver1.Task("Channel3COT_" + t).Tag("NutNhanKetThuc").Status == "Good")
                //        {
                //            iDriver1.Task("Channel3COT_" + t).Tag("NutNhanKetThuc").Value = "0";
                //        }
                //    }
                //    else if (t2 > 60 && t2 <= 69)
                //    {
                //        //sửa channel 4
                //        var tag = iDriver1.Task("Channel4COT_" + t).Tag("NutNhanKetThuc");
                //        iDriver1.Task("Channel4COT_" + t).Tag("NutNhanKetThuc").TagValueChanged += NutNhan_TagValueChanged;
                //        iDriver1.Task("Channel4COT_" + t).Tag("NutNhanKetThuc").TagStatusChanged += (s, e) =>
                //        {
                //            string task = tag.Task.Name;
                //            FTableManager_TagStatusChanged(s, e, task);
                //        };
                //        if (iDriver1.Task("Channel4COT_" + t).Tag("NutNhanKetThuc").Status == "Good")
                //        {
                //            iDriver1.Task("Channel4COT_" + t).Tag("NutNhanKetThuc").Value = "0";
                //        }
                //    }

                //}
                #endregion

            }
            catch
            {
            }


            //gọi sự kiện lúc timer quét
            OnPlcServiceValuesRefreshed2(null, null);
            //gọi sự kiện của vtimer
            TimerScan3s.Instance.ValuesRefreshed += OnPlcServiceValuesRefreshed2;

        }

        private void FTableManager_TagStatusChanged(object o, TagStatusEventArgs e, string task)
        {
            if (InvokeRequired)
            {
                MethodInvoker dowork = new MethodInvoker(delegate
                {
                    try
                    {
                        // "Channel1COT_001/NutNhanKetThuc/1"
                        // string t = e.NewDisplayValue;
                        //string[] arrListStr = e.NewDisplayValue.Split('/');
                        //string task = arrListStr[0];
                        //  arrListStr[0]= Channel1COT_001
                        string chuoicot = task.Substring(task.Length - 7, 7);
                        if (iDriver1.Task(task).Tag("NutNhanKetThuc").Value == "1")
                        {
                            List<DuLieuVaBaoCao> list = new List<DuLieuVaBaoCao>();
                            //lấy ra 1 list theo số cột và trạng thái đã khô
                            //list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai("COT_001","Đã Khô","Chuyển Tiếp");
                            list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai(chuoicot, "Đã Khô");

                            foreach (var item in list)
                            {
                                if (item.SoLopHienTai < item.SoLopKetThuc)
                                {
                                    //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô
                                    bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Chuyển Tiếp", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    if (updatehoanthanh)
                                    {
                                        object sorow1 = DuLieuVaBaoCaoDAO.Instance.SelecttheoSanPhanVaSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                        int sorow = Convert.ToInt16(sorow1);
                                        //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri bang so count trong dòng cong 1
                                        bool reset = DuLieuVaBaoCaoDAO.Instance.InsertSanPhamSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot, sorow + 1);
                                        //neu row duoc tao tien hanh reset
                                        if (reset)
                                        {
                                            MaBarCodeDAO.Instance.UpdateTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot, "0");

                                        }
                                    }
                                }
                                if (item.SoLopHienTai == item.SoLopKetThuc)
                                {
                                    //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô

                                    ///update trang thai qua chu trinh
                                    bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Hoàn Thành", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);

                                    if (updatehoanthanh)
                                    {
                                        ///update tat ca cac trang thai hoan thanh thanh chuyen chu trinh khi so lop bang số lớp kết thúc
                                        bool updatehoanthanh2 = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSanPhamVaLot("Hoàn Thành", "Chuyển Tiếp", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                        MaBarCodeDAO.Instance.DeleteTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    }
                                }
                            }
                            try
                            {
                                if (iDriver1.Task(task).Tag("NutNhanKetThuc").Status == "Good")
                                {
                                    iDriver1.Task(task).Tag("NutNhanKetThuc").Value = "0";
                                }
                            }
                            catch { }

                        }
                    }
                    catch
                    {




                    }

                });

                Invoke(dowork);
                return;

            }
            else
            {
                try
                {
                    // "Channel1COT_001/NutNhanKetThuc/1"
                    // string t = e.NewDisplayValue;
                    //string[] arrListStr = e.NewDisplayValue.Split('/');
                    //string task = arrListStr[0];
                    //  arrListStr[0]= Channel1COT_001
                    string chuoicot = task.Substring(task.Length - 7, 7);
                    if (iDriver1.Task(task).Tag("NutNhanKetThuc").Value == "1")
                    {
                        List<DuLieuVaBaoCao> list = new List<DuLieuVaBaoCao>();
                        //lấy ra 1 list theo số cột và trạng thái đã khô
                        //list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai("COT_001","Đã Khô","Chuyển Tiếp");
                        list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai(chuoicot, "Đã Khô");

                        foreach (var item in list)
                        {
                            if (item.SoLopHienTai < item.SoLopKetThuc)
                            {
                                //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô
                                bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Chuyển Tiếp", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                if (updatehoanthanh)
                                {
                                    object sorow1 = DuLieuVaBaoCaoDAO.Instance.SelecttheoSanPhanVaSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    int sorow = Convert.ToInt16(sorow1);
                                    //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri bang so count trong dòng cong 1
                                    bool reset = DuLieuVaBaoCaoDAO.Instance.InsertSanPhamSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot, sorow + 1);
                                    //neu row duoc tao tien hanh reset
                                    if (reset)
                                    {
                                        MaBarCodeDAO.Instance.UpdateTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot, "0");

                                    }
                                }
                            }
                            if (item.SoLopHienTai == item.SoLopKetThuc)
                            {
                                //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô

                                ///update trang thai qua chu trinh
                                bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Hoàn Thành", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);

                                if (updatehoanthanh)
                                {
                                    ///update tat ca cac trang thai hoan thanh thanh chuyen chu trinh khi so lop bang số lớp kết thúc
                                    bool updatehoanthanh2 = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSanPhamVaLot("Hoàn Thành", "Chuyển Tiếp", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    MaBarCodeDAO.Instance.DeleteTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                }
                            }
                        }
                        try
                        {
                            if (iDriver1.Task(task).Tag("NutNhanKetThuc").Status == "Good")
                            {
                                iDriver1.Task(task).Tag("NutNhanKetThuc").Value = "0";
                            }
                        }
                        catch { }

                    }
                }
                catch
                {




                }
            }
        }

        //haythaydoi
        //Event nút nhấn kết thúc
        private void NutNhan_TagValueChanged(object o, TagValueEventArgs e)
        {
            if (InvokeRequired)
            {
                MethodInvoker dowork = new MethodInvoker(delegate
                {
                    try
                    {
                        // "Channel1COT_001/NutNhanKetThuc/1"
                        // string t = e.NewDisplayValue;
                        string[] arrListStr = e.NewDisplayValue.Split('/');
                        string task = arrListStr[0];
                        //  arrListStr[0]= Channel1COT_001
                        string chuoicot = task.Substring(task.Length - 7, 7);
                        if (iDriver1.Task(task).Tag("NutNhanKetThuc").Value == "1")
                        {
                            List<DuLieuVaBaoCao> list = new List<DuLieuVaBaoCao>();
                            //lấy ra 1 list theo số cột và trạng thái đã khô
                            //list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai("COT_001","Đã Khô","Chuyển Tiếp");
                            list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai(chuoicot, "Đã Khô");

                            foreach (var item in list)
                            {
                                if (item.SoLopHienTai < item.SoLopKetThuc)
                                {
                                    //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô
                                    bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Chuyển Tiếp", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    if (updatehoanthanh)
                                    {
                                        object sorow1 = DuLieuVaBaoCaoDAO.Instance.SelecttheoSanPhanVaSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                        int sorow = Convert.ToInt16(sorow1);
                                        //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri bang so count trong dòng cong 1
                                        bool reset = DuLieuVaBaoCaoDAO.Instance.InsertSanPhamSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot, sorow + 1);
                                        //neu row duoc tao tien hanh reset
                                        if (reset)
                                        {
                                            MaBarCodeDAO.Instance.UpdateTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot, "0");

                                        }
                                    }
                                }
                                if (item.SoLopHienTai == item.SoLopKetThuc)
                                {
                                    //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô

                                    ///update trang thai qua chu trinh
                                    bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Hoàn Thành", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);

                                    if (updatehoanthanh)
                                    {
                                        ///update tat ca cac trang thai hoan thanh thanh chuyen chu trinh khi so lop bang số lớp kết thúc
                                        bool updatehoanthanh2 = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSanPhamVaLot("Hoàn Thành", "Chuyển Tiếp", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                        MaBarCodeDAO.Instance.DeleteTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    }
                                }
                            }
                            try
                            {
                                if (iDriver1.Task(task).Tag("NutNhanKetThuc").Status == "Good")
                                {
                                    iDriver1.Task(task).Tag("NutNhanKetThuc").Value = "0";
                                }
                            }
                            catch { }

                        }
                    }
                    catch
                    {
                    }

                });

                Invoke(dowork);
                return;

            }
            else
            {
                try
                {
                    // "Channel1COT_001/NutNhanKetThuc/1"
                    // string t = e.NewDisplayValue;
                    string[] arrListStr = e.NewDisplayValue.Split('/');
                    string task = arrListStr[0];
                    //  arrListStr[0]= Channel1COT_001
                    string chuoicot = task.Substring(task.Length - 7, 7);
                    if (iDriver1.Task(task).Tag("NutNhanKetThuc").Value == "1")
                    {
                        List<DuLieuVaBaoCao> list = new List<DuLieuVaBaoCao>();
                        //lấy ra 1 list theo số cột và trạng thái đã khô
                        //list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai("COT_001","Đã Khô","Chuyển Tiếp");
                        list = DuLieuVaBaoCaoDAO.Instance.GetListMaBarCodeTheoTrangThai(chuoicot, "Đã Khô");

                        foreach (var item in list)
                        {
                            if (item.SoLopHienTai < item.SoLopKetThuc)
                            {
                                //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô
                                bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Chuyển Tiếp", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                if (updatehoanthanh)
                                {
                                    object sorow1 = DuLieuVaBaoCaoDAO.Instance.SelecttheoSanPhanVaSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    int sorow = Convert.ToInt16(sorow1);
                                    //insert 1 dong gom barcodesanpham va barcodlot va thoi gian bat dau va so lop hien tai co gia tri bang so count trong dòng cong 1
                                    bool reset = DuLieuVaBaoCaoDAO.Instance.InsertSanPhamSoLot(item.MaBarCodeSanpham, item.MaBarCodeLot, sorow + 1);
                                    //neu row duoc tao tien hanh reset
                                    if (reset)
                                    {
                                        MaBarCodeDAO.Instance.UpdateTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot, "0");

                                    }
                                }
                            }
                            if (item.SoLopHienTai == item.SoLopKetThuc)
                            {
                                //update trang thai hoan thanh  và thoi gian hoan thanh lọc theo số cột và trạng thái đã khô

                                ///update trang thai qua chu trinh
                                bool updatehoanthanh = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSoCot("Hoàn Thành", chuoicot, "Đã Khô", item.MaBarCodeSanpham, item.MaBarCodeLot);

                                if (updatehoanthanh)
                                {
                                    ///update tat ca cac trang thai hoan thanh thanh chuyen chu trinh khi so lop bang số lớp kết thúc
                                    bool updatehoanthanh2 = DuLieuVaBaoCaoDAO.Instance.UpdateTrangThaiKhoTheoSanPhamVaLot("Hoàn Thành", "Chuyển Tiếp", item.MaBarCodeSanpham, item.MaBarCodeLot);
                                    MaBarCodeDAO.Instance.DeleteTrangThaiTheoSanPhamVaLot(item.MaBarCodeSanpham, item.MaBarCodeLot);
                                }
                            }
                        }
                        try
                        {
                            if (iDriver1.Task(task).Tag("NutNhanKetThuc").Status == "Good")
                            {
                                iDriver1.Task(task).Tag("NutNhanKetThuc").Value = "0";
                            }
                        }
                        catch { }

                    }
                }
                catch
                {

                }
            }
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //            frmBaoCao f = new frmBaoCao();
            Report f = new Report();
            f.ShowDialog();

        }

        private void bảngThôngBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fView f = new fView();
            f.Show();
        }

        private void chỉnhSửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData f = new UpdateData();
            f.Show();
        }
    }
}
