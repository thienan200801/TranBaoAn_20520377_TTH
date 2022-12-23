using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranBaoAn_20520377_TTH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != null && textBox2.Text.Trim() != null)
            {
                if (textBox1.Text == "admin" || textBox2.Text == "admin")
                {
                    DangNhap f = new DangNhap();
                    f.ShowDialog();
                }
                else MessageBox.Show("Đăng nhập thất bại");
            }
            else MessageBox.Show("Sai định dạng");
        }
    }
}
