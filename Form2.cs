using Pertemuan10.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan10
{
    public partial class Form2 : Form
    {
        private BarangController brgcontroller;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            brgcontroller = new BarangController();
            brgcontroller.tambahBarang(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            this.Controls.Clear();
            this.InitializeComponent();
            textBox1.Focus();
            MessageBox.Show("data disimpan");
            Form1 lk = new Form1();

            lk.Show();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Contiue or not", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.No)
                Application.Exit();
            Form1 cl = new Form1();
            cl.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 11;
            textBox2.MaxLength = 25;
            textBox3.MaxLength = 11;
            textBox4.MaxLength = 11;
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
    }
}