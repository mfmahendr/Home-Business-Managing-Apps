using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Home_Business_Managing.HomeBusinessDB
{
    public class Barang
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

        private string connectionString;

        private int idBarang;
        private string nama;
        private string jenis;
        private double ukuranJenis;
        private string satuan;
        private double hargaJual;
        private double stokJenis;
        private double stokDalamSatuan;

        public Barang(string nama, string jenis, double ukuranJenis, string satuan, double hargaJual, double stokJenis, double stokDalamSatuan)
        {
            this.nama = nama;
            this.jenis = jenis;
            this.ukuranJenis = ukuranJenis;
            this.satuan = satuan;
            this.hargaJual = hargaJual;
            this.stokJenis = stokJenis;
            this.stokDalamSatuan = stokDalamSatuan;
        }

        public void SetConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Read()
        {
            string querySelect = "SELECT * FROM Barang";
            string error = string.Empty;
            sqlConnection = new SqlConnection(this.connectionString);
            sqlCommand = new SqlCommand(querySelect, sqlConnection);

            try
            {
                sqlConnection.Open();
                sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    Console.WriteLine("\t{0} \t{1} \t{2} \t {3} \t{4} \t{5} \t{6} \t{7}",
                                        sqlReader[0], sqlReader[1], sqlReader[2], sqlReader[3], sqlReader[4], sqlReader[5], sqlReader[6], sqlReader[7]);
                }
            }
            catch (Exception e) { error = e.Message; }
            finally { sqlConnection.Close(); }
        }
    }
}
