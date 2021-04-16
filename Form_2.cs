using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quickSortapp
{
    public partial class Form_2 : Form
    {
        public Form_2()
        {
            InitializeComponent();
            txt_value.Focus();
        }

        int index = 0;

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            int value;
            Boolean kiemtra = true;
            try
            {
                index = Convert.ToInt32(txt_index.Text);
            }
            catch
            {
                MessageBox.Show("Chỉ số không hợp lệ!");
                txt_index.Text = "0";
                return;
            }
            if (index > Form_main.so_phan_tu -1 || index < 0)
            {
                MessageBox.Show("Không có phần tử thứ "+ index);
                txt_index.Text ="0";
                return;
            }

            try
            {
                value = Convert.ToInt32(txt_value.Text);
            }
            catch
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                txt_value.Text = "0";
                return;
            }
            if( value < 0 || value > 99)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                txt_value.Text = "0";
                return;
            }

            if (kiemtra)
            {
                Form_main.a[index] = value;
                Form_main.node1[index].Text = value.ToString();
                // Đoạn này cho nó nhấp nháy 1 cái khi nhận giá trị
                Form_main.node1[index].BackgroundImage = Properties.Resources.img_select;
                Form_main.node1[index].Refresh();
                Thread.Sleep(500);
                Form_main.node1[index].BackgroundImage = Properties.Resources.img_simple;
                Form_main.node1[index].Refresh();

                this.txt_value.Text = "0";
                this.txt_value.Focus();
                this.txt_index.Text = (index + 1).ToString();
                this.txt_index.SelectAll();
            }
        }
    }
}
