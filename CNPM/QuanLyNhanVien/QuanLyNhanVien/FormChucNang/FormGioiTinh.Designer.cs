namespace QuanLyNhanVien
{
    partial class FormGioiTinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGioiTinh));
            this.label3 = new System.Windows.Forms.Label();
            this.txtLoaiGioiTinh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaGioiTinh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTuoiDiLam = new System.Windows.Forms.TextBox();
            this.grbChiTiet = new System.Windows.Forms.GroupBox();
            this.txtTuoiNghiHuu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvGioiTinh = new System.Windows.Forms.DataGridView();
            this.maGioiTinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiGioiTinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doTuoiDiLamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doTuoiNghiHuuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinhViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioiTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gioiTinhViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giới tính";
            // 
            // txtLoaiGioiTinh
            // 
            this.txtLoaiGioiTinh.Location = new System.Drawing.Point(92, 90);
            this.txtLoaiGioiTinh.Name = "txtLoaiGioiTinh";
            this.txtLoaiGioiTinh.Size = new System.Drawing.Size(160, 20);
            this.txtLoaiGioiTinh.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã giới tính";
            // 
            // txtMaGioiTinh
            // 
            this.txtMaGioiTinh.Location = new System.Drawing.Point(92, 36);
            this.txtMaGioiTinh.Name = "txtMaGioiTinh";
            this.txtMaGioiTinh.Size = new System.Drawing.Size(160, 20);
            this.txtMaGioiTinh.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tuổi đi làm";
            // 
            // txtTuoiDiLam
            // 
            this.txtTuoiDiLam.Location = new System.Drawing.Point(92, 141);
            this.txtTuoiDiLam.Name = "txtTuoiDiLam";
            this.txtTuoiDiLam.Size = new System.Drawing.Size(160, 20);
            this.txtTuoiDiLam.TabIndex = 3;
            // 
            // grbChiTiet
            // 
            this.grbChiTiet.Controls.Add(this.txtTuoiNghiHuu);
            this.grbChiTiet.Controls.Add(this.label5);
            this.grbChiTiet.Controls.Add(this.txtTuoiDiLam);
            this.grbChiTiet.Controls.Add(this.label4);
            this.grbChiTiet.Controls.Add(this.txtMaGioiTinh);
            this.grbChiTiet.Controls.Add(this.label2);
            this.grbChiTiet.Controls.Add(this.txtLoaiGioiTinh);
            this.grbChiTiet.Controls.Add(this.label3);
            this.grbChiTiet.Location = new System.Drawing.Point(530, 95);
            this.grbChiTiet.Name = "grbChiTiet";
            this.grbChiTiet.Size = new System.Drawing.Size(258, 223);
            this.grbChiTiet.TabIndex = 19;
            this.grbChiTiet.TabStop = false;
            this.grbChiTiet.Text = "Chi tiết";
            // 
            // txtTuoiNghiHuu
            // 
            this.txtTuoiNghiHuu.Location = new System.Drawing.Point(92, 186);
            this.txtTuoiNghiHuu.Name = "txtTuoiNghiHuu";
            this.txtTuoiNghiHuu.Size = new System.Drawing.Size(160, 20);
            this.txtTuoiNghiHuu.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tuổi nghỉ hưu";
            // 
            // dgvGioiTinh
            // 
            this.dgvGioiTinh.AutoGenerateColumns = false;
            this.dgvGioiTinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioiTinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGioiTinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maGioiTinhDataGridViewTextBoxColumn,
            this.loaiGioiTinhDataGridViewTextBoxColumn,
            this.doTuoiDiLamDataGridViewTextBoxColumn,
            this.doTuoiNghiHuuDataGridViewTextBoxColumn});
            this.dgvGioiTinh.DataSource = this.gioiTinhViewModelBindingSource;
            this.dgvGioiTinh.Location = new System.Drawing.Point(12, 95);
            this.dgvGioiTinh.Name = "dgvGioiTinh";
            this.dgvGioiTinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioiTinh.Size = new System.Drawing.Size(512, 223);
            this.dgvGioiTinh.TabIndex = 18;
            this.dgvGioiTinh.SelectionChanged += new System.EventHandler(this.dgvGioiTinh_SelectionChanged);
            // 
            // maGioiTinhDataGridViewTextBoxColumn
            // 
            this.maGioiTinhDataGridViewTextBoxColumn.DataPropertyName = "MaGioiTinh";
            this.maGioiTinhDataGridViewTextBoxColumn.HeaderText = "Mã Giới Tính";
            this.maGioiTinhDataGridViewTextBoxColumn.Name = "maGioiTinhDataGridViewTextBoxColumn";
            // 
            // loaiGioiTinhDataGridViewTextBoxColumn
            // 
            this.loaiGioiTinhDataGridViewTextBoxColumn.DataPropertyName = "LoaiGioiTinh";
            this.loaiGioiTinhDataGridViewTextBoxColumn.HeaderText = "Giới Tính";
            this.loaiGioiTinhDataGridViewTextBoxColumn.Name = "loaiGioiTinhDataGridViewTextBoxColumn";
            // 
            // doTuoiDiLamDataGridViewTextBoxColumn
            // 
            this.doTuoiDiLamDataGridViewTextBoxColumn.DataPropertyName = "DoTuoiDiLam";
            this.doTuoiDiLamDataGridViewTextBoxColumn.HeaderText = "Độ Tuổi Đi Làm";
            this.doTuoiDiLamDataGridViewTextBoxColumn.Name = "doTuoiDiLamDataGridViewTextBoxColumn";
            // 
            // doTuoiNghiHuuDataGridViewTextBoxColumn
            // 
            this.doTuoiNghiHuuDataGridViewTextBoxColumn.DataPropertyName = "DoTuoiNghiHuu";
            this.doTuoiNghiHuuDataGridViewTextBoxColumn.HeaderText = "Độ Tuổi Nghỉ Hưu";
            this.doTuoiNghiHuuDataGridViewTextBoxColumn.Name = "doTuoiNghiHuuDataGridViewTextBoxColumn";
            // 
            // gioiTinhViewModelBindingSource
            // 
            this.gioiTinhViewModelBindingSource.DataSource = typeof(QuanLyNhanVien.ViewModel.GioiTinhViewModel);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(93, 338);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(713, 377);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 26;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 338);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 20;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(175, 338);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(622, 338);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 23;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(713, 338);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 24;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(253, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 37);
            this.label1.TabIndex = 25;
            this.label1.Text = "Quản Lý Giới Tính";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(206, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // FormGioiTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 406);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvGioiTinh);
            this.Controls.Add(this.grbChiTiet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGioiTinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý giới tính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGioiTinh_FormClosing);
            this.Load += new System.EventHandler(this.FormGioiTinh_Load);
            this.grbChiTiet.ResumeLayout(false);
            this.grbChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioiTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gioiTinhViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLoaiGioiTinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaGioiTinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTuoiDiLam;
        private System.Windows.Forms.GroupBox grbChiTiet;
        private System.Windows.Forms.DataGridView dgvGioiTinh;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTuoiNghiHuu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn maGioiTinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiGioiTinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doTuoiDiLamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doTuoiNghiHuuDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource gioiTinhViewModelBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}