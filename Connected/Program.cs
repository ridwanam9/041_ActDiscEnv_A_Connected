using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Connected
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = GetConnectionString();
            string query1 = "select * from Pembimbing_Akademik where NIK = 333";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand(query1, cn); cn.Open();
                using (SqlDataReader dr1 = cmd1.ExecuteReader()) 
                {
                    while (dr1.Read()) 
                    {
                        string query2 = "update Pembimbing_Akademik Set Keahlian = 'Jaringan' Where NIK = 333";
                        SqlCommand cmd2 = new SqlCommand(query2, cn);
                        cmd2.ExecuteNonQuery();
                        Console.WriteLine("Data has been updated");
                    }
                }
            }
            Console.ReadLine();
        }
        private static string GetConnectionString() 
        {
            return "data source = DESKTOP-KVHUS77\\RIDWANAM;database=ProdiTI;MultipleActiveResultSets=true;User ID=sa;Password = riamima";
        }
    }
}
