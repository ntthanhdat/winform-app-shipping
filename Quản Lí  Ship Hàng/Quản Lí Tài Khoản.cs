using BussinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí__Ship_Hàng
{
    public partial class Ftaikhoan : Form
    {
        taikhoann tk = new taikhoann();
        Data da = new Data();
        public Ftaikhoan()
        {
            InitializeComponent();
        }

      
        private void hienthi_Tk()
        {

            DataTable dt = new DataTable();
            dt = tk.ShowTK();
            dataGridView1.DataSource = dt;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn cần nhập tên tài khoản");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = da.xuly("select * from TaiKhoan where username = '" + textBox1.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Ten tai khoan da co");
                }
                else
                {
                   try
                    {
                        tk.InsertTK(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                        MessageBox.Show("Bạn thêm thành công");
                        Ftaikhoan_Load(sender, e);
                    }
                   catch
                    {
                        MessageBox.Show("Lỗi thêm " + this.textBox1.Text);
                    }
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ftaikhoan_Load(object sender, EventArgs e)
        {
            hienthi_Tk();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập username cần sửa");
            }
            else
            {
                tk.UpdateTK(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text,this.textBox1.Text);
                MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + "thành công");
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                Ftaikhoan_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập username cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    tk.XoaTK(this.textBox1.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + "thành công");
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    this.textBox3.Clear();
                    Ftaikhoan_Load(sender, e);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            this.textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (this.textBox4.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = tk.ShowTK1(this.textBox4.Text);
                dataGridView1.DataSource = dt;
            }
        }
    }
}

