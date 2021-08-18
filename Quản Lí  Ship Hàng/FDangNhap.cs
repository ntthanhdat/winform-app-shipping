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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.TextLength == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản");
            }
            else
            {
                if (this.textBox2.TextLength == 0)
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                }
                else
                {
                    Fmain main = new Fmain();
                    if (dn.KiemTraTK(this.textBox1.Text, this.textBox2.Text) != "")
                    {
                        if (dn.KiemTraTK(this.textBox1.Text, this.textBox2.Text) == "admin")
                        {
                            MessageBox.Show("Bạn đã đăng nhập thành công với quyền admin");
                            main.Show();
                            
                        }
                        if (dn.KiemTraTK(this.textBox1.Text, this.textBox2.Text) == "user")
                        {
                            MessageBox.Show("Bạn đã đăng nhập thành công");
                            //main.EnabledMenu();
                            main.DisAdminEnabledMenu();
                            main.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên tài khoản và mật khẩu!");
                        return;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }

   
}
