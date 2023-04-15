namespace QuetBarcode
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labSp = new System.Windows.Forms.Label();
            this.labLot = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labCot = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labXe = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.iDriver1 = new ATSCADA.iDriver();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.labNPT = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textSP
            // 
            this.textSP.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSP.Location = new System.Drawing.Point(480, 141);
            this.textSP.Name = "textSP";
            this.textSP.Size = new System.Drawing.Size(648, 46);
            this.textSP.TabIndex = 0;
            this.textSP.TextChanged += new System.EventHandler(this.textSP_TextChanged);
            this.textSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSP_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrange;
            this.label2.Location = new System.Drawing.Point(116, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Sản Phẩm";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labSp
            // 
            this.labSp.BackColor = System.Drawing.Color.LightCyan;
            this.labSp.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSp.Location = new System.Drawing.Point(367, 431);
            this.labSp.Name = "labSp";
            this.labSp.Size = new System.Drawing.Size(464, 70);
            this.labSp.TabIndex = 3;
            this.labSp.Text = "1234-q345";
            this.labSp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labLot
            // 
            this.labLot.BackColor = System.Drawing.Color.LightCyan;
            this.labLot.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLot.Location = new System.Drawing.Point(1142, 233);
            this.labLot.Name = "labLot";
            this.labLot.Size = new System.Drawing.Size(464, 70);
            this.labLot.TabIndex = 5;
            this.labLot.Text = "WP1234";
            this.labLot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkOrange;
            this.label5.Location = new System.Drawing.Point(891, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã Lot";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labCot
            // 
            this.labCot.BackColor = System.Drawing.Color.LightCyan;
            this.labCot.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCot.Location = new System.Drawing.Point(1137, 332);
            this.labCot.Name = "labCot";
            this.labCot.Size = new System.Drawing.Size(434, 70);
            this.labCot.TabIndex = 7;
            this.labCot.Text = "COT1";
            this.labCot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkOrange;
            this.label7.Location = new System.Drawing.Point(891, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 51);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mã Cột";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labXe
            // 
            this.labXe.BackColor = System.Drawing.Color.LightCyan;
            this.labXe.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labXe.Location = new System.Drawing.Point(1137, 431);
            this.labXe.Name = "labXe";
            this.labXe.Size = new System.Drawing.Size(434, 70);
            this.labXe.TabIndex = 9;
            this.labXe.Text = "XE1";
            this.labXe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkOrange;
            this.label9.Location = new System.Drawing.Point(891, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 51);
            this.label9.TabIndex = 8;
            this.label9.Text = "Mã Xe";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkOrange;
            this.label10.Location = new System.Drawing.Point(30, 806);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(224, 23);
            this.label10.TabIndex = 10;
            this.label10.Text = "Trạng thái kết nối server";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(329, 806);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(363, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Chot SP|Phoi";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // iDriver1
            // 
            this.iDriver1.Designmode = false;
            this.iDriver1.GetTaskTimeOut = ((ulong)(5000ul));
            this.iDriver1.MaxTagWriteTimes = 10;
            this.iDriver1.ProjectFile = null;
            this.iDriver1.WaitingTime = 1000;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightCyan;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(536, 620);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(941, 58);
            this.label4.TabIndex = 12;
            this.label4.Text = "TT DK SP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightCyan;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(365, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(466, 70);
            this.label6.TabIndex = 14;
            this.label6.Text = "sukien";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(119, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(177, 51);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mã Sự Kiện";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightCyan;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(367, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(464, 70);
            this.label11.TabIndex = 16;
            this.label11.Text = "ma barcode";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkOrange;
            this.label12.Location = new System.Drawing.Point(116, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(180, 51);
            this.label12.TabIndex = 15;
            this.label12.Text = "Mã Barcode";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LightCyan;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(530, 715);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(947, 58);
            this.label13.TabIndex = 17;
            this.label13.Text = "TT DK Phoi";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkOrange;
            this.label14.Location = new System.Drawing.Point(87, 638);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(397, 32);
            this.label14.TabIndex = 19;
            this.label14.Text = "Trạng Thái Đăng Ký Sản Phẩm";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkOrange;
            this.label15.Location = new System.Drawing.Point(40, 728);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(422, 32);
            this.label15.TabIndex = 18;
            this.label15.Text = "Trạng Thái Đăng Ký Phơi";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.DarkGreen;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Gold;
            this.label16.Location = new System.Drawing.Point(621, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(429, 126);
            this.label16.TabIndex = 21;
            this.label16.Text = "ĐỌC BARCODE";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Honeydew;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1307, 796);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 37);
            this.label1.TabIndex = 28;
            this.label1.Text = "15/06/2019 12:30:00";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuetBarcode.Properties.Resources.logoATSCADA;
            this.pictureBox2.Location = new System.Drawing.Point(1048, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(553, 126);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuetBarcode.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(43, 183);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "label17";
            this.label17.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(43, 209);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 31;
            this.label18.Text = "label18";
            this.label18.Visible = false;
            // 
            // labNPT
            // 
            this.labNPT.BackColor = System.Drawing.Color.LightCyan;
            this.labNPT.Font = new System.Drawing.Font("Times New Roman", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNPT.Location = new System.Drawing.Point(1137, 531);
            this.labNPT.Name = "labNPT";
            this.labNPT.Size = new System.Drawing.Size(445, 70);
            this.labNPT.TabIndex = 33;
            this.labNPT.Text = "NPT:1234";
            this.labNPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkOrange;
            this.label20.Location = new System.Drawing.Point(891, 546);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(262, 44);
            this.label20.TabIndex = 32;
            this.label20.Text = "Mã NPT";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(1600, 881);
            this.Controls.Add(this.labNPT);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labXe);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labCot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labLot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labSp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textSP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG KÝ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labSp;
        private System.Windows.Forms.Label labLot;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labCot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labXe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private ATSCADA.iDriver iDriver1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labNPT;
        private System.Windows.Forms.Label label20;
    }
}

