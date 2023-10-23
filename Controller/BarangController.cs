using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pertemuan10.Controller
{
    internal class BarangController:Model.Connection
    {
        public DataTable tampilBarang()
        {
            DataTable data = new DataTable();
            try
            {
                string tampil = "SELECT * FROM barang";
                da = new MySqlConnector.MySqlDataAdapter(tampil, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
        public void tambahBarang(string idbarang, string namabarang, string hargabarang, string stok)
        {
            string tambah = "insert into barang values(" + "@id_barang,@nama_barang,@harga_barang,@stok)";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(tambah, GetConn());
                cmd.Parameters.Add("@id_barang", MySqlConnector.MySqlDbType.VarChar).Value = idbarang;
                cmd.Parameters.Add("@nama_barang", MySqlConnector.MySqlDbType.VarChar).Value = namabarang;
                cmd.Parameters.Add("@harga_barang", MySqlConnector.MySqlDbType.VarChar).Value = hargabarang;
                cmd.Parameters.Add("@stok", MySqlConnector.MySqlDbType.VarChar).Value = stok;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("tambah data gagal" + ex.Message);
            }
        }
        public void updateBarang(string idbarang, string namabarang, string hargabarang, string stok)
        {
            string update = "update barang set " + "nama_barang=@nama_barang,harga_barang=@harga_barang,stok=@stok " +"where id_barang=" + idbarang;
            try
            {
                cmd = new MySqlConnector.MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@id_barang", MySqlConnector.MySqlDbType.VarChar).Value = idbarang;
                cmd.Parameters.Add("@nama_barang", MySqlConnector.MySqlDbType.VarChar).Value = namabarang;
                cmd.Parameters.Add("@harga_barang", MySqlConnector.MySqlDbType.VarChar).Value = hargabarang;
                cmd.Parameters.Add("@stok", MySqlConnector.MySqlDbType.VarChar).Value = stok;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("update data gagal" + ex.Message);
            }
        }
        public void hapusbarang(string id_barang)
        {
            string hapus = "delete from barang where id_barang=" + id_barang;
            try
            {
                cmd = new MySqlConnector.MySqlCommand(hapus, GetConn());
                cmd.Parameters.Add("@id_barang", MySqlConnector.MySqlDbType.VarChar).Value = id_barang;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("delete data gagal" + ex.Message);
            }
        }
        public DataTable selectBarang(MySqlCommand command)
        {
            DataTable data = new DataTable();
            try
            {
                string tampil = "SELECT * FROM barang";
                da = new MySqlConnector.MySqlDataAdapter(tampil, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }
    }
}
