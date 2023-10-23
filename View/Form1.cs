using MySqlConnector;
using Pertemuan10.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan10
{
    public partial class Form1 : Form
    {
        private BarangController brgcontroller;
        public Form1()
        {
            brgcontroller = new BarangController();
            InitializeComponent();
        }
        bool verify()
        {
            if ((txtDelete1.Text == "") || (txtDelete2.Text == "") || (txtDelete3.Text == "") || (txtDelete4.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            showTable();
        }
        /*public void segarkan()
        {
            dataGridView1.DataSource = brgcontroller.tampilBarang();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDelete1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtDelete2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDelete3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDelete4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Form3 upd = new Form3();
            upd.Show();
            this.Hide();

            upd.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            upd.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            upd.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            upd.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {
                    brgcontroller.hapusbarang(txtDelete1.Text);
                    showTable();
                    btnClear.PerformClick();
                    MessageBox.Show("Teacher Deleted succesfully", "Delete Teacher",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDelete1.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error-Barang not delete", "Delete Barang",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void showTable()
        {
            dataGridView1.DataSource = brgcontroller.selectBarang(new MySqlCommand("SELECT * FROM barang"));
            dataGridView1.RowTemplate.Height = 80;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDelete1.Clear();
            txtDelete2.Clear();
            txtDelete3.Clear();
            txtDelete4.Clear();

        }
    }
}