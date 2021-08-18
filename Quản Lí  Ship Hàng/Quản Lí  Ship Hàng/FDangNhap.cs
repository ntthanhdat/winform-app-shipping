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
    public partial class Fdangnhap : Form
    {

        login dn = new login();
        public Fdangnhap()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        { 
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
                textBox1.Focus();
            }
            else
            {
                if (this.textBox2.TextLength == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                    textBox2.Focus();
                }
                else
                {
                    Fmain main = new Fmain();
                    if (dn.KiemTraTK(this.textBox1.Text, this.textBox2.Text) != "")
                    {
                        if (dn.KiemTraTK(this.textBox1.Text, this.textBox2.Text) == "admin")
                        {
                            MessageBox.Show("Bạn đã đăng nhập thành công với quyền admin","Đăng nhập thành công");
                            main.ShowDialog();
                            

                        }
                        if (dn.KiemTraTK(this.textBox1.Text, this.textBox2.Text) == "user")
                        {
                            MessageBox.Show("Bạn đã đăng nhập thành công","Đăng nhập thành công");
                            
                            //main.dissadmin1();
                            main.DisAdminEnabledMenu();
                            main.ShowDialog();
                            //main.DisAdminEnabledMenu();
                        }
                        if(dn.KiemTraTK(this.textBox1.Text, this.textBox2.Text) == null)
                        {
                            MessageBox.Show("Đăng nhập hệ thống không thành công");
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên tài khoản và mật khẩu!");
                        return;
                    }
                }
            }
                //*/
            //Fmain main = new Fmain();
            //main.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Bạn Có Muốn Thoát Khỏi Chương Trình Không","Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning))
            {
                Application.Exit();
            }                
        }

        private void Fdangnhap_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }

   
}
