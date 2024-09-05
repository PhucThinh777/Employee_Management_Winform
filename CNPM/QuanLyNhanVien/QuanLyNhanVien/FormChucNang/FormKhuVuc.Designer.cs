namespace QuanLyNhanVien
{
    partial class FormKhuVuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormKhuVuc));
            this.dgvKhuVuc = new System.Windows.Forms.DataGridView();
            this.maKhuVucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhuVucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.khuVucViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grbChiTiet = new System.Windows.Forms.GroupBox();
            this.txtMaKhuVuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenKhuVuc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khuVucViewModelBindingSource)).BeginInit();
            this.grbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKhuVuc
            // 
            this.dgvKhuVuc.AutoGenerateColumns = false;
            this.dgvKhuVuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuVuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuVuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maKhuVucDataGridViewTextBoxColumn,
            this.tenKhuVucDataGridViewTextBoxColumn});
            this.dgvKhuVuc.DataSource = this.khuVucViewModelBindingSource;
            this.dgvKhuVuc.Location = new System.Drawing.Point(11, 97);
            this.dgvKhuVuc.Name = "dgvKhuVuc";
            this.dgvKhuVuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuVuc.Size = new System.Drawing.Size(254, 212);
            this.dgvKhuVuc.TabIndex = 9;
            this.dgvKhuVuc.SelectionChanged += new System.EventHandler(this.dgvKhuVuc_SelectionChanged);
            // 
            // maKhuVucDataGridViewTextBoxColumn
            // 
            this.maKhuVucDataGridViewTextBoxColumn.DataPropertyName = "MaKhuVuc";
            this.maKhuVucDataGridViewTextBoxColumn.HeaderText = "Mã Khu Vực";
            this.maKhuVucDataGridViewTextBoxColumn.Name = "maKhuVucDataGridViewTextBoxColumn";
            // 
            // tenKhuVucDataGridViewTextBoxColumn
            // 
            this.tenKhuVucDataGridViewTextBoxColumn.DataPropertyName = "TenKhuVuc";
            this.tenKhuVucDataGridViewTextBoxColumn.HeaderText = "Khu Vực";
            this.tenKhuVucDataGridViewTextBoxColumn.Name = "tenKhuVucDataGridViewTextBoxColumn";
            // 
            // khuVucViewModelBindingSource
            // 
            this.khuVucViewModelBindingSource.DataSource = typeof(QuanLyNhanVien.ViewModel.KhuVucViewModel);
            // 
            // grbChiTiet
            // 
            this.grbChiTiet.Controls.Add(this.txtMaKhuVuc);
            this.grbChiTiet.Controls.Add(this.label2);
            this.grbChiTiet.Controls.Add(this.txtTenKhuVuc);
            this.grbChiTiet.Controls.Add(this.label3);
            this.grbChiTiet.Location = new System.Drawing.Point(271, 97);
            this.grbChiTiet.Name = "grbChiTiet";
            this.grbChiTiet.Size = new System.Drawing.Size(258, 116);
            this.grbChiTiet.TabIndex = 10;
            this.grbChiTiet.TabStop = false;
            this.grbChiTiet.Text = "Chi tiết";
            // 
            // txtMaKhuVuc
            // 
            this.txtMaKhuVuc.Location = new System.Drawing.Point(92, 36);
            this.txtMaKhuVuc.Name = "txtMaKhuVuc";
            this.txtMaKhuVuc.Size = new System.Drawing.Size(160, 20);
            this.txtMaKhuVuc.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã khu vực";
            // 
            // txtTenKhuVuc
            // 
            this.txtTenKhuVuc.Location = new System.Drawing.Point(92, 90);
            this.txtTenKhuVuc.Name = "txtTenKhuVuc";
            this.txtTenKhuVuc.Size = new System.Drawing.Size(160, 20);
            this.txtTenKhuVuc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Khu vực";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(454, 388);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 17;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(141, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 37);
            this.label1.TabIndex = 16;
            this.label1.Text = "Quản Lý Khu Vực";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(454, 326);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(363, 326);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 14;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(174, 326);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(92, 326);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(11, 326);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(103, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // FormKhuVuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 428);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvKhuVuc);
            this.Controls.Add(this.grbChiTiet);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormKhuVuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khu vực";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormKhuVuc_FormClosing);
            this.Load += new System.EventHandler(this.FormKhuVuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuVuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khuVucViewModelBindingSource)).EndInit();
            this.grbChiTiet.ResumeLayout(false);
            this.grbChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKhuVuc;
        private System.Windows.Forms.GroupBox grbChiTiet;
        private System.Windows.Forms.TextBox txtMaKhuVuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenKhuVuc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKhuVucDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhuVucDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource khuVucViewModelBindingSource;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}