using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TranBaoAn_20520377_TTH
{
    public partial class DangNhap : Form
    {
        String name;
        String cccd;
        DateTime dob;
        Boolean men;
        Boolean women;
        String address;
        String ticketCode;
        String noiDen;
        String noiDi;
        int soGheNgoi;
        int number = 0;
        int price;

        List<Ticket> tickets = new List<Ticket>();


        public DangNhap()
        {
            InitializeComponent();
        }

        public void getInputAndCreateTicket()
        {
            Ticket ticket = new Ticket();
            ticket.name = name;
            ticket.address = address;
            ticket.gaden = noiDen;
            ticket.gadi = noiDi;
            ticket.soghengoi = soGheNgoi;
            ticket.dob = dob;
            ticket.cccd = cccd;
            ticket.mave = generateTicketCode();
            tickets.Add(ticket);

        }

        public string generateTicketCode()
            
        {
            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            return r.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            number++;
            ticketCode = generateTicketCode();

            string[] row = { number.ToString(), ticketCode, noiDi,noiDen };
            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);
        }

        

        private void textBox1_hoten_TextChanged(object sender, EventArgs e)
        {
            name = this.textBox1_hoten.Text;
        }

        private void textBox2_cccd_TextChanged(object sender, EventArgs e)
        {
            cccd = this.textBox2_cccd.Text;
        }

        private void dateTimePicker1_dob_ValueChanged(object sender, EventArgs e)
        {
            dob = this.dateTimePicker1_dob.Value;
        }

        private void radioButton1_men_CheckedChanged(object sender, EventArgs e)
        {
            men = this.radioButton1_men.Checked;
            women = !men;
            this.radioButton2_woman.Checked = women;
        }

        private void radioButton2_woman_CheckedChanged(object sender, EventArgs e)
        {
            women = this.radioButton2_woman.Checked;
            men = !women;
            this.radioButton2_woman.Checked = women;
        }

        private void tinhGiaVe()
        {
            
            if (noiDi=="Hồ Chí Minh")
            {
                price = soGheNgoi * 300000;
            }
            if (noiDi=="Biên Hoà")
            {
                price = soGheNgoi * 25000;
            }
            this.label_price.Text = price.ToString();
        }
        private void comboBox4_soghengoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            soGheNgoi = Int32.Parse(comboBox4_soghengoi.Text);
            tinhGiaVe();
        }

        private void comboBox2_gadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            noiDi = this.comboBox2_gadi.Text;
            tinhGiaVe();
        }

        private void comboBox3_gaden_SelectedIndexChanged(object sender, EventArgs e)
        {
            noiDen = this.comboBox3_gaden.Text;
        }
    }
}
