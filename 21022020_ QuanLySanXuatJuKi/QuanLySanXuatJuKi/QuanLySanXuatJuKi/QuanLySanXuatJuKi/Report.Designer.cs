namespace QuanLySanXuatJuKi
{
    partial class Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TimeFrom = new System.Windows.Forms.DateTimePicker();
            this.TimeTo = new System.Windows.Forms.DateTimePicker();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPhamTiengAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPhamTiengViet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLopKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLopHienTai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenCatNhung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDauNhung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianNhung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianBatDauPhoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianKetThucQuaTrinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianPhoiCaiDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianPhoiThucTe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All",
            "LOT",
            "Sản Phẩm"});
            this.comboBox1.Location = new System.Drawing.Point(991, 24);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ngày sản xuất lớn hơn -  より大きな製造日：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(914, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Lọc theo mã:";
            // 
            // TimeFrom
            // 
            this.TimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeFrom.Location = new System.Drawing.Point(237, 22);
            this.TimeFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimeFrom.Name = "TimeFrom";
            this.TimeFrom.Size = new System.Drawing.Size(183, 20);
            this.TimeFrom.TabIndex = 10;
            // 
            // TimeTo
            // 
            this.TimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TimeTo.Location = new System.Drawing.Point(662, 22);
            this.TimeTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimeTo.Name = "TimeTo";
            this.TimeTo.Size = new System.Drawing.Size(183, 20);
            this.TimeTo.TabIndex = 13;
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(1561, 12);
            this.btnBaoCao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(211, 45);
            this.btnBaoCao.TabIndex = 11;
            this.btnBaoCao.Text = "Tạo báo cáo - レポートを作成:";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ngày sản xuất nhỏ hơn - 生産日が小さい :";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "All",
            "LOT",
            "Sản Phẩm"});
            this.comboBox2.Location = new System.Drawing.Point(1180, 24);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(183, 21);
            this.comboBox2.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1394, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 45);
            this.button1.TabIndex = 17;
            this.button1.Text = "Truy vấn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.AllowUserToAddRows = false;
            this.dataGridViewReport.AllowUserToDeleteRows = false;
            this.dataGridViewReport.AllowUserToResizeRows = false;
            this.dataGridViewReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSanPham,
            this.TenSanPhamTiengAnh,
            this.TenSanPhamTiengViet,
            this.MaLOT,
            this.Xe,
            this.Cot,
            this.SoLopKetThuc,
            this.SoLopHienTai,
            this.TenCatNhung,
            this.ThoiGianBatDauNhung,
            this.ThoiGianNhung,
            this.ThoiGianBatDauPhoi,
            this.ThoiGianKetThucQuaTrinh,
            this.ThoiGianPhoiCaiDat,
            this.ThoiGianPhoiThucTe,
            this.NhanVien,
            this.TrangThai});
            this.dataGridViewReport.Location = new System.Drawing.Point(12, 75);
            this.dataGridViewReport.Name = "dataGridViewReport";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewReport.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewReport.RowHeadersVisible = false;
            this.dataGridViewReport.Size = new System.Drawing.Size(1760, 674);
            this.dataGridViewReport.TabIndex = 18;
            // 
            // MaSanPham
            // 
            this.MaSanPham.DataPropertyName = "MaSanPham";
            this.MaSanPham.HeaderText = "Mã SP";
            this.MaSanPham.Name = "MaSanPham";
            // 
            // TenSanPhamTiengAnh
            // 
            this.TenSanPhamTiengAnh.DataPropertyName = "TenSanPhamTiengAnh";
            this.TenSanPhamTiengAnh.HeaderText = "Tên SP Tiếng Anh";
            this.TenSanPhamTiengAnh.Name = "TenSanPhamTiengAnh";
            // 
            // TenSanPhamTiengViet
            // 
            this.TenSanPhamTiengViet.DataPropertyName = "TenSanPhamTiengViet";
            this.TenSanPhamTiengViet.HeaderText = "Tên SP Tiếng Việt";
            this.TenSanPhamTiengViet.Name = "TenSanPhamTiengViet";
            // 
            // MaLOT
            // 
            this.MaLOT.DataPropertyName = "MaLOT";
            this.MaLOT.HeaderText = "Mã LOT";
            this.MaLOT.Name = "MaLOT";
            // 
            // Xe
            // 
            this.Xe.DataPropertyName = "Xe";
            this.Xe.HeaderText = "Xe";
            this.Xe.Name = "Xe";
            // 
            // Cot
            // 
            this.Cot.DataPropertyName = "Cot";
            this.Cot.HeaderText = "Cột";
            this.Cot.Name = "Cot";
            // 
            // SoLopKetThuc
            // 
            this.SoLopKetThuc.DataPropertyName = "SoLopKetThuc";
            this.SoLopKetThuc.HeaderText = "Tổng Số Lớp";
            this.SoLopKetThuc.Name = "SoLopKetThuc";
            // 
            // SoLopHienTai
            // 
            this.SoLopHienTai.DataPropertyName = "SoLopHienTai";
            this.SoLopHienTai.HeaderText = "Lớp Hiện Tại";
            this.SoLopHienTai.Name = "SoLopHienTai";
            // 
            // TenCatNhung
            // 
            this.TenCatNhung.DataPropertyName = "TenCatNhung";
            this.TenCatNhung.HeaderText = "Tên Cát Nhúng";
            this.TenCatNhung.Name = "TenCatNhung";
            // 
            // ThoiGianBatDauNhung
            // 
            this.ThoiGianBatDauNhung.DataPropertyName = "ThoiGianBatDauNhung";
            this.ThoiGianBatDauNhung.HeaderText = "TGBD Nhúng";
            this.ThoiGianBatDauNhung.Name = "ThoiGianBatDauNhung";
            // 
            // ThoiGianNhung
            // 
            this.ThoiGianNhung.DataPropertyName = "ThoiGianNhung";
            this.ThoiGianNhung.HeaderText = "TG Nhúng";
            this.ThoiGianNhung.Name = "ThoiGianNhung";
            // 
            // ThoiGianBatDauPhoi
            // 
            this.ThoiGianBatDauPhoi.DataPropertyName = "ThoiGianBatDauPhoi";
            this.ThoiGianBatDauPhoi.HeaderText = "TGBD Phơi";
            this.ThoiGianBatDauPhoi.Name = "ThoiGianBatDauPhoi";
            // 
            // ThoiGianKetThucQuaTrinh
            // 
            this.ThoiGianKetThucQuaTrinh.DataPropertyName = "ThoiGianKetThucQuaTrinh";
            this.ThoiGianKetThucQuaTrinh.HeaderText = "TGKT Phơi";
            this.ThoiGianKetThucQuaTrinh.Name = "ThoiGianKetThucQuaTrinh";
            // 
            // ThoiGianPhoiCaiDat
            // 
            this.ThoiGianPhoiCaiDat.DataPropertyName = "ThoiGianPhoiCaiDat";
            this.ThoiGianPhoiCaiDat.HeaderText = "TG Phơi Cài Đặt";
            this.ThoiGianPhoiCaiDat.Name = "ThoiGianPhoiCaiDat";
            // 
            // ThoiGianPhoiThucTe
            // 
            this.ThoiGianPhoiThucTe.DataPropertyName = "ThoiGianPhoiThucTe";
            this.ThoiGianPhoiThucTe.HeaderText = "TG Phơi Thực Tế";
            this.ThoiGianPhoiThucTe.Name = "ThoiGianPhoiThucTe";
            // 
            // NhanVien
            // 
            this.NhanVien.DataPropertyName = "NhanVien";
            this.NhanVien.HeaderText = "Nhân Viên";
            this.NhanVien.Name = "NhanVien";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 761);
            this.Controls.Add(this.dataGridViewReport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TimeFrom);
            this.Controls.Add(this.TimeTo);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TimeFrom;
        private System.Windows.Forms.DateTimePicker TimeTo;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPhamTiengAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPhamTiengViet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Xe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cot;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLopKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLopHienTai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenCatNhung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDauNhung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianNhung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDauPhoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianKetThucQuaTrinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianPhoiCaiDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianPhoiThucTe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}