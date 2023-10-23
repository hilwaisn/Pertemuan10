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
    public partial class Form3 : Form
    {
        private BarangController brgcontroller;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
         private void btnSave_Click(object sender, EventArgs e)
         {
            brgcontroller = new BarangController();
            brgcontroller.updateBarang(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            this.Controls.Clear();
            this.InitializeComponent();
            textBox2.Focus();
            MessageBox.Show("data di update");
            Form1 lk = new Form1();
            lk.Show();
            this.Hide();
         }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Contiue or not", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.No)
                Application.Exit();
            Form1 cl = new Form1();
            cl.Show();
            this.Hide();
        }
    }
}
