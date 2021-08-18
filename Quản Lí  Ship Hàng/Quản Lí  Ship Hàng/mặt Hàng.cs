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
    public partial class Fmathang : Form
    {
        Data da = new Data();
        mathang MH = new mathang();
        public Fmathang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.textBox5.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = MH.ShowMH1(this.textBox5.Text);
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã mặt hàng");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = da.xuly("select * from MatHang where mahang = '" + textBox1.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Đã trùng mã hàng");
                }
                else
                {
                    try
                    {
                        MH.InsertMh(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, int.Parse(this.textBox4.Text),textBox6.Text);
                        MessageBox.Show("Bạn thêm thành công");
                        Fmathang_Load(sender, e);
                    }
                    catch(FormatException)
                    {
                        MessageBox.Show("Lỗi thêm dữ liệu");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã mặt hàng cấp cần sửa");
            }
            else
            {
                MH.UpdateMh(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox1.Text);
                MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + "thành công");
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                Fmathang_Load(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã mặt hàng cấp cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    MH.XoaMh(textBox5.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + "thành công");
                    
                    Fmathang_Load(sender, e);
                }
            }
        }

        private void hienthi_mh()
        {

            DataTable dt = new DataTable();
            dt = MH.ShowMH();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fmathang_Load(object sender, EventArgs e)
        {
            hienthi_mh();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;          
            this.textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            this.textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
