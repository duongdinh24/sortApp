using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quickSortapp
{
    public partial class Form_main : Form
    {
        #region Khai báo biến

        public static Button[] node1;   // Biến minh họa mảng
        public static int so_phan_tu;   // Số phần tử của mảng
        public static Label[] chiSo;   // Chỉ số vị trí của mảng
        public static int[] a;         // Mảng a
        int toc_Do=1;                    // Độ trễ của di chuyểnm
        Boolean tang = true;     // Kiểu sắp xếp
        Boolean da_Tao_Mang = false;
        Boolean da_Tao_GT = false;
        Boolean chay_het = false;
        Boolean kt_tam_dung = false; //Biến kiểm tra đã tạo mảng và kiểm tra tạm dừng
        Boolean sap_Xep_Tung_Buoc;        // Biến kiểm tra sắp xếp từng bước hay nhanh
        CodeC code_C = new CodeC();       // Code C/C++ cho thuật toán
        int i;    // Biến này dùng nhiều

        // Các biến thiết lập cho node
        int khoang_Cach;            // Khoảng cách hai node
        int kich_Thuoc;             // Kích thước node
        int co_Chu;                 // Cỡ chữ node
        int le_Node;                // Căn lề node
        #endregion

        // Hàm này tự chạy khi khởi động Form
        public Form_main()
        {
            InitializeComponent();
            code_C.quicksort(lb_list_code, tang);  // Tải code C/C++ vào listBox

            // Vô hiệu hóa các lable, button, checkbox, Radiobutton
            btn_break.Enabled = false;
            btn_nhaptay.Enabled = false;
            btn_random.Enabled = false;
            btn_readfile.Enabled = false;
            btn_sapxep.Enabled = false;
            ckb_tungbuoc.Enabled = false;
            rad_giam.Enabled = false;
            rad_tang.Enabled = false;
            lbl_mangA.Visible = false;
            lbl_index.Visible = false;
            lbl_status.Visible = false;
            lbl_right.Visible = false;
            lbl_left.Visible = false;
            lbl_pivot.Visible = false;
            ckb_tungbuoc.Enabled = false;
            rad_giam.Enabled = false;
            rad_tang.Enabled = false;
        }

        private void Form_main_Load(object sender, EventArgs e)
        {

        }
        private void btn_taomang_Click(object sender, EventArgs e)
        {   
            lbl_Tieude.Visible = false;
            lbl_left.Visible = false;
            lbl_pivot.Visible = false;
            lbl_right.Visible = false;
            da_Tao_GT = false;
            if(da_Tao_Mang)
              xoa_Mang(node1);
            lbl_status.ResetText();
            nmr_sophantu.Focus();
            try
            {
                so_phan_tu = Convert.ToInt32(nmr_sophantu.Value);
            }
            catch
            {
                MessageBox.Show("Số phần tử vừa nhập vào không hợp lệ!");
                nmr_sophantu.Value = 8;
                return;
            }
            a = new int[so_phan_tu];
            tao_Mang(150, Properties.Resources.img_simple);
        }

        public void tao_Mang(int kc,System.Drawing.Image img_nen)
        {
            if(so_phan_tu <2 || so_phan_tu > 10)
            {
                MessageBox.Show(" Số phần tử >1 và <=10");
                da_Tao_Mang = false;
                nmr_sophantu.Value = 8;   // Mặc định cho nó bằng 8 cho đẹp
                return;
            }
               
            // Tạo thuộc tính cho node
            kich_Thuoc = 70;
            co_Chu = 15;
            khoang_Cach = 25;
            le_Node = (1350 - kich_Thuoc * so_phan_tu - khoang_Cach * (so_phan_tu - 1)) / 2;

            // KHởi tạo mảng node
            node1 = new Button[so_phan_tu];
            chiSo = new Label[so_phan_tu];
            lbl_index.Visible = true;
            lbl_mangA.Visible = true;
            for (int i = 0; i < so_phan_tu; i++)
            {
                node1[i] = new Button();
                node1[i].Text = a[i].ToString();
                node1[i].TextAlign = ContentAlignment.MiddleCenter;
                node1[i].Width = kich_Thuoc;
                node1[i].Height = kich_Thuoc;
                node1[i].Location = new Point(le_Node + (kich_Thuoc+khoang_Cach) * i, kc);
                node1[i].ForeColor = Color.Black;
                node1[i].Font = new Font(this.Font, FontStyle.Bold);
                node1[i].Font = new System.Drawing.Font("Arial", co_Chu, FontStyle.Bold);
                node1[i].FlatStyle = FlatStyle.Flat;
                node1[i].BackgroundImage = img_nen;
                node1[i].BackgroundImageLayout = ImageLayout.Stretch;
                node1[i].FlatAppearance.BorderSize = 0;
                this.Controls.Add(node1[i]);

                // Tạo nhãn chỉ sổ
                chiSo[i] = new Label();
                chiSo[i].TextAlign = ContentAlignment.MiddleCenter;
                chiSo[i].Text = i.ToString();
                chiSo[i].Width = kich_Thuoc;
                chiSo[i].Height = kich_Thuoc;
                chiSo[i].ForeColor = Color.Black;

                chiSo[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, 270 + khoang_Cach*3);
                chiSo[i].Font = new System.Drawing.Font("Arial", co_Chu - 4, FontStyle.Bold);
                this.Controls.Add(chiSo[i]);
            }
            da_Tao_Mang = true; //Xác nhận đã tạo mảng                                        
            btn_nhaptay.Enabled = true; //Cho phép các nút điều khiển có tác dụng khi đã tạo mảng
            btn_random.Enabled = true;
            btn_readfile.Enabled = true;

        }

        // Hàm reset giá trị của các node về 0;
        public void reset_node()
        {
            for(int i=0; i<so_phan_tu; i++)
            {
                a[i] = 0;
                node1[i].Text = a[i].ToString();
            }
        }

        // Hàm xóa mảng đã tạo
        public void xoa_Mang(Button[] Node)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                btn_nhaptay.Enabled = false;
                btn_random.Enabled = false;
                btn_sapxep.Enabled = false;
                btn_readfile.Enabled = false;
                if (da_Tao_Mang == true)
                {
                    for (i = 0; i < so_phan_tu; i++)
                    {
                        this.Controls.Remove(Node[i]);
                        this.Controls.Remove(chiSo[i]);

                    }
                    da_Tao_Mang = false;
                    lbl_mangA.Visible = false;
                    lbl_index.Visible = false;
                }
            });

        }

        private void zoomcode_EditValueChanged(object sender, EventArgs e)
        {
            if (zoomcode.Value > 8)
            {
                lb_list_code.Font = new Font("Consolas", zoomcode.Value + 5, FontStyle.Regular);
            }

        }


        #region NHẬP DỮ LIỆU CHO MẢNG
        
        // Hàm nhập random
        private void btn_random_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            for (int i = 0; i < so_phan_tu; i++)
            {
                a[i] = rd.Next(20);
                node1[i].Text = a[i].ToString();

            }

            // Mở các nút bấm
            rad_tang.Enabled = true;
            rad_giam.Enabled = true;
            ckb_tungbuoc.Enabled = true;
            da_Tao_GT = true;
            btn_sapxep.Enabled = true;
            btn_break.Enabled = true;
        }

        // Nhập dữ liệu từ file cùng với thư mục chứa file.exe
        private void btn_readfile_Click(object sender, EventArgs e)
        {
            StreamReader re = File.OpenText("mangA.txt");
            string input =null;
            int i = 0;
            while ((input = re.ReadLine()) != null)
            {
                try
                {
                    a[i] = Convert.ToInt32(input);
                    node1[i].Text = a[i].ToString();
                    i++;
                }
                catch
                {
                    MessageBox.Show("Sô lượng phần tử trong file nhiều hơn " + so_phan_tu.ToString());
                    reset_node();
                    nmr_sophantu.Focus();
                    return;
                }


            }
            re.Close();
            if(i < so_phan_tu)
            {
                MessageBox.Show("Số lượng phần tử trong file ít hơn "+ so_phan_tu.ToString());
                nmr_sophantu.Focus();
                reset_node();
                return;
            }
            // Mở các nút
            rad_tang.Enabled = true;
            rad_giam.Enabled = true;
            ckb_tungbuoc.Enabled = true;
            da_Tao_GT = true;
            btn_sapxep.Enabled = true;

        }

        // Nhập dữ liệu bằng tay
        private void btn_nhaptay_Click(object sender, EventArgs e)
        {
            Form_2 f2 = new Form_2();
            f2.ShowDialog();
            rad_tang.Enabled = true;
            rad_giam.Enabled = true;
            ckb_tungbuoc.Enabled = true;
            da_Tao_GT = true;
            btn_sapxep.Enabled = true;
        }
        #endregion

        #region CÁC HÀM CHỨC NĂNG

        // Hàm tạo một node simple, với text = !
        public Button create_node(Button node, String t)
        {
            node = new Button();
            node.Text = t;
            node.TextAlign = ContentAlignment.MiddleCenter;
            node.Width = kich_Thuoc;
            node.Height = kich_Thuoc;
            node.ForeColor = Color.Black;
            node.Font = new Font(this.Font, FontStyle.Bold);
            node.Font = new System.Drawing.Font("Arial", co_Chu, FontStyle.Bold);
            node.FlatStyle = FlatStyle.Flat;
            node.BackgroundImage = Properties.Resources.img_simple;
            node.BackgroundImageLayout = ImageLayout.Stretch;
            node.FlatAppearance.BorderSize = 0;
            return node;
        }
        
        // Hàm set màu node
        public void set_node_color(Control t, System.Drawing.Image img_nen)
        {
            t.BackgroundImage = img_nen;
            t.BackgroundImageLayout = ImageLayout.Stretch;
            t.Refresh();
        }

        // Hàm đổi giá trị phần tử mảng
        public void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        
        // Hàm dừng chương trình
        public void Play_or_Stop()
        {
            while (kt_tam_dung == true)
            {
                Application.DoEvents();   // Câu lệnh gọi cho máy tính thực hiện hành động trống
            }
        }
        //Hàm Tạm dừng
        public void Tam_dung()
        {
            if (sap_Xep_Tung_Buoc == true)
            {
                kt_tam_dung = true;
                btn_sapxep.Enabled = false;
                Play_or_Stop();
            }

        }
        
        // Hàm trễ một khoảng thời gian mili secondS
        public void wait_time(int milisecond)
        {
            Application.DoEvents();
            Thread.Sleep(milisecond);

        }

        // Hàm đổi giá trị của hai node
        public void swap_button(int t1, int t2)
        {

            Button Temp = node1[t1];
            node1[t1] = node1[t2];
            node1[t2] = Temp;
        }

        #endregion

        #region CÁC HÀM DI CHUYỂN
        // Hàm đổi chỗ hai nod
        public void swap_Node(Control node_a, Control node_b)
        {
            // Thời gian di chuyển tối đa là 1s
            // Nếu 2 node cách nhau >= 4 node thì di chuyển 4 lần 0.25s (lên, sang, sang, xuống)
            // Nếu 2 node cách nhau <=3 node thì chi chuyển 3 lần 0.25s (lên, sang, xuống)
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                Point pa = node_a.Location;  // Lưu vị trí hai node
                Point pb = node_b.Location;
                if(pa != pb)
                {
                    // Node_a lên, node_b xuống 100 đơn vị
                    if (node_a.Location.X < node_b.Location.X)
                    {
                        for(int j=0; j < 100; j++)
                        {
                            node_a.Top -= 1;
                            node_b.Top += 1;
                            wait_time(3*toc_Do);  // 250 / 100 = 2.5, làm tròn lên 3
                        }
                    }

                    // Node b lên, node a xuống
                    if (node_a.Location.X > node_b.Location.X)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            node_a.Top += 1;
                            node_b.Top -= 1;
                            wait_time(3*toc_Do);
                        }
                    }

                    // Node a qua phải, node b qua trái
                    if(node_a.Location.X < node_b.Location.X)
                    {
                        int dodai = node_b.Location.X - node_a.Location.X;  // Hai node cách nhau bao nhiêu độ dài
                        int step = dodai / (kich_Thuoc + khoang_Cach);      // Hai node cách nhau bao nhiêu ô
                        int ms =2;
                        if (step < 4) // Di chuyen 1 lan
                        {
                            ms = (300 / dodai);  // Thời gian wait time
                        }
                        else
                        {
                            ms = 500 / dodai;
                        }

                        for (int j = 0; j < dodai; j++)
                        {
                            node_a.Left += 1;
                            node_b.Left -= 1;
                            wait_time(ms*toc_Do);
                        }
                    }

                    // Node a qua trái, node b qua phải
                    //if (node_a.Location.X > node_b.Location.X)
                    else
                    {
                        int dodai = node_a.Location.X - node_b.Location.X;  // Hai node cách nhau bao nhiêu độ dài
                        int step = dodai / (kich_Thuoc + khoang_Cach);      // Hai node cách nhau bao nhiêu ô
                        int ms = 2;
                        if (step < 3) // Di chuyen 1 lan
                        {
                            ms = (300 / dodai);  // Thời gian wait time
                        }
                        else
                        {
                            ms = 600 / dodai;
                        }

                        for (int j = 0; j < dodai; j++)
                        {
                            node_a.Left -= 1;
                            node_b.Left += 1;
                            wait_time(ms*toc_Do);
                        }
                    }
                    
                    // Khu vực đưa các node về đến đích
                    // a xuống, b lên
                    if(node_b.Location.Y > pa.Y)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            node_a.Top += 1;
                            node_b.Top -= 1;
                            wait_time(3*toc_Do);
                        }
                    }

                     // a lên, b xuống
                    if (node_b.Location.Y < pa.Y)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            node_a.Top -= 1;
                            node_b.Top += 1;
                            wait_time(3*toc_Do);
                        }
                    }

                }
                wait_time(500 * toc_Do);
                set_node_color(node_a, Properties.Resources.img_simple);
                set_node_color(node_b, Properties.Resources.img_simple); // Swap xong cho màu về mặc định

            });
         }

        // Hàm node đi lên
        public void go_up(Control node, int vitri)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
           {
               //for(int j =0; i<5; )
               //node.Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * vitri, 100);
               for(int j =0; j < 100; j++)
               {
                   node.Top -= 1;  // Giảm trục Y của node, làm cho node đi lên trên
                   wait_time(5);   // Chờ 5 mili giây rồi tiếp tục thực hiện
               }
               node.Refresh();
           });
        }

        // Hàm node đi xuống
        public void go_down(Control node, int vitri)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                //for(int j =0; i<5; )
                //node.Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * vitri, 100);
                for (int j = 0; j < 100; j++)
                {
                    node.Top += 1;  // Giảm trục Y của node, làm cho node đi lên trên
                    wait_time(5);
                }
                node.Refresh();
            });
        }
        #endregion

        #region KHU VỰC HÀM SẮP XẾP

        // Quicksort theo chiều tăng cho một mảng
        public void quickSort(int[] a, int low, int high)
        {
            if (low >= high)
                return;
            else
            {
                int pivot = a[high];
                int right = high - 1;
                int left = low;
                while (true)
                {
                    while (a[left] < pivot && left <= right && left < so_phan_tu - 1) left++;
                    while (a[right] > pivot && right >= left && right >0) right--;
                    if (left >= right)
                        break;
                    swap(ref a[left], ref a[right]);
                    left++;
                    right--;
                }
                swap(ref a[left], ref a[high]);
                quickSort(a, low, left - 1);
                quickSort(a, left + 1, high);
            }
        }

        // Quicksort theo chiều giảm cho một mảng
        public void quickSort_giam(int[] a, int low, int high)
        {
            if (low >= high)
                return;
            else
            {
                int pivot = a[high];
                int right = high - 1;
                int left = low;
                while (true)
                {
                    while (a[left] > pivot && left <= right && left < so_phan_tu - 1) left++;
                    while (a[right] < pivot && right >= left && right > 0) right--;
                    if (left >= right)
                        break;
                    swap(ref a[left], ref a[right]);
                    left++;
                    right--;
                }
                swap(ref a[left], ref a[high]);
                quickSort(a, low, left - 1);
                quickSort(a, left + 1, high);
            }
        }
        // Hàm sắp xếp các node theo thuật toán quickSort tăng
        public void quickSort_Node_increase(int low, int high)
        {
            if (low >= high)
            {
                lbl_status.Text = "Status: return";
                return;
            }
                
            else
            {
                int pivot = a[high];
                lbl_pivot.Text = "pivot = a[" + high +"]";
                // Hiển thị pivot
                set_node_color(node1[high], Properties.Resources.img_pivot);    // Đổi màu nút pivot
                lb_list_code.SelectedIndex = 6;                                 // Cho code C nhảy đến dòng 6
                wait_time(1000*toc_Do);

                int left = low;
                lbl_left.Text = "left = a[" + left + "]";                       // Hiển thị left
                set_node_color(node1[left], Properties.Resources.img_done);   // Đổi màu left
                lb_list_code.SelectedIndex = 8;
                wait_time(1000 * toc_Do);

                int right = high - 1; 
                lbl_right.Text = "right = a[" + right + "]";                    // Hiển thị right
                set_node_color(node1[right], Properties.Resources.img_select);   // Đổi màu nút right
                lb_list_code.SelectedIndex = 7; 
                wait_time(1000*toc_Do);


                lbl_status.Text = "Status: phân hoạch a[" + left + "], a[" + right + "]";
                wait_time(1000 * toc_Do);


                while (true)
                {
                    while (a[left] < pivot && left <= right && left <so_phan_tu)
                    {
                        wait_time(1000);
                        left++;
                        lbl_status.Text = "Status: left++";
                        lbl_left.Text = "left = a[" + left + "]";
                        lb_list_code.SelectedIndex = 11;                                       // Cho code C nhảy đến dòng 11
                        set_node_color(node1[left-1], Properties.Resources.img_simple);// Xóa màu node left cũ
                        if(left<so_phan_tu)
                        set_node_color(node1[left], Properties.Resources.img_done);       // Tạo màu node left mới
                    }
                        

                    while (a[right] > pivot && right >= left && right >0)
                    {
                        wait_time(1000);
                        right--;
                        lbl_status.Text = "Status: right--";
                        lbl_right.Text = "right = a[" + right + "]";
                        lb_list_code.SelectedIndex = 12;
                        set_node_color(node1[right+1], Properties.Resources.img_simple);
                        if(right >=0)
                        set_node_color(node1[right], Properties.Resources.img_select);
                    }
                    if (left >= right)
                    {
                        lb_list_code.SelectedIndex = 14;
                        lbl_status.Text = "Status: break";
                        lbl_pivot.Text = "pivot = _ _";
                        lbl_right.Text = "right = _ _";
                        lbl_left.Text = "left = _ _";
                        set_node_color(node1[high], Properties.Resources.img_simple);
                        set_node_color(node1[left], Properties.Resources.img_simple);
                        set_node_color(node1[right], Properties.Resources.img_simple);
                        wait_time(1000*toc_Do);
                        break;
                    }

                    swap(ref a[left], ref a[right]);
                    lb_list_code.SelectedIndex = 24;
                    lbl_status.Text = "Status: swap(a[" + left + "], a[" + right + "]";
                    swap_Node(node1[left], node1[right]);
                    swap_button(left, right);
                    wait_time(1000 * toc_Do);

                    left++;
                    lb_list_code.SelectedIndex = 16;
                    lbl_status.Text = "Status: left++";
                    lbl_left.Text = "left = a[" + left + "]";
                    set_node_color(node1[left - 1], Properties.Resources.img_simple);      // Xóa màu node left cũ
                    if(left < so_phan_tu)
                        set_node_color(node1[left], Properties.Resources.img_done);           // Gán màu node left mới
                    wait_time(1000 * toc_Do);

                    right--;
                    lb_list_code.SelectedIndex = 17;
                    lbl_status.Text = "Status: right--";
                    lbl_right.Text = "right = a[" + right + "]";
                    if(right >=0)
                        set_node_color(node1[right], Properties.Resources.img_select);    // Gán màu node right mới
                    set_node_color(node1[right + 1], Properties.Resources.img_simple);    // Xóa màu node right
                    wait_time(1000 * toc_Do);

                }

                swap(ref a[left], ref a[high]);
                lb_list_code.SelectedIndex = 24;
                lbl_status.Text = "Status: swap(a[" + left + "], a[" + high + "])";
                swap_Node(node1[left], node1[high]);
                wait_time(1000 * toc_Do);
                swap_button(left, high);
                set_node_color(node1[high], Properties.Resources.img_simple);
                set_node_color(node1[left], Properties.Resources.img_simple);
                set_node_color(node1[right], Properties.Resources.img_simple);
                wait_time(1000*toc_Do);

                quickSort_Node_increase(low, left - 1);
                wait_time(1000 * toc_Do);
                quickSort_Node_increase(left + 1, high);
            }

            //quickSort(a, 0, so_phan_tu - 1);
        }
        
        public void quickSort_Node_decrease()
        {

        }
        #endregion

        public void complete()
        {
            for(int i =0; i < so_phan_tu; i++)
            {
                set_node_color(node1[i], Properties.Resources.img_done);
            }
            lbl_right.Visible = false;
            lbl_left.Visible = false;
            lbl_pivot.Visible = false;

        }
        #region TÍNH NĂNG SẮP XẾP CLICK
        private void btn_sapxep_Click(object sender, EventArgs e)
        {

            if (da_Tao_GT)
            {

                //Thread t = new Thread(() => { go_up(node1[0], 0); });
                //t.IsBackground = true;
                //t.Start();

                //Application.DoEvents();
                //this.Invoke((MethodInvoker)delegate
                //{
                //    go_up(node1[0], 0);
                //});
                lbl_status.Visible = true;
                lbl_left.Visible = true;
                lbl_pivot.Visible = true;
                lbl_right.Visible = true;
                quickSort_Node_increase(0, so_phan_tu - 1);
                lbl_status.Text = "Status: Đã sắp xếp xong";
                complete();
            }

        }
        #endregion

        private void btn_break_Click(object sender, EventArgs e)
        {
                quickSort(a, 0, so_phan_tu - 1);
                
                tao_Mang(150, Properties.Resources.img_done);
        }

        private void btn_sapxep_Click_1(object sender, EventArgs e)
        {
            btn_sapxep.Image = Properties.Resources.img_pause;
            quickSort_Node_increase(0, so_phan_tu -1);

        }
    }
}