
namespace QLDonHang_1851010089
{
    partial class FMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btNV = new System.Windows.Forms.Button();
            this.btSP = new System.Windows.Forms.Button();
            this.btDonHang = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btNV);
            this.groupBox1.Controls.Add(this.btSP);
            this.groupBox1.Controls.Add(this.btDonHang);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(-1, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản Lý";
            // 
            // btNV
            // 
            this.btNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNV.Location = new System.Drawing.Point(109, 189);
            this.btNV.Name = "btNV";
            this.btNV.Size = new System.Drawing.Size(233, 42);
            this.btNV.TabIndex = 3;
            this.btNV.Text = "Nhân Viên";
            this.btNV.UseVisualStyleBackColor = true;
            this.btNV.Click += new System.EventHandler(this.btNV_Click);
            // 
            // btSP
            // 
            this.btSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSP.Location = new System.Drawing.Point(109, 93);
            this.btSP.Name = "btSP";
            this.btSP.Size = new System.Drawing.Size(233, 42);
            this.btSP.TabIndex = 1;
            this.btSP.Text = "Sản Phẩm";
            this.btSP.UseVisualStyleBackColor = true;
            this.btSP.Click += new System.EventHandler(this.btSP_Click);
            // 
            // btDonHang
            // 
            this.btDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDonHang.Location = new System.Drawing.Point(109, 141);
            this.btDonHang.Name = "btDonHang";
            this.btDonHang.Size = new System.Drawing.Size(233, 42);
            this.btDonHang.TabIndex = 0;
            this.btDonHang.Text = "Đơn Hàng";
            this.btDonHang.UseVisualStyleBackColor = true;
            this.btDonHang.Click += new System.EventHandler(this.btDonHang_Click);
            // 
            // btThoat
            // 
            this.btThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(338, 324);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(93, 29);
            this.btThoat.TabIndex = 5;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(436, 359);
            this.ControlBox = false;
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.groupBox1);
            this.Name = "FMain";
            this.Text = "FMain";
            this.Load += new System.EventHandler(this.FMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btDonHang;
        private System.Windows.Forms.Button btNV;
        private System.Windows.Forms.Button btSP;
        private System.Windows.Forms.Button btThoat;
    }
}