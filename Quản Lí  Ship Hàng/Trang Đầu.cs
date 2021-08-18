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
    public partial class Fmain : Form
    {
         public void EnabledMenu()
        {
            quảnLíTàiKhoảnToolStripMenuItem.Enabled = true;
            nhânViênToolStripMenuItem.Enabled = true;
            dịchVụToolStripMenuItem.Enabled = true;
            kháchHàngToolStripMenuItem.Enabled = true;
            đơnHàngToolStripMenuItem.Enabled = true ;
            mặtHàngToolStripMenuItem.Enabled = true;
        }
        public void DisEnabledMenu()
        {
            quảnLíTàiKhoảnToolStripMenuItem.Enabled = false;
            nhânViênToolStripMenuItem.Enabled = false;
            dịchVụToolStripMenuItem.Enabled = false;
            kháchHàngToolStripMenuItem.Enabled = false;
            đơnHàngToolStripMenuItem.Enabled = false;
            mặtHàngToolStripMenuItem.Enabled = false;
        }
        public void AdminEnabledMenu()
        {
            quảnLíTàiKhoảnToolStripMenuItem.Enabled = true;
            nhânViênToolStripMenuItem.Enabled = true;
        }
        public void DisAdminEnabledMenu()
        {
            quảnLíTàiKhoảnToolStripMenuItem.Enabled = false ;
            nhânViênToolStripMenuItem.Enabled = false;
        }

        public Fmain()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void heThongToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quảnLíTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Ftaikhoan t4 = new Ftaikhoan();
            t4.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK == MessageBox.Show("Bạn có muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                Fdangnhap d = new Fdangnhap();
                d.Show();
                this.Close();



            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Xác nhận thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                Application.Exit();
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fnhanvien nv = new Fnhanvien();
            nv.Show();
        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fdonhang dh = new Fdonhang();
            dh.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fnguoinhan kh = new Fnguoinhan();
            kh.Show();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fmathang f = new Fmathang();
            f.Show();
        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fdichvu f = new Fdichvu();
            f.Show();
        }

        private void mặtHàngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Fmathang f = new Fmathang();
            f.Show();
            
        }

        private void Fmain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
