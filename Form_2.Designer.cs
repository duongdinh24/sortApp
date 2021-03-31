
namespace quickSortapp
{
    partial class Form_2
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
            this.btn_nhap = new System.Windows.Forms.Button();
            this.txt_value = new System.Windows.Forms.TextBox();
            this.txt_index = new System.Windows.Forms.TextBox();
            this.lbl_tenmang = new System.Windows.Forms.Label();
            this.lbl_daubang = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_nhap
            // 
            this.btn_nhap.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nhap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_nhap.Location = new System.Drawing.Point(209, 175);
            this.btn_nhap.Name = "btn_nhap";
            this.btn_nhap.Size = new System.Drawing.Size(106, 37);
            this.btn_nhap.TabIndex = 0;
            this.btn_nhap.Text = "Nhập";
            this.btn_nhap.UseVisualStyleBackColor = true;
            this.btn_nhap.Click += new System.EventHandler(this.btn_nhap_Click);
            // 
            // txt_value
            // 
            this.txt_value.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_value.Location = new System.Drawing.Point(305, 73);
            this.txt_value.Multiline = true;
            this.txt_value.Name = "txt_value";
            this.txt_value.Size = new System.Drawing.Size(54, 40);
            this.txt_value.TabIndex = 1;
            this.txt_value.Text = "0";
            this.txt_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_index
            // 
            this.txt_index.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_index.Location = new System.Drawing.Point(180, 73);
            this.txt_index.Multiline = true;
            this.txt_index.Name = "txt_index";
            this.txt_index.Size = new System.Drawing.Size(56, 40);
            this.txt_index.TabIndex = 1;
            this.txt_index.TabStop = false;
            this.txt_index.Text = "0";
            this.txt_index.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_tenmang
            // 
            this.lbl_tenmang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tenmang.Location = new System.Drawing.Point(140, 68);
            this.lbl_tenmang.Name = "lbl_tenmang";
            this.lbl_tenmang.Size = new System.Drawing.Size(34, 45);
            this.lbl_tenmang.TabIndex = 2;
            this.lbl_tenmang.Text = "A";
            this.lbl_tenmang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_daubang
            // 
            this.lbl_daubang.Font = new System.Drawing.Font("Consolas", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_daubang.Location = new System.Drawing.Point(260, 76);
            this.lbl_daubang.Name = "lbl_daubang";
            this.lbl_daubang.Size = new System.Drawing.Size(22, 25);
            this.lbl_daubang.TabIndex = 3;
            this.lbl_daubang.Text = "=";
            // 
            // Form_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 278);
            this.Controls.Add(this.lbl_daubang);
            this.Controls.Add(this.lbl_tenmang);
            this.Controls.Add(this.txt_index);
            this.Controls.Add(this.txt_value);
            this.Controls.Add(this.btn_nhap);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập dữ liệu cho mảng";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_nhap;
        private System.Windows.Forms.TextBox txt_value;
        private System.Windows.Forms.TextBox txt_index;
        private System.Windows.Forms.Label lbl_tenmang;
        private System.Windows.Forms.Label lbl_daubang;
    }
}