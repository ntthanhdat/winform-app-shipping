using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLogic;
using DataAccess;

namespace Quản_Lí__Ship_Hàng
{
    public partial class Fchitiet : Form
    {

        chitiet nv = new chitiet();
        Data da = new Data();
        public Fchitiet()
        {
            InitializeComponent();
        } 
        private void hienthi_ct()
        {
            DataTable dt = new DataTable();
            dt = nv.ShowChiTiet();
            dataGridView1.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đơn hàng");
            }
            else
            {
                //DataTable dt = new DataTable();
                //dt = da.xuly("select * from ChiTietDonHang where maHD = '" + textBox1.Text + "'");
                //if (dt.Rows.Count > 0)
                //{
                //    MessageBox.Show("Trùng Mã đơn hàng");
                //    textBox1.Focus();
                //}
                
                
                    nv.InsertChiTiet(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
                    MessageBox.Show("Bạn thêm thành công");
                    Fchitiet_Load(sender, e);
                

            }
        }

        private void Fchitiet_Load(object sender, EventArgs e)
        {
            hienthi_ct();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
                switch (comboBox1.SelectedItem)
                {
                    case "Mã đơn hàng":
                        DataTable dt = new DataTable();
                        dt = nv.ShowTim(this.textBox6.Text);
                        dataGridView1.DataSource = dt;
                        break;
                    case "Mã hàng":
                        DataTable dt2 = new DataTable();
                        dt2 = nv.ShowTim1(this.textBox6.Text);
                        dataGridView1.DataSource = dt2;
                        break;
                    
                    default:
                        break;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đơn hàng cần sửa");
            }
            else
            {
                nv.UpdateChiTiet(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
                MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + " thành công");

                Fchitiet_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đơn hàng cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    nv.XoaChiTiet(this.textBox1.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + " thành công");

                    Fchitiet_Load(sender, e);
                }
            }
        }
    }
}
