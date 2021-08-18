using BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_Lí__Ship_Hàng
{
    public partial class Fdonhang : Form
    {
        donhang dh = new donhang();

        public Fdonhang()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Fchitiet f = new Fchitiet();
            f.Show();
        }

        private void hienthi_dh()
        {
            DataTable dt = new DataTable();
            dt = dh.ShowDh();
            dataGridView1.DataSource = dt;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            txbTim.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0)
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu");
            }
            else
            {
                //try
               // {
                    //dh.InsertDh(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.dateTimePicker1.Value.Date.ToShortDateString(), this.dateTimePicker2.Value.Date.ToShortDateString(), this.textBox5.Text);
                    //MessageBox.Show("Bạn thêm thành công");
                    //hienthi_dh();
                // }
                // catch
                //{
                //    MessageBox.Show("Lỗi thêm");
                // }


                //try
                // {
                dh.UpdateHd(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.dateTimePicker1.Value.ToShortDateString(), this.dateTimePicker2.Value.ToShortDateString(), this.textBox5.Text);
                MessageBox.Show("Bạn sửa thành công");
                hienthi_dh();
                // }
                // catch
                // {
                // MessageBox.Show("Lỗi sửa");
                // }

            }
        }

        private void Fdonhang_Load(object sender, EventArgs e)
        {
            hienthi_dh();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0)
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu");
            }
            else
            {
                //try
               // {
                    dh.UpdateHd(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.dateTimePicker1.Value.ToShortDateString(), this.dateTimePicker2.Value.ToShortDateString(), this.textBox5.Text);
                    MessageBox.Show("Bạn sửa thành công");
                    hienthi_dh();
               // }
               // catch
               // {
                   // MessageBox.Show("Lỗi sửa");
               // }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    try
                    {
                        dh.XoaHd(this.textBox1.Text);
                        MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + "thành công");
                        hienthi_dh();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi xóa");
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Fmain main = new Fmain();
            this.Close();
            main.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.txbTim.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
               // try
                //{
                    if (cbbSearch.Text == "Mã đơn hàng")
                    {
                        DataTable dt = new DataTable();
                        dt = dh.ShowHd1(this.txbTim.Text);
                        dataGridView1.DataSource = dt;
                    }
                    if (cbbSearch.Text == "Mã khách hàng")
                    {
                        DataTable dt = new DataTable();
                        dt = dh.ShowHd2(this.txbTim.Text);
                        dataGridView1.DataSource = dt;
                    }
                    if (cbbSearch.Text == "Mã nhân viên")
                    {
                        DataTable dt = new DataTable();
                        dt = dh.ShowHd3(this.txbTim.Text);
                        dataGridView1.DataSource = dt;
                    }
                    if (cbbSearch.Text == "Dịch vụ")
                    {
                        DataTable dt = new DataTable();
                        dt = dh.ShowHd4(this.txbTim.Text);
                        dataGridView1.DataSource = dt;
                    }
                    if (cbbSearch.Text == "Trạng thái")
                    {
                        DataTable dt = new DataTable();
                        dt = dh.ShowHd5(this.txbTim.Text);
                        dataGridView1.DataSource = dt;
                    }
               // }
               // catch
               // {
                 //   MessageBox.Show("Lỗi tìm");
               // }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
              textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            txbTim.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();


        }

        private void cbbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
    }
}
