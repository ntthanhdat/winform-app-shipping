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
    public partial class Fdichvu : Form
    {
        dichvu dv = new dichvu();
        Data da = new Data();
        public Fdichvu()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void hienthi_dv()
        {

            DataTable dt = new DataTable();
            dt = dv.ShowDV();
            dataGridView1.DataSource = dt;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            this.textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();


        }

        private void Fdichvu_Load(object sender, EventArgs e)
        {
            hienthi_dv();
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
                dt = da.xuly("select * from dichvu where tenDV = '" + textBox2.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Dịch vụ đã có");
                }
                else
                {
                    try
                    {
                        dv.InsertDv(this.textBox1.Text, this.textBox2.Text, textBox3.Text);
                        MessageBox.Show("Bạn thêm thành công");
                        hienthi_dv();
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
                MessageBox.Show("Bạn chưa nhập mã dịch vụ cần sửa");
            }
            else
            {
                dv.UpdateDv(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);
                MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + "thành công");
                hienthi_dv();
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
                    dv.XoaDV(textBox1.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + "thành công");
                    hienthi_dv();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
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
                dt = dv.ShowDV1(this.textBox4.Text);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
