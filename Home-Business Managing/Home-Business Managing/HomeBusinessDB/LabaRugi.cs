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
    public class LabaRugi
    {
        private string connectionString;

        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;

        private int id;
        private DateTime periode;
        private double totalPendapatan;
        private double totalBiaya;
        private double totalLabaRugi;


        public int Id { get => id; set => id = value; }
        public DateTime Periode { get => periode; set => periode = DateTime.Today; }
        public double TotalPendapatan { get => totalPendapatan; set => totalPendapatan = value; }
        public double TotalBiaya { get => totalBiaya; set => totalBiaya = value; }
        public double TotalLabaRugi { get => totalLabaRugi; set => totalLabaRugi = value; }

        public LabaRugi(DateTime Periode, double TotalPendapatan, double TotalBiaya, double TotalLabaRugi)
        {
            this.Periode = Periode;
            this.TotalPendapatan = TotalPendapatan;
            this.TotalBiaya = TotalBiaya;
            this.TotalLabaRugi = TotalLabaRugi;
        }

        public void SetConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Insert(LabaRugi data)
        {
            bool isSuccess;
            string queryInsert = "INSERT INTO LabaRugiKotor (PeriodeBulan, TotalPendapatan, TotalBiaya, TotalLabaRugiKotor)" +
                                     "VALUES (@Periode, @TotalPendapatan, @TotalBiaya, @TotalLabaRugiKotor)";
            sqlConnection = new SqlConnection(this.connectionString);
            sqlCommand = new SqlCommand(queryInsert, sqlConnection);

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Periode", data.Periode);
                sqlCommand.Parameters.AddWithValue("@TotalPendapatan", data.TotalPendapatan);
                sqlCommand.Parameters.AddWithValue("@TotalBiaya", data.TotalBiaya);
                sqlCommand.Parameters.AddWithValue("@TotalLabaRugiKotor", data.TotalLabaRugi);

                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0) { isSuccess = true; }
                else { isSuccess = false; }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
                
            return isSuccess;
        }

        public DataTable SelectThisYear(DateTime date)
        {
            string querySelect = "SELECT Id, PeriodeBulan, TotalPendapatan, TotalBiaya, TotalLabaRugiKotor " +
                                 "FROM LabaRugiKotor" +
                                 "WHERE PeriodeBulan = '@Periode'";
            sqlConnection = new SqlConnection(this.connectionString);
            sqlCommand = new SqlCommand(querySelect, sqlConnection);
            DataTable dataTable = new DataTable();

            try
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Periode", date);

                sqlAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataTable;
        }


    }
}
