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
    public partial class Fdonhang : Form
    {
        donhang nv = new donhang ();
        Data da = new Data();
        public Fdonhang()
        {
            InitializeComponent();
        }
        private void hienthi_dh()
        {
            DataTable dt = new DataTable();
            dt = nv.ShowDh();
            dataGridView1.DataSource = dt;

        }
        private void Fdonhang_Load(object sender, EventArgs e)
        {
            hienthi_dh();
            this.textBox1.Clear();
            this.textBox2.Clear();
            this.textBox3.Clear();
            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Fchitiet  f = new Fchitiet();
            f.Show();
            
        }


        private void buttonthem_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = da.xuly("select * from NhanVien where maNV = '" + textBox1.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Trùng Mã nhân viên");
                    textBox1.Focus();
                }
                else
                {
                    try
                    {
                        nv.InsertDh(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, dateTimePicker1.Value.Date.ToShortDateString(), dateTimePicker2.Value.Date.ToShortDateString(), this.textBox5.Text);
                        MessageBox.Show("Bạn thêm thành công");
                        Fdonhang_Load(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi nhập dữ liệu");
                    }
                }

            }
        }

        private void buttonsua_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã đơn hàng cần sửa");
            }
            else
            {
                try
                {
                    nv.UpdateHd(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, dateTimePicker1.Value.Date.ToShortDateString(), dateTimePicker2.Value.Date.ToShortDateString(), this.textBox5.Text);
                    MessageBox.Show("Bạn đã sửa " + this.textBox1.Text + " thành công");
                    Fdonhang_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Lỗi nhập dữ liệu");
                }
            }
        }

        private void buttonxoa_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên cần xóa");
            }
            else
            {

                if (DialogResult.OK == MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel))
                {
                    nv.XoaHd(this.textBox1.Text);
                    MessageBox.Show("Bạn đã xóa " + this.textBox1.Text + " thành công");
                    Fdonhang_Load(sender, e);
                }
            }
        }

        private void buttontim_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm");
            }
            else
            {
                switch (comboBox1.SelectedItem)
                {
                    case "Mã đơn hàng":
                        DataTable dt = new DataTable();
                        dt = nv.ShowHd1(this.textBox6.Text);
                        dataGridView1.DataSource = dt;
                        break;
                    case "Mã khách hàng":
                        DataTable dt2 = new DataTable();
                        dt2 = nv.ShowHd2(this.textBox6.Text);
                        dataGridView1.DataSource = dt2;
                        break;
                    case "Mã nhân viên":
                        DataTable dt3 = new DataTable();
                        dt3 = nv.ShowHd3(this.textBox6.Text);
                        dataGridView1.DataSource = dt3;
                        break;
                    case "Mã dịch vụ":
                        DataTable dt4 = new DataTable();
                        dt4 = nv.ShowHd4(this.textBox6.Text);
                        dataGridView1.DataSource = dt4;
                        break;
                    case "Trạng thái":
                        DataTable dt5 = new DataTable();
                        dt5 = nv.ShowHd5(this.textBox6.Text);
                        dataGridView1.DataSource = dt5;
                        break;
                    
                    default:
                        break;
                }

            }
        }

        private void buttonrefresh_Click(object sender, EventArgs e)
        {
            Fdonhang_Load(sender, e);
        }

        private void buttonmk_Click(object sender, EventArgs e)
        {
            Fnguoinhan f = new Fnguoinhan();
            f.ShowDialog();
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
