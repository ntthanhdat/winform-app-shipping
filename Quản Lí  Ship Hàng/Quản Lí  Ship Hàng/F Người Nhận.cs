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
    public partial class Fnguoinhan : Form
    {
        nguoinhan NN = new nguoinhan();
        Data da = new Data();
        public Fnguoinhan()
        {
            InitializeComponent();
        }
        private void hienthi_Kh()
        {
            DataTable dt = new DataTable();
            dt = NN.ShowKh();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Fnguoinhan_Load(object sender, EventArgs e)
        {
            hienthi_Kh();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = da.xuly("select * from NguoiNhan where maNN = '" + textBox1.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã người nhận bị trùng");
                }
                else
                {
                    try
                    {
                        NN.InsertKh(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
                        MessageBox.Show("Bạn thêm thành công");
                        Fnguoinhan_Load(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi thêm " + this.textBox1.Text);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng cần sửa");
            }
            else
            {
                NN.UpdateKh(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
                MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + " thành công");
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                Fnguoinhan_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã khách hàng cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    NN.XoaKh(this.textBox1.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + " thành công");
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    this.textBox3.Clear();
                    this.textBox4.Clear();
                    this.textBox5.Clear();
                    Fnguoinhan_Load(sender, e);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.textBox5.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = NN.ShowKh1(this.textBox5.Text);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            Fnguoinhan_Load(sender, e);
        }
    }
}
