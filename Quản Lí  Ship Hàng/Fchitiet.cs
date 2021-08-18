using BussinessLogic;
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
    public partial class Fchitiet : Form
    {
        chitiet ct = new chitiet();
       
        private void hienthi_hd()
        {
            DataTable dt = new DataTable();
            dt = ct.ShowChiTiet();
            dataGridView1.DataSource = dt;
        }
            public Fchitiet()
            {
                InitializeComponent();
            }

            private void button1_Click(object sender, EventArgs e)
            {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đơn hàng");
            }
            else
            {
              //  try
              //  {
                    ct.InsertChiTiet(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text);
                    MessageBox.Show("Bạn thêm thành công");
                    hienthi_hd();
               // }
              //  catch
           // {
          //      MessageBox.Show("lỗi thêm dữ liệu");
          //  }
        }
        }

            private void Fchitiet_Load(object sender, EventArgs e)
            {
                hienthi_hd();
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đơn hàng");
            }
            else
            {
                try
                {
                    ct.UpdateChiTiet(this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox1.Text);
                    MessageBox.Show("Bạn sửa thành công");
                    hienthi_hd();
                }
                catch
                {
                    MessageBox.Show("Lỗi sửa " + this.textBox1.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đơn hàng");
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    try
                    {
                        ct.XoaChiTiet(this.textBox1.Text);
                        MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + "thành công");
                        hienthi_hd();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi xóa");
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.textBox6.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
               // try
                //{
                    if (comboBox1.Text == "Mã đơn hàng")
                    {
                        DataTable dt = new DataTable();
                        dt = ct.ShowTim(this.textBox6.Text);
                        dataGridView1.DataSource = dt;
                    }
                    if (comboBox1.Text == "Mã hàng")
                    {
                        DataTable dt = new DataTable();
                        dt = ct.ShowTim1(this.textBox6.Text);
                        dataGridView1.DataSource = dt;
                    }
                //}
               // catch
               // {
                //    MessageBox.Show("Lỗi tìm");
               // }
            }
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }

