using QuanLySanXuatJuKi.DAO;
using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;

namespace QuanLySanXuatJuKi
{
    public partial class fAdmin : Form
    {
        BindingSource BatchNumberList = new BindingSource();

        BindingSource accountList = new BindingSource();

        BindingSource ProductCodeList = new BindingSource();


        public Account loginAccount;
        private int seach;
        private string filePath;

        public fAdmin()
        {
            InitializeComponent();
            // Control.CheckForIllegalCrossThreadCalls = false;
            LoadData();
        }

        #region methods

        List<BangNhapSoLop> SearchBatchNumberByName(string name)
        {
            List<BangNhapSoLop> listBatchNumber = BangNhapSoLopDAO.Instance.SearchBatchNumberByName(name);

            return listBatchNumber;
        }
        void LoadData()
        {
            dtgvBatchNumber.DataSource = BatchNumberList;
            dtgvAccount.DataSource = accountList;

            LoadListBatchNumber();
            LoadAccount();
            LoadProductCodeIntoCombobox(txbSearchBatchNumberName);
            AddBatchNumberBinding();
            AddAccountBinding();
        }



        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            numericUpDown1.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }


        //binding list chọn ra các textbox
        void AddBatchNumberBinding()
        {

            string MaBarCodeSanPham = tbxMaSanPham.Text;
            string TenSanPhamTiengViet = tbxTenSPTV.Text;
            string TenSanPhamTiengAnh = tbxTenSPTA.Text;
            string LopNhung = tbxLopNhung.Text;
            int TongLopNhung = (int)tbxTongSoLop.Value;
            int Zircon01 = (int)num1.Value;
            int Zircon02 = (int)num2.Value;
            int Zircon03 = (int)num3.Value;
            int Zircon04 = (int)num4.Value;
            int CatL01 = (int)num5.Value;
            int CatL02 = (int)num6.Value;
            int CatL03 = (int)num7.Value;
            int CatL04 = (int)num8.Value;
            int CatL05 = (int)num9.Value;
            int CatL06 = (int)num10.Value;
            int CatL07 = (int)num11.Value;
            int CatL08 = (int)num12.Value;
            int CatL09 = (int)num12.Value;
            int SIRU = (int)num12.Value;

            //    txbBatchNumberID.DataBindings.Add(new Binding("Text", dtgvBatchNumber.DataSource, "ID", true, DataSourceUpdateMode.Never));


            tbxMaSanPham.DataBindings.Add(new Binding("Text", dtgvBatchNumber.DataSource, "MaBarCodeSanPham", true, DataSourceUpdateMode.Never));
            tbxTenSPTV.DataBindings.Add(new Binding("Text", dtgvBatchNumber.DataSource, "TenSanPhamTiengViet", true, DataSourceUpdateMode.Never));
            tbxTenSPTA.DataBindings.Add(new Binding("Text", dtgvBatchNumber.DataSource, "TenSanPhamTiengAnh", true, DataSourceUpdateMode.Never));
            tbxLopNhung.DataBindings.Add(new Binding("Text", dtgvBatchNumber.DataSource, "LopNhung", true, DataSourceUpdateMode.Never));

            tbxTongSoLop.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "TongLopNhung", true, DataSourceUpdateMode.Never));
            num1.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "Zircon01", true, DataSourceUpdateMode.Never));
            num2.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "Zircon02", true, DataSourceUpdateMode.Never));
            num3.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "Zircon03", true, DataSourceUpdateMode.Never));
            num4.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "Zircon04", true, DataSourceUpdateMode.Never));
            num5.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL01", true, DataSourceUpdateMode.Never));
            num6.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL02", true, DataSourceUpdateMode.Never));
            num7.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL03", true, DataSourceUpdateMode.Never));
            num8.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL04", true, DataSourceUpdateMode.Never));
            num9.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL05", true, DataSourceUpdateMode.Never));
            num10.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL06", true, DataSourceUpdateMode.Never));
            num11.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL07", true, DataSourceUpdateMode.Never));
            num12.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL08", true, DataSourceUpdateMode.Never));
            num13.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "CatL09", true, DataSourceUpdateMode.Never));
            num14.DataBindings.Add(new Binding("Value", dtgvBatchNumber.DataSource, "SIRU", true, DataSourceUpdateMode.Never));



        }


        //load 1 list của produstcode vô combobox
        void LoadProductCodeIntoCombobox(ComboBox cb)
        {
            // cb.DataSource = BangNhapSanPhamDAO.Instance.GetListProductCode();
            cb.DataSource = BangNhapSoLopDAO.Instance.GetListBatchNumber();

            cb.DisplayMember = "MaBarCodeSanPham";

        }
        void LoadListBatchNumber()
        {
            BatchNumberList.DataSource = BangNhapSoLopDAO.Instance.GetListBatchNumber();
        }

        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            LoadAccount();
        }

        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }

            LoadAccount();
        }

        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa chính bạn chứ");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }
        #endregion

        #region events
        
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)numericUpDown1.Value;

            EditAccount(userName, displayName, type);
        }


        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;

            ResetPass(userName);
        }


        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }


        private void btnSearchBatchNumber_Click(object sender, EventArgs e)
        {
            seach = 1;
            BatchNumberList.DataSource = SearchBatchNumberByName(txbSearchBatchNumberName.Text);
        }
        private void txbBatchNumberID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvBatchNumber.SelectedCells.Count > 0)
                {
                    string MaBarCodeSanPham = dtgvBatchNumber.SelectedCells[0].OwningRow.Cells["MaBarCodeSanPham"].Value.ToString();




                }
            }
            catch { }
        }

        private void btnAddBatchNumber_Click(object sender, EventArgs e)
        {
            try
            {


                ////loc ra index của textbox
                //BangNhapSanPham cateogory = BangNhapSanPhamDAO.Instance.GetProductCodeByID(cbProductCode.Text);

                //cbProductCode.SelectedItem = cateogory;

                //int index = -1;
                //int i = 0;
                //foreach (BangNhapSanPham item in cbProductCode.Items)
                //{
                //    if (item.ID == cateogory.ID)
                //    {
                //        index = i;
                //        break;
                //    }
                //    i++;
                //}

                //cbProductCode.SelectedIndex = index;






                string MaBarCodeSanPham = tbxMaSanPham.Text;
                string TenSanPhamTiengViet = tbxTenSPTV.Text;
                string TenSanPhamTiengAnh = tbxTenSPTA.Text;
                string LopNhung = tbxLopNhung.Text;
                int TongLopNhung = (int)tbxTongSoLop.Value;
                int Zircon01 = (int)num1.Value;
                int Zircon02 = (int)num2.Value;
                int Zircon03 = (int)num3.Value;
                int Zircon04 = (int)num4.Value;
                int CatL01 = (int)num5.Value;
                int CatL02 = (int)num6.Value;
                int CatL03 = (int)num7.Value;
                int CatL04 = (int)num8.Value;
                int CatL05 = (int)num9.Value;
                int CatL06 = (int)num10.Value;
                int CatL07 = (int)num11.Value;
                int CatL08 = (int)num12.Value;
                int CatL09 = (int)num13.Value;
                int SIRU = (int)num14.Value;




                //string TenSanPham = (cbProductCode.SelectedItem as BangNhapSanPham).TenSanPham;
                //string MaBarCodeSanPham = (cbProductCode.SelectedItem as BangNhapSanPham).MaBarCodeSanPham;
                //int SoLopKetThuc = (cbProductCode.SelectedItem as BangNhapSanPham).SoLopKetThuc;

                //  float SoThoiGianKho = (float)nmBatchNumberSoThoiGianKho.Value;

                if (BangNhapSoLopDAO.Instance.InsertBatchNumber(MaBarCodeSanPham, TenSanPhamTiengViet, TenSanPhamTiengAnh, LopNhung, TongLopNhung, Zircon01,
                    Zircon02, Zircon03, Zircon04, CatL01, CatL02, CatL03, CatL04, CatL05, CatL06, CatL07, CatL08, CatL09, SIRU))
                {
                    MessageBox.Show("Thêm thành công");
                    if (seach == 0)
                    {
                        LoadListBatchNumber();

                    }
                    if (seach == 1)
                    {
                        BatchNumberList.DataSource = SearchBatchNumberByName(txbSearchBatchNumberName.Text);

                    }


                    if (insertBatchNumber != null)
                        insertBatchNumber(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm ");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng chọn Sản Phẩm trong ComboBox");
            }
        }

        private void btnEditBatchNumber_Click(object sender, EventArgs e)
        {
            try
            {

                ////loc ra index của textbox
                //BangNhapSanPham cateogory = BangNhapSanPhamDAO.Instance.GetProductCodeByID(cbProductCode.Text);

                //cbProductCode.SelectedItem = cateogory;

                //int index = -1;
                //int i = 0;
                //foreach (BangNhapSanPham item in cbProductCode.Items)
                //{
                //    if (item.ID == cateogory.ID)
                //    {
                //        index = i;
                //        break;
                //    }
                //    i++;
                //}

                //cbProductCode.SelectedIndex = index;





                string MaBarCodeSanPham = tbxMaSanPham.Text;
                string TenSanPhamTiengViet = tbxTenSPTV.Text;
                string TenSanPhamTiengAnh = tbxTenSPTA.Text;
                string LopNhung = tbxLopNhung.Text;
                int TongLopNhung = (int)tbxTongSoLop.Value;
                int Zircon01 = (int)num1.Value;
                int Zircon02 = (int)num2.Value;
                int Zircon03 = (int)num3.Value;
                int Zircon04 = (int)num4.Value;
                int CatL01 = (int)num5.Value;
                int CatL02 = (int)num6.Value;
                int CatL03 = (int)num7.Value;
                int CatL04 = (int)num8.Value;
                int CatL05 = (int)num9.Value;
                int CatL06 = (int)num10.Value;
                int CatL07 = (int)num11.Value;
                int CatL08 = (int)num12.Value;
                int CatL09 = (int)num13.Value;
                int SIRU = (int)num14.Value;



                //if (BangNhapSoLopDAO.Instance.UpdateBatchNumber(TenSanPham, MaBarCodeSanPham, SoLopKetThuc, SoLopHienTai, SoThoiGianKho, id))

                if (BangNhapSoLopDAO.Instance.UpdateBatchNumber(MaBarCodeSanPham, TenSanPhamTiengViet, TenSanPhamTiengAnh, LopNhung, TongLopNhung, Zircon01,
Zircon02, Zircon03, Zircon04, CatL01, CatL02, CatL03, CatL04, CatL05, CatL06, CatL07, CatL08, CatL09, SIRU))

                {
                    MessageBox.Show("Sửa thành công");
                    //LoadListBatchNumber();
                    if (seach == 0)
                    {
                        LoadListBatchNumber();

                    }
                    if (seach == 1)
                    {
                        BatchNumberList.DataSource = SearchBatchNumberByName(txbSearchBatchNumberName.Text);

                    }

                    if (updateBatchNumber != null)
                        updateBatchNumber(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Có lỗi khi sửa");
                }


            }
            catch (Exception)
            {

                MessageBox.Show("Có lỗi khi sửa, Vui lòng làm đúg quy trình");
            }
        }

        private void btnDeleteBatchNumber_Click(object sender, EventArgs e)
        {
            // int id = Convert.ToInt32(txbBatchNumberID.Text);

            string MasanPham = tbxMaSanPham.Text;


            if (BangNhapSoLopDAO.Instance.DeleteBatchNumber(MasanPham))
            {
                MessageBox.Show("Xóa món thành công");
                // LoadListBatchNumber();
                if (seach == 0)
                {
                    LoadListBatchNumber();

                }
                if (seach == 1)
                {
                    BatchNumberList.DataSource = SearchBatchNumberByName(txbSearchBatchNumberName.Text);

                }

                if (deleteBatchNumber != null)
                    deleteBatchNumber(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa");
            }
        }
        private void btnShowBatchNumber_Click(object sender, EventArgs e)
        {
            LoadListBatchNumber();
            seach = 0;
        }


        private event EventHandler insertBatchNumber;
        public event EventHandler InsertBatchNumber
        {
            add { insertBatchNumber += value; }
            remove { insertBatchNumber -= value; }
        }

        private event EventHandler deleteBatchNumber;
        public event EventHandler DeleteBatchNumber
        {
            add { deleteBatchNumber += value; }
            remove { deleteBatchNumber -= value; }
        }

        private event EventHandler updateBatchNumber;
        public event EventHandler UpdateBatchNumber
        {
            add { updateBatchNumber += value; }
            remove { updateBatchNumber -= value; }
        }

        #endregion              


        private void fAdmin_Load(object sender, EventArgs e)
        {
        }


        //sự kiệu chọn tab trong tab control thay đổi
        private void tcAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            // LoadProductCodeIntoCombobox(cbProductCode);
            LoadProductCodeIntoCombobox(txbSearchBatchNumberName);

        }

        //mở 1 đường đẫn đến thư mục chứa file list hàng
        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                
                // tạo SaveFileDialog để lưu file excel
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                filePath = dialog.FileName;



                ThreadStart ts = new ThreadStart(Demo);
                Thread thrd = new Thread(ts);
                thrd.Start();

                LoadListBatchNumber();
                seach = 0;


            }
            catch (Exception)
            {

                throw;
            }
           

        }

        //chuyển database từ excel vô access sau đó lưu vô mysql
        private void Demo()
        {
            try
            {
                string connectionString = "";

                string[] cot_excel_import = new string[22];
                if (filePath.EndsWith(".xls"))
                {
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + @";Extended Properties=" + Convert.ToChar(34).ToString() + @"Excel 8.0;Imex=1;HDR=Yes;" + Convert.ToChar(34).ToString();
                }
                else if (filePath.EndsWith(".xlsx"))
                {
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                }
                #region doc excel ghi csdl
                // Tạo đối tượng kết nối
                OleDbConnection oledbConn = new OleDbConnection(connectionString);

                oledbConn.Open();

                // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

                // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
                OleDbDataAdapter oleda = new OleDbDataAdapter();

                oleda.SelectCommand = cmd;

                // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
                DataSet dtExcelRecords = new DataSet();

                // Đổ đữ liệu từ tập excel vào DataSet
                oleda.Fill(dtExcelRecords);
                DataTable data = dtExcelRecords.Tables[0];
                for (int i = 4; i <= data.Rows.Count - 1; i++)
                {
                    //kiem tra neu du lieu trong thi thay doi thanh gia tri "0" doi voi plan;
                    //con model trong thi thay doi thay gia tri "Off"
                    for (byte j = 1; j < 20; j++)
                    {
                        string t = data.Rows[i][j].ToString();
                        if (data.Rows[i][j].ToString() != "0" && !string.IsNullOrEmpty(data.Rows[i][j].ToString()))
                        {
                            cot_excel_import[j - 1] = "'" + data.Rows[i][j].ToString() + "'";

                        }
                        else
                        { cot_excel_import[j - 1] = "null"; }

                    }


                    try
                    {
                        BangNhapSoLopDAO.Instance.InsertBatchNumberExcel(cot_excel_import[0], cot_excel_import[1], cot_excel_import[2], cot_excel_import[3], cot_excel_import[4], cot_excel_import[5], cot_excel_import[6], cot_excel_import[7], cot_excel_import[8], cot_excel_import[9], cot_excel_import[10], cot_excel_import[11], cot_excel_import[12], cot_excel_import[13], cot_excel_import[14], cot_excel_import[15], cot_excel_import[16], cot_excel_import[17], cot_excel_import[18]);

                    }
                    catch (Exception)
                    {

                        BangNhapSoLopDAO.Instance.UpdateBatchNumberExcel(cot_excel_import[0], cot_excel_import[1], cot_excel_import[2], cot_excel_import[3], cot_excel_import[4], cot_excel_import[5], cot_excel_import[6], cot_excel_import[7], cot_excel_import[8], cot_excel_import[9], cot_excel_import[10], cot_excel_import[11], cot_excel_import[12], cot_excel_import[13], cot_excel_import[14], cot_excel_import[15], cot_excel_import[16], cot_excel_import[17], cot_excel_import[18]);
                    }


                }

                oledbConn.Close();

                MessageBox.Show("Import Excel hoàn thiện");
                #endregion





            }
            catch (Exception)
            {

            }



        }

    }

}
    

