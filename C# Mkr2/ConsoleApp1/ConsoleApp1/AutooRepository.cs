using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AutoRepository : IRepository<Auto>
    {
        protected SqlConnection _connection;

        public AutoRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Auto> GetAllAuto()
        {
            var autos = new List<Auto>();
            string query = "SELECT * FROM Auto";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Auto auto = new Auto()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            CarNumber = Convert.ToString(reader["CarNumber"]),
                            Brand = Convert.ToString(reader["Brand"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            HomeAddress = Convert.ToString(reader["HomeAddress"])
                        };
                        autos.Add(auto);
                    }
                }
            }
            return autos;
        }

        public void PrintAutoDataToConsole()
        {
            string query = "SELECT * FROM Auto";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, LastName: {reader["LastName"]}, CarNumber: {reader["CarNumber"]}, Brand: {reader["Brand"]}, Price: {reader["Price"]}, HomeAddress: {reader["HomeAddress"]}");
                    }
                }
            }
        }

        public int CountOwnersOfCarsWithDigitSevenInNumber(string brand)
        {
            string query = $"SELECT COUNT(*) FROM Auto WHERE Brand = '{brand}' AND CarNumber LIKE '%7%'";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                return (int)command.ExecuteScalar();
            }
        }

        public decimal CalculateTotalPriceOfBrandCars(string brand)
        {
            string query = $"SELECT SUM(Price) FROM Auto WHERE Brand = '{brand}'";
            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                var result = command.ExecuteScalar();
                return (result != DBNull.Value) ? Convert.ToDecimal(result) : 0;
            }
        }
    }

}
