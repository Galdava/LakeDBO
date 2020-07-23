using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;

namespace LakeDBO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Country Name:");
            string countryName = Console.ReadLine();
            string select = "SELECT Name,Area FROM dbo.Lakes" +
                " WHERE Country = '"+ countryName+"'";
            string source = "server=GALDAVA-PC\\SQLEXPRESS;" +
"integrated security=SSPI;" +
"database=Earth";
            SqlConnection conn = new SqlConnection(source);
            conn.Open();
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Name: {0,-10} Area: {1}",reader[0],reader[1]);
            }
            conn.Close();
            conn.Open();
            String lake = Console.ReadLine();
            String country = Console.ReadLine();
            decimal area = decimal.Parse(Console.ReadLine());
            SqlCommand sqlCommand = new SqlCommand("LakeInsert", conn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@Name",
                lake));
            sqlCommand.Parameters.Add(new SqlParameter("@Country",
                country));
            sqlCommand.Parameters.Add(new SqlParameter("@Area",
                area));
            sqlCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
            
            sqlCommand.ExecuteNonQuery();

        }
    }
}
