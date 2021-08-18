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
    public partial class Fdichvu : Form
    {
        dichvu nv = new dichvu();
        Data da = new Data();
        public Fdichvu()
        {
            InitializeComponent();
        }
        private void hienthi_dv()
        {
            DataTable dt = new DataTable();
            dt = nv.ShowDV();
            dataGridView1.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã dịch vụ");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = da.xuly("select * from Dichvu where maDV = '" + textBox1.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Trùng Mã dịch vụ");
                    textBox1.Focus();
                }
                else
                {
                    try
                    {
                        nv.InsertDV(this.textBox1.Text, this.textBox2.Text, float.Parse(this.textBox3.Text));
                        MessageBox.Show("Bạn thêm thành công");
                        Fdichvu_Load(sender, e);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Nhập sai kiểu dữ liệu", "LỖI");
                    }
                }

            }
        }

        private void Fdichvu_Load(object sender, EventArgs e)
        {
            hienthi_dv();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox5.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã dịch vụ cần sửa");
            }
            else
            {
                try
                {
                    nv.UpdateDV(this.textBox1.Text, this.textBox2.Text, float.Parse(this.textBox3.Text));
                    MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + "thành công");
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    this.textBox3.Clear();

                    Fdichvu_Load(sender, e);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Nhập sai kiểu dữ liệu", "LỖI");
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi", "LỖI");
                }

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã dịch vụ cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    nv.XoaDV(this.textBox1.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + "thành công");
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    this.textBox3.Clear();
                    Fdichvu_Load(sender, e);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();

        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã dịch vụ cần tìm");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = nv.ShowDV1(this.textBox5.Text);
                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fmain main = new Fmain();
            main.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            
            this.textBox5.Clear();
            
            Fdichvu_Load(sender, e);
        }
    }
}
