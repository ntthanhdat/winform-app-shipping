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
    public partial class Fnhanvien : Form
    {
        nhanvien nv = new nhanvien();
        Data da = new Data();
       
        public Fnhanvien()
        {
            InitializeComponent();
        }

        private void hienthi_nv()
        {
            DataTable dt = new DataTable();
            dt = nv.ShowNv();
            dataGridView1.DataSource = dt;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Fnhanvien_Load(object sender, EventArgs e)
        {
            hienthi_nv();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần sửa");
            }
            else
            {
                nv.UpdateNv(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox5.Text, this.textBox6.Text);
                MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + "thành công");
                this.textBox1.Clear();
                this.textBox2.Clear();
                this.textBox3.Clear();
                this.textBox4.Clear();
                this.textBox5.Clear();
                this.textBox6.Clear();
                Fnhanvien_Load(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = da.xuly("select * from NhanVien where sdt = '" + textBox5.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Sdt trung");
                }
                else
                {
                    nv.InsertNv(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.textBox5.Text, this.textBox6.Text);
                    MessageBox.Show("Bạn thêm thành công");
                    Fnhanvien_Load(sender, e);
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    nv.Xoanv(this.textBox1.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + "thành công");
                    this.textBox1.Clear();
                    this.textBox2.Clear();
                    this.textBox3.Clear();
                    this.textBox4.Clear();
                    this.textBox5.Clear();
                    this.textBox6.Clear();
                    Fnhanvien_Load(sender, e);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (this.textBox6.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = nv.ShowNv1(this.textBox7.Text);
                dataGridView1.DataSource = dt;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();
            Fnhanvien_Load(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();

            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();

        }        

        private void Fnhanvien_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
