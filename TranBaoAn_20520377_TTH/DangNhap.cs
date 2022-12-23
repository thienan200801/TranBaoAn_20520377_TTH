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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0)
            {
                label11.Text = (Int32.Parse(comboBox4.Items[comboBox1.SelectedIndex].ToString()) * 300000).ToString();
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                label11.Text = (Int32.Parse(comboBox4.Items[comboBox1.SelectedIndex].ToString()) * 250000).ToString();
            }
        }
    }
}
