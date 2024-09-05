namespace QuanLyNhanVien
{
    partial class QuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLy));
            this.label3 = new System.Windows.Forms.Label();
            this.dgvQuanLy = new System.Windows.Forms.DataGridView();
            this.tenNguoiDungDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuoiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soDienThoaiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaChiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quyenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenChucVuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKhuVucDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gioiTinhDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.luongCoBanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nhanVienViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(400, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 37);
            this.label3.TabIndex = 18;
            this.label3.Text = "Quản Lý";
            // 
            // dgvQuanLy
            // 
            this.dgvQuanLy.AutoGenerateColumns = false;
            this.dgvQuanLy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tenNguoiDungDataGridViewTextBoxColumn,
            this.tuoiDataGridViewTextBoxColumn,
            this.soDienThoaiDataGridViewTextBoxColumn,
            this.diaChiDataGridViewTextBoxColumn,
            this.quyenDataGridViewTextBoxColumn,
            this.tenChucVuDataGridViewTextBoxColumn,
            this.tenKhuVucDataGridViewTextBoxColumn,
            this.gioiTinhDataGridViewTextBoxColumn,
            this.luongCoBanDataGridViewTextBoxColumn});
            this.dgvQuanLy.DataSource = this.nhanVienViewModelBindingSource;
            this.dgvQuanLy.Location = new System.Drawing.Point(28, 59);
            this.dgvQuanLy.Name = "dgvQuanLy";
            this.dgvQuanLy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuanLy.Size = new System.Drawing.Size(942, 379);
            this.dgvQuanLy.TabIndex = 19;
            // 
            // tenNguoiDungDataGridViewTextBoxColumn
            // 
            this.tenNguoiDungDataGridViewTextBoxColumn.DataPropertyName = "TenNguoiDung";
            this.tenNguoiDungDataGridViewTextBoxColumn.FillWeight = 100.1112F;
            this.tenNguoiDungDataGridViewTextBoxColumn.HeaderText = "Tên Người Dùng";
            this.tenNguoiDungDataGridViewTextBoxColumn.Name = "tenNguoiDungDataGridViewTextBoxColumn";
            // 
            // tuoiDataGridViewTextBoxColumn
            // 
            this.tuoiDataGridViewTextBoxColumn.DataPropertyName = "Tuoi";
            this.tuoiDataGridViewTextBoxColumn.FillWeight = 100.0755F;
            this.tuoiDataGridViewTextBoxColumn.HeaderText = "Tuổi";
            this.tuoiDataGridViewTextBoxColumn.Name = "tuoiDataGridViewTextBoxColumn";
            // 
            // soDienThoaiDataGridViewTextBoxColumn
            // 
            this.soDienThoaiDataGridViewTextBoxColumn.DataPropertyName = "SoDienThoai";
            this.soDienThoaiDataGridViewTextBoxColumn.FillWeight = 100.0438F;
            this.soDienThoaiDataGridViewTextBoxColumn.HeaderText = "Số điện thoại";
            this.soDienThoaiDataGridViewTextBoxColumn.Name = "soDienThoaiDataGridViewTextBoxColumn";
            // 
            // diaChiDataGridViewTextBoxColumn
            // 
            this.diaChiDataGridViewTextBoxColumn.DataPropertyName = "DiaChi";
            this.diaChiDataGridViewTextBoxColumn.FillWeight = 100.0156F;
            this.diaChiDataGridViewTextBoxColumn.HeaderText = "Địa Chỉ";
            this.diaChiDataGridViewTextBoxColumn.Name = "diaChiDataGridViewTextBoxColumn";
            // 
            // quyenDataGridViewTextBoxColumn
            // 
            this.quyenDataGridViewTextBoxColumn.DataPropertyName = "Quyen";
            this.quyenDataGridViewTextBoxColumn.FillWeight = 99.99059F;
            this.quyenDataGridViewTextBoxColumn.HeaderText = "Quyền";
            this.quyenDataGridViewTextBoxColumn.Name = "quyenDataGridViewTextBoxColumn";
            // 
            // tenChucVuDataGridViewTextBoxColumn
            // 
            this.tenChucVuDataGridViewTextBoxColumn.DataPropertyName = "TenChucVu";
            this.tenChucVuDataGridViewTextBoxColumn.FillWeight = 99.96832F;
            this.tenChucVuDataGridViewTextBoxColumn.HeaderText = "Chức Vụ";
            this.tenChucVuDataGridViewTextBoxColumn.Name = "tenChucVuDataGridViewTextBoxColumn";
            // 
            // tenKhuVucDataGridViewTextBoxColumn
            // 
            this.tenKhuVucDataGridViewTextBoxColumn.DataPropertyName = "TenKhuVuc";
            this.tenKhuVucDataGridViewTextBoxColumn.FillWeight = 99.94855F;
            this.tenKhuVucDataGridViewTextBoxColumn.HeaderText = "Khu";
            this.tenKhuVucDataGridViewTextBoxColumn.Name = "tenKhuVucDataGridViewTextBoxColumn";
            this.tenKhuVucDataGridViewTextBoxColumn.Width = 99;
            // 
            // gioiTinhDataGridViewTextBoxColumn
            // 
            this.gioiTinhDataGridViewTextBoxColumn.DataPropertyName = "GioiTinh";
            this.gioiTinhDataGridViewTextBoxColumn.FillWeight = 99.93095F;
            this.gioiTinhDataGridViewTextBoxColumn.HeaderText = "Giới Tính";
            this.gioiTinhDataGridViewTextBoxColumn.Name = "gioiTinhDataGridViewTextBoxColumn";
            // 
            // luongCoBanDataGridViewTextBoxColumn
            // 
            this.luongCoBanDataGridViewTextBoxColumn.DataPropertyName = "LuongCoBan";
            this.luongCoBanDataGridViewTextBoxColumn.FillWeight = 99.91532F;
            this.luongCoBanDataGridViewTextBoxColumn.HeaderText = "Lương Cơ Bản";
            this.luongCoBanDataGridViewTextBoxColumn.Name = "luongCoBanDataGridViewTextBoxColumn";
            // 
            // nhanVienViewModelBindingSource
            // 
            this.nhanVienViewModelBindingSource.DataSource = typeof(QuanLyNhanVien.ViewModel.NhanVienViewModel);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(882, 444);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(88, 33);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Đăng Xuất";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click_1);
            // 
            // QuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 484);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvQuanLy);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLy_FormClosing_1);
            this.Load += new System.EventHandler(this.QuanLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvQuanLy;
        private System.Windows.Forms.BindingSource nhanVienViewModelBindingSource;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNguoiDungDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuoiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soDienThoaiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaChiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quyenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenChucVuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKhuVucDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gioiTinhDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn luongCoBanDataGridViewTextBoxColumn;
    }
}