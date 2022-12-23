using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            listView1.Columns.Add("Stt", 120);
            listView1.Columns.Add("Mã Vé", 120);
            listView1.Columns.Add("Nơi Đi", 120);
            listView1.HideSelection = false;
            listView1.Columns.Add("Nơi Đến", 120);
        }



        public string generateTicketCode()
            
        {
            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            return r.ToString();
        }

        private void AddBtn_Click(object sender, EventArgs e)
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
            ticket.price = label_price.Text;
            tickets.Add(ticket);

            number++;

            string[] row = { number.ToString(), ticket.mave, noiDi,noiDen };
            var listViewItem = new ListViewItem(row);
            listView1.Items.Add(listViewItem);
        }

        public int findTicketWithId()
        {
            return 0;
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
                price = soGheNgoi * 250000;
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                string ticketCode = listView1.SelectedItems[0].SubItems[1].Text;
                MessageBox.Show(ticketCode);
                

                //do something
                //MessageBox.Show(listView1.Items[intselectedindex].Text); 
            }
        }

        private void findAndUpdate()
        {

        }

        public void FileterRecordByTicketCode()
        {
            String txt_Search = ticketCode;
            if (txt_Search != "")
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    var item = listView1.Items[i];
                    try
                    {
                        if (item.SubItems[1].Text == txt_Search)
                        {
                            item.BackColor = SystemColors.Highlight;
                            item.ForeColor = SystemColors.HighlightText;

                        }
                        else
                        {

                            listView1.Items.Remove(item);

                        }
                    }
                    catch
                    {

                    }

                }
                if (listView1.SelectedItems.Count == 1)
                {
                    listView1.Focus();
                }
            }
        }

        public void DeleteItem()
        {
            String txt_Search = ticketCode;
            if (txt_Search != "")
            {
                for (int i = listView1.Items.Count - 1; i >= 0; i--)
                {
                    var item = listView1.Items[i];
                    try
                    {
                        if (item.SubItems[1].Text == txt_Search)
                        {

                            listView1.Items.Remove(item);

                        }
                        else
                        {

                        }
                    }
                    catch
                    {

                    }

                }
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Ticket findTicket = tickets.Find(x => x.mave.Contains(ticketCode));
            if (findTicket != null)
            {
                this.textBox1_hoten.Text = findTicket.name;
                this.textBox2_cccd.Text = findTicket.cccd;
                this.textBox3_adress.Text = findTicket.address;
                this.label_price.Text = findTicket.price;
                //this.dateTimePicker1_dob.Value = findTicket.dob;
                this.textBox4_ticketcode.Text = findTicket.mave;
                this.comboBox2_gadi.Text = findTicket.gadi;
                this.comboBox3_gaden.Text = findTicket.gaden;
            }
            else
            {
                MessageBox.Show("Mã Vé Không Tồn Tại");
            }
            DeleteItem();


        }
    

        private void textBox4_ticketcode_TextChanged(object sender, EventArgs e)
        {
            ticketCode = textBox4_ticketcode.Text;
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            Ticket findTicket = tickets.Find(x => x.mave.Contains(ticketCode));
            if (findTicket != null)
            {
                this.textBox1_hoten.Text = findTicket.name;
                this.textBox2_cccd.Text = findTicket.cccd;
                this.textBox3_adress.Text = findTicket.address;
                this.label_price.Text = findTicket.price;
                //this.dateTimePicker1_dob.Value = findTicket.dob;
                this.textBox4_ticketcode.Text = findTicket.mave;
                this.comboBox2_gadi.Text = findTicket.gadi;
                this.comboBox3_gaden.Text = findTicket.gaden;
                FileterRecordByTicketCode();
            }
            else
            {
                MessageBox.Show("Mã Vé Không Tồn Tại");
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Ticket findTicket = tickets.Find(x => x.mave.Contains(ticketCode));
            if (findTicket != null)
            {
                this.textBox1_hoten.Text = findTicket.name;
                this.textBox2_cccd.Text = findTicket.cccd;
                this.textBox3_adress.Text = findTicket.address;
                this.label_price.Text = findTicket.price;
                //this.dateTimePicker1_dob.Value = findTicket.dob;
                this.textBox4_ticketcode.Text = findTicket.mave;
                this.comboBox2_gadi.Text = findTicket.gadi;
                this.comboBox3_gaden.Text = findTicket.gaden;
                FileterRecordByTicketCode();
            }
            else
            {
                MessageBox.Show("Mã Vé Không Tồn Tại");
            }
        }
    }
}
