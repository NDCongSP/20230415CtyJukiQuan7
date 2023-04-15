using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuetBarcode
{
    public partial class Form1 : Form
    {
        static string MaSanPham = "", MaLot = "", MaCot = "", MaXe = "", MaNguoiPhuTrach = "";
        static ConnectMySQL MySqlCmd = new ConnectMySQL();
        //static string MaSanPhamMoi = "DKSP", MaKTSPMoi = "HOANTHANH", MaBatDauPhoi = "START";//cac bien chua ma code de nhan biet qui trinh
        static string MaSanPhamMoi = "STARTSP", MaKTSPMoi = "ENDSP", MaBatDauPhoi = "STARTPHOI";//cac bien chua ma code de nhan biet qui trinh
        static string KiemTraquiTrinhQuet = "";//kiem tra xem thu tu quet ma co ok hay ko
        static byte ChotSPMoi = 0, ChotPhoi = 0;
        static byte QuiTrinh = 0;//=1 dang ky san pham moi; =2 dang ky phoi cho lop
        static byte DemMaDKSPMoi = 0, DemDKPhoi = 0;
        static byte KhoaDKSP = 0, KhoaDKPhoi = 0, ChotNhieuXe = 0;

        private void label11_Click(object sender, EventArgs e)
        {

        }

        static DataTable TableKiemTra = new DataTable();

        static string MaCotUpdateDB = "", MaXeUpdateDB = "", MaNguoiPhuTrachUpdateDB = "";


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (e.CloseReason == CloseReason.UserClosing)
            //{
            //    e.Cancel = true;
            //    Hide();
            //    notifyIcon1.Visible = true;
            //}
        }

        //#region notyficon
        //private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        //{
        //    Show();
        //    this.WindowState = FormWindowState.Normal;
        //    notifyIcon1.Visible = false;
        //}

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (e.CloseReason == CloseReason.UserClosing)
        //    {
        //        e.Cancel = true;
        //        Hide();
        //        notifyIcon1.Visible = true;
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    Hide();
        //    notifyIcon1.Visible = true;
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Hide();
        //    notifyIcon1.Visible = true;
        //}

        //private void Form1_Resize(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Minimized)
        //    {
        //        Hide();
        //        notifyIcon1.Visible = true;
        //    }
        //}

        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
        //    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Cảnh Báo", buttons);
        //    if (result == DialogResult.Yes)
        //    {
        //        Application.Exit();
        //    }
        //    else
        //    {
        //        // Do something  
        //    }

        //}

        //private void showToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Show();
        //    this.WindowState = FormWindowState.Normal;
        //    notifyIcon1.Visible = false;
        //}
        //#endregion

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            try
            {
                //lay conrting DB server tu file config
                MySqlCmd.ConectionString = ConfigurationManager.AppSettings["ConString"];// "Server=localhost;Database=juki_giamsatthoigiankho;Port=3306;Uid=root;Pwd=100100;charset=utf8";
                                                                                         //  DataTable bangtam = MySqlCmd.Table("mabarcode");
                DataTable bangtam = MySqlCmd.Table("account");

                if (bangtam != null && bangtam.Rows.Count > 0)
                {
                    label10.BackColor = Color.Green;
                }
                else
                    label10.BackColor = Color.Red;
            }
            catch { }
            timer1.Enabled = true;
            // this.reportViewer1.RefreshReport();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                label1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                #region hiển thị mã hiện tại đang đoc vê
                labSp.Text = MaSanPham;
                labLot.Text = MaLot;
                labNPT.Text = MaNguoiPhuTrach;

                labCot.Text = MaCot;
                labXe.Text = MaXe;
                #endregion
                label3.Text = "Chot DKSP=" + ChotSPMoi.ToString() + "|Chot DK Phoi=" + ChotPhoi.ToString();
                label17.Text = MaCotUpdateDB;
                label18.Text = MaXeUpdateDB;
            }
            catch { }
            timer1.Enabled = true;
        }

        #region Sự kiện textbox nhận mã barcode
        private void textSP_TextChanged(object sender, EventArgs e)
        {
            textSP.Focus();
        }
        private void textSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NhanDangLoaiMa(textSP.Text);
                textSP.Text = "";//làm trống textbox1 để nhận mã barcode sau
            }
        }
        #endregion


        private void TruyentinhieuDO8(string address, string value)
        {
            try
            {
                if (iDriver1.Task("ChannelDevice").Tag(address).Status == "Good")
                {
                    iDriver1.Task("ChannelDevice").Tag(address).Value = value;
                }


            }
            catch { }
        }

        #region các method chức năng
        /// <summary>
        /// Nhận dạng xem mã đọc về là của mã nào.
        /// </summary>
        /// <param name="MaBarcodeDocVe">Mã barcode đọc về.</param>
        private void NhanDangLoaiMa(string MaBarcodeDocVe)
        {
            try
            {
                //kiem tra su kien dang ky ma san pham moi
                label11.Text = MaBarcodeDocVe;
                if (MaBarcodeDocVe != "RESETQUETMA")
                {
                    #region Dang Ky San Pham Moi
                    #region buoc 1. quet ma lenh dang ky san pham moi
                    if (ChotSPMoi == 0 && KhoaDKSP == 0)
                    {
                        if (MaBarcodeDocVe.Contains("STARTSP") == true)
                        {
                            label6.Text = MaBarcodeDocVe;
                            KhoaDKPhoi = 1;
                            ChotSPMoi = 1;
                            DemMaDKSPMoi = 0;

                            TruyentinhieuDO8("Q00", "0");


                            label4.Text = "Quét mã đăng ký sản phẩm mới OK --> Quét lần lượt các mã sau: Sản phẩm -> Lot -> ENDSP";
                            label13.Text = "Quét mã đăng ký phơi";
                        }
                        else
                        {
                            label4.Text = "Quét mã đăng ký SP lỗi. Đăng ký lại.";
                            TruyentinhieuDO8("Q00", "1");
                        }
                    }
                    #endregion
                    #region buoc 2. quet ma san pham moi
                    else if (ChotSPMoi == 1 && KhoaDKSP == 0)
                    {
                        #region kiem tra tim ma san pham
                        if (MaBarcodeDocVe.Contains("COT") == false && MaBarcodeDocVe.Contains("WP") == false && MaBarcodeDocVe.Contains("XE") == false
                            && MaBarcodeDocVe.Contains("STARTSP") == false && MaBarcodeDocVe.Contains("ENDSP") == false && MaBarcodeDocVe.Contains("STARTPHOI") == false && MaBarcodeDocVe.Contains("ENDPHOI") == false && DemMaDKSPMoi == 0)
                        {
                            int s = MySqlCmd.KiemtraMaBarCode(MaBarcodeDocVe);
                            if (s!= -1 && s !=0)
                            {
                                DemMaDKSPMoi++;
                                MaSanPham = MaBarcodeDocVe;
                                TruyentinhieuDO8("Q00", "0");
                                label4.Text = "Quét mã sản phẩm OK --> Mã LOT.";
                            }
                            else
                            {
                                label4.Text = "Mã sản phẩm không tồn tại.";
                                TruyentinhieuDO8("Q00", "1");
                            }
                        }
                        #endregion
                        #region kiem tra tim ma lot
                        else if (MaBarcodeDocVe.Contains("WP") && DemMaDKSPMoi == 1)
                        {
                            DemMaDKSPMoi = 0;
                            ChotSPMoi = 2;//de ghi vao DB
                            MaLot = MaBarcodeDocVe;
                            TruyentinhieuDO8("Q00", "0");
                            label4.Text = "Quét mã LOT OK --> Mã kết thúc đăng ký sản phẩm mới.";
                        }
                        #endregion
                        else
                        {
                            label4.Text = "Quét Mã Sai Qui Trình. Chỉ quét mã sản phẩm và mã LOT theo thứ tự SP ->LOT. Quét mã lại.";
                            TruyentinhieuDO8("Q00", "1");
                        }
                    }
                    #endregion
                    #region buoc 3. quet ma ket thuc dang ky san pham moi
                    else if (ChotSPMoi == 2 && KhoaDKSP == 0)//insert SP moi vao DB
                    {
                        if (MaBarcodeDocVe.Contains("ENDSP") == true)
                        {
                            label6.Text = MaBarcodeDocVe;
                            TruyentinhieuDO8("Q00", "0");
                            TableKiemTra = MySqlCmd.TableWhere("mabarcode", "MaBarCodeSanPham", "MaBarCodeSanPham ='" + MaSanPham + "' and MaBarCodeLot='" + MaLot + "'");
                            if (TableKiemTra != null && TableKiemTra.Rows.Count == 0)
                            {
                                if (MySqlCmd.Insert("mabarcode", "MaBarCodeSanPham,MaBarCodeLot,TrangThai", "'" + MaSanPham + "','" + MaLot + "','1'") != 0)
                                {
                                    MaSanPham = "";
                                    MaLot = "";
                                    ChotSPMoi = 0;
                                    KhoaDKPhoi = 0;
                                    DemMaDKSPMoi = 0;
                                    label10.BackColor = Color.Green;
                                    TruyentinhieuDO8("Q00", "0");
                                    label4.Text = "Chuyển Tiếp đăng ký sản phẩm mới!";
                                    goto ThoatVong;
                                }
                                else
                                {
                                    MaSanPham = "";
                                    MaLot = "";
                                    ChotSPMoi = 0;
                                    KhoaDKPhoi = 0;
                                    DemMaDKSPMoi = 0;
                                    label10.BackColor = Color.Red;
                                    label4.Text = "Đăng ký sản phẩm mới thất bại. Không kết nối được DB server. Đăng ký lại.";
                                    TruyentinhieuDO8("Q00", "1");
                                    goto ThoatVong;
                                }
                            }
                            else
                            {
                                MaSanPham = "";
                                MaLot = "";
                                ChotSPMoi = 0;
                                KhoaDKPhoi = 0;
                                DemMaDKSPMoi = 0;
                                label4.Text = "Đăng ký sản phẩm mới thất bại. Sản phẩm đã được đăng ký rồi, hoặc không kết nối được DB server. Đăng ký lại.";
                                TruyentinhieuDO8("Q00", "1");
                                goto ThoatVong;
                            }

                        }
                        else
                        {
                            label4.Text = "Quét mã kết thúc đăng ký sản phẩm mới lỗi. Chỉ quét mã kết thúc đăng ký sản phẩm. Quét mã lại.";
                            TruyentinhieuDO8("Q00", "1");
                        }
                    }
                    #endregion
                    #endregion
                    #region đăng ký phơi
                    #region buoc 1. quet ma lenh dang ky phoi
                    if (ChotPhoi == 0 && KhoaDKPhoi == 0)
                    {
                        if (MaBarcodeDocVe.Contains("STARTPHOI") == true)
                        {
                            label6.Text = MaBarcodeDocVe;
                            KhoaDKSP = 1;
                            ChotPhoi = 1;
                            DemDKPhoi = 0;
                            TruyentinhieuDO8("Q00", "0");
                            label13.Text = "Đăng ký phơi OK -->Tiếp tục quét lần lượt các mã sau: LOT -> CỘT -> XE-> NGUOI PHU TRACH";
                            label4.Text = "Quét mã đăng ký SP";
                        }
                        else
                        {
                            label13.Text = "Đăng ký phơi lỗi";
                            TruyentinhieuDO8("Q00", "1");
                        }
                    }
                    #endregion
                    #region buoc 2. quet ma theo quy trinh: MaSP-->MaLot-->MaCot-->MaXe
                    else if (ChotPhoi == 1 && KhoaDKPhoi == 0)
                    {
                        //#region kiem tra tim ma san pham
                        //if (MaBarcodeDocVe.Contains("COT") == false && MaBarcodeDocVe.Contains("WP") == false && MaBarcodeDocVe.Contains("XE") == false
                        //    && MaBarcodeDocVe.Contains("STARTSP") == false && MaBarcodeDocVe.Contains("ENDPHOI") == false && MaBarcodeDocVe.Contains("ENDSP") == false && MaBarcodeDocVe.Contains("STARTPHOI") == false && DemDKPhoi == 0)
                        //{
                        //    DemDKPhoi++;
                        //    MaSanPham = MaBarcodeDocVe;
                        //    if (iDriver1.Task("ChannelDevice").Tag("Q00").Status == "Good")
                        //    {
                        //        iDriver1.Task("ChannelDevice").Tag("Q00").Value = "0";
                        //    }
                        //    label13.Text = "Quét mã sản phẩm OK --> Quét mã LOT";
                        //}
                        //#endregion

                        #region kiem tra tim ma san pham
                        if (MaBarcodeDocVe.Contains("WP") && MaBarcodeDocVe.Contains("COT") == false && MaBarcodeDocVe.Contains("XE") == false
                            && MaBarcodeDocVe.Contains("STARTSP") == false && MaBarcodeDocVe.Contains("ENDPHOI") == false && MaBarcodeDocVe.Contains("ENDSP") == false && MaBarcodeDocVe.Contains("STARTPHOI") == false && DemDKPhoi == 0)
                        {
                            DemDKPhoi++;
                            MaLot = MaBarcodeDocVe;
                            TruyentinhieuDO8("Q00", "0");
                            label13.Text = "Quét mã LOT OK --> Quét mã COT->XE";
                        }
                        #endregion

                        //#region kiem tra tim ma lot
                        //else if (MaBarcodeDocVe.Contains("WP") && DemDKPhoi == 1)
                        //{
                        //    DemDKPhoi++;
                        //    MaLot = MaBarcodeDocVe;
                        //    if (iDriver1.Task("ChannelDevice").Tag("Q00").Status == "Good")
                        //    {
                        //        iDriver1.Task("ChannelDevice").Tag("Q00").Value = "0";
                        //    }
                        //    label13.Text = "Quét mã LOT OK --> Quét mã người phụ trách";
                        //}
                        //#endregion

                        //#region kiem tra tim ma Nguoi phu trach phơi
                        //else if (MaBarcodeDocVe.Contains("NPT:") && DemDKPhoi == 2)
                        //{
                        //    DemDKPhoi++;
                        //    MaNguoiPhuTrach = MaBarcodeDocVe;
                        //    MaNguoiPhuTrachUpdateDB = MaNguoiPhuTrach;

                        //    if (iDriver1.Task("ChannelDevice").Tag("Q00").Status == "Good")
                        //    {
                        //        iDriver1.Task("ChannelDevice").Tag("Q00").Value = "0";
                        //    }
                        //    label13.Text = "Quét mã người phụ trách OK --> Quét mã cột";
                        //}
                        //#endregion


                        #region kiem tra tim ma cot
                        else if (MaBarcodeDocVe.Contains("COT") && DemDKPhoi == 1)
                        {
                            DemDKPhoi++;
                            MaCot = MaBarcodeDocVe;
                            MaCotUpdateDB = MaCot;
                            TruyentinhieuDO8("Q00", "0");
                            label13.Text = "Quét mã cột OK --> Quét mã xe";
                        }
                        #endregion
                        #region kiem tra tim ma xe
                        else if (MaBarcodeDocVe.Contains("XE") && DemDKPhoi == 2)
                        {
                            MaXe = MaBarcodeDocVe;
                            if (MaXeUpdateDB.Contains(MaXe) == false)
                            {
                                DemDKPhoi++;
                                if (ChotNhieuXe == 0)
                                    MaXeUpdateDB = MaBarcodeDocVe;
                                else
                                    MaXeUpdateDB = MaXeUpdateDB + "|" + MaBarcodeDocVe;

                                TruyentinhieuDO8("Q00", "0");
                                label13.Text = "Quét mã xe OK --> Quét mã người phụ trách để kết thúc đăng ký phơi, hoặc quét mã cột kế tiếp";
                            }
                            else
                            {
                                TruyentinhieuDO8("Q00", "1");
                                label13.Text = "Mã xe này đã được nhập. Mời quét mã xe lại.";
                            }
                        }
                        #endregion
                        #region kiem tra tim ma ket thuc dang ky phoi hay dang ky tiep xe va cot phoi
                        else if (DemDKPhoi == 3)
                        {
                            #region quet ma cot ke tiep
                            if (MaBarcodeDocVe.Contains("COT") == true)
                            {
                                MaCot = MaBarcodeDocVe;
                                if (MaCotUpdateDB.Contains(MaCot) == false)
                                {
                                    DemDKPhoi = 2;
                                    ChotNhieuXe = 1;
                                    MaCotUpdateDB = MaCotUpdateDB + "|" + MaCot;
                                    TruyentinhieuDO8("Q00", "0");
                                    label13.Text = "Quét mã cột kế tiếp OK --> Quét mã xe kế tiếp";
                                }
                                else
                                {
                                    TruyentinhieuDO8("Q00", "1");
                                    label13.Text = "Mã cột này đã được nhập. Mời quét mã cột lại.";
                                }
                            }
                            #endregion
                            #region quet ma ket thuc phoi
                            //  else if (MaBarcodeDocVe.Contains("ENDPHOI") == true)
                            else if (MaBarcodeDocVe.Contains("NPT:") == true)

                            {
                                MaNguoiPhuTrach = MaBarcodeDocVe;
                                labNPT.Text = MaBarcodeDocVe;
                                label6.Text = MaBarcodeDocVe;
                                TruyentinhieuDO8("Q00", "0");
                                #region update ma cot va xe vao san pham
                               // TableKiemTra = MySqlCmd.TableWhere("mabarcode", "TrangThai", "MaBarCodeSanPham ='" + MaSanPham + "' and MaBarCodeLot='" + MaLot + "'");
                                TableKiemTra = MySqlCmd.TableWhere("mabarcode", "TrangThai"," MaBarCodeLot='" + MaLot + "'");

                                if (TableKiemTra != null && TableKiemTra.Rows.Count > 0)
                                {
                                    label10.BackColor = Color.Green;
                                    //kiem tra xem neu cot trang thai =0 thi moi update cot xe, ko thi chưa đc phep update
                                    if (TableKiemTra.Rows[0][0].ToString() == "0")
                                    {
                                        // if (MySqlCmd.Update("mabarcode", "MaBarCodeNguoi='" + MaNguoiPhuTrach + "', MaBarCodeCot='" + MaCotUpdateDB + "',MaBarCodeXe='" + MaXeUpdateDB + "',TrangThai='2'", "MaBarCodeSanPham ='" + MaSanPham + "' and MaBarCodeLot='" + MaLot + "'") != 0)
                                        if (MySqlCmd.Update("mabarcode", "MaBarCodeNguoi='" + MaNguoiPhuTrach + "', MaBarCodeCot='" + MaCotUpdateDB + "',MaBarCodeXe='" + MaXeUpdateDB + "',TrangThai='2'", " MaBarCodeLot='" + MaLot + "'") != 0)

                                        {
                                            label10.BackColor = Color.Green;
                                            label13.Text = "Chuyển Tiếp đăng ký phơi!";
                                            MaSanPham = MaLot = MaNguoiPhuTrach = MaCot = MaXe = "";
                                            ChotPhoi = 0;
                                            KhoaDKSP = 0;
                                            ChotNhieuXe = 0;
                                            MaCotUpdateDB = MaXeUpdateDB = "";
                                            TruyentinhieuDO8("Q00", "0");
                                        }
                                        else
                                        {
                                            MaSanPham = MaLot = MaNguoiPhuTrach = MaCot = MaXe = "";
                                            MaCotUpdateDB = MaXeUpdateDB = "";
                                            ChotNhieuXe = 0;
                                            ChotPhoi = 0;
                                            KhoaDKSP = 0; label10.BackColor = Color.Red;
                                            label13.Text = "Đăng ký phơi lỗi. Không kết nối được DB server. Đăng ký phơi lại.";
                                            TruyentinhieuDO8("Q00", "1");
                                        }
                                    }
                                    else if (TableKiemTra.Rows[0][0].ToString() == "1")
                                    {
                                        MaSanPham = MaLot = MaNguoiPhuTrach = MaCot = MaXe = "";
                                        ChotNhieuXe = 0;
                                        ChotPhoi = 0;
                                        KhoaDKSP = 0;
                                        MaCotUpdateDB = MaXeUpdateDB = "";
                                        label13.Text = "Sản phẩm đang chờ đăng ký, đợi một lát rồi đăng ký phơi lại.";
                                        TruyentinhieuDO8("Q00", "1");
                                    }
                                    else if (TableKiemTra.Rows[0][0].ToString() == "2")
                                    {
                                        MaSanPham = MaNguoiPhuTrach = MaLot = MaCot = MaXe = "";
                                        ChotNhieuXe = 0;
                                        ChotPhoi = 0;
                                        KhoaDKSP = 0;
                                        MaCotUpdateDB = MaXeUpdateDB = "";
                                        label13.Text = "Sản phẩm đã được đăng ký phơi.";
                                        TruyentinhieuDO8("Q00", "1");
                                    }
                                    else if (TableKiemTra.Rows[0][0].ToString() == "3")
                                    {
                                        MaSanPham = MaNguoiPhuTrach = MaLot = MaCot = MaXe = "";
                                        ChotNhieuXe = 0;
                                        ChotPhoi = 0;
                                        KhoaDKSP = 0;
                                        MaCotUpdateDB = MaXeUpdateDB = "";
                                        label13.Text = "Sản phẩm đang trong thời gian phơi, không đăng ký phơi lớp kế tiếp được.";
                                        TruyentinhieuDO8("Q00", "1");
                                    }
                                }
                                else
                                {
                                    MaSanPham = MaLot = MaNguoiPhuTrach = MaCot = MaXe = "";
                                    ChotNhieuXe = 0;
                                    ChotPhoi = 0;
                                    KhoaDKSP = 0;
                                    MaCotUpdateDB = MaXeUpdateDB = "";
                                    label10.BackColor = Color.Green;
                                    label13.Text = "Sản phẩm chưa đăng ký, hoặc kết nối DB server lỗi. Đăng ký phơi lại.";
                                    TruyentinhieuDO8("Q00", "1");
                                }
                                #endregion
                                //label13.Text = "Chuyển Tiếp đăng ký phơi OK";
                            }
                            #endregion
                            else
                            {
                                //MaSanPham = MaLot = MaCot = MaXe = "";
                                label13.Text = "Quét mã lỗi, chỉ quét mã cột hoặc mã người phụ trách để kết thúc phơi";
                                //ChotPhoi = 0;
                                //KhoaDKSP = 0;
                                //ChotNhieuXe = 0;
                                //MaCotUpdateDB = MaXeUpdateDB = "";
                                TruyentinhieuDO8("Q00", "1");
                            }
                        }
                        #endregion
                        else
                        {
                            //if (DemDKPhoi == 0)
                            //    label13.Text = "Quét mã không đúng qui trình, quét mã sản phẩm";
                             if (DemDKPhoi == 0)
                                label13.Text = "Quét mã không đúng qui trình, quét mã LOT";
                            //else if (DemDKPhoi == 2)
                            //    label13.Text = "Quét mã không đúng qui trình, quét mã Người Phụ Trách";

                            else if (DemDKPhoi == 1)
                                label13.Text = "Quét mã không đúng qui trình, quét mã cột";
                            else if (DemDKPhoi == 2)
                                label13.Text = "Quét mã không đúng qui trình, quét mã Xe";
                            //MaSanPham = MaLot = MaCot = MaXe = "";
                            //MaCotUpdateDB = MaXeUpdateDB = "";
                            //ChotNhieuXe = 0;
                            //ChotPhoi = 0;
                            //KhoaDKSP = 0;
                            //DemDKPhoi = 0;
                            TruyentinhieuDO8("Q00", "1");
                        }
                    }
                    #endregion
                    #endregion
                    ThoatVong:
                    label11.Text = label11.Text;
                }
                //neu quet ma reset thi reset lai de dang ký lai
                else
                {
                    ChotSPMoi = 0;
                    KhoaDKPhoi = 0;
                    DemMaDKSPMoi = 0;

                    MaSanPham = MaNguoiPhuTrach = MaLot = MaCot = MaXe = "";
                    MaCotUpdateDB = MaXeUpdateDB = "";
                    ChotNhieuXe = 0;
                    ChotPhoi = 0;
                    KhoaDKSP = 0;
                    DemDKPhoi = 0;

                    label4.Text = "Quét mã đăng ký SP";
                    label13.Text = "Quét mã đăng ký phơi";

                    TruyentinhieuDO8("Q00", "0");

                }
            }
            catch { }
        }
        #endregion
    }
}
